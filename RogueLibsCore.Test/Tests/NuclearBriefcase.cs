using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RogueLibsCore.Test
{
	public class NuclearBriefcase : CustomItem, IItemUsable
	{
		public static void Test()
		{
			RogueLibs.CreateCustomItem<NuclearBriefcase>()
				.WithName(new CustomNameInfo("Nuclear Briefcase"))
				.WithDescription(new CustomNameInfo("Obliterates the entire level, leaving absolutely nothing behind."))
				.WithSprite(Properties.Resources.NuclearBriefcase)
				.WithUnlock(new ItemUnlock { UnlockCost = 20, CharacterCreationCost = 10, LoadoutCost = 10 });

			RogueLibs.CreateCustomItem<OpenNuclearBriefcase>()
				.WithName(new CustomNameInfo("Open Nuclear Briefcase"))
				.WithDescription(new CustomNameInfo("Oh no..."))
				.WithSprite(Properties.Resources.OpenNuclearBriefcase);

			RogueLibs.CreateCustomName("UseNuclearBriefcase", "Interface", new CustomNameInfo("Activate here"));

			RoguePatcher patcher = new RoguePatcher(TestPlugin.Instance, typeof(NuclearBriefcasePatches));
			patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnWreckage));
			patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnParticleEffect),
				new Type[4] { typeof(string), typeof(Vector3), typeof(float), typeof(Transform) });

			TestPlugin.Log.LogWarning("Created everything");
		}

		public override void SetupDetails()
		{
			TestPlugin.Log.LogWarning("Set up details");
			Item.itemType = ItemTypes.Tool;
			Item.initCount = 1;
			Item.rewardCount = 1;
			Item.itemValue = 300;
			Item.cantBeCloned = true;
			Item.goesInToolbar = true;
		}
		public bool UseItem()
		{
			TestPlugin.Log.LogWarning("Used");
			Count--;
			OpenNuclearBriefcase open = Inventory.AddItem<OpenNuclearBriefcase>(1);
			gc.audioHandler.Play(Owner, "DoorOpen");
			Inventory.StartCoroutine(open.BriefcaseChecker());
			return true;
		}
	}
	public class OpenNuclearBriefcase : CustomItem, IItemTargetableAnywhere
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.initCount = 1;
			Item.rewardCount = 1;
			Item.itemValue = 300;
			Item.cantBeCloned = true;
			Item.goesInToolbar = true;
		}

		private float timer;
		public IEnumerator BriefcaseChecker()
		{
			timer = 3f;
			while (timer > 0)
			{
				yield return null;
				if (Item.invItemCount is 0 || Item.database != Inventory) yield break;
				if (Item.invInterface.draggedInvItem == Item || Item.invInterface.mainGUI.targetItem == Item
					|| Item.invInterface.Slots[Item.slotNum].overSlot)
				{
					timer = 3f;
				}
				timer -= Time.unscaledDeltaTime;
			}
			Count--;
			Inventory.AddItem<NuclearBriefcase>(1);
			gc.audioHandler.Play(Owner, "DoorClose");
		}

		public bool TargetFilter(Vector3 pos) => true;
		public bool TargetPosition(Vector3 pos)
		{
			Count--;
			gc.StartCoroutine(Explode(pos));
			return true;
		}
		private IEnumerator Explode(Vector3 pos)
		{
			BombFalling bomb = gc.spawnerMain.SpawnBombFalling(pos, string.Empty);
			gc.StartCoroutine(bomb.DropBomb());
			Danger danger = gc.spawnerMain.SpawnDanger(Owner, "Major", "Spooked");
			danger.tr.position = bomb.tr.position;
			danger.curPosition = danger.tr.position;
			danger.tr.parent = gc.dangersNest.transform;
			danger.timer = 5f;

			gc.audioHandler.Play(Owner, "ArmedMine");

			for (int i = 3; i >= 0; i--)
			{
				gc.spawnerMain.SpawnStatusText(Owner, "Countdown", i.ToString());
				yield return new WaitForSeconds(0.35f);
				gc.audioHandler.Stop(Owner, "ArmedMine");
				gc.audioHandler.Play(Owner, "ArmedMine");
				yield return new WaitForSeconds(0.35f);
			}

			gc.StartCoroutine(gc.SetSecondaryTimeScale(0.1f, 0.7f));
			yield return new WaitForSeconds(0.1f);
			gc.audioHandler.Stop(Owner, "ArmedMine");

			Explosion explosion = gc.spawnerMain.SpawnExplosion(Owner, pos, "Ridiculous");
			NuclearBriefcasePatches.suppress = true;
			gc.tileInfo.clearingDoorWindowWalls = true;
			explosion.destroySteel = true;
			explosion.damage = 488755541;
			explosion.circleCollider2D.enabled = true;
			explosion.circleCollider2D.radius = 64;

			foreach (Agent agent in gc.agentList.ToList())
			{
				if (!agent.teleporting && agent.isPlayer is 0)
				{
					gc.stats.AddToStat(Owner, "Killed", 1);
					if (agent.statusEffects.IsInnocent(Owner))
						gc.stats.AddToStat(Owner, "InnocentsKilled", 1);

					try { agent.DestroyMe(); } catch { }
				}
			}
			foreach (ObjectReal obj in gc.objectRealList.ToList())
			{
				if (obj is Elevator || obj is StartingPoint || obj is ExitPoint || obj is CornerCombatHelper) continue;
				gc.stats.AddToStat(Owner, "Destruction2", 1);
				try { obj.DestroyMe(); } catch { }
			}
			foreach (Item item in gc.itemList.ToList())
			{
				gc.stats.AddToStat(Owner, "Destruction", 1);
				try { item.DestroyMe(); } catch { }
			}
			// gc.FreezeFrames(5);

			yield return new WaitForSeconds(0.5f);

			foreach (Agent agent in gc.agentList.ToList())
				if (!agent.teleporting && agent.isPlayer is 0) try { agent.DestroyMe(); } catch { }
			foreach (ObjectReal obj in gc.objectRealList.ToList())
			{
				if (obj is Elevator || obj is ExitPoint || obj is CornerCombatHelper) continue;
				try { obj.DestroyMe(); } catch { }
			}
			foreach (Item item in gc.itemList.ToList())
				try { item.DestroyMe(); } catch { }

			gc.tileInfo.clearingDoorWindowWalls = false;
			NuclearBriefcasePatches.suppress = false;
		}
		public CustomTooltip TargetCursorText(Vector3 pos) => gc.nameDB.GetName("UseNuclearBriefcase", "Interface");
	}
	public static class NuclearBriefcasePatches
	{
		public static bool suppress;
		public static bool SpawnerMain_SpawnWreckage() => !suppress;
		public static bool SpawnerMain_SpawnParticleEffect() => !suppress;
	}
}
