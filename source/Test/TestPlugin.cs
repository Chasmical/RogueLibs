using UnityEngine;
using BepInEx;

namespace RogueLibsCore.Test
{
#pragma warning disable CS1591
	
	[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
	[BepInDependency(RogueLibs.pluginGuid, "2.0.0")]
	public class TestPlugin : BaseUnityPlugin
	{
		public const string pluginGuid = "abbysssal.streetsofrogue.roguelibs.test";
		public const string pluginName = "RogueLibs.Test";
		public const string pluginVersion = "0.4.1";

		public void Awake()
		{
			#region Giant Ability
			Sprite sprite = RogueUtilities.ConvertToSprite(new byte[0]);
			CustomAbility giantAbility = RogueLibs.CreateCustomAbility("GiantAbility_u", sprite, false,
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
			Sprite sprite2 = RogueUtilities.ConvertToSprite(new byte[0]);
			CustomAbility regeneration = RogueLibs.CreateCustomAbility("RegenerationAbility_u", sprite2, false,
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
			CustomTrait someCoolTrait = RogueLibs.CreateCustomTrait("SomeCoolTrait_u", false,
				new CustomNameInfo("Cool Trait"),
				new CustomNameInfo("It's a very cool trait. It does a lot of cool stuff."));
			someCoolTrait.UnlockCost = 2;
			someCoolTrait.CostInCharacterCreation = 5;
			#endregion
			#region Cool Trait +
			CustomTrait someCoolTrait2 = RogueLibs.CreateCustomTrait("SomeCoolTrait2_u", false,
				new CustomNameInfo("<color=purple>Cool Trait +</color>"),
				new CustomNameInfo("It's an extremely cool trait! You won't believe what it can do!"));
			someCoolTrait.Upgrade = someCoolTrait2.Id;
			someCoolTrait.Conflicting.Add(someCoolTrait2.Id);
			someCoolTrait2.UnlockCost = 8;
			someCoolTrait2.CostInCharacterCreation = 10;
			#endregion
		}
	}
	
#pragma warning restore CS1591
}
