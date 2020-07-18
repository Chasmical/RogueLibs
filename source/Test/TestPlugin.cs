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

			giantAbility.OnPressed = (agent, item, target) =>
			{
				if (item.invItemCount > 0)
					agent.gc.audioHandler.Play(agent, "CantDo");
				else
				{
					agent.statusEffects.AddStatusEffect("Giant", true, true, 5);
					agent.inventory.buffDisplay.specialAbilitySlot.MakeNotUsable();
					item.invItemCount = 10;
				}
			};
			giantAbility.RechargePeriod = (agent, item) =>
			{
				if (item.invItemCount > 0)
					return new WaitForSeconds(1f);
				return null;
			};
			giantAbility.Recharge = (agent, item) =>
			{
				if (item.invItemCount > 0 && agent.statusEffects.CanRecharge())
				{
					item.invItemCount--;
					if (item.invItemCount == 0)
					{
						agent.statusEffects.CreateBuffText("Recharged", agent.objectNetID);
						agent.gc.audioHandler.Play(agent, "Recharge");
					}
				}
			};
		}
	}
#pragma warning restore CS1591
}
