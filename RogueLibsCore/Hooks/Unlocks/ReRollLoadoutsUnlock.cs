using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	public class ReRollLoadoutsUnlock : MutatorUnlock
	{
		public ReRollLoadoutsUnlock() : base("ReRollLoadouts", true) { }
		public override bool IsAvailable { get; set; } = true;
		public override bool IsEnabled { get => false; set { } }

		private static readonly FieldInfo loadoutListField = AccessTools.Field(typeof(ScrollingMenu), "loadoutList");
		private static readonly FieldInfo listUnlocksField = AccessTools.Field(typeof(ScrollingMenu), "listUnlocks");

		public override void UpdateButton()
		{
			UpdateButton(false);
			ScrollingMenu menu = ((CustomScrollingMenu)Menu).Menu;
			Text += $" - ${menu.reRollCost}";
		}
		public override void OnPushedButton()
		{
			ScrollingMenu menu = ((CustomScrollingMenu)Menu).Menu;
			if (gc.sessionDataBig.nuggets + gc.sessionDataBig.loadoutNuggetsSpent >= menu.reRollCost)
			{
				menu.RefreshLoadouts(true);
				gc.mainGUI.scrollingMenuScript.loadingLoadouts = true;
				menu.SortUnlocks((List<Unlock>)loadoutListField.GetValue(menu), "Loadout");
				gc.mainGUI.scrollingMenuScript.loadingLoadouts = false;

				List<Unlock> listUnlocks = (List<Unlock>)listUnlocksField.GetValue(menu);
				for (int j = 1; j < menu.buttonsData.Count; j++)
					menu.SetupLoadouts(menu.buttonsData[j], listUnlocks[j]);

				gc.unlocks.SubtractNuggets(menu.reRollCost);
				gc.unlocks.AddNuggets(gc.sessionDataBig.loadoutNuggetsSpent);
				gc.sessionDataBig.loadoutNuggetsSpent = 0;

				if (menu.agent.isPlayer is 1)
					gc.sessionDataBig.loadouts1.Clear();
				else if (menu.agent.isPlayer is 2)
					gc.sessionDataBig.loadouts2.Clear();
				else if (menu.agent.isPlayer is 3)
					gc.sessionDataBig.loadouts3.Clear();
				else if (menu.agent.isPlayer is 4)
					gc.sessionDataBig.loadouts4.Clear();

				PlaySound("BuyItem");
				gc.unlocks.SaveUnlockData(true);
			}
			else PlaySound("CantDo");

			UpdateMenu();
		}
	}
}
