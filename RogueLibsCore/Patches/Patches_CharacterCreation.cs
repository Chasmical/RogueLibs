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
using static UnityEngine.Random;
using System.Diagnostics;

namespace RogueLibsCore
{
	internal sealed partial class RogueLibsPlugin
	{
		public void PatchCharacterCreation()
		{
			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SetupItems));
			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SetupTraits));
			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SetupAbilities));
			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SetupBigQuests));

			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SortUnlocks));

			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.PushedButton));

			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.ShowDetails));

			Patcher.AnyErrors();
		}

		public static bool CharacterCreation_SetupItems(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool CharacterCreation_SetupTraits(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool CharacterCreation_SetupAbilities(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool CharacterCreation_SetupBigQuests(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);

		public static bool CharacterCreation_SortUnlocks(CharacterCreation __instance, List<Unlock> myUnlockList, string unlockType)
		{
			if (unlockType == UnlockTypes.BigQuest) myUnlockList = __instance.gc.sessionDataBig.bigQuestUnlocks;

			List<DisplayedUnlock> displayedList = myUnlockList.Select(u => u.__RogueLibsCustom).OfType<DisplayedUnlock>().ToList();
			if (unlockType == UnlockTypes.Ability || unlockType == UnlockTypes.BigQuest)
				displayedList.RemoveAll(u => u is IUnlockInCC inCC && !inCC.IsAvailableInCC);

			displayedList.Sort();
			CustomCharacterCreation menu = new CustomCharacterCreation(__instance, displayedList);
			if (RogueFramework.IsDebugEnabled(DebugFlags.UnlockMenus))
				RogueFramework.LogDebug($"Setting up \"{menu.Type}\" menu.");

			List<Unlock> listUnlocks = unlockType == UnlockTypes.Item ? __instance.listUnlocksItems
				: unlockType == UnlockTypes.Trait ? __instance.listUnlocksTraits
				: unlockType == UnlockTypes.Ability ? __instance.listUnlocksAbilities
				: unlockType == UnlockTypes.BigQuest ? __instance.listUnlocksBigQuests : null;
			listUnlocks.Clear();
			listUnlocks.AddRange(menu.Unlocks.Select(du => du.Unlock));

			foreach (DisplayedUnlock du in menu.Unlocks)
				du.Menu = menu;

			if (unlockType == UnlockTypes.Item)
			{
				clearAllItems.Menu = menu;
				listUnlocks.Insert(0, clearAllItems.Unlock);
			}
			else if (unlockType == UnlockTypes.Trait)
			{
				clearAllTraits.Menu = menu;
				listUnlocks.Insert(0, clearAllTraits.Unlock);
			}

			if (unlockType == UnlockTypes.Item) __instance.numButtonsItems = listUnlocks.Count - 1;
			else if (unlockType == UnlockTypes.Trait) __instance.numButtonsTraits = listUnlocks.Count - 1;
			else if (unlockType == UnlockTypes.Ability) __instance.numButtonsAbilities = listUnlocks.Count;
			else if (unlockType == UnlockTypes.BigQuest) __instance.numButtonsBigQuests = listUnlocks.Count;
			return false;
		}

		public static bool CharacterCreation_PushedButton(CharacterCreation __instance, ButtonHelper myButton)
		{
			bool debug = RogueFramework.IsDebugEnabled(DebugFlags.UnlockMenus);
			if (__instance.selectedSpace == "Load")
			{
				if (debug) RogueFramework.LogDebug("Redirecting the button push to the original method.");
				return true;
			}

			if (debug) RogueFramework.LogDebug($"Pressing \"{myButton.myText.text}\" ({myButton.scrollingButtonNum}, {myButton.scrollingButtonType}) button.");

			string type = myButton.scrollingButtonUnlock.unlockType;
			List<ButtonData> buttonsData = type == UnlockTypes.Item ? __instance.buttonsDataItems
				: type == UnlockTypes.Trait ? __instance.buttonsDataTraits
				: type == UnlockTypes.Ability ? __instance.buttonsDataAbilities
				: type == UnlockTypes.BigQuest ? __instance.buttonsDataBigQuests : null;

			ButtonData buttonData = buttonsData[myButton.scrollingButtonNum];
			DisplayedUnlock du = (DisplayedUnlock)buttonData.__RogueLibsCustom;

			try { du.OnPushedButton(); }
			catch (Exception e) { RogueFramework.LogError(e, "DisplayedUnlock.OnPushedButton", du, du.Menu); }
			__instance.curSelectedButton = myButton;
			__instance.curSelectedButtonNum = myButton.scrollingButtonNum;
			return false;
		}

		public static bool CharacterCreation_ShowDetails(CharacterCreation __instance, ButtonHelper myButton)
		{
			if (__instance.loadMenu.gameObject.activeSelf) return true;

			Image image = null; Text title = null; Text text = null;
			if (myButton.scrollingButtonUnlock.unlockType == UnlockTypes.Item)
			{ image = __instance.detailsImageItems; title = __instance.detailsTitleItems; text = __instance.detailsTextItems; }
			else if (myButton.scrollingButtonUnlock.unlockType == UnlockTypes.Trait)
			{ image = __instance.detailsImageTraits; title = __instance.detailsTitleTraits; text = __instance.detailsTextTraits; }
			else if (myButton.scrollingButtonUnlock.unlockType == UnlockTypes.Ability)
			{ image = __instance.detailsImageAbilities; title = __instance.detailsTitleAbilities; text = __instance.detailsTextAbilities; }
			else if (myButton.scrollingButtonUnlock.unlockType == UnlockTypes.BigQuest)
			{ image = __instance.detailsImageBigQuests; title = __instance.detailsTitleBigQuests; text = __instance.detailsTextBigQuests; }

			if (image != null)
			{
				DisplayedUnlock du = (DisplayedUnlock)myButton.scrollingButtonUnlock.__RogueLibsCustom;

				title.text = du.GetName();
				text.text = du.GetFancyDescription();
				image.sprite = du.GetImage();
				image.gameObject.SetActive(image.sprite != null);
			}

			__instance.curSelectedButton = myButton;
			__instance.curSelectedButtonNum = myButton.scrollingButtonNum;
			return false;
		}
	}
}
