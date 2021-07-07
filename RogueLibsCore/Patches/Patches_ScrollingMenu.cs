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

			RogueLibs.CreateCustomName("GiveNuggetsDebug", "Unlock", new CustomNameInfo("[DEBUG] +10 Nuggets"));
			RogueLibs.CreateCustomName("D_GiveNuggetsDebug", "Unlock", new CustomNameInfo("A debug-build feature that gives you 10 nuggets."));
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
			myButtonData.buttonText = du.GetName();

			du.UpdateUnlock();
			du.UpdateButton();
			return false;
		}

		public static readonly ClearAllMutatorsUnlock clearAllMutators = new ClearAllMutatorsUnlock();
		public static readonly ClearAllItemsUnlock clearAllItems = new ClearAllItemsUnlock();
		public static readonly ClearAllTraitsUnlock clearAllTraits = new ClearAllTraitsUnlock();
		public static readonly ReRollLoadoutsUnlock reRollLoadouts = new ReRollLoadoutsUnlock();
		private static readonly GiveNuggetsButton giveNuggets = new GiveNuggetsButton();

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
				if (RogueFramework.IsDebugEnabled(DebugFlags.EnableTools))
				{
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
			if (__instance.menuType.EndsWith("Configs"))
				return true;

			ButtonData buttonData = __instance.buttonsData[myButton.scrollingButtonNum];
			DisplayedUnlock du = (DisplayedUnlock)buttonData.__RogueLibsCustom;

			try
			{
				du.OnPushedButton();
			}
			catch (Exception e)
			{
				RogueFramework.Logger.LogError($"An error updating {du?.Name} ({du?.Type}) button.");
				RogueFramework.Logger.LogError(e);
			}
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

		public static void ScrollingMenu_RefreshLoadouts(List<Unlock> ___loadoutList)
		{
			___loadoutList.RemoveAt(0);
			for (int i = 0; i < ___loadoutList.Count; i++)
			{
				Unlock unlock = ___loadoutList[i];
				if (unlock.__RogueLibsCustom is null)
				{
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
					Unlock traitUnlock = RogueLibs.GetUnlock(trait.traitName, "Trait")?.Unlock;
					if (traitUnlock?.cancellations.Contains(myUnlock.unlockName) == true)
					{
						__result = false;
						return;
					}
				}
			}
		}
	}
	internal class GiveNuggetsButton : MutatorUnlock
	{
		public GiveNuggetsButton() : base("GiveNuggetsDebug", true) { }

		public override string GetFancyName() => $"<color=cyan>{GetName()}</color>";
		public override void OnPushedButton()
		{
			gc.unlocks.AddNuggets(10);
			PlaySound("BuyItem");
			gc.unlocks.SaveUnlockData(true);
			UpdateMenu();
		}
	}
}
