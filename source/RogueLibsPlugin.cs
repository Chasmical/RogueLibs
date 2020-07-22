using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

			patcher.Postfix(typeof(ScrollingMenu), "SortUnlocks"); // insert CustomMutators in the menu
			patcher.Postfix(typeof(ScrollingMenu), "PushedButton"); // disable conflicting mutators and triggering CustomMutator events

			patcher.Postfix(typeof(InvItem), "SetupDetails"); // CustomItem's SetupDetails
			patcher.Postfix(typeof(InvItem), "LoadItemSprite"); // CustomItem's Sprite
			patcher.Postfix(typeof(ItemFunctions), "UseItem"); // CustomItem's UseItem
			patcher.Postfix(typeof(ItemFunctions), "TargetObject"); // CustomItem's TargetFilter and TargetObject
			patcher.Postfix(typeof(ItemFunctions), "CombineItems"); // CustomItem's CombineFilter and CombineItems
			patcher.Postfix(typeof(InvSlot), "SetColor"); // CustomItem's CombineTooltip

			patcher.Postfix(typeof(GameResources), "SetupDics"); // make sure that GameResources has CustomItems' sprites

			patcher.Postfix(typeof(StatusEffects), "SpecialAbilityInterfaceCheck2"); // CustomAbility's IndicatorCheck
			patcher.Postfix(typeof(StatusEffects), "RechargeSpecialAbility2"); // CustomAbility's RechargeInterval and Recharge
			patcher.Postfix(typeof(StatusEffects), "GiveSpecialAbility"); // CustomAbility set up enumerators
			patcher.Postfix(typeof(StatusEffects), "PressedSpecialAbility"); // CustomAbility's OnPressed
			patcher.Postfix(typeof(StatusEffects), "HeldSpecialAbility"); // CustomAbility's OnHeld
			patcher.Postfix(typeof(StatusEffects), "ReleasedSpecialAbility"); // CustomAbility's OnReleased

			patcher.Postfix(typeof(SpecialAbilityIndicator), "ShowIndicator", new Type[] { typeof(PlayfieldObject), typeof(string), typeof(string) });








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

		protected static void ScrollingMenu_SortUnlocks(ScrollingMenu __instance, string unlockType, List<Unlock> ___listUnlocks)
		{
			if (unlockType == "Challenge")
			{
				List<Unlock> addToBeginning = new List<Unlock>();
				List<Unlock> mixWithOriginal = new List<Unlock>();
				List<Unlock> addToEnd = new List<Unlock>();

				RogueLibs.CustomMutators.Sort();

				foreach (CustomMutator mutator in RogueLibs.CustomMutators)
				{
					if (!mutator.ShowInMenu) continue;
					Unlock unlock = new Unlock(mutator.Id, "Challenge", mutator.Unlocked)
					{
						cancellations = mutator.Conflicting
					};
					if (mutator.SortingOrder > 0) addToEnd.Add(unlock);
					else if (mutator.SortingOrder == 0) mixWithOriginal.Add(unlock);
					else addToBeginning.Add(unlock);
				}
				___listUnlocks.AddRange(mixWithOriginal);
				___listUnlocks.Sort(1, ___listUnlocks.Count - 1, null);
				___listUnlocks.InsertRange(1, addToBeginning);
				___listUnlocks.AddRange(addToEnd);

				__instance.numButtons += addToBeginning.Count + mixWithOriginal.Count + addToEnd.Count;
			}
		}
		protected static void ScrollingMenu_PushedButton(ScrollingMenu __instance, ButtonHelper myButton)
		{
			if (__instance.menuType == "Challenges")
			{
				if (!__instance.gc.serverPlayer || myButton.scrollingButtonType == "ClearAll" || myButton.scrollingButtonType == "CreateAMutator") return;

				if (myButton.scrollingHighlighted)
				{
					foreach (CustomMutator mutator in RogueLibs.CustomMutators)
						if (mutator.Conflicting.IndexOf(myButton.scrollingButtonType) != -1)
						{
							foreach (ButtonData buttonData in __instance.buttonsData)
								if (buttonData.scrollingButtonType == mutator.Id)
								{
									buttonData.scrollingHighlighted = false;
									buttonData.highlightedSprite = __instance.solidObjectButton;
									__instance.gc.challenges.Remove(buttonData.scrollingButtonType);
									__instance.gc.originalChallenges.Remove(buttonData.scrollingButtonType);
									break;
								}
						}
				}
				CustomMutator mut = RogueLibs.CustomMutators.Find(m => m.Id == myButton.scrollingButtonType);
				mut?.TriggerStateChange(myButton.scrollingHighlighted);

				__instance.gc.SetDailyRunText();
				__instance.UpdateOtherVisibleMenus(__instance.menuType);
			}
		}

		protected static void InvItem_SetupDetails(InvItem __instance)
		{
			CustomItem cItem = RogueLibs.CustomItems.Find(i => i.Id == __instance.invItemName);
			if (cItem == null) return;
			cItem.SetupDetails?.Invoke(__instance);
			__instance.LoadItemSprite(cItem.Id);
		}
		protected static void InvItem_LoadItemSprite(InvItem __instance)
		{
			CustomItem cItem = RogueLibs.CustomItems.Find(i => i.Id == __instance.invItemName);
			if (cItem == null) return;
			__instance.itemIcon = cItem.Sprite;
		}
		protected static void ItemFunctions_UseItem(InvItem item, Agent agent)
		{
			CustomItem cItem = RogueLibs.CustomItems.Find(i => i.Id == item.invItemName);
			if (cItem == null) return;

			if (cItem.TargetObject != null)
				item.invInterface.ShowOrHideTarget(item);
			cItem.UseItem?.Invoke(item, agent);
		}
		protected static void ItemFunctions_TargetObject(InvItem item, Agent agent, PlayfieldObject otherObject, string combineType, ref bool __result)
		{
			CustomItem cItem = RogueLibs.CustomItems.Find(i => i.Id == item.invItemName);
			if (cItem?.TargetObject == null) return;

			if ((__result = cItem.TargetFilter == null || cItem.TargetFilter(item, agent, otherObject)) && combineType == "Combine")
			{
				cItem.TargetObject(item, agent, otherObject);
				if (item.invItemCount < 1)
				{
					agent.mainGUI.invInterface.HideDraggedItem();
					agent.mainGUI.invInterface.HideTarget();
				}
			}
		}
		protected static void ItemFunctions_CombineItems(InvItem item, Agent agent, InvItem otherItem, string combineType, ref bool __result)
		{
			CustomItem citem = RogueLibs.CustomItems.Find(i => i.Id == item.invItemName);
			if (citem?.CombineItems == null) return;

			if ((__result = citem.CombineFilter == null || citem.CombineFilter(item, agent, otherItem)) && combineType == "Combine")
			{
				citem.CombineItems(item, agent, otherItem);
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

			if (targetItem != null && (__instance.slotType == "Player" || __instance.slotType == "Toolbar" || __instance.slotType == "Chest" || __instance.slotType == "NPCChest"))
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

		protected static void GameResources_SetupDics(GameResources __instance)
		{
			foreach (CustomItem item in RogueLibs.CustomItems)
			{
				if (!__instance.itemDic.ContainsKey(item.Id))
					__instance.itemDic.Add(item.Id, item.Sprite);
				if (!__instance.itemList.Contains(item.Sprite))
					__instance.itemList.Add(item.Sprite);
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
					if (res == null)
						__instance.agent.specialAbilityIndicator.Revert();
					else
						__instance.agent.specialAbilityIndicator.ShowIndicator(res, __instance.agent.specialAbility);
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

			CustomAbility ability = RogueLibs.GetCustomAbility(__instance.agent.inventory.equippedSpecialAbility.invItemName);

			if (ability?.IndicatorCheck != null) __instance.SpecialAbilityInterfaceCheck();
			if (ability?.Recharge != null) __instance.RechargeSpecialAbility(abilityName);
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












	}
#pragma warning restore CS1591
}
