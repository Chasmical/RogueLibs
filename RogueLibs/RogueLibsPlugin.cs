using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using tk2dRuntime;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLibsCore
{
#pragma warning disable CS1591
	[BepInPlugin(RogueLibs.pluginGuid, RogueLibs.pluginName, RogueLibs.pluginVersion)]
	public class RogueLibsPlugin : BaseUnityPlugin
	{
		protected static ManualLogSource MyLogger;

		protected void Awake()
		{
			RogueLibs.PluginInstance = this;
			RogueLibs.Logger = MyLogger = Logger;

			RoguePatcher patcher = new RoguePatcher(this, GetType());

			patcher.Postfix(typeof(NameDB), "GetName"); // CustomNames

			patcher.Postfix(typeof(InvItem), "SetupDetails"); // CustomItem's SetupDetails
			patcher.Postfix(typeof(ItemFunctions), "UseItem"); // CustomItem's UseItem
			patcher.Postfix(typeof(ItemFunctions), "TargetObject"); // CustomItem's TargetObject
			patcher.Postfix(typeof(ItemFunctions), "CombineItems"); // CustomItem's CombineItems
			patcher.Postfix(typeof(InvSlot), "SetColor"); // CustomItem's CombineTooltip

			patcher.Postfix(typeof(StatusEffects), "SpecialAbilityInterfaceCheck2"); // CustomAbility's IndicatorCheck
			patcher.Postfix(typeof(StatusEffects), "RechargeSpecialAbility2"); // CustomAbility's RechargeInterval and Recharge
			patcher.Postfix(typeof(StatusEffects), "GiveSpecialAbility"); // starting special ability enumerators
			patcher.Postfix(typeof(StatusEffects), "PressedSpecialAbility"); // CustomAbility's OnPressed
			patcher.Postfix(typeof(StatusEffects), "HeldSpecialAbility"); // CustomAbility's OnHeld
			patcher.Postfix(typeof(StatusEffects), "ReleasedSpecialAbility"); // CustomAbility's OnReleased

			patcher.Postfix(typeof(SpecialAbilityIndicator), "ShowIndicator", new Type[] { typeof(PlayfieldObject), typeof(string), typeof(string) });
			// CustomAbility's IndicatorCheck

			Awake2();
		}

		protected static string[] languages = new string[8] { "english", "schinese", "german", "spanish", "brazilian", "russian", "french", "koreana" };
		protected static string[] nameTypes = new string[8] { "Agent", "Item", "Object", "StatusEffect", "Interface", "Dialogue", "Description", "Unlock" };
		protected static void NameDB_GetName(NameDB __instance, string myName, string type, ref string __result)
		{
			if (!__result.StartsWith("E_")) return;
			foreach (CustomName name in RogueLibs.CustomNames)
				if (name.Id == myName && name.Type == type)
				{
					int index = Array.IndexOf(languages, __instance.language);
					if (index < 0) index++;
					__result = name.Translations[index] ?? name.English;
					return;
				}
		}

		protected static void InvItem_SetupDetails(InvItem __instance)
		{
			CustomItem customItem = RogueLibs.CustomItems.Find(i => i.Id == __instance.invItemName);
			if (customItem != null)
			{
				__instance.LoadItemSprite(__instance.invItemName);
				customItem.SetupDetails?.Invoke(__instance);
			}
			else
			{
				CustomAbility customAbility = RogueLibs.CustomAbilities.Find(a => a.Id == __instance.invItemName);
				if (customAbility != null)
				{
					__instance.LoadItemSprite(__instance.invItemName);
					customAbility.SetupDetails?.Invoke(__instance);
				}
			}
		}
		protected static void ItemFunctions_UseItem(InvItem item, Agent agent)
		{
			CustomItem customItem = RogueLibs.CustomItems.Find(i => i.Id == item.invItemName);
			if (customItem == null) return;
			if (customItem.TargetObject != null)
				item.invInterface.ShowOrHideTarget(item);
			else
				customItem.UseItem?.Invoke(item, agent);
		}
		protected static void ItemFunctions_TargetObject(InvItem item, Agent agent, PlayfieldObject otherObject, string combineType, ref bool __result)
		{
			CustomItem customItem = RogueLibs.CustomItems.Find(i => i.Id == item.invItemName);
			if (customItem?.TargetObject == null) return;

			if ((__result = customItem.TargetFilter == null || customItem.TargetFilter(item, agent, otherObject)) && combineType == "Combine")
			{
				customItem.TargetObject(item, agent, otherObject);
				if (item.invItemCount < 1)
				{
					agent.mainGUI.invInterface.HideDraggedItem();
					agent.mainGUI.invInterface.HideTarget();
				}
			}
		}
		protected static void ItemFunctions_CombineItems(InvItem item, Agent agent, InvItem otherItem, string combineType, ref bool __result)
		{
			CustomItem customItem = RogueLibs.CustomItems.Find(i => i.Id == item.invItemName);
			if (customItem?.CombineItems == null) return;

			if ((__result = customItem.CombineFilter == null || customItem.CombineFilter(item, agent, otherItem)) && combineType == "Combine")
			{
				customItem.CombineItems(item, agent, otherItem);
				if (item.invItemCount < 1)
				{
					agent.mainGUI.invInterface.HideDraggedItem();
					agent.mainGUI.invInterface.HideTarget();
				}
			}
		}
		protected static void InvSlot_SetColor(InvSlot __instance, Text ___itemText)
		{
			InvItem targetItem = __instance.mainGUI.targetItem ?? __instance.database.invInterface.draggedInvItem;
			if (targetItem == null) return;
			InvItem thisItem = __instance.curItemList[__instance.slotNumber];

			CustomItem cItem = RogueLibs.CustomItems.Find(i => i.Id == targetItem.invItemName);
			if (cItem?.CombineTooltip == null) return;

			if (__instance.slotType == "Player" || __instance.slotType == "Toolbar" || __instance.slotType == "Chest" || __instance.slotType == "NPCChest")
			{
				if (thisItem.invItemName != null && targetItem.itemType == "Combine")
				{
					if (targetItem.CombineItems(thisItem, __instance.slotNumber, string.Empty, __instance.agent) && __instance.slotType != "NPCChest")
					{
						__instance.myImage.color = new Color32(0, __instance.br, __instance.br, __instance.standardAlpha);
						__instance.itemImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
						__instance.myImage.sprite = __instance.invBoxCanUse;

						if (__instance.slotType != "NPCChest" && __instance.slotType != "Chest")
						{
							string result = cItem.CombineTooltip(targetItem, targetItem.agent, thisItem) ?? string.Empty;
							__instance.toolbarNumTextGo.SetActive(result != string.Empty);
							__instance.toolbarNumText.text = result;
						}
					}
					else if ((__instance.slotType != "Toolbar" || __instance.mainGUI.openedInventory) && __instance.slotType != "NPCChest")
					{
						__instance.myImage.color = new Color32(__instance.br, 0, __instance.br, __instance.standardAlpha);
						__instance.itemImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, __instance.fadedItemAlpha);
						__instance.myImage.sprite = __instance.invBoxNormal;
						___itemText.color = __instance.whiteTransparent;
						__instance.toolbarNumTextGo.SetActive(false);
					}
				}
				else if (__instance.slotType != "NPCChest" && (thisItem.invItemName != null || targetItem.itemType != "Combine"))
				{
					__instance.myImage.color = __instance.overSlot
						? (Color)new Color32(0, __instance.br, __instance.br, __instance.standardAlpha)
						: (Color)new Color32(__instance.br, __instance.br, __instance.br, __instance.standardAlpha);

					__instance.itemImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					__instance.myImage.sprite = __instance.invBoxNormal;
					if (__instance.slotType == "Toolbar")
						__instance.toolbarNumTextGo.SetActive(false);
				}
				if (__instance.mainGUI.curSelected == __instance.mySelectable && __instance.agent.controllerType != "Keyboard")
					__instance.invInterface.OnSelectionBox(__instance.slotType, __instance.tr.position);
			}
		}

		protected static IEnumerator StatusEffects_SpecialAbilityInterfaceCheck2(IEnumerator iEnumerator, StatusEffects __instance)
		{
			while (iEnumerator.MoveNext())
			{
				CustomAbility ability = RogueLibs.GetCustomAbility(__instance.agent.specialAbility);
				if (ability?.IndicatorCheck != null)
				{
					PlayfieldObject res = ability.IndicatorCheck.Invoke(__instance.agent.inventory.equippedSpecialAbility, __instance.agent);
					if (res == null) __instance.agent.specialAbilityIndicator.Revert();
					else __instance.agent.specialAbilityIndicator.ShowIndicator(res, __instance.agent.specialAbility);
				}
				yield return iEnumerator.Current;
			}
		}
		protected static IEnumerator StatusEffects_RechargeSpecialAbility2(IEnumerator iEnumerator, StatusEffects __instance)
		{
			while (iEnumerator.MoveNext())
			{
				CustomAbility ability = RogueLibs.GetCustomAbility(__instance.agent.specialAbility);
				if (ability == null)
					yield return iEnumerator.Current;
				else
				{
					yield return ability.RechargeInterval?.Invoke(__instance.agent.inventory.equippedSpecialAbility, __instance.agent);
					ability.Recharge?.Invoke(__instance.agent.inventory.equippedSpecialAbility, __instance.agent);
				}
			}
		}
		protected static void StatusEffects_GiveSpecialAbility(StatusEffects __instance, string abilityName)
		{
			if (GameController.gameController.levelType == "HomeBase" && !__instance.agent.isDummy) return;
			if (__instance.agent.name == "DummyAgent" || __instance.agent.name.Contains("BackupAgent")) return;

			CustomAbility ability = RogueLibs.GetCustomAbility(__instance.agent.specialAbility);

			if (ability != null)
			{
				__instance.SpecialAbilityInterfaceCheck();
				__instance.RechargeSpecialAbility(abilityName);
			}
		}
		protected static void StatusEffects_PressedSpecialAbility(StatusEffects __instance)
		{
			if (__instance.agent.ghost || __instance.agent.teleporting) return;

			CustomAbility ability = RogueLibs.GetCustomAbility(__instance.agent.specialAbility);
			ability?.OnPressed?.Invoke(__instance.agent.inventory.equippedSpecialAbility, __instance.agent);
		}
		protected static void StatusEffects_HeldSpecialAbility(StatusEffects __instance)
		{
			if (__instance.agent.ghost || __instance.agent.teleporting) return;

			CustomAbility ability = RogueLibs.GetCustomAbility(__instance.agent.specialAbility);
			ability?.OnHeld?.Invoke(__instance.agent.inventory.equippedSpecialAbility, __instance.agent, ref __instance.agent.gc.playerControl.pressedSpecialAbilityTime[__instance.agent.isPlayer - 1]);
		}
		protected static void StatusEffects_ReleasedSpecialAbility(StatusEffects __instance)
		{
			if (__instance.agent.ghost || __instance.agent.teleporting) return;

			CustomAbility ability = RogueLibs.GetCustomAbility(__instance.agent.specialAbility);
			ability?.OnReleased?.Invoke(__instance.agent.inventory.equippedSpecialAbility, __instance.agent);
		}

		protected static void SpecialAbilityIndicator_ShowIndicator(SpecialAbilityIndicator __instance, string specialAbilityType)
		{
			CustomAbility ability = RogueLibs.GetCustomAbility(specialAbilityType);
			if (ability != null)
				__instance.image.sprite = ability.Sprite;
		}

		protected void Awake2()
		{
			RoguePatcher patcher = new RoguePatcher(this, GetType());

			patcher.Postfix(typeof(Unlocks), "LoadInitialUnlocks"); // CustomUnlocks

			patcher.Postfix(typeof(ScrollingMenu), "SortUnlocks"); // sorting/filtering Challenges, Item and Trait Unlocks

			patcher.Prefix(typeof(ScrollingMenu), "SetupChallenges"); // setting up Challenges in Mutators Menu
			patcher.Prefix(typeof(ScrollingMenu), "SetupItemUnlocks"); // setting up Item Unlocks in Rewards Menu
			patcher.Prefix(typeof(ScrollingMenu), "SetupTraitUnlocks"); // setting up Trait Unlocks in Traits Menu
			patcher.Prefix(typeof(ScrollingMenu), "SetupFreeItems"); // setting up Free Items in Item Teleporter

			patcher.Prefix(typeof(ScrollingMenu), "PushedButton"); // toggling and purchasing Challenges, Item and Trait Unlocks

			patcher.Postfix(typeof(ScrollingMenu), "ShowDetails"); // displaying details

			patcher.Postfix(typeof(CharacterCreation), "SortUnlocks"); // sorting/filtering Abilities, Items and Traits in CC
			patcher.Postfix(typeof(CharacterCreation), "OpenCharacterCreation", new Type[] { typeof(bool) }); // enable nugget slot for purchases

			patcher.Prefix(typeof(CharacterCreation), "SetupAbilities"); // setting up Abilities in CC
			patcher.Prefix(typeof(CharacterCreation), "SetupItems"); // setting up Items in CC
			patcher.Prefix(typeof(CharacterCreation), "SetupTraits"); // setting up Traits in CC

			patcher.Prefix(typeof(CharacterCreation), "DoCancellations"); // more thorough cancellation
			patcher.Prefix(typeof(CharacterCreation), "PushedButton"); // toggling and purchasing Abilities, Items and Traits in CC

			patcher.Postfix(typeof(CharacterCreation), "ShowDetails"); // displaying details

			patcher.Postfix(typeof(Unlocks), "DoUnlock"); // CustomUnlock's OnUnlocked event

			Awake3();
		}

		internal void EnsureOne(List<Unlock> list, Unlock unlock, bool add)
		{
			list.RemoveAll(u => u.unlockName == unlock.unlockName);
			if (add) list.Add(unlock);
		}
		internal void EnsureOne(List<string> list, string text, bool add)
		{
			list.RemoveAll(t => t == text);
			if (add) list.Add(text);
		}
		internal void Setup(CustomUnlock customUnlock)
		{
			SessionDataBig big = GameController.gameController?.sessionDataBig;
			if (big == null)
			{
				MyLogger.LogDebug(customUnlock.Id + " - too early! Wait for initial.");
				return;
			}
			GameResources gr = GameController.gameController?.gameResources;

			Unlock newUnlock = big.unlocks.Find(u => u.unlockName == customUnlock.Id && u.unlockType == customUnlock.Type);

			customUnlock.unlock = null;
			if (newUnlock == null)
			{
				newUnlock = new Unlock(customUnlock.Id, customUnlock.Type, customUnlock.Unlocked, customUnlock.UnlockCost ?? 0);
				newUnlock = GameController.gameController.unlocks.AddUnlock(newUnlock);
				newUnlock.cancellations = customUnlock.Conflicting;
				newUnlock.unavailable = !customUnlock.Available;
				newUnlock.prerequisites = customUnlock.Prerequisites;
				newUnlock.recommendations = customUnlock.Recommendations;
				newUnlock.categories = customUnlock.Categories;
				EnsureOne(big.unlocks, newUnlock, true);
			}

			if (customUnlock is CustomMutator mutator)
			{
				EnsureOne(big.challengeUnlocks, newUnlock, mutator.Available);
				if (mutator.Available) Unlock.challengeCount++;

				EnsureOne(GameController.gameController.challenges, mutator.Id, mutator.IsActive);
				newUnlock.notActive = !mutator.IsActive;
			}
			else if (customUnlock is CustomItem item)
			{
				EnsureOne(big.itemUnlocks, newUnlock, item.Available);
				if (item.Available) Unlock.itemCount++;
				EnsureOne(big.itemUnlocksCharacterCreation, newUnlock, item.AvailableInCharacterCreation);
				if (item.AvailableInCharacterCreation) Unlock.itemCountCharacterCreation++;
				EnsureOne(big.freeItemUnlocks, newUnlock, item.AvailableInItemTeleporter);
				if (item.AvailableInItemTeleporter) Unlock.itemCountFree++;

				newUnlock.notActive = !item.IsActive;
				newUnlock.onlyInCharacterCreation = !item.Available && item.AvailableInCharacterCreation;
				newUnlock.freeItem = item.AvailableInItemTeleporter;

				newUnlock.cost2 = item.CostInLoadout;
				newUnlock.cost3 = item.CostInCharacterCreation;
			}
			else if (customUnlock is CustomAbility ability)
			{
				EnsureOne(big.abilityUnlocks, newUnlock, ability.Available);
				if (ability.Available) Unlock.abilityCount++;

				newUnlock.cost3 = ability.CostInCharacterCreation;
			}
			else if (customUnlock is CustomTrait trait)
			{
				EnsureOne(big.traitUnlocks, newUnlock, trait.Available);
				if (trait.Available) Unlock.traitCount++;
				EnsureOne(big.traitUnlocksCharacterCreation, newUnlock, trait.AvailableInCharacterCreation);
				if (trait.AvailableInCharacterCreation) Unlock.traitCountCharacterCreation++;

				newUnlock.notActive = !trait.IsActive;
				newUnlock.onlyInCharacterCreation = !trait.Available && trait.AvailableInCharacterCreation;
				newUnlock.upgrade = trait.Upgrade;
				newUnlock.cantLose = !trait.CanRemove;
				newUnlock.cantSwap = !trait.CanSwap;
				newUnlock.specialAbilities = trait.SpecialAbilities;

				newUnlock.cost3 = trait.CostInCharacterCreation;

				CustomTrait.UpgradeCheck(trait.Id);
				CustomTrait.UpgradeCheck(trait.Upgrade);
			}

			if (customUnlock.Sprite != null)
			{
				gr.itemDic[customUnlock.Id] = customUnlock.Sprite;

				if (!gr.itemList.Contains(customUnlock.Sprite))
					gr.itemList.Add(customUnlock.Sprite);
			}
			MyLogger.LogDebug("Unlock " + customUnlock.Id + " set up!");
			customUnlock.unlock = newUnlock;
		}
		protected static void CheckPrerequisites(Unlock unlock)
		{
			if (unlock.unlocked) unlock.nowAvailable = true;
			if (unlock.prerequisites.Count == 0) return;
			foreach (string name in unlock.prerequisites)
				foreach (Unlock u in GameController.gameController.sessionDataBig.unlocks)
					if (!u.unlocked && u.unlockName == name)
					{ unlock.nowAvailable = false; return; }
			unlock.nowAvailable = true;
		}

		protected static bool loadedInitialUnlocks = false;
		protected static void Unlocks_LoadInitialUnlocks()
		{
			if (loadedInitialUnlocks) return;
			loadedInitialUnlocks = true;

			foreach (CustomUnlock unlock in RogueLibs.EnumerateCustomUnlocks())
				RogueLibs.PluginInstance.Setup(unlock);

			GameController.gameController.SetDailyRunText();
			GameController.gameController.mainGUI?.scrollingMenuScript?.UpdateOtherVisibleMenus(GameController.gameController.mainGUI.scrollingMenuScript.menuType);
		}

		protected static void ScrollingMenu_SortUnlocks(ScrollingMenu __instance, string unlockType, List<Unlock> ___listUnlocks)
		{
			IEnumerable list; int offset = 0;

			if (unlockType == "Challenge") { RogueLibs.CustomMutators.Sort(); list = RogueLibs.CustomMutators; offset = 1; }
			else if (__instance.menuType == "Items") { RogueLibs.CustomItems.Sort(); list = RogueLibs.CustomItems; }
			else if (__instance.menuType == "TraitUnlocks") { RogueLibs.CustomTraits.Sort(); list = RogueLibs.CustomTraits; }
			else return;

			List<Unlock> addToBeginning = new List<Unlock>(); List<Unlock> addToEnd = new List<Unlock>();

			foreach (CustomUnlock customUnlock in list)
			{ // enumerate through sorted CustomUnlocks and put them in the lists (in sorted order)
				if (customUnlock.SortingOrder == 0) continue;

				int index = ___listUnlocks.FindIndex(u => u.unlockName == customUnlock.Id);
				if (index == -1) continue;
				if (customUnlock.SortingOrder < 0) addToBeginning.Add(___listUnlocks[index]);
				else addToEnd.Add(___listUnlocks[index]);
				___listUnlocks.RemoveAt(index);
			}
			___listUnlocks.InsertRange(offset, addToBeginning);
			___listUnlocks.AddRange(addToEnd);
		}

		protected static bool ScrollingMenu_SetupChallenges(ScrollingMenu __instance, ButtonData myButtonData, Unlock myUnlock)
		{
			CustomMutator custom = RogueLibs.GetCustomMutator(myUnlock.unlockName);
			return ScrollingMenu_Setup(__instance, myButtonData, myUnlock, custom);
		}
		protected static bool ScrollingMenu_SetupItemUnlocks(ScrollingMenu __instance, ButtonData myButtonData, Unlock myUnlock)
		{
			CustomItem custom = RogueLibs.GetCustomItem(myUnlock.unlockName);
			return ScrollingMenu_Setup(__instance, myButtonData, myUnlock, custom);
		}
		protected static bool ScrollingMenu_SetupTraitUnlocks(ScrollingMenu __instance, ButtonData myButtonData, Unlock myUnlock)
		{
			CustomTrait custom = RogueLibs.GetCustomTrait(myUnlock.unlockName);
			return ScrollingMenu_Setup(__instance, myButtonData, myUnlock, custom);
		}
		protected static bool ScrollingMenu_SetupFreeItems(ScrollingMenu __instance, ButtonData myButtonData, Unlock myUnlock)
		{
			CustomItem custom = RogueLibs.GetCustomItem(myUnlock.unlockName);
			return ScrollingMenu_Setup(__instance, myButtonData, myUnlock, custom);
		}
		protected static bool ScrollingMenu_Setup(ScrollingMenu __instance, ButtonData myButtonData, Unlock myUnlock, CustomUnlock custom)
		{
			CheckPrerequisites(myUnlock);

			myButtonData.scrollingButtonType = myUnlock.unlockName;
			myButtonData.interactable = true;
			myButtonData.scrollingButtonUnlock = myUnlock;

			myButtonData.buttonText = myUnlock.unlockType == "Challenge"
				? __instance.gc.unlocks.GetChallengeName(myUnlock.unlockName)
				: __instance.gc.nameDB.GetName(myUnlock.unlockName, myUnlock.unlockNameType);

			if (!myUnlock.nowAvailable)
			{ // not all prerequisites are unlocked
				myButtonData.scrollingHighlighted2 = false;
				myButtonData.scrollingHighlighted3 = true; // red 'unavailable' highlight
				myButtonData.scrollingHighlighted4 = false;
				myButtonData.highlightedSprite = __instance.solidObjectButtonRed;

				myButtonData.buttonText = "?????";
			}
			else if (myUnlock.unlocked)
			{ // is unlocked
				myButtonData.scrollingHighlighted2 = false;
				myButtonData.scrollingHighlighted3 = false;
				myButtonData.scrollingHighlighted4 = (__instance.menuType == "Items" || __instance.menuType == "TraitUnlocks") && myUnlock.notActive; // gray 'not active' highlight
				myButtonData.highlightedSprite = __instance.solidObjectButton;
			}
			else if ((custom == null && myUnlock.cost != 0) || custom?.UnlockCost != null)
			{ // not unlocked, original mutator OR custom and can be purchased
				myButtonData.buttonText += " - $" + myUnlock.cost;
				myButtonData.scrollingHighlighted2 = true; // blue 'purchasable' highlight
				myButtonData.scrollingHighlighted3 = false;
				myButtonData.scrollingHighlighted4 = false;
				myButtonData.highlightedSprite = __instance.solidObjectButtonLocked;
			}
			else
			{ // not unlocked, can't be bought
				myButtonData.scrollingHighlighted2 = false;
				myButtonData.scrollingHighlighted3 = true; // red 'unavailable' highlight
				myButtonData.scrollingHighlighted4 = false;
				myButtonData.highlightedSprite = __instance.solidObjectButtonRed;

				myButtonData.buttonText = "?????";
			}
			if (myUnlock.unlockType == "Challenge")
				myButtonData.scrollingHighlighted = __instance.gc.challenges.Contains(myUnlock.unlockName);
			return false;
		}

		protected static bool ScrollingMenu_PushedButton(ScrollingMenu __instance, ButtonHelper myButton, List<Unlock> ___listUnlocks)
		{
			Unlock u = myButton.scrollingButtonUnlock;
			ButtonData data = __instance.buttonsData[myButton.scrollingButtonNum];

			if (__instance.menuType == "Challenges")
			{
				#region Challenges / Mutator Menu
				CustomMutator custom = RogueLibs.GetCustomMutator(u.unlockName);

				bool doDefaultHandling = custom?.ScrollingMenu_PushedButton?.Invoke(__instance, myButton) ?? true;
				if (doDefaultHandling)
					if (!__instance.gc.serverPlayer) { __instance.gc.audioHandler.Play(__instance.agent, "CantDo"); return false; }
					else if (u.unlocked)
					{ // if unlocked, then handle ClearAll OR toggle on/off
						if (myButton.scrollingButtonType == "ClearAll")
						{ // handling ClearAll button
							__instance.gc.challenges.Clear();
							__instance.gc.originalChallenges.Clear();
							foreach (ButtonData buttonData in __instance.buttonsData)
								if (buttonData.scrollingHighlighted)
								{
									buttonData.scrollingHighlighted = false;
									buttonData.highlightedSprite = __instance.solidObjectButton;
									if (buttonData.scrollingButtonUnlock.unlockName == "SuperSpecialCharacters")
										__instance.gc.mainGUI.characterSelectScript.RefreshSuperSpecials();
									CustomMutator dsb = RogueLibs.GetCustomMutator(buttonData.scrollingButtonUnlock.unlockName);
									dsb?.InvokeOnChangedState(false);
								}
							if (__instance.gc.multiplayerMode)
								__instance.agent.objectMult.SendChatAnnouncement("ClearedAllChallenges", string.Empty, string.Empty);
						}
						else if (myButton.scrollingButtonType != "CreateAMutator")
						{ // toggle on/off
							myButton.scrollingHighlighted = data.scrollingHighlighted = !myButton.scrollingHighlighted;
							SpriteState spriteState = default;
							spriteState.highlightedSprite = myButton.scrollingHighlighted ? myButton.solidObjectButtonSelected : myButton.solidObjectButton;
							myButton.button.spriteState = spriteState;
							data.highlightedSprite = myButton.scrollingHighlighted ? __instance.solidObjectButtonSelected : __instance.solidObjectButton;

							if (myButton.scrollingHighlighted)
							{ // was toggled on
								foreach (ButtonData buttonData in __instance.buttonsData) // handle cancellations
									if (__instance.gc.challenges.Contains(buttonData.scrollingButtonType) && (u.cancellations.Contains(buttonData.scrollingButtonType) || buttonData.scrollingButtonUnlock.cancellations.Contains(u.unlockName)))
									{
										buttonData.scrollingHighlighted = false;
										buttonData.highlightedSprite = __instance.solidObjectButton;
										__instance.gc.challenges.Remove(buttonData.scrollingButtonType);
										__instance.gc.originalChallenges.Remove(buttonData.scrollingButtonType);
										if (buttonData.scrollingButtonUnlock.unlockName == "SuperSpecialCharacters")
											__instance.gc.mainGUI.characterSelectScript.RefreshSuperSpecials();
										CustomMutator dsb2 = RogueLibs.GetCustomMutator(buttonData.scrollingButtonUnlock.unlockName);
										dsb2?.InvokeOnChangedState(false);
									}

								__instance.gc.challenges.Add(myButton.scrollingButtonType);
								__instance.gc.originalChallenges.Add(myButton.scrollingButtonType);
								CustomMutator dsb = RogueLibs.GetCustomMutator(myButton.scrollingButtonType);
								dsb?.InvokeOnChangedState(true);
							}
							else
							{ // was toggled off
								__instance.gc.challenges.Remove(myButton.scrollingButtonType);
								__instance.gc.originalChallenges.Remove(myButton.scrollingButtonType);
								CustomMutator dsb = RogueLibs.GetCustomMutator(myButton.scrollingButtonType);
								dsb?.InvokeOnChangedState(false);
							}
							custom?.InvokeOnToggledEvent(__instance, myButton, myButton.scrollingHighlighted);

							if (myButton.scrollingButtonType == "SuperSpecialCharacters")
								__instance.gc.mainGUI.characterSelectScript.RefreshSuperSpecials();
							if (__instance.gc.multiplayerMode)
								__instance.agent.objectMult.SendChatAnnouncement((myButton.scrollingHighlighted ? "Added" : "Removed") + "Challenge", myButton.scrollingButtonType, string.Empty);
						}
						__instance.gc.audioHandler.Play(__instance.gc.playerAgent, "ClickButton");
						__instance.gc.sessionDataBig.challenges = __instance.gc.challenges;
						__instance.gc.sessionDataBig.originalChallenges = __instance.gc.originalChallenges;
						__instance.gc.SetDailyRunText();
						__instance.UpdateOtherVisibleMenus(__instance.menuType);
					}
					else if (u.nowAvailable && ((custom == null && u.cost != 0) || custom?.UnlockCost != null) && u.cost <= __instance.gc.sessionDataBig.nuggets)
					{ // not unlocked, is a custom mutator, can be purchased and affordable
						__instance.gc.unlocks.SubtractNuggets(u.cost);
						__instance.gc.unlocks.DoUnlock(u.unlockName, u.unlockType);
						__instance.gc.audioHandler.Play(__instance.agent, "BuyUnlock");

						custom?.InvokeOnUnlockedEvent(__instance, myButton);

						for (int i = 0; i < __instance.numButtons; i++)
							__instance.SetupChallenges(__instance.buttonsData[i], ___listUnlocks[i]);

						__instance.gc.SetDailyRunText();
						__instance.UpdateOtherVisibleMenus(__instance.menuType);
					}
					else // can't purchase
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
				#endregion
			}
			else if (__instance.menuType == "Items")
			{
				#region Item Unlocks / Rewards Menu
				CustomItem custom = RogueLibs.GetCustomItem(u.unlockName);

				bool doDefaultHandling = custom?.ScrollingMenu_PushedButton?.Invoke(__instance, myButton) ?? true;
				if (doDefaultHandling)
					if (u.unlocked)
					{ // if unlocked, then check reward count OR toggle on/off
						if (!u.notActive && __instance.activeRewardCount <= __instance.minRewards)
						{ // check reward count
							__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
							__instance.ActiveCountFlash();
						}
						else
						{ // toggle on/off
							u.notActive = !u.notActive;
							myButton.scrollingHighlighted4 = data.scrollingHighlighted4 = u.notActive;

							custom?.InvokeOnToggledEvent(__instance, myButton, !u.notActive);

							__instance.gc.audioHandler.Play(__instance.gc.playerAgent, "ClickButton");

							__instance.UpdateOtherVisibleMenus(__instance.menuType);
							__instance.UpdateActiveCount();
							__instance.gc.unlocks.SaveUnlockData(true);
						}
					}
					else if (u.nowAvailable && ((custom == null && u.cost != 0) || custom?.UnlockCost != null) && u.cost <= __instance.gc.sessionDataBig.nuggets)
					{ // not unlocked, can be purchased and affordable
						__instance.gc.unlocks.SubtractNuggets(u.cost);
						__instance.gc.unlocks.DoUnlock(u.unlockName, u.unlockType);
						__instance.gc.audioHandler.Play(__instance.agent, "BuyUnlock");

						custom?.InvokeOnUnlockedEvent(__instance, myButton);

						for (int i = 0; i < __instance.numButtons; i++)
							__instance.SetupItemUnlocks(__instance.buttonsData[i], ___listUnlocks[i]);

						__instance.UpdateActiveCount();
						__instance.UpdateOtherVisibleMenus(__instance.menuType);
					}
					else // can't purchase
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
				#endregion
			}
			else if (__instance.menuType == "TraitUnlocks")
			{
				#region Trait Unlocks
				CustomTrait custom = RogueLibs.GetCustomTrait(u.unlockName);

				bool doDefaultHandling = custom?.ScrollingMenu_PushedButton?.Invoke(__instance, myButton) ?? true;
				if (doDefaultHandling)
					if (u.unlocked)
					{ // if unlocked, then check trait count OR toggle on/off
						if (!u.notActive && __instance.activeTraitCount <= __instance.minTraits)
						{ // check trait count
							__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
							__instance.ActiveCountFlash();
						}
						else
						{ // toggle on/off
							u.notActive = !u.notActive;
							myButton.scrollingHighlighted4 = data.scrollingHighlighted4 = u.notActive;

							custom?.InvokeOnToggledEvent(__instance, myButton, !u.notActive);

							__instance.gc.audioHandler.Play(__instance.gc.playerAgent, "ClickButton");

							__instance.UpdateOtherVisibleMenus(__instance.menuType);
							__instance.UpdateActiveCount();
							__instance.gc.unlocks.SaveUnlockData(true);
						}
					}
					else if (u.nowAvailable && ((custom == null && u.cost != 0) || custom?.UnlockCost != null) && u.cost <= __instance.gc.sessionDataBig.nuggets)
					{ // not unlocked, can be purchased and affordable
						__instance.gc.unlocks.SubtractNuggets(u.cost);
						__instance.gc.unlocks.DoUnlock(u.unlockName, u.unlockType);
						__instance.gc.audioHandler.Play(__instance.agent, "BuyUnlock");

						custom?.InvokeOnUnlockedEvent(__instance, myButton);

						for (int i = 0; i < __instance.numButtons; i++)
							__instance.SetupTraitUnlocks(__instance.buttonsData[i], ___listUnlocks[i]);

						__instance.UpdateActiveCount();
						__instance.UpdateOtherVisibleMenus(__instance.menuType);
					}
					else // can't purchase
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
				#endregion
			}
			else if (__instance.menuType == "FreeItems")
			{
				#region Free Items / Item Teleporter
				CustomItem custom = RogueLibs.GetCustomItem(u.unlockName);

				bool doDefaultHandling = custom?.ScrollingMenu_PushedButton?.Invoke(__instance, myButton) ?? true;
				if (doDefaultHandling)
					if (u.unlocked)
					{ // if unlocked, then give the item to the player
						InvItem invItem = new InvItem { invItemName = u.unlockName };
						invItem.SetupDetails(false);
						invItem.invItemCount = invItem.initCount;
						__instance.gc.audioHandler.Play(__instance.agent, "UseItemTeleporter");
						__instance.agent.inventory.DontPlayPickupSounds(true);
						__instance.agent.agentInvDatabase.AddItemOrDrop(invItem);
						if (invItem.invItemName == "BombMaker" && !__instance.agent.agentInvDatabase.HasItem("BombTrigger"))
						{
							invItem = new InvItem { invItemName = "BombTrigger" };
							invItem.SetupDetails(false);
							invItem.invItemCount = invItem.initCount;
							__instance.agent.agentInvDatabase.AddItemOrDrop(invItem);
						}
						__instance.agent.inventory.DontPlayPickupSounds(false);
					}
					else if (u.nowAvailable && ((custom == null && u.cost != 0) || custom?.UnlockCost != null) && u.cost <= __instance.gc.sessionDataBig.nuggets)
					{ // not unlocked, can be purchased and affordable
						__instance.gc.unlocks.SubtractNuggets(u.cost);
						__instance.gc.unlocks.DoUnlock(u.unlockName, u.unlockType);
						__instance.gc.audioHandler.Play(__instance.agent, "BuyUnlock");

						custom?.InvokeOnUnlockedEvent(__instance, myButton);

						for (int i = 0; i < __instance.numButtons; i++)
							__instance.SetupFreeItems(__instance.buttonsData[i], ___listUnlocks[i]);

						__instance.UpdateOtherVisibleMenus(__instance.menuType);
					}
					else // can't purchase
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
				#endregion
			}
			else
				return true;

			try { __instance.scrollerController.myScroller.RefreshActiveCellViews(); } catch { }
			return false;
		}

		protected static void ScrollingMenu_ShowDetails(ScrollingMenu __instance, ButtonHelper myButton)
		{
			if (__instance.menuType != "Items" && __instance.menuType != "TraitUnlocks" && __instance.menuType != "Challenges") return;
			Unlock u = myButton.scrollingButtonUnlock;
			CustomUnlock custom = RogueLibs.GetCustomUnlock(u.unlockName, u.unlockType);
			CheckPrerequisites(u);

			if (u.unlocked || u.nowAvailable)
			{ // unlocked or available
				if (custom?.Sprite != null)
				{
					__instance.detailsImage.gameObject.SetActive(true);
					__instance.detailsImage.sprite = custom.Sprite;
				}
			}
			else if (u.prerequisites.Count > 0)
			{ // has prerequisites and at least one prerequisite is locked
				__instance.detailsImage.gameObject.SetActive(false);

				__instance.detailsTitle.text = "?????";
				__instance.detailsText.text = "<color=cyan>" + __instance.gc.nameDB.GetName("Prerequisites", "Unlock") + "</color>\n";

				string special = custom?.GetSpecialUnlockInfo?.Invoke(u) ?? __instance.gc.unlocks.GetSpecialUnlockInfo(u.unlockName, u);
				if (special != string.Empty)
					__instance.detailsText.text += special + "\n";

				foreach (string pre in u.prerequisites)
					foreach (Unlock unl in __instance.gc.sessionDataBig.unlocks)
						if (unl.unlockName == pre)
						{
							if (!unl.unlocked)
								__instance.detailsText.text += (unl.nowAvailable ? __instance.gc.nameDB.GetName(unl.unlockName, unl.unlockNameType) : "?????") + "\n";
							break;
						}
			}
		}

		protected static void CharacterCreation_SortUnlocks(CharacterCreation __instance, string unlockType)
		{
			IEnumerable customUnlocks; List<Unlock> listUnlocks;
			int offset = 0; bool abilityCheck = false;

			if (unlockType == "Item") { RogueLibs.CustomItems.Sort(); customUnlocks = RogueLibs.CustomItems; listUnlocks = __instance.listUnlocksItems; offset = 1; }
			else if (unlockType == "Ability") { RogueLibs.CustomItems.Sort(); customUnlocks = RogueLibs.CustomAbilities; listUnlocks = __instance.listUnlocksAbilities; abilityCheck = true; }
			else if (unlockType == "Trait") { RogueLibs.CustomTraits.Sort(); customUnlocks = RogueLibs.CustomTraits; listUnlocks = __instance.listUnlocksTraits; offset = 1; }
			else return;

			List<Unlock> addToBeginning = new List<Unlock>(); List<Unlock> addToEnd = new List<Unlock>();

			foreach (CustomUnlock customUnlock in customUnlocks)
			{ // enumerate through sorted CustomUnlocks and put them in the lists (in sorted order)
				int index = listUnlocks.FindIndex(u => u.unlockName == customUnlock.Id);

				if (index == -1) continue;
				if (abilityCheck && !((CustomAbility)customUnlock).AvailableInCharacterCreation)
				{ // non-regular implementation for abilities not available in character creation
					listUnlocks.RemoveAt(index);
					__instance.numButtonsAbilities--;
					continue;
				}
				if (customUnlock.SortingOrder == 0) continue;
				if (customUnlock.SortingOrder < 0) addToBeginning.Add(listUnlocks[index]);
				else addToEnd.Add(listUnlocks[index]);
				listUnlocks.RemoveAt(index);
			}
			listUnlocks.InsertRange(offset, addToBeginning);
			listUnlocks.AddRange(addToEnd);
		}
		protected static void CharacterCreation_OpenCharacterCreation(CharacterCreation __instance)
		{
			__instance.nuggetSlot.gameObject.SetActive(true);
			__instance.nuggetSlot.gameObject.transform.localPosition += new Vector3(60, 120);
		}

		protected static bool CharacterCreation_SetupAbilities(CharacterCreation __instance, ButtonData myButtonData, Unlock myUnlock)
		{
			CustomItem custom = RogueLibs.GetCustomItem(myUnlock.unlockName);
			return CharacterCreation_Setup(__instance, myButtonData, myUnlock, custom);
		}
		protected static bool CharacterCreation_SetupItems(CharacterCreation __instance, ButtonData myButtonData, Unlock myUnlock)
		{
			CustomItem custom = RogueLibs.GetCustomItem(myUnlock.unlockName);
			return CharacterCreation_Setup(__instance, myButtonData, myUnlock, custom);
		}
		protected static bool CharacterCreation_SetupTraits(CharacterCreation __instance, ButtonData myButtonData, Unlock myUnlock)
		{
			CustomItem custom = RogueLibs.GetCustomItem(myUnlock.unlockName);
			return CharacterCreation_Setup(__instance, myButtonData, myUnlock, custom);
		}
		protected static bool CharacterCreation_Setup(CharacterCreation __instance, ButtonData myButtonData, Unlock myUnlock, CustomUnlock custom)
		{
			CheckPrerequisites(myUnlock);

			myButtonData.scrollingButtonType = myUnlock.unlockName;
			myButtonData.interactable = true;
			myButtonData.scrollingButtonUnlock = myUnlock;

			if (!myUnlock.nowAvailable) // not all prerequisites are unlocked
			{
				myButtonData.buttonText = __instance.gc.nameDB.GetName(myUnlock.unlockName, myUnlock.unlockNameType);
				myButtonData.scrollingHighlighted2 = false;
				myButtonData.scrollingHighlighted3 = true; // red 'unavailable' highlight
				myButtonData.scrollingHighlighted4 = false;
				myButtonData.highlightedSprite = __instance.solidObjectButtonRed;

				myButtonData.buttonText = "?????";
			}
			else if (myUnlock.unlocked) // is unlocked
			{
				if (myUnlock.unlockName == "ClearAllItems" || myUnlock.unlockName == "ClearAllTraits")
					myButtonData.buttonText = __instance.gc.nameDB.GetName(myUnlock.unlockName, myUnlock.unlockNameType);
				else if (myUnlock.unlockType == "Item")
				{
					InvItem invItem = new InvItem { invItemName = myUnlock.unlockName };
					invItem.SetupDetails(false);
					bool displayAmount = invItem.rewardCount != 1 && !invItem.isArmor && !invItem.isArmorHead && invItem.itemType != "WeaponMelee";

					myButtonData.buttonText = string.Concat(
						__instance.gc.nameDB.GetName(myUnlock.unlockName, myUnlock.unlockNameType),
						displayAmount ? string.Concat(" (", invItem.rewardCount.ToString(), ")") : string.Empty,
						" | <color=orange>", myUnlock.cost3.ToString(), "</color>");
				}
				else if (myUnlock.unlockType == "Trait")
				{
					myButtonData.buttonText = string.Concat(
						__instance.gc.nameDB.GetName(myUnlock.unlockName, myUnlock.unlockNameType),
						" | <color=", myUnlock.cost3 < 0 ? "lime" : "orange", ">",
						myUnlock.cost3.ToString(), "</color>");
				}
				else if (myUnlock.unlockType == "Ability")
				{
					myButtonData.buttonText = string.Concat(
						__instance.gc.nameDB.GetName(myUnlock.unlockName, myUnlock.unlockNameType),
						" | <color=orange>", myUnlock.cost3, "</color>");
				}
				myButtonData.scrollingHighlighted2 = false;
				myButtonData.scrollingHighlighted3 = false;
				myButtonData.scrollingHighlighted4 = false;
				myButtonData.highlightedSprite = __instance.solidObjectButton;
			}
			else if ((custom == null && myUnlock.cost != 0) || custom?.UnlockCost != null) // not unlocked, original mutator OR custom and can be purchased
			{
				myButtonData.buttonText = __instance.gc.nameDB.GetName(myUnlock.unlockName, myUnlock.unlockNameType) + " - $" + myUnlock.cost;
				myButtonData.scrollingHighlighted2 = true; // blue 'purchasable' highlight
				myButtonData.scrollingHighlighted3 = false;
				myButtonData.scrollingHighlighted4 = false;
				myButtonData.highlightedSprite = __instance.solidObjectButtonLocked;
			}
			else // not unlocked, can't be bought
			{
				myButtonData.buttonText = __instance.gc.nameDB.GetName(myUnlock.unlockName, myUnlock.unlockNameType);
				myButtonData.scrollingHighlighted2 = false;
				myButtonData.scrollingHighlighted3 = true; // red 'unavailable' highlight
				myButtonData.scrollingHighlighted4 = false;
				myButtonData.highlightedSprite = __instance.solidObjectButtonRed;

				myButtonData.buttonText = "?????";
			}

			if (myUnlock.unlockType == "Item")
				myButtonData.scrollingHighlighted = __instance.itemsChosen.Contains(myUnlock);
			else if (myUnlock.unlockType == "Trait")
				myButtonData.scrollingHighlighted = __instance.traitsChosen.Contains(myUnlock);
			else if (myUnlock.unlockType == "Ability")
				myButtonData.scrollingHighlighted = __instance.abilityChosen == myUnlock.unlockName;

			return false;
		}

		protected static bool CharacterCreation_DoCancellations(CharacterCreation __instance, ButtonHelper myButton)
		{
			Unlock u = myButton.scrollingButtonUnlock;
			MyLogger.LogWarning("Doing cancellations for \"" + u.unlockName + "\", " + u.cancellations.Count + " items.");
			foreach (ButtonData buttonData in __instance.buttonsDataTraits) // handle cancellations
				if (__instance.traitsChosen.Contains(buttonData.scrollingButtonUnlock) && (u.cancellations.Contains(buttonData.scrollingButtonType) || buttonData.scrollingButtonUnlock.cancellations.Contains(u.unlockName)))
				{
					buttonData.scrollingHighlighted = false;
					buttonData.highlightedSprite = __instance.solidObjectButton;
					__instance.traitsChosen.Remove(buttonData.scrollingButtonUnlock);
					MyLogger.LogWarning("Removed \"" + buttonData.scrollingButtonType + "\" (" + buttonData.scrollingButtonUnlock.unlockName + ")");
				}
			foreach (ButtonData buttonData in __instance.buttonsDataItems) // handle cancellations
				if (__instance.itemsChosen.Contains(buttonData.scrollingButtonUnlock) && (u.cancellations.Contains(buttonData.scrollingButtonType) || buttonData.scrollingButtonUnlock.cancellations.Contains(u.unlockName)))
				{
					buttonData.scrollingHighlighted = false;
					buttonData.highlightedSprite = __instance.solidObjectButton;
					__instance.itemsChosen.Remove(buttonData.scrollingButtonUnlock);
				}
			foreach (ButtonData buttonData in __instance.buttonsDataAbilities) // handle cancellations
				if (__instance.abilityChosen == buttonData.scrollingButtonType && (u.cancellations.Contains(buttonData.scrollingButtonType) || buttonData.scrollingButtonUnlock.cancellations.Contains(u.unlockName)))
				{
					buttonData.scrollingHighlighted = false;
					buttonData.highlightedSprite = __instance.solidObjectButton;
					__instance.abilityChosen = string.Empty;
				}
			foreach (ButtonData buttonData in __instance.buttonsDataBigQuests) // handle cancellations
				if (__instance.bigQuestChosen == buttonData.scrollingButtonType && (u.cancellations.Contains(buttonData.scrollingButtonType) || buttonData.scrollingButtonUnlock.cancellations.Contains(u.unlockName)))
				{
					buttonData.scrollingHighlighted = false;
					buttonData.highlightedSprite = __instance.solidObjectButton;
					__instance.bigQuestChosen = string.Empty;
				}
			return false;
		}
		protected static bool CharacterCreation_PushedButton(CharacterCreation __instance, ButtonHelper myButton)
		{
			if (__instance.selectedSpace == "Load") return true;

			Unlock u = myButton.scrollingButtonUnlock;

			if (u.unlockType == "Item")
			{
				#region Items Screen
				ButtonData buttonData = __instance.buttonsDataItems[myButton.scrollingButtonNum];
				CustomItem custom = RogueLibs.GetCustomItem(u.unlockName);

				bool doDefaultHandling = custom?.CharacterCreation_PushedButton?.Invoke(__instance, myButton) ?? true;
				if (doDefaultHandling)
					if (u.unlocked)
					{ // if unlocked, then handle ClearAll OR toggle on/off
						if (myButton.scrollingButtonType == "ClearAllItems")
						{ // handling ClearAllItems button
							foreach (ButtonData buttonData2 in __instance.buttonsDataItems)
								if (buttonData2.scrollingHighlighted)
								{
									buttonData2.scrollingHighlighted = false;
									buttonData2.highlightedSprite = __instance.solidObjectButton;
								}
							__instance.itemsChosen.Clear();
							__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "ClickButtonMenu");
						}
						else
						{ // toggle on/off
							myButton.scrollingHighlighted = buttonData.scrollingHighlighted = !myButton.scrollingHighlighted;
							SpriteState spriteState = default;
							spriteState.highlightedSprite = myButton.scrollingHighlighted ? myButton.solidObjectButtonSelected : myButton.solidObjectButton;
							myButton.button.spriteState = spriteState;
							buttonData.highlightedSprite = myButton.scrollingHighlighted ? __instance.solidObjectButtonSelected : __instance.solidObjectButton;

							if (myButton.scrollingHighlighted)
							{
								__instance.itemsChosen.Add(u);
								__instance.DoCancellations(myButton);
							}
							else __instance.itemsChosen.Remove(u);

							custom?.InvokeOnToggledEvent(__instance, myButton, myButton.scrollingHighlighted);

							__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "ClickButtonMenu");
						}
					}
					else if (u.nowAvailable && ((custom == null && u.cost != 0) || custom?.UnlockCost != null) && u.cost <= __instance.gc.sessionDataBig.nuggets)
					{ // not unlocked, can be purchased and affordable
						__instance.gc.unlocks.SubtractNuggets(u.cost);
						__instance.gc.unlocks.DoUnlock(u.unlockName, u.unlockType);
						__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "BuyUnlock");

						custom?.InvokeOnUnlockedEvent(__instance, myButton);

						for (int i = 0; i < __instance.numButtonsItems; i++)
							__instance.SetupItems(__instance.buttonsDataItems[i], __instance.listUnlocksItems[i]);
					}
					else // can't purchase
						__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "CantDo");
				__instance.scrollerControllerItems.myScroller.RefreshActiveCellViews();
				#endregion
			}
			else if (u.unlockType == "Ability")
			{
				#region Special Ability Screen
				ButtonData data = __instance.buttonsDataAbilities[myButton.scrollingButtonNum];
				CustomAbility custom = RogueLibs.GetCustomAbility(u.unlockName);

				bool doDefaultHandling = custom?.CharacterCreation_PushedButton?.Invoke(__instance, myButton) ?? true;
				if (doDefaultHandling)
					if (u.unlocked)
					{ // if unlocked, then toggle on/off
						if (!myButton.scrollingHighlighted) // if was off, but now on, disable all other
							foreach (ButtonData buttonData in __instance.buttonsDataAbilities)
								if (buttonData.scrollingHighlighted)
								{
									buttonData.scrollingHighlighted = false;
									buttonData.highlightedSprite = __instance.solidObjectButton;
								}

						myButton.scrollingHighlighted = data.scrollingHighlighted = !myButton.scrollingHighlighted;
						SpriteState spriteState = default;
						spriteState.highlightedSprite = myButton.scrollingHighlighted ? myButton.solidObjectButtonSelected : myButton.solidObjectButton;
						myButton.button.spriteState = spriteState;
						data.highlightedSprite = myButton.scrollingHighlighted ? __instance.solidObjectButtonSelected : __instance.solidObjectButton;

						if (myButton.scrollingHighlighted)
						{
							__instance.abilityChosen = u.unlockName;
							__instance.DoCancellations(myButton);
						}
						else
						{
							__instance.abilityChosen = string.Empty;
							try { myButton.RefreshContent(data); } catch { }
						}
						custom?.InvokeOnToggledEvent(__instance, myButton, myButton.scrollingHighlighted);

						__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "ClickButtonMenu");
					}
					else if (u.nowAvailable && ((custom == null && u.cost != 0) || custom?.UnlockCost != null) && u.cost <= __instance.gc.sessionDataBig.nuggets)
					{ // not unlocked, can be purchased and affordable
						__instance.gc.unlocks.SubtractNuggets(u.cost);
						__instance.gc.unlocks.DoUnlock(u.unlockName, u.unlockType);
						__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "BuyUnlock");

						custom?.InvokeOnUnlockedEvent(__instance, myButton);

						for (int i = 0; i < __instance.numButtonsAbilities; i++)
							__instance.SetupAbilities(__instance.buttonsDataAbilities[i], __instance.listUnlocksAbilities[i]);
					}
					else // can't purchase
						__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "CantDo");
				__instance.scrollerControllerAbilities.myScroller.RefreshActiveCellViews();
				#endregion
			}
			else if (u.unlockType == "Trait")
			{
				#region Traits Screen
				ButtonData data = __instance.buttonsDataTraits[myButton.scrollingButtonNum];
				CustomTrait custom = RogueLibs.GetCustomTrait(u.unlockName);

				bool doDefaultHandling = custom?.CharacterCreation_PushedButton?.Invoke(__instance, myButton) ?? true;
				if (doDefaultHandling)
					if (u.unlocked)
					{ // if unlocked, then handle ClearAllTraits OR toggle on/off
						if (myButton.scrollingButtonType == "ClearAllTraits")
						{ // handling ClearAllTraits button
							foreach (ButtonData buttonData2 in __instance.buttonsDataTraits)
								if (buttonData2.scrollingHighlighted)
								{
									buttonData2.scrollingHighlighted = false;
									buttonData2.highlightedSprite = __instance.solidObjectButton;
								}
							__instance.traitsChosen.Clear();
							__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "ClickButtonMenu");
						}
						else
						{ // toggle on/off
							myButton.scrollingHighlighted = data.scrollingHighlighted = !myButton.scrollingHighlighted;
							SpriteState spriteState = default;
							spriteState.highlightedSprite = myButton.scrollingHighlighted ? myButton.solidObjectButtonSelected : myButton.solidObjectButton;
							myButton.button.spriteState = spriteState;
							data.highlightedSprite = myButton.scrollingHighlighted ? __instance.solidObjectButtonSelected : __instance.solidObjectButton;

							if (myButton.scrollingHighlighted)
							{
								__instance.traitsChosen.Add(u);
								__instance.DoCancellations(myButton);
							}
							else
								__instance.traitsChosen.Remove(u);

							custom?.InvokeOnToggledEvent(__instance, myButton, myButton.scrollingHighlighted);

							__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "ClickButtonMenu");
						}
					}
					else if (u.nowAvailable && ((custom == null && u.cost != 0) || custom?.UnlockCost != null) && u.cost <= __instance.gc.sessionDataBig.nuggets)
					{  // not unlocked, can be purchased and affordable
						__instance.gc.unlocks.SubtractNuggets(u.cost);
						__instance.gc.unlocks.DoUnlock(u.unlockName, u.unlockType);
						__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "BuyUnlock");

						custom?.InvokeOnUnlockedEvent(__instance, myButton);

						for (int i = 0; i < __instance.numButtonsTraits; i++)
							__instance.SetupTraits(__instance.buttonsDataTraits[i], __instance.listUnlocksTraits[i]);
					}
					else // can't purchase
						__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "CantDo");
				__instance.scrollerControllerTraits.myScroller.RefreshActiveCellViews();
				#endregion
			}
			else
				return true;

			__instance.CreatePointTallyText();
			return false;
		}

		protected static void CharacterCreation_ShowDetails(CharacterCreation __instance, ButtonHelper myButton)
		{
			Unlock u = myButton.scrollingButtonUnlock;
			if (u == null) return;
			CustomUnlock custom = RogueLibs.GetCustomUnlock(u.unlockName, u.unlockType);

			Image detailsImage = null; Text detailsTitle = null; Text detailsText = null;
			if (u.unlockType == "Item")
			{ detailsImage = __instance.detailsImageItems; detailsTitle = __instance.detailsTitleItems; detailsText = __instance.detailsTextItems; }
			else if (u.unlockType == "Ability")
			{ detailsImage = __instance.detailsImageAbilities; detailsTitle = __instance.detailsTitleAbilities; detailsText = __instance.detailsTextAbilities; }
			else if (u.unlockType == "Trait")
			{ detailsImage = __instance.detailsImageTraits; detailsTitle = __instance.detailsTitleTraits; detailsText = __instance.detailsTextTraits; }
			else if (u.unlockType == "BigQuest")
			{ detailsImage = __instance.detailsImageBigQuests; detailsTitle = __instance.detailsTitleBigQuests; detailsText = __instance.detailsTextBigQuests; }
			else return;

			if (u.unlocked || u.nowAvailable)
			{ // unlocked or available
				if (detailsImage != null && custom?.Sprite != null)
				{
					detailsImage.gameObject.SetActive(true);
					detailsImage.sprite = custom.Sprite;
				}

				detailsTitle.text = __instance.gc.nameDB.GetName(u.unlockName, u.unlockNameType);
				detailsText.text = __instance.gc.nameDB.GetName(u.unlockName, u.unlockDescriptionType);

				if (u.cancellations.Count > 0)
				{
					detailsText.text += "\n<color=orange>" + __instance.gc.nameDB.GetName("Cancels", "Interface") + ": </color>";
					for (int i = 0; i < u.cancellations.Count; i++)
						foreach (Unlock unl in __instance.gc.sessionDataBig.unlocks)
							if (unl.unlockName == u.cancellations[i])
							{
								if (i != 0) detailsText.text += ", ";
								detailsText.text += unl.unlocked || unl.nowAvailable ? __instance.gc.nameDB.GetName(unl.unlockName, unl.unlockNameType) : "?????";
								break;
							}
				}
				if (u.recommendations.Count > 0)
				{
					detailsText.text += "\n<color=cyan>" + __instance.gc.nameDB.GetName("Recommends", "Interface") + ": </color>";
					for (int i = 0; i < u.recommendations.Count; i++)
						foreach (Unlock unl in __instance.gc.sessionDataBig.unlocks)
							if (unl.unlockName == u.recommendations[i])
							{
								if (i != 0) detailsText.text += ", ";
								detailsText.text += unl.unlocked || unl.nowAvailable ? __instance.gc.nameDB.GetName(unl.unlockName, unl.unlockNameType) : "?????";
								break;
							}
				}

			}
			else
			{ // has prerequisites and at least one prerequisite is locked
				detailsImage.gameObject.SetActive(false);

				detailsTitle.text = "?????";
				detailsText.text = string.Empty;

				string special = custom?.GetSpecialUnlockInfo?.Invoke(u) ?? __instance.gc.unlocks.GetSpecialUnlockInfo(u.unlockName, u);
				if (u.prerequisites.Count > 0 || special != string.Empty)
				{
					detailsText.text = "<color=cyan>" + __instance.gc.nameDB.GetName("Prerequisites", "Unlock") + "</color>\n";

					if (special != string.Empty)
						detailsText.text += special + "\n";

					foreach (string pre in u.prerequisites)
						foreach (Unlock unl in __instance.gc.sessionDataBig.unlocks)
							if (unl.unlockName == pre)
							{
								if (!unl.unlocked)
									detailsText.text += (unl.nowAvailable ? __instance.gc.nameDB.GetName(unl.unlockName, unl.unlockNameType) : "?????") + "\n";
								break;
							}
				}

			}
		}

		protected static void Unlocks_DoUnlock(Unlocks __instance, string unlockName, string unlockType)
		{
			if (!__instance.CanDoUnlocks()) return;
			CustomUnlock custom = null;
			if (unlockType == "Challenge")
				custom = RogueLibs.GetCustomMutator(unlockName);
			else if (unlockType == "Item")
				custom = RogueLibs.GetCustomItem(unlockName);
			else if (unlockType == "Ability")
				custom = RogueLibs.GetCustomAbility(unlockName);
			else if (unlockType == "Trait")
				custom = RogueLibs.GetCustomTrait(unlockName);

			custom?.InvokeOnUnlockedEvent();
		}

		protected void Awake3()
		{
			RoguePatcher patcher = new RoguePatcher(this, GetType());
			patcher.Prefix(typeof(tk2dSpriteCollectionData), "GetSpriteIdByName", new Type[] { typeof(string), typeof(int) });

			Type type = Assembly.GetAssembly(typeof(ISpriteCollectionForceBuild)).GetType("tk2dRuntime.SpriteCollectionGenerator");
			createDef = AccessTools.Method(type, "CreateDefinitionForRegionInTexture");




		}
		protected static MethodInfo createDef;
		internal static void AddSpriteToCollection(tk2dSpriteCollectionData collection, Sprite sprite)
		{
			try
			{
				collection.materials = collection.materials.Where(m => m.mainTexture != sprite.texture).ToArray();
				collection.textures = collection.textures.Where(t => t != sprite.texture).ToArray();
				collection.spriteDefinitions = collection.spriteDefinitions.Where(sd => sd.name != sprite.name).ToArray();

				List<tk2dSpriteDefinition> defs = new List<tk2dSpriteDefinition>(collection.spriteDefinitions);
				float scale = 1f / collection.invOrthoSize / collection.halfTargetHeight;
				Rect region = sprite.textureRect;

				// string name, Vector2 textureDimensions, float scale, Rect uvRegion, Rect trimRect, Vector2 anchor, bool rotated
				tk2dSpriteDefinition def = (tk2dSpriteDefinition)createDef.Invoke(null, new object[7] { sprite.name, region.size, scale, region,
				new Rect(0f, 0f, region.width, region.height), region.size / 2f, false });

				def.material = def.materialInst = new Material(Shader.Find("tk2d/BlendVertexColor")) { mainTexture = sprite.texture };
				def.sourceTextureGUID = Convert.ToString(sprite.texture.GetHashCode(), 16);

				collection.materials = collection.materials.AddItem(def.material).ToArray();
				collection.materialInsts = collection.materials.ToArray();
				collection.textures = collection.textures.AddItem(sprite.texture).ToArray();
				collection.spriteDefinitions = collection.spriteDefinitions.AddItem(def).ToArray();

				collection.inst.ClearDictionary();
				collection.inst.InitDictionary();
				collection.materialIdsValid = false;
				collection.needMaterialInstance = true;

				AccessTools.Method(typeof(tk2dSpriteCollectionData), "InitMaterialIds").Invoke(collection, null);
				AccessTools.Method(typeof(tk2dSpriteCollectionData), "Init").Invoke(collection, null);

				MyLogger.LogWarning("Added/updated tk2dSprite \"" + sprite.name + "\" to the collection \"" + (collection.spriteCollectionName ?? collection.name) + "\"!");
			}
			catch (Exception e)
			{
				MyLogger.LogError(e);
			}
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles")]
		protected static bool tk2dSpriteCollectionData_GetSpriteIdByName(tk2dSpriteCollectionData __instance, string name, int defaultValue, ref int __result)
		{
			__instance.inst.InitDictionary();
			Dictionary<string, int> dict = (Dictionary<string, int>)AccessTools.Field(typeof(tk2dSpriteCollectionData), "spriteNameLookupDict").GetValue(__instance);
			bool success = dict.TryGetValue(name, out int res);
			if (!success)
			{
				MyLogger.LogWarning("Failed to locate sprite \"" + name + "\"!");

				CustomUnlock unlock = null;
				foreach (CustomUnlock u in RogueLibs.EnumerateCustomUnlocks())
					if (u.Sprite?.name == name)
					{
						unlock = u;
						break;
					}
				if (unlock == null)
				{
					MyLogger.LogWarning("Failed to locate a custom unlock \"" + name + "\"!");
				}
				else
				{
					AddSpriteToCollection(__instance, unlock.Sprite);
					dict = (Dictionary<string, int>)AccessTools.Field(typeof(tk2dSpriteCollectionData), "spriteNameLookupDict").GetValue(__instance);
					success = dict.TryGetValue(name, out res);
					MyLogger.LogWarning("Just created a new tk2dSprite. ^^^ LOG ^^^ (" + res.ToString() + ")");

				}

			}

			__result = success ? res : defaultValue;
			return false;
		}

	}
#pragma warning restore CS1591
}
