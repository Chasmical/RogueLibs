using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
			patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnWreckage2));
			patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnParticleEffect),
				new Type[4] { typeof(string), typeof(Vector3), typeof(float), typeof(Transform) });
			patcher.Prefix(typeof(Explosion), nameof(Explosion.ExplosionHit));
			patcher.Prefix(typeof(AudioHandler), nameof(AudioHandler.PlayClipAt));
		}

		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.initCount = 1;
			Item.rewardCount = 1;
			Item.itemValue = 300;
			Item.cantBeCloned = true;
			Item.goesInToolbar = true;
		}
		public bool UseItem()
		{
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
				yield return new WaitForSeconds(0.375f);
				gc.audioHandler.Stop(Owner, "ArmedMine");
				gc.audioHandler.Play(Owner, "ArmedMine");
				yield return new WaitForSeconds(0.375f);
			}

			gc.StartCoroutine(gc.SetSecondaryTimeScale(0.05f, 0.45f));
			yield return new WaitForSeconds(0.025f);
			gc.audioHandler.Stop(Owner, "ArmedMine");

			Explosion explosion = gc.spawnerMain.SpawnExplosion(Owner, pos, "Ridiculous");
			for (int i = 10; i < 20; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					float angle = UnityEngine.Random.Range(0f, 360f);
					gc.spawnerMain.SpawnParticleEffect("Explosion", explosion.tr.position, angle).transform.localScale = new Vector3(i, i, i);
				}
			}
			for (int i = 0; i < 10; i++)
				explosion.gc.audioHandler.Play(explosion, "ExplodeRidiculous");

			NuclearBriefcasePatches.suppress = true;
			gc.tileInfo.clearingDoorWindowWalls = true;
			explosion.agent = Owner;
			explosion.destroySteel = true;
			explosion.damage = 488755541;
			explosion.circleCollider2D.enabled = true;
			NuclearBriefcasePatches.canHit.SetValue(explosion, 1.1f);

			explosion.circleCollider2D.radius = 0;
			yield return null;
			explosion.circleCollider2D.radius = 10;
			yield return null;

			const float time = 1f;
			for (int i = 0; i < 240; i++)
			{
				explosion.circleCollider2D.radius += 0.25f;
				yield return new WaitForSeconds(time / 240f);
			}

			yield return new WaitForSeconds(0.5f);

			gc.audioHandler.MusicStop();

			gc.tileInfo.clearingDoorWindowWalls = false;
			NuclearBriefcasePatches.suppress = false;
		}
		public CustomTooltip TargetCursorText(Vector3 pos) => gc.nameDB.GetName("UseNuclearBriefcase", "Interface");
	}
	public static class NuclearBriefcasePatches
	{
		public static bool suppress;
		public static bool SpawnerMain_SpawnWreckage(ref Item __result)
		{
			__result = new Item();
			return !suppress;
		}
		public static bool SpawnerMain_SpawnWreckage2() => !suppress;
		public static bool SpawnerMain_SpawnParticleEffect(ref GameObject __result)
		{
			__result = new GameObject();
			return !suppress;
		}
		public static void AudioHandler_PlayClipAt(string clipName, ref float vol)
		{
			if (clipName == "ExplodeRidiculous") vol *= 5f;
		}
		internal static readonly FieldInfo canHit = typeof(Explosion).GetField("canHit", BindingFlags.Instance | BindingFlags.NonPublic);
		public static bool Explosion_ExplosionHit(Explosion __instance, GameObject hitObject)
		{
			if (__instance.damage != 488755541) return true;

			if ((float)canHit.GetValue(__instance) <= 0f) return false;

			if (__instance.objectList.Contains(hitObject)) return false;
			__instance.objectList.Add(hitObject);

			if (hitObject.CompareTag("AgentSprite"))
			{
				try
				{
					hitObject = hitObject.GetComponent<AgentColliderBox>().objectSprite.go;
				}
				catch
				{
					hitObject = hitObject.transform.Find("AgentHitboxColliders").transform.GetChild(0).GetComponent<AgentColliderBox>().objectSprite.go;
				}
			}

			ObjectSprite spr = hitObject.GetComponent<ObjectSprite>();
			if (spr?.agent != null)
			{
				Agent Owner = __instance.agent;
				Agent agent = spr.agent;
				try
				{
					if (agent.isPlayer == 0)
					{
						GameController.gameController.stats.AddToStat(Owner, "Killed", 1);
						GameController.gameController.stats.AddToStat(Owner, "InnocentsKilled", 1);

						if (agent.statusEffects.AgentIsRival(Owner))
						{
							GameController.gameController.quests.AddBigQuestPoints(Owner, agent, "KillGuilty");
							Owner.skillPoints.AddPoints("KillPointsRival");
						}
						else if (agent.statusEffects.IsInnocent(Owner))
						{
							GameController.gameController.quests.AddBigQuestPoints(Owner, "KillInnocent");
							Owner.skillPoints.AddPoints("KillPointsInnocent");
						}
						else Owner.skillPoints.AddPoints("KillPoints");

						GameController.gameController.quests.AddBigQuestPoints(Owner, agent, "Dead");
						GameController.gameController.quests.AddBigQuestPoints(Owner, agent, "Neutralize");
						GameController.gameController.quests.AddBigQuestPoints(Owner, agent, "BloodlustKill");
					}

					agent.inventory.ClearInventory(false);

					agent.resurrect = false;
					agent.statusEffects.SetupDeath(__instance, false, true);
					agent.statusEffects.Disappear();
				}
				catch { }
			}
			if (spr?.objectReal != null)
			{
				ObjectReal obj = spr?.objectReal;
				try
				{
					obj.objectInvDatabase?.ClearInventory(false);
					obj.specialInvDatabase?.ClearInventory(false);
					obj.DestroyMe();
				}
				catch { }
			}
			if (spr?.item != null)
			{
				spr.item.DestroyMeFromClient();
			}

			if (hitObject.CompareTag("Fire"))
			{
				Fire fire = hitObject.GetComponent<Fire>();
				fire.DestroyMe();
			}
			if (hitObject.CompareTag("Wall"))
			{
				__instance.tileInfo.DestroyWallTileAtPosition(hitObject.transform.position.x, hitObject.transform.position.y, true, __instance.agent);

				__instance.gc.stats.AddDestructionQuestPoints();
				__instance.gc.stats.AddToStat(__instance.agent, "Destruction", 1);
			}

			return false;
		}
	}
}
