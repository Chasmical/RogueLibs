using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
	internal sealed partial class RogueLibsPlugin
	{
		public void PatchScrollingMenu()
		{
			clearAllMutators = new ClearAllMutatorsUnlock();
			clearAllItems = new ClearAllItemsUnlock();
			clearAllTraits = new ClearAllTraitsUnlock();
			reRollLoadouts = new ReRollLoadoutsUnlock();
			giveNuggets = new GiveNuggetsButton();

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

			Patcher.Postfix(typeof(ScrollingMenu), nameof(ScrollingMenu.CanHaveTrait));

			Patcher.AnyErrors();

			RogueLibs.CreateCustomName("GiveNuggetsDebug", NameTypes.Unlock, new CustomNameInfo("[DEBUG] +10 Nuggets"));
			RogueLibs.CreateCustomName("D_GiveNuggetsDebug", NameTypes.Unlock, new CustomNameInfo("A debug tool that gives you 10 nuggets."));
		}

		public static void ScrollingMenu_OpenScrollingMenu_Prefix(ScrollingMenu __instance, out float __state)
		{
			float x = 1f - __instance.scrollBar.value;
			__state = x * (__instance.numButtons - __instance.numButtonsOnScreen + 1f);
			if (RogueFramework.IsDebugEnabled(DebugFlags.UnlockMenus))
				RogueFramework.LogDebug($"Stored menu's scrolling value of {__state} units.");
		}
		public static void ScrollingMenu_OpenScrollingMenu(ScrollingMenu __instance, ref float __state, List<Unlock> ___listUnlocks)
		{
			__instance.numButtons = ___listUnlocks.Count;
			float x = __state / (__instance.numButtons - __instance.numButtonsOnScreen + 1f);
			bool debug = RogueFramework.IsDebugEnabled(DebugFlags.UnlockMenus);
			if (debug) RogueFramework.LogDebug($"Restoring menu's scrolling value of {__state} units.");
			__instance.StartCoroutine(EnsureScrollbarValue(__instance, Mathf.Clamp01(1f - x)));

			if (__instance.menuType == "Challenges" || __instance.menuType == "FreeItems")
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
			}
			else if (__instance.menuType == "Floors")
			{
				if (debug) RogueFramework.LogDebug("Setting up \"Floors\" menu.");
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
				if (debug) RogueFramework.LogDebug("Setting up \"Traits\" menu.");
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
				if (debug) RogueFramework.LogDebug($"Setting up \"{__instance.menuType}\" menu.");
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

		public static bool ScrollingMenu_SetupChallenges(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupFreeItems(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupItemUnlocks(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupTraitUnlocks(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);

		public static bool ScrollingMenu_SetupLoadouts(ScrollingMenu __instance, ButtonData myButtonData, Unlock myUnlock, List<Unlock> ___listUnlocks)
		{
			SetupUnlocks(myButtonData, myUnlock);
			__instance.numButtons = ___listUnlocks.Count;
			return false;
		}
		public static bool ScrollingMenu_SetupChangeTraitsRandom(ButtonData myButtonData, Unlock myUnlock)
		{
			myButtonData.scrollingButtonUnlock = myUnlock;
			return false;
		}
		public static bool ScrollingMenu_SetupRemoveTraits(ButtonData myButtonData, Unlock myUnlock)
		{
			myButtonData.scrollingButtonUnlock = myUnlock;
			return false;
		}
		public static bool ScrollingMenu_SetupUpgradeTraits(ButtonData myButtonData, Unlock myUnlock)
		{
			myButtonData.scrollingButtonUnlock = myUnlock;
			return false;
		}

		public static bool SetupUnlocks(ButtonData myButtonData, Unlock myUnlock)
		{
			DisplayedUnlock du = (DisplayedUnlock)(myButtonData.__RogueLibsCustom = myUnlock.__RogueLibsCustom);
			du.ButtonData = myButtonData;

			myButtonData.scrollingButtonUnlock = myUnlock;
			myButtonData.scrollingButtonType = myUnlock.unlockName;
			myButtonData.interactable = true;
			myButtonData.buttonText = du.GetFancyName();

			du.UpdateUnlock();
			du.UpdateButton();
			return false;
		}

		public static ClearAllMutatorsUnlock clearAllMutators;
		public static ClearAllItemsUnlock clearAllItems;
		public static ClearAllTraitsUnlock clearAllTraits;
		public static ReRollLoadoutsUnlock reRollLoadouts;
		private static GiveNuggetsButton giveNuggets;

		public static bool ScrollingMenu_SortUnlocks(ScrollingMenu __instance, List<Unlock> myUnlockList, List<Unlock> ___listUnlocks)
		{
			List<DisplayedUnlock> displayedList = myUnlockList.ConvertAll(u => (DisplayedUnlock)u.__RogueLibsCustom);
			if (__instance.menuType == "FreeItems")
				displayedList.RemoveAll(u => u is ItemUnlock itemUnlock && !itemUnlock.IsAvailableInItemTeleporter);

			displayedList.Sort();
			CustomScrollingMenu menu = new CustomScrollingMenu(__instance, displayedList);
			if (RogueFramework.IsDebugEnabled(DebugFlags.UnlockMenus))
				RogueFramework.LogDebug($"Setting up \"{menu.Type}\" menu.");

			___listUnlocks.Clear();
			___listUnlocks.AddRange(menu.Unlocks.Select(du => du.Unlock));

			foreach (DisplayedUnlock du in menu.Unlocks)
				du.Menu = menu;

			if (menu.Type == UnlocksMenuType.Loadouts)
			{
				reRollLoadouts.Menu = menu;
				___listUnlocks.Insert(0, reRollLoadouts.Unlock);
				if (RogueFramework.IsDebugEnabled(DebugFlags.EnableTools))
				{
					RogueFramework.LogDebug("Adding \"GiveNuggets\" debug tool to the menu.");
					giveNuggets.Menu = menu;
					___listUnlocks.Insert(0, giveNuggets.Unlock);
				}
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
			bool debug = RogueFramework.IsDebugEnabled(DebugFlags.UnlockMenus);
			if (__instance.menuType.EndsWith("Configs"))
			{
				if (debug) RogueFramework.LogDebug("Redirecting the button push to the original method.");
				return true;
			}

			if (debug) RogueFramework.LogDebug($"Pressing \"{myButton.myText.text}\" ({myButton.scrollingButtonNum}, {myButton.scrollingButtonType}) button.");

			ButtonData buttonData = __instance.buttonsData[myButton.scrollingButtonNum];
			DisplayedUnlock du = (DisplayedUnlock)buttonData.__RogueLibsCustom;

			try { du.OnPushedButton(); }
			catch (Exception e) { RogueFramework.LogError(e, "DisplayedUnlock.OnPushedButton", du, du.Menu); }
			return false;
		}

		public static bool ScrollingMenu_ShowDetails(ScrollingMenu __instance, ButtonHelper myButton)
		{
			if (__instance.agent != null && myButton.scrollingButtonUnlock?.unlockType == "Trait" && __instance.agent.addedEndLevelTrait || !string.IsNullOrEmpty(myButton.scrollingButtonLevelFeeling) || !string.IsNullOrEmpty(myButton.scrollingButtonConfigName) || !string.IsNullOrEmpty(myButton.scrollingButtonAgentName))
				return true;
			DisplayedUnlock du = (DisplayedUnlock)myButton.scrollingButtonUnlock.__RogueLibsCustom;

            bool show = du.IsUnlocked || du.Unlock.nowAvailable || du.Menu.ShowLockedUnlocks;
            __instance.detailsTitle.text = show ? du.GetName() : "?????";
			__instance.detailsText.text = du.GetFancyDescription();
			__instance.detailsImage.sprite = show ? du.GetImage() : null;
			__instance.detailsImage.gameObject.SetActive(__instance.detailsImage.sprite != null);

			// Gamepad scrolling fix
			__instance.curSelectedButtonNum = myButton.scrollingButtonNum;
			if (__instance.menuType == "FreeItems" && __instance.setInitialSelectedChildFreeItems)
				__instance.curSelectedChildFreeItems = myButton.scrollingButtonNum;
			__instance.curSelectedButton = myButton;
			if (__instance.agent.controllerType == "Gamepad")
			{
				if (!__instance.refreshing)
				{
					__instance.scrollBar.value = Mathf.Clamp01(1f - __instance.yOffset / ((__instance.numButtons - __instance.numButtonsOnScreen + 1f) * __instance.yOffset) * ((float)myButton.scrollingButtonNum - (__instance.numButtonsOnScreen / 2f - 1f)));
				}
				if ((__instance.menuType == "TraitUnlocks" || __instance.menuType == "Items") && !__instance.isPersonal)
				{
					__instance.instructionText2.text
						= myButton.scrollingButtonUnlock.unlocked
							  ? __instance.gc.nameDB.GetName(myButton.scrollingButtonUnlock.notActive
								                                 ? "AddToPool" : "RemoveFromPool", "Interface")
							  : __instance.gc.nameDB.GetName("ScrollingInstr4", "Interface");
				}
			}

			return false;
		}

		public static void ScrollingMenu_RefreshLoadouts(List<Unlock> ___loadoutList)
		{
			bool debug = RogueFramework.IsDebugEnabled(DebugFlags.UnlockMenus);
			if (debug) RogueFramework.LogDebug("Refreshing the loadouts.");
			___loadoutList.RemoveAt(0);
			for (int i = 0; i < ___loadoutList.Count; i++)
			{
				Unlock unlock = ___loadoutList[i];
				if (unlock.__RogueLibsCustom is null)
				{
					if (debug) RogueFramework.LogDebug("Hooking up an unhooked unlock.");
					Unlock normalized = GameController.gameController.sessionDataBig.unlocks
						.Find(u => u.unlockName == unlock.unlockName && u.unlockType == unlock.unlockType);
					unlock.__RogueLibsCustom = normalized.__RogueLibsCustom;
				}
			}
		}

		public static void ScrollingMenu_CanHaveTrait(ScrollingMenu __instance, Unlock myUnlock, ref bool __result)
		{
			if (__result)
			{
				foreach (Trait trait in __instance.agent.statusEffects.TraitList)
				{
					if (myUnlock.cancellations.Contains(trait.traitName))
					{
						__result = false;
						return;
					}
					Unlock traitUnlock = RogueLibs.GetUnlock(trait.traitName, UnlockTypes.Trait)?.Unlock;
					if (traitUnlock?.cancellations.Contains(myUnlock.unlockName) == true)
					{
						__result = false;
						return;
					}
				}
			}
		}
	}
}
