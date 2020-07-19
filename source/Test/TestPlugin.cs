using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using UnityEngine;

namespace RogueLibsCore.Test
{
#pragma warning disable CS1591
	[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
	[BepInDependency(RogueLibs.pluginGuid, "1.4.0")]
	public class TestPlugin : BaseUnityPlugin
	{
		public const string pluginGuid = "abbysssal.streetsofrogue.roguelibs.test";
		public const string pluginName = "RogueLibs.Test";
		public const string pluginVersion = "1.0";

		public void Awake()
		{
			Sprite sprite = RogueUtilities.ConvertToSprite(new byte[0]);
			CustomItem giantItem = RogueLibs.SetItem("GiantAbility", sprite,
				new CustomNameInfo("Giant"),
				new CustomNameInfo("Gives you Giant status effect"),
				item =>
				{
					item.lowCountThreshold = 100;
					item.initCount = 0;
					item.stackable = true;
				});
			CustomAbility giantAbility = RogueLibs.SetAbility(giantItem);

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

			giantAbility.RechargePeriod = (item, agent)
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

			Sprite sprite2 = RogueUtilities.ConvertToSprite(new byte[0]);
			CustomItem cItem = RogueLibs.SetItem("RegenerationAbility", sprite2,
				new CustomNameInfo("Regeneration"),
				new CustomNameInfo("Use it to regenerate health"),
				item =>
				{
					item.initCount = 0;
					item.stackable = true;
				});
			CustomAbility regeneration = RogueLibs.SetAbility(cItem);

			regeneration.OnPressed = (item, agent)
				=> item.invItemCount = 1;
			    // see StatusEffects.PressedSpecialAbility() for more info
			regeneration.OnHeld = (item, agent) =>
			{
				if (agent.gc.playerControl.pressedSpecialAbilityTime[agent.isPlayer - 1] * 2f > item.invItemCount)
				{
					if (item.invItemCount < 10)
						item.invItemCount++;
					// each half second the item count is incremented
				}

				// see StatusEffects.HeldSpecialAbility() for more info
			};
			regeneration.OnReleased = (item, agent) =>
			{
				agent.statusEffects.ChangeHealth(item.invItemCount);
				item.invItemCount = 0;
				agent.gc.audioHandler.Play(agent, "Heal");

				// see StatusEffects.ReleasedSpecialAbility() for more info
			};
		}
	}
#pragma warning restore CS1591
}
