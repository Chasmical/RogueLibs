using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
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

			patcher.Postfix(typeof(Unlocks), "LoadInitialUnlocks");
			patcher.Postfix(typeof(ScrollingMenu), "SortUnlocks");
			patcher.Postfix(typeof(CharacterCreation), "SortUnlocks");
			patcher.Prefix(typeof(ScrollingMenu), "PushedButton");

			patcher.Postfix(typeof(InvItem), "SetupDetails");
			patcher.Postfix(typeof(ItemFunctions), "UseItem");
			patcher.Postfix(typeof(ItemFunctions), "TargetObject");
			patcher.Postfix(typeof(ItemFunctions), "CombineItems");

			patcher.Postfix(typeof(InvSlot), "SetColor");

			patcher.Postfix(typeof(StatusEffects), "SpecialAbilityInterfaceCheck2");
			patcher.Postfix(typeof(StatusEffects), "RechargeSpecialAbility2");
			patcher.Postfix(typeof(StatusEffects), "GiveSpecialAbility");
			patcher.Postfix(typeof(StatusEffects), "PressedSpecialAbility");
			patcher.Postfix(typeof(StatusEffects), "HeldSpecialAbility");
			patcher.Postfix(typeof(StatusEffects), "ReleasedSpecialAbility");

			patcher.Postfix(typeof(SpecialAbilityIndicator), "ShowIndicator", new Type[] { typeof(PlayfieldObject), typeof(string), typeof(string) });

			Awake2();
		}

		protected static string[] languages = new string[8] { "english", "schinese", "german", "spanish", "brazilian", "russian", "french", "koreana" };
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
				newUnlock = new Unlock(customUnlock.Id, customUnlock.Type, customUnlock.Unlocked, customUnlock.UnlockCost ?? 0)
				{
					cancellations = customUnlock.Conflicting,
					unavailable = !customUnlock.Available,
					prerequisites = customUnlock.Prerequisites,
					recommendations = customUnlock.Recommendations,
					specialAbilities = customUnlock.SpecialAbilities,
					categories = customUnlock.Categories
				};
				newUnlock = GameController.gameController.unlocks.AddUnlock(newUnlock);
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
			}
			else if (customUnlock is CustomAbility ability)
			{
				EnsureOne(big.abilityUnlocks, newUnlock, ability.Available);
				if (ability.Available) Unlock.abilityCount++;
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
				newUnlock.cantLose = trait.CantLose;
				newUnlock.cantSwap = trait.CantSwap;

				CustomTrait.UpgradeCheck(trait.Id);
				CustomTrait.UpgradeCheck(trait.Upgrade);
			}

			if (customUnlock.Sprite != null)
			{
				if (gr.itemDic.ContainsKey(customUnlock.Id))
					gr.itemDic[customUnlock.Id] = customUnlock.Sprite;
				else gr.itemDic.Add(customUnlock.Id, customUnlock.Sprite);

				if (!gr.itemList.Contains(customUnlock.Sprite))
					gr.itemList.Add(customUnlock.Sprite);
			}
			MyLogger.LogDebug("Unlock " + customUnlock.Id + " set up!");
			customUnlock.unlock = newUnlock;
		}

		protected static bool loadedInitialUnlocks = false;
		protected static void Unlocks_LoadInitialUnlocks(Unlocks __instance, ref bool ___doResetCertainAbilities)
		{
			bool prev = ___doResetCertainAbilities;
			___doResetCertainAbilities = false;

			if (loadedInitialUnlocks) return;
			loadedInitialUnlocks = true;

			foreach (CustomUnlock unlock in RogueLibs.EnumerateCustomUnlocks())
				RogueLibs.PluginInstance.Setup(unlock);

			GameController.gameController.SetDailyRunText();
			GameController.gameController.mainGUI?.scrollingMenuScript?.UpdateOtherVisibleMenus(GameController.gameController.mainGUI.scrollingMenuScript.menuType);

			___doResetCertainAbilities = prev;
		}
		protected static void ScrollingMenu_SortUnlocks(ScrollingMenu __instance, string unlockType, List<Unlock> ___listUnlocks)
		{
			IEnumerable list;
			int offset = 0;

			if (unlockType == "Challenge") // Mutator Menu
			{
				RogueLibs.CustomMutators.Sort();
				list = RogueLibs.CustomMutators;
				offset = 1; // Clear All Mutators button
			}
			else if (__instance.menuType == "Items") // Item Unlocks / Rewards
			{
				RogueLibs.CustomItems.Sort();
				list = RogueLibs.CustomItems;
			}
			else if (__instance.menuType == "TraitUnlocks") // Trait Unlocks
			{
				RogueLibs.CustomTraits.Sort();
				list = RogueLibs.CustomTraits;
			}
			else
				return;

			List<Unlock> addToBeginning = new List<Unlock>();
			List<Unlock> addToEnd = new List<Unlock>();

			foreach (CustomUnlock customUnlock in list)
			{ // enumerate through sorted CustomUnlocks and put them in the lists (in sorted order)
				if (customUnlock.SortingOrder == 0) continue;

				int index = ___listUnlocks.FindIndex(u => u.unlockName == customUnlock.Id);

				if (customUnlock.SortingOrder < 0) addToBeginning.Add(___listUnlocks[index]);
				else addToEnd.Add(___listUnlocks[index]);
				___listUnlocks.RemoveAt(index);
			}

			___listUnlocks.InsertRange(offset, addToBeginning);
			___listUnlocks.AddRange(addToEnd);
		}
		protected static void CharacterCreation_SortUnlocks(CharacterCreation __instance, string unlockType)
		{
			IEnumerable customUnlocks;
			List<Unlock> listUnlocks;
			int offset = 0;
			bool abilityCheck = false;

			if (unlockType == "Item")
			{
				RogueLibs.CustomItems.Sort();
				customUnlocks = RogueLibs.CustomItems;
				listUnlocks = __instance.listUnlocksItems;
				offset = 1; // Clear All Items button
			}
			else if (unlockType == "Ability")
			{
				RogueLibs.CustomItems.Sort();
				customUnlocks = RogueLibs.CustomAbilities;
				listUnlocks = __instance.listUnlocksAbilities;
				abilityCheck = true;
			}
			else
				return;

			List<Unlock> addToBeginning = new List<Unlock>();
			List<Unlock> addToEnd = new List<Unlock>();

			foreach (CustomUnlock customUnlock in customUnlocks)
			{ // enumerate through sorted CustomUnlocks and put them in the lists (in sorted order)
				int index = listUnlocks.FindIndex(u => u.unlockName == customUnlock.Id);

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
		protected static bool ScrollingMenu_PushedButton(ScrollingMenu __instance, ButtonHelper myButton, List<Unlock> ___listUnlocks)
		{
			Unlock u = myButton.scrollingButtonUnlock;
			ButtonData data = __instance.buttonsData[myButton.scrollingButtonNum];

			if (__instance.menuType == "Challenges")
			{
				if (!__instance.gc.serverPlayer)
				{
					__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
					return false;
				}

				CustomMutator custom = RogueLibs.GetCustomMutator(myButton.scrollingButtonType);

				if (u.unlocked)
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
							}
						if (__instance.gc.multiplayerMode)
							__instance.agent.objectMult.SendChatAnnouncement("ClearedAllChallenges", string.Empty, string.Empty);
					}
					else
					{ // normal handling / toggle on/off
						myButton.scrollingHighlighted = data.scrollingHighlighted = !myButton.scrollingHighlighted;
						SpriteState spriteState = default;
						spriteState.highlightedSprite = myButton.scrollingHighlighted ? myButton.solidObjectButtonSelected : myButton.solidObjectButton;
						myButton.button.spriteState = spriteState;
						data.highlightedSprite = myButton.scrollingHighlighted ? __instance.solidObjectButtonSelected : __instance.solidObjectButton;

						if (myButton.scrollingHighlighted)
						{ // was toggled on
							__instance.gc.challenges.Add(myButton.scrollingButtonType);
							__instance.gc.originalChallenges.Add(myButton.scrollingButtonType);
						}
						else
						{ // was toggled off
							__instance.gc.challenges.Remove(myButton.scrollingButtonType);
							__instance.gc.originalChallenges.Remove(myButton.scrollingButtonType);
						}

						if (myButton.scrollingButtonType == "SuperSpecialCharacters")
							__instance.gc.mainGUI.characterSelectScript.RefreshSuperSpecials();
						if (__instance.gc.multiplayerMode)
							__instance.agent.objectMult.SendChatAnnouncement((myButton.scrollingHighlighted ? "Added" : "Removed") + "Challenge", myButton.scrollingButtonType, string.Empty);
					}

					__instance.gc.sessionDataBig.challenges = __instance.gc.challenges;
					__instance.gc.sessionDataBig.originalChallenges = __instance.gc.originalChallenges;
					__instance.gc.audioHandler.Play(__instance.gc.playerAgent, "ClickButton");
					__instance.gc.SetDailyRunText();
					__instance.UpdateOtherVisibleMenus(__instance.menuType);
				}
				else if (custom != null)
				{ // not unlocked and is a custom mutator
					if (custom.UnlockCost != null)
					{ // can be purchased
						if (custom.UnlockCost <= __instance.gc.sessionDataBig.nuggets)
						{ // the player can afford the purchase
							__instance.gc.unlocks.SubtractNuggets(custom.UnlockCost.Value);
							__instance.gc.unlocks.DoUnlock(custom.Id, "Challenge");
							__instance.gc.audioHandler.Play(__instance.agent, "BuyUnlock");

							for (int i = 0; i < __instance.numButtons; i++)
								__instance.SetupChallenges(__instance.buttonsData[i], ___listUnlocks[i]);

							__instance.gc.SetDailyRunText();
							__instance.UpdateOtherVisibleMenus(__instance.menuType);
						}
						else
						{ // the player can not afford the purchase
							__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
						}
					}
					else
					{ // can't be purchased
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
					}
				}
				else
				{ // is original mutator and is not unlocked
					__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
				}

				return false;
			}
			else if (__instance.menuType == "Items")
			{

				return true;
			}
			else if (__instance.menuType == "TraitUnlocks")
			{

				return true;
			}
			else
				return true;
		}
		protected static bool CharacterCreation_PushedButton(CharacterCreation __instance, ButtonHelper myButton)
		{
			if (__instance.selectedSpace == "Load") return true;

			ButtonData buttonData = __instance.buttonsDataItems[myButton.scrollingButtonNum];
			Unlock unlock = myButton.scrollingButtonUnlock;

			if (unlock.unlockType == "Item")
			{
				CustomItem custom = RogueLibs.GetCustomItem(unlock.unlockName);
				if (unlock.unlocked)
				{ // if unlocked, then handle ClearAll OR toggle on/off
					if (myButton.scrollingButtonType == "ClearAllItems")
					{ // handling ClearAll button
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
					{ // normal handling / toggle on/off
						myButton.scrollingHighlighted = buttonData.scrollingHighlighted = !myButton.scrollingHighlighted;
						SpriteState spriteState = default;
						spriteState.highlightedSprite = myButton.scrollingHighlighted ? myButton.solidObjectButtonSelected : myButton.solidObjectButton;
						myButton.button.spriteState = spriteState;
						buttonData.highlightedSprite = myButton.scrollingHighlighted ? __instance.solidObjectButtonSelected : __instance.solidObjectButton;

						if (myButton.scrollingHighlighted)
							__instance.itemsChosen.Add(unlock);
						else
							__instance.itemsChosen.Remove(unlock);

						__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "ClickButtonMenu");
					}
					__instance.scrollerControllerItems.myScroller.RefreshActiveCellViews();
				}
				else if (custom != null)
				{ // not unlocked and is a custom item
					if (custom.UnlockCost != null)
					{ // can be purchased
						if (custom.UnlockCost <= __instance.gc.sessionDataBig.nuggets)
						{ // the player can afford the purchase
							__instance.gc.unlocks.SubtractNuggets(custom.UnlockCost.Value);
							__instance.gc.unlocks.DoUnlock(custom.Id, "Item");
							__instance.gc.audioHandler.Play(__instance.agent, "BuyUnlock");

							for (int i = 0; i < __instance.numButtonsItems; i++)
								__instance.SetupItems(__instance.buttonsDataItems[i], __instance.listUnlocksItems[i]);
						}
						else // the player can not afford the purchase
							__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
					}
					else // can't be purchased
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
				}
				else // is original item and is not unlocked
					__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
			}
			else if (unlock.unlockType == "Ability")
			{
				CustomAbility custom = RogueLibs.GetCustomAbility(unlock.unlockName);
				if (unlock.unlocked)
				{ // if unlocked, then toggle on/off
					__instance.DoCancellations(myButton);

					myButton.scrollingHighlighted = buttonData.scrollingHighlighted = !myButton.scrollingHighlighted;
					SpriteState spriteState = default;
					spriteState.highlightedSprite = myButton.scrollingHighlighted ? myButton.solidObjectButtonSelected : myButton.solidObjectButton;
					myButton.button.spriteState = spriteState;
					buttonData.highlightedSprite = myButton.scrollingHighlighted ? __instance.solidObjectButtonSelected : __instance.solidObjectButton;

					__instance.abilityChosen = myButton.scrollingHighlighted ? unlock.unlockName : string.Empty;

					__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "ClickButtonMenu");
					try { myButton.RefreshContent(buttonData); } catch { }
					__instance.scrollerControllerItems.myScroller.RefreshActiveCellViews();
				}
				else if (custom != null)
				{ // not unlocked and is a custom ability
					if (custom.UnlockCost != null)
					{ // can be purchased
						if (custom.UnlockCost <= __instance.gc.sessionDataBig.nuggets)
						{ // the player can afford the purchase
							__instance.gc.unlocks.SubtractNuggets(custom.UnlockCost.Value);
							__instance.gc.unlocks.DoUnlock(custom.Id, "Ability");
							__instance.gc.audioHandler.Play(__instance.agent, "BuyUnlock");

							for (int i = 0; i < __instance.numButtonsAbilities; i++)
								__instance.SetupAbilities(__instance.buttonsDataAbilities[i], __instance.listUnlocksAbilities[i]);
						}
						else // the player can not afford the purchase
							__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
					}
					else // can't be purchased
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
				}
				else // is original ability and is not unlocked
					__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
			}
			else if (unlock.unlockType == "Trait")
			{
				CustomTrait custom = RogueLibs.GetCustomTrait(unlock.unlockName);
				if (unlock.unlocked)
				{ // if unlocked, then toggle on/off
					if (myButton.scrollingButtonType == "ClearAllTraits")
					{ // handling ClearAll button
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
					{ // normal handling / toggle on/off
						myButton.scrollingHighlighted = buttonData.scrollingHighlighted = !myButton.scrollingHighlighted;
						SpriteState spriteState = default;
						spriteState.highlightedSprite = myButton.scrollingHighlighted ? myButton.solidObjectButtonSelected : myButton.solidObjectButton;
						myButton.button.spriteState = spriteState;
						buttonData.highlightedSprite = myButton.scrollingHighlighted ? __instance.solidObjectButtonSelected : __instance.solidObjectButton;

						if (myButton.scrollingHighlighted)
							__instance.traitsChosen.Add(unlock);
						else
							__instance.traitsChosen.Remove(unlock);

						__instance.gc.audioHandler.PlayMust(__instance.gc.playerAgent, "ClickButtonMenu");
					}
					__instance.scrollerControllerItems.myScroller.RefreshActiveCellViews();
				}
				else if (custom != null)
				{  // not unlocked and is a custom trait
					if (custom.UnlockCost != null)
					{ // can be purchased
						if (custom.UnlockCost <= __instance.gc.sessionDataBig.nuggets)
						{ // the player can afford the purchase
							__instance.gc.unlocks.SubtractNuggets(custom.UnlockCost.Value);
							__instance.gc.unlocks.DoUnlock(custom.Id, "Trait");
							__instance.gc.audioHandler.Play(__instance.agent, "BuyUnlock");

							for (int i = 0; i < __instance.numButtonsTraits; i++)
								__instance.SetupTraits(__instance.buttonsDataTraits[i], __instance.listUnlocksTraits[i]);
						}
						else // the player can not afford the purchase
							__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
					}
					else // can't be purchased
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
				}
				else // is original ability and is not unlocked
					__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
			}
			__instance.CreatePointTallyText();
			return false;
		}

		protected static void InvItem_SetupDetails(InvItem __instance)
		{
			CustomItem customItem = RogueLibs.CustomItems.Find(i => i.Id == __instance.invItemName);
			if (customItem == null) return;
			__instance.LoadItemSprite(__instance.invItemName);
			customItem.SetupDetails?.Invoke(__instance);
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
		protected static void ItemFunctions_CombineItems(InvItem item, Agent agent, InvItem otherItem, int slotNum, string combineType, ref bool __result)
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
					else if ((!(__instance.slotType == "Toolbar") || __instance.mainGUI.openedInventory) && __instance.slotType != "NPCChest")
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
			__instance.image.sprite = ability.Sprite;
		}

		protected void Awake2()
		{
			RoguePatcher patcher = new RoguePatcher(this, GetType());


		}




	}
#pragma warning restore CS1591
}
