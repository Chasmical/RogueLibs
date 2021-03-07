using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BepInEx;
using HarmonyLib;

namespace RogueLibsCore
{
	public partial class RogueLibsPlugin
	{
		public void PatchScrollingMenu()
		{
			//patcher.Transpiler(typeof(ScrollingMenu), nameof(ScrollingMenu.OpenScrollingMenu), nameof(ScrollingMenu_OpenScrollingMenu_Transpiler));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.OpenScrollingMenu), nameof(ScrollingMenu_OpenScrollingMenu_Prefix));
			Patcher.Postfix(typeof(ScrollingMenu), nameof(ScrollingMenu.OpenScrollingMenu));

			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupChallenges));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupChangeTraitsRandom));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupFreeItems));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupItemUnlocks));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupLoadouts));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupRemoveTraits));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupTraitUnlocks));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupUpgradeTraits));

			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SortUnlocks));

			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.PushedButton));

			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.ShowDetails));

			Patcher.Postfix(typeof(ScrollingMenu), nameof(ScrollingMenu.RefreshLoadouts));
		}

		public static void ScrollingMenu_OpenScrollingMenu_Prefix(ScrollingMenu __instance, out float __state)
		{
			float x = 1f - __instance.scrollBar.value;
			__state = x * (__instance.numButtons - __instance.numButtonsOnScreen + 1f);
		}
		public static void ScrollingMenu_OpenScrollingMenu(ScrollingMenu __instance, ref float __state, List<Unlock> ___listUnlocks)
		{
			__instance.numButtons = ___listUnlocks.Count;
			float x = __state / (__instance.numButtons - __instance.numButtonsOnScreen + 1f);
			__instance.StartCoroutine(EnsureScrollbarValue(__instance, 1f - x));
			if (__instance.menuType == "Challenges" || __instance.menuType == "FreeItems")
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
			}
			else if (__instance.menuType == "Traits" || __instance.menuType == "Floors")
			{
				foreach (ButtonData buttonData in __instance.buttonsData)
					SetupUnlocks(buttonData, buttonData.scrollingButtonUnlock);
			}
		}
		private static IEnumerator EnsureScrollbarValue(ScrollingMenu menu, float value)
		{
			menu.scrollBar.value = value;
			yield return null;
			menu.scrollBar.value = value;
			yield return null;
			menu.scrollBar.value = value;
			yield return null;
			menu.scrollBar.value = value;
		}

		public static bool ScrollingMenu_SetupChallenges(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupChangeTraitsRandom(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupFreeItems(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupItemUnlocks(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupLoadouts(ScrollingMenu __instance, ButtonData myButtonData, Unlock myUnlock, List<Unlock> ___listUnlocks)
		{
			SetupUnlocks(myButtonData, myUnlock);
			__instance.numButtons = ___listUnlocks.Count;
			return false;
		}
		public static bool ScrollingMenu_SetupRemoveTraits(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupTraitUnlocks(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupUpgradeTraits(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);

		public static bool SetupUnlocks(ButtonData myButtonData, Unlock myUnlock)
		{
			DisplayedUnlock du = (DisplayedUnlock)(myButtonData.__RogueLibsCustom = myUnlock.__RogueLibsCustom);
			du.ButtonData = myButtonData;

			myButtonData.scrollingButtonUnlock = myUnlock;
			myButtonData.scrollingButtonType = myUnlock.unlockName;
			myButtonData.interactable = true;
			myButtonData.buttonText = du.GetName();

			du.UpdateUnlock();
			du.UpdateButton();
			return false;
		}

		public static readonly DisplayedUnlock clearAllMutators = new ClearAllMutatorsUnlock();
		public static readonly DisplayedUnlock clearAllItems = new ClearAllItemsUnlock();
		public static readonly DisplayedUnlock clearAllTraits = new ClearAllTraitsUnlock();
		public static readonly DisplayedUnlock reRollLoadouts = new ReRollLoadoutsUnlock();

		public static bool ScrollingMenu_SortUnlocks(ScrollingMenu __instance, List<Unlock> myUnlockList, List<Unlock> ___listUnlocks)
		{
			List<DisplayedUnlock> displayedList = myUnlockList.Select(u => u.__RogueLibsCustom).OfType<DisplayedUnlock>().ToList();
			if (__instance.menuType == "FreeItems")
				displayedList.RemoveAll(u => u is ItemUnlock itemUnlock && !itemUnlock.IsAvailableInItemTeleporter);

			displayedList.Sort();
			CustomScrollingMenu menu = new CustomScrollingMenu(__instance, displayedList);

			___listUnlocks.Clear();
			___listUnlocks.AddRange(menu.Unlocks.Select(du => du.Unlock));

			foreach (DisplayedUnlock du in menu.Unlocks)
				du.Menu = menu;

			if (menu.Type == UnlocksMenuType.Loadouts)
			{
				reRollLoadouts.Menu = menu;
				___listUnlocks.Insert(0, reRollLoadouts.Unlock);
			}
			if (menu.Type == UnlocksMenuType.MutatorMenu)
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
				clearAllMutators.Menu = menu;
				___listUnlocks.Insert(0, clearAllMutators.Unlock);
			}
			else if (menu.Type == UnlocksMenuType.RewardsMenu)
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
				// clearAllItems.Menu = menu;
				// ___listUnlocks.Insert(0, clearAllItems.Unlock);
			}
			else if (menu.Type == UnlocksMenuType.TraitsMenu)
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
				// clearAllTraits.Menu = menu;
				// ___listUnlocks.Insert(0, clearAllTraits.Unlock);
			}

			__instance.numButtons = ___listUnlocks.Count;
			return false;
		}

		public static bool ScrollingMenu_PushedButton(ScrollingMenu __instance, ButtonHelper myButton)
		{
			if (__instance.menuType.EndsWith("Configs"))
				return true;

			ButtonData buttonData = __instance.buttonsData[myButton.scrollingButtonNum];
			DisplayedUnlock du = (DisplayedUnlock)buttonData.__RogueLibsCustom;

			du?.OnPushedButton();
			return false;
		}

		public static bool ScrollingMenu_ShowDetails(ScrollingMenu __instance, ButtonHelper myButton)
		{
			if (__instance.agent != null && myButton.scrollingButtonUnlock?.unlockType == "Trait" && __instance.agent.addedEndLevelTrait || !string.IsNullOrEmpty(myButton.scrollingButtonLevelFeeling) || !string.IsNullOrEmpty(myButton.scrollingButtonConfigName) || !string.IsNullOrEmpty(myButton.scrollingButtonAgentName))
				return true;
			DisplayedUnlock du = (DisplayedUnlock)myButton.scrollingButtonUnlock.__RogueLibsCustom;

			__instance.detailsTitle.text = du.GetName();
			__instance.detailsText.text = du.GetDescription();
			__instance.detailsImage.sprite = du.GetImage();
			__instance.detailsImage.gameObject.SetActive(__instance.detailsImage.sprite != null);

			return false;
		}

		public static void ScrollingMenu_RefreshLoadouts(List<Unlock> ___loadoutList) => ___loadoutList.RemoveAt(0);
	}
}
