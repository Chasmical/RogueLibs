using BepInEx;
using UnityEngine;

namespace RogueLibsCore.Test
{
#pragma warning disable CS1591

	[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
	[BepInDependency(RogueLibs.pluginGuid, "2.0.0")]
	public class TestPlugin : BaseUnityPlugin
	{
		public const string pluginGuid = "abbysssal.streetsofrogue.roguelibs.test";
		public const string pluginName = "RogueLibs.Test";
		public const string pluginVersion = "0.5.0";

		public void Awake()
		{
			Sprite noSprite = RogueUtilities.ConvertToSprite(new byte[0]);

			#region Giant Ability
			CustomAbility giantAbility = RogueLibs.CreateCustomAbility("GiantAbility_u", noSprite, false,
				new CustomNameInfo("Giant"),
				new CustomNameInfo("Gives you Giant status effect"),
				item =>
				{
					item.lowCountThreshold = 100;
					item.initCount = 0;
					item.stackable = true;
				});

			giantAbility.OnPressed = (item, agent) =>
			{
				if (item.invItemCount > 0) // is recharging
					agent.gc.audioHandler.Play(agent, "CantDo");
				else
				{
					agent.statusEffects.AddStatusEffect("Giant", true, true, 3);
					agent.inventory.buffDisplay.specialAbilitySlot.MakeNotUsable();
					// make special ability slot half-transparent
					item.invItemCount = 100; // 100 x 0.13f = 13 seconds to recharge
											 // or you can replace 100 with 13, and 0.13 with 1 to make it simpler
				}
			};
			giantAbility.RechargeInterval = (item, agent)
				=> item.invItemCount > 0 ? new WaitForSeconds(0.13f) : null;
			giantAbility.Recharge = (item, agent) =>
			{
				if (item.invItemCount > 0 && agent.statusEffects.CanRecharge())
				{ // if can recharge
					item.invItemCount--;
					if (item.invItemCount == 0) // ability recharged
					{
						agent.statusEffects.CreateBuffText("Recharged", agent.objectNetID);
						agent.gc.audioHandler.Play(agent, "Recharge");
						agent.inventory.buffDisplay.specialAbilitySlot.MakeUsable();
						// make special ability slot fully visible
					}
				}
			};
			giantAbility.UnlockCost = 5;
			giantAbility.CostInCharacterCreation = 10;
			#endregion

			#region Regeneration Ability
			CustomAbility regeneration = RogueLibs.CreateCustomAbility("RegenerationAbility_u", noSprite, false,
				new CustomNameInfo("Regeneration"),
				new CustomNameInfo("Use it to regenerate health"),
				item =>
				{
					item.initCount = 0;
					item.stackable = true;
				});

			regeneration.OnHeld = (InvItem item, Agent agent, ref float time) =>
			{
				if (time * 2f > item.invItemCount && item.invItemCount < 10)
					item.invItemCount++;
			};
			regeneration.OnReleased = (item, agent) =>
			{
				if (item.invItemCount < 2) return;
				agent.statusEffects.ChangeHealth(item.invItemCount);
				item.invItemCount = 0;
				agent.gc.audioHandler.Play(agent, "Heal");
			};
			regeneration.UnlockCost = 3;
			regeneration.CostInCharacterCreation = 10;
			#endregion

			#region Cool Trait 
			CustomTrait someCoolTrait = RogueLibs.CreateCustomTrait("SomeCoolTrait_u3", false,
				new CustomNameInfo("Cool Trait"),
				new CustomNameInfo("It's a very cool trait. It does a lot of cool stuff."));
			someCoolTrait.UnlockCost = 2;
			someCoolTrait.CostInCharacterCreation = 5;
			#endregion

			#region Cool Trait +
			CustomTrait someCoolTrait2 = RogueLibs.CreateCustomTrait("SomeCoolTrait2_u3", false,
				new CustomNameInfo("<color=purple>Cool Trait +</color>"),
				new CustomNameInfo("It's an extremely cool trait! You won't believe what it can do!"));
			someCoolTrait.Upgrade = someCoolTrait2.Id;
			someCoolTrait.Conflicting.Add(someCoolTrait2.Id);
			someCoolTrait2.UnlockCost = 8;
			someCoolTrait2.Prerequisites.Add(someCoolTrait.Id);
			someCoolTrait2.CostInCharacterCreation = 10;
			someCoolTrait2.Recommendations.Add("Banana");
			someCoolTrait.GetSpecialUnlockInfo = unlock => "Some unique method of unlocking the trait.";
			#endregion

			#region Wild Bypasser
			CustomItem wildBypasser = RogueLibs.CreateCustomItem("WildBypasser_u3", noSprite, false,
				new CustomNameInfo("Wild Bypasser",
					null, null, null, null,
					"Универсальный проход сквозь стены",
					null, null),
				new CustomNameInfo("Warps you in the direction you're facing. Teleports through any amount of walls.",
					null, null, null, null,
					"Перемещает тебя в направлении, в которое ты смотришь. Телепортирует сквозь любое количество стен.",
					null, null),
				item =>
				{
					item.itemType = "Tool";
					item.Categories.Add("Technology");
					item.Categories.Add("Usable");
					item.Categories.Add("Stealth");
					item.itemValue = 60;
					item.initCount = 1;
					item.rewardCount = 2;
					item.stackable = true;
					item.goesInToolbar = true;
				});
			wildBypasser.UnlockCost = 3;
			wildBypasser.CostInCharacterCreation = 5;
			wildBypasser.Conflicting.Add("NoFollowers");
			wildBypasser.Prerequisites.Add(someCoolTrait2.Id);
			wildBypasser.UseItem = (item, agent) =>
			{
				Vector3 position = agent.agentHelperTr.localPosition = Vector3.zero;
				TileData tileData;
				int limit = 0;
				do
				{
					position.x += 0.64f;
					agent.agentHelperTr.localPosition = position;
					tileData = GameController.gameController.tileInfo.GetTileData(agent.agentHelperTr.position);

				} while ((GameController.gameController.tileInfo.IsOverlapping(agent.agentHelperTr.position, "Anything") || tileData.wallMaterial != wallMaterialType.None) && limit++ < 250);

				if (limit > 249) return;

				agent.SpawnParticleEffect("Spawn", agent.tr.position);
				agent.Teleport(new Vector3(agent.agentHelperTr.position.x, agent.agentHelperTr.position.y, agent.tr.position.z), false, true);
				agent.rb.velocity = Vector2.zero;

				if (!(agent.statusEffects.hasTrait("ThiefToolsMayNotSubtract2") && GameController.gameController.percentChance(agent.DetermineLuck(80, "ThiefToolsMayNotSubtract", true))) && !(agent.statusEffects.hasTrait("ThiefToolsMayNotSubtract") && GameController.gameController.percentChance(agent.DetermineLuck(40, "ThiefToolsMayNotSubtract", true))))
					item.database.SubtractFromItemCount(item, 1);

				agent.SpawnParticleEffect("Spawn", agent.tr.position, false);
				GameController.gameController.audioHandler.Play(agent, "Spawn");

				new ItemFunctions().UseItemAnim(item, agent);
			};
			#endregion









		}










	}

#pragma warning restore CS1591
}
