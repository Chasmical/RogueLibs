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
		/// <summary>
		///   <para>Applies the patches to <see cref="ScrollingMenu"/>.</para>
		/// </summary>
		public void PatchScrollingMenu()
		{
			//patcher.Transpiler(typeof(ScrollingMenu), nameof(ScrollingMenu.OpenScrollingMenu), nameof(ScrollingMenu_OpenScrollingMenu_Transpiler));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.OpenScrollingMenu), nameof(ScrollingMenu_OpenScrollingMenu_Prefix));
			Patcher.Postfix(typeof(ScrollingMenu), nameof(ScrollingMenu.OpenScrollingMenu));

			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupChallenges));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupFreeItems));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupItemUnlocks));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupTraitUnlocks));

			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupLoadouts));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupChangeTraitsRandom));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupRemoveTraits));
			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupUpgradeTraits));

			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SortUnlocks));

			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.PushedButton));

			Patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.ShowDetails));

			Patcher.Postfix(typeof(ScrollingMenu), nameof(ScrollingMenu.RefreshLoadouts));
		}

		/// <summary>
		///   <para><b>Prefix-patch.</b> Saves the scroll bar's absolute value.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="ScrollingMenu"/>.</param>
		/// <param name="__state">Scroll bar's absolute value.</param>
		public static void ScrollingMenu_OpenScrollingMenu_Prefix(ScrollingMenu __instance, out float __state)
		{
			float x = 1f - __instance.scrollBar.value;
			__state = x * (__instance.numButtons - __instance.numButtonsOnScreen + 1f);
		}
		/// <summary>
		///   <para><b>Postfix-patch.</b> Makes sure that the scroll bar value is set to the one before and sets up the <see cref="DisplayedUnlock"/>s if they weren't set up by the original method.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="ScrollingMenu"/>.</param>
		/// <param name="__state">Previously saved scroll bar's absolute value.</param>
		/// <param name="___listUnlocks">Private field. List of unlocks to be displayed the menu.</param>
		public static void ScrollingMenu_OpenScrollingMenu(ScrollingMenu __instance, ref float __state, List<Unlock> ___listUnlocks)
		{
			__instance.numButtons = ___listUnlocks.Count;
			float x = __state / (__instance.numButtons - __instance.numButtonsOnScreen + 1f);
			__instance.StartCoroutine(EnsureScrollbarValue(__instance, Mathf.Clamp01(1f - x)));

			if (__instance.menuType == "Challenges" || __instance.menuType == "FreeItems")
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
			}
			else if (__instance.menuType == "Floors")
			{
				List<DisplayedUnlock> displayedUnlocks = GameController.gameController.sessionDataBig.floorUnlocks.Select(u => (DisplayedUnlock)u.__RogueLibsCustom).OrderBy(d => d).ToList();
				CustomScrollingMenu menu = new CustomScrollingMenu(__instance, displayedUnlocks);

				foreach (DisplayedUnlock du in displayedUnlocks.ToList())
					if (!du.IsAvailable)
					{
						displayedUnlocks.Remove(du);
						__instance.buttonsData.Remove(du.ButtonData);
						__instance.numButtons--;
					}
					else du.Menu = menu;

				foreach (ButtonData buttonData in __instance.buttonsData)
					SetupUnlocks(buttonData, buttonData.scrollingButtonUnlock);
			}
			else if (__instance.menuType == "Traits")
			{
				__instance.numButtons = __instance.smallTraitList.Count;
				List<DisplayedUnlock> displayedUnlocks = __instance.smallTraitList.Select(u => (DisplayedUnlock)u.__RogueLibsCustom).OrderBy(d => d).ToList();
				CustomScrollingMenu menu = new CustomScrollingMenu(__instance, displayedUnlocks);

				foreach (DisplayedUnlock du in displayedUnlocks)
					du.Menu = menu;

				foreach (ButtonData buttonData in __instance.buttonsData)
					SetupUnlocks(buttonData, buttonData.scrollingButtonUnlock);
			}
			else if (__instance.menuType == "RemoveTrait" || __instance.menuType == "ChangeTraitRandom" || __instance.menuType == "UpgradeTrait")
			{
				__instance.numButtons = __instance.customTraitList.Count;
				List<DisplayedUnlock> displayedUnlocks = __instance.customTraitList.Select(u => (DisplayedUnlock)u.__RogueLibsCustom).OrderBy(d => d).ToList();
				CustomScrollingMenu menu = new CustomScrollingMenu(__instance, displayedUnlocks);

				foreach (DisplayedUnlock du in displayedUnlocks)
					du.Menu = menu;

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

		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Invokes the default button setup method - <see cref="SetupUnlocks(ButtonData, Unlock)"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool ScrollingMenu_SetupChallenges(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Invokes the default button setup method - <see cref="SetupUnlocks(ButtonData, Unlock)"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool ScrollingMenu_SetupFreeItems(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Invokes the default button setup method - <see cref="SetupUnlocks(ButtonData, Unlock)"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool ScrollingMenu_SetupItemUnlocks(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Invokes the default button setup method - <see cref="SetupUnlocks(ButtonData, Unlock)"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool ScrollingMenu_SetupTraitUnlocks(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);

		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Invokes the default button setup method - <see cref="SetupUnlocks(ButtonData, Unlock)"/>, and updates the <see cref="ScrollingMenu.numButtons"/> value.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="ScrollingMenu"/>.</param>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <param name="___listUnlocks">Private field. List of unlocks to be displayed in the menu.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool ScrollingMenu_SetupLoadouts(ScrollingMenu __instance, ButtonData myButtonData, Unlock myUnlock, List<Unlock> ___listUnlocks)
		{
			SetupUnlocks(myButtonData, myUnlock);
			__instance.numButtons = ___listUnlocks.Count;
			return false;
		}
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Sets the <see cref="ButtonData.scrollingButtonUnlock"/> value. The button is set up later, in the <see cref="ScrollingMenu_OpenScrollingMenu(ScrollingMenu, ref float, List{Unlock})"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool ScrollingMenu_SetupChangeTraitsRandom(ButtonData myButtonData, Unlock myUnlock)
		{
			myButtonData.scrollingButtonUnlock = myUnlock;
			return false;
		}
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Sets the <see cref="ButtonData.scrollingButtonUnlock"/> value. The button is set up later, in the <see cref="ScrollingMenu_OpenScrollingMenu(ScrollingMenu, ref float, List{Unlock})"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool ScrollingMenu_SetupRemoveTraits(ButtonData myButtonData, Unlock myUnlock)
		{
			myButtonData.scrollingButtonUnlock = myUnlock;
			return false;
		}
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Sets the <see cref="ButtonData.scrollingButtonUnlock"/> value. The button is set up later, in the <see cref="ScrollingMenu_OpenScrollingMenu(ScrollingMenu, ref float, List{Unlock})"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool ScrollingMenu_SetupUpgradeTraits(ButtonData myButtonData, Unlock myUnlock)
		{
			myButtonData.scrollingButtonUnlock = myUnlock;
			return false;
		}

		/// <summary>
		///   <para>Attaches the <see cref="UnlockWrapper"/> to the button and sets up the button.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
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

		/// <summary>
		///   <para><see cref="ClearAllMutatorsUnlock"/> button.</para>
		/// </summary>
		public static readonly ClearAllMutatorsUnlock clearAllMutators = new ClearAllMutatorsUnlock();
		/// <summary>
		///   <para><see cref="ClearAllItemsUnlock"/> button.</para>
		/// </summary>
		public static readonly ClearAllItemsUnlock clearAllItems = new ClearAllItemsUnlock();
		/// <summary>
		///   <para><see cref="ClearAllTraitsUnlock"/> button.</para>
		/// </summary>
		public static readonly ClearAllTraitsUnlock clearAllTraits = new ClearAllTraitsUnlock();
		/// <summary>
		///   <para><see cref="ReRollLoadoutsUnlock"/> button.</para>
		/// </summary>
		public static readonly ReRollLoadoutsUnlock reRollLoadouts = new ReRollLoadoutsUnlock();

		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Sets up the <see cref="CustomScrollingMenu"/> and sorts the unlocks according to their <see cref="DisplayedUnlock"/>s.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="ScrollingMenu"/>.</param>
		/// <param name="myUnlockList">List with unlocks to be displayed in the menu.</param>
		/// <param name="___listUnlocks">Private field. Sorted list with unlocks to be displayed in the menu.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool ScrollingMenu_SortUnlocks(ScrollingMenu __instance, List<Unlock> myUnlockList, List<Unlock> ___listUnlocks)
		{
			List<DisplayedUnlock> displayedList = myUnlockList.ConvertAll(u => (DisplayedUnlock)u.__RogueLibsCustom);
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

		/// <summary>
		///   <para><b>Prefix-patch (partial override).</b> Invokes the selected unlock's <see cref="DisplayedUnlock.OnPushedButton"/>.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="ScrollingMenu"/>.</param>
		/// <param name="myButton">Pressed button.</param>
		/// <returns><see langword="false"/>, if the menu doesn't display configurations; otherwise, <see langword="true"/>. Partial override.</returns>
		public static bool ScrollingMenu_PushedButton(ScrollingMenu __instance, ButtonHelper myButton)
		{
			if (__instance.menuType.EndsWith("Configs"))
				return true;

			ButtonData buttonData = __instance.buttonsData[myButton.scrollingButtonNum];
			DisplayedUnlock du = (DisplayedUnlock)buttonData.__RogueLibsCustom;

			du.OnPushedButton();
			return false;
		}

		/// <summary>
		///   <para><b>Prefix-patch (partial override).</b> Makes use of the <see cref="DisplayedUnlock"/>'s self-descriptive methods to set up the details window.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="ScrollingMenu"/>.</param>
		/// <param name="myButton">Button whose unlock's details are to be displayed.</param>
		/// <returns><see langword="false"/>, if certain conditions are met (see the code); otherwise, <see langword="true"/>. Partial override.</returns>
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

		/// <summary>
		///   <para><b>Postfix-patch.</b> Removes the unhooked reroll loadouts unlock from the list. Hooked version of that unlock is then added in <see cref="ScrollingMenu_SortUnlocks(ScrollingMenu, List{Unlock}, List{Unlock})"/>.</para>
		/// </summary>
		/// <param name="___loadoutList">Private field. List with loadout unlocks.</param>
		public static void ScrollingMenu_RefreshLoadouts(List<Unlock> ___loadoutList) => ___loadoutList.RemoveAt(0);
	}
}
