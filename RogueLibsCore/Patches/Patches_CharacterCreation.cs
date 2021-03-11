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
		///   <para>Applies the patches to <see cref="CharacterCreation"/>.</para>
		/// </summary>
		public void PatchCharacterCreation()
		{
			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SetupItems));
			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SetupTraits));
			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SetupAbilities));
			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SetupBigQuests));

			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.SortUnlocks));

			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.PushedButton));

			Patcher.Prefix(typeof(CharacterCreation), nameof(CharacterCreation.ShowDetails));
		}

		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Invokes the default unlocks setup method - <see cref="SetupUnlocks(ButtonData, Unlock)"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool CharacterCreation_SetupItems(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Invokes the default unlocks setup method - <see cref="SetupUnlocks(ButtonData, Unlock)"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool CharacterCreation_SetupTraits(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Invokes the default unlocks setup method - <see cref="SetupUnlocks(ButtonData, Unlock)"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool CharacterCreation_SetupAbilities(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Invokes the default unlocks setup method - <see cref="SetupUnlocks(ButtonData, Unlock)"/>.</para>
		/// </summary>
		/// <param name="myButtonData"><see cref="ButtonData"/> that displays <paramref name="myUnlock"/> in the menu.</param>
		/// <param name="myUnlock"><see cref="Unlock"/> that is displayed by <paramref name="myButtonData"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool CharacterCreation_SetupBigQuests(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);

		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Sets up the <see cref="CustomCharacterCreation"/> menu and sorts the unlocks according to their <see cref="DisplayedUnlock"/>s.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="CharacterCreation"/>.</param>
		/// <param name="myUnlockList">List with unlocks to be displayed in the menu.</param>
		/// <param name="unlockType">Type of the unlocks to be displayed.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool CharacterCreation_SortUnlocks(CharacterCreation __instance, List<Unlock> myUnlockList, string unlockType)
		{
			if (unlockType == "BigQuest") myUnlockList = __instance.gc.sessionDataBig.bigQuestUnlocks;

			List<DisplayedUnlock> displayedList = myUnlockList.Select(u => u.__RogueLibsCustom).OfType<DisplayedUnlock>().ToList();
			if (unlockType == "Ability" || unlockType == "BigQuest") displayedList.RemoveAll(u => u is IUnlockInCC inCC && !inCC.IsAvailableInCC);

			displayedList.Sort();
			CustomCharacterCreation menu = new CustomCharacterCreation(__instance, displayedList);

			List<Unlock> listUnlocks = unlockType == "Item" ? __instance.listUnlocksItems
				: unlockType == "Trait" ? __instance.listUnlocksTraits
				: unlockType == "Ability" ? __instance.listUnlocksAbilities
				: unlockType == "BigQuest" ? __instance.listUnlocksBigQuests : null;
			listUnlocks.Clear();
			listUnlocks.AddRange(menu.Unlocks.Select(du => du.Unlock));

			foreach (DisplayedUnlock du in menu.Unlocks)
				du.Menu = menu;

			if (unlockType == "Item")
			{
				clearAllItems.Menu = menu;
				listUnlocks.Insert(0, clearAllItems.Unlock);
			}
			else if (unlockType == "Trait")
			{
				clearAllTraits.Menu = menu;
				listUnlocks.Insert(0, clearAllTraits.Unlock);
			}

			if (unlockType == "Item") __instance.numButtonsItems = listUnlocks.Count - 1;
			else if (unlockType == "Trait") __instance.numButtonsTraits = listUnlocks.Count - 1;
			else if (unlockType == "Ability") __instance.numButtonsAbilities = listUnlocks.Count;
			else if (unlockType == "BigQuest") __instance.numButtonsBigQuests = listUnlocks.Count;
			return false;
		}

		/// <summary>
		///   <para><b>Prefix-patch (partial override).</b> Invokes the selected unlock's <see cref="DisplayedUnlock.OnPushedButton"/> method.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="CharacterCreation"/>.</param>
		/// <param name="myButton">Pressed button.</param>
		/// <returns><see langword="false"/>, if the selected namespace is not "Load"; otherwise, <see langword="true"/>. Partial override.</returns>
		public static bool CharacterCreation_PushedButton(CharacterCreation __instance, ButtonHelper myButton)
		{
			if (__instance.selectedSpace == "Load") return true;

			string type = myButton.scrollingButtonUnlock.unlockType;
			List<ButtonData> buttonsData = type == "Item" ? __instance.buttonsDataItems
				: type == "Trait" ? __instance.buttonsDataTraits
				: type == "Ability" ? __instance.buttonsDataAbilities
				: type == "BigQuest" ? __instance.buttonsDataBigQuests : null;

			ButtonData buttonData = buttonsData[myButton.scrollingButtonNum];
			DisplayedUnlock du = (DisplayedUnlock)buttonData.__RogueLibsCustom;

			du.OnPushedButton();
			__instance.curSelectedButton = myButton;
			__instance.curSelectedButtonNum = myButton.scrollingButtonNum;
			return false;
		}

		/// <summary>
		///   <para><b>Prefix-patch (partial override).</b> Makes use of the <see cref="DisplayedUnlock"/>'s self-descriptive methods to set up the details window.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="CharacterCreation"/>.</param>
		/// <param name="myButton">Button whose unlock's details are to be displayed.</param>
		/// <returns><see langword="false"/>, if the character loading menu is not active; otherwise, <see langword="true"/>. Partial override.</returns>
		public static bool CharacterCreation_ShowDetails(CharacterCreation __instance, ButtonHelper myButton)
		{
			if (__instance.loadMenu.gameObject.activeSelf) return true;

			Image image = null; Text title = null; Text text = null;
			if (myButton.scrollingButtonUnlock.unlockType == "Item")
			{ image = __instance.detailsImageItems; title = __instance.detailsTitleItems; text = __instance.detailsTextItems; }
			else if (myButton.scrollingButtonUnlock.unlockType == "Trait")
			{ image = __instance.detailsImageTraits; title = __instance.detailsTitleTraits; text = __instance.detailsTextTraits; }
			else if (myButton.scrollingButtonUnlock.unlockType == "Ability")
			{ image = __instance.detailsImageAbilities; title = __instance.detailsTitleAbilities; text = __instance.detailsTextAbilities; }
			else if (myButton.scrollingButtonUnlock.unlockType == "BigQuest")
			{ image = __instance.detailsImageBigQuests; title = __instance.detailsTitleBigQuests; text = __instance.detailsTextBigQuests; }

			if (image != null)
			{
				DisplayedUnlock du = (DisplayedUnlock)myButton.scrollingButtonUnlock.__RogueLibsCustom;

				title.text = du.GetName();
				text.text = du.GetDescription();
				image.sprite = du.GetImage();
				image.gameObject.SetActive(image.sprite != null);
			}

			__instance.curSelectedButton = myButton;
			__instance.curSelectedButtonNum = myButton.scrollingButtonNum;
			return false;
		}
	}
}
