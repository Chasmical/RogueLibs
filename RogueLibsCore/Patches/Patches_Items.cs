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
		///   <para>Applies the patches to <see cref="InvItem"/>, <see cref="ItemFunctions"/>, <see cref="InvDatabase"/>, <see cref="InvInterface"/> and <see cref="InvSlot"/>.</para>
		/// </summary>
		public void PatchItems()
		{
			// create and initialize item hooks
			Patcher.Postfix(typeof(InvItem), nameof(InvItem.SetupDetails));

			// CustomItem, IItemUsable patch
			Patcher.Prefix(typeof(ItemFunctions), nameof(ItemFunctions.UseItem));
			Patcher.Postfix(typeof(ItemFunctions), nameof(ItemFunctions.UseItem), nameof(ItemFunctions_UseItem_Postfix));

			// CustomItem, IItemCombinable and IItemTargetable
			Patcher.Prefix(typeof(InvItem), nameof(InvItem.CombineItems));
			Patcher.Prefix(typeof(InvItem), nameof(InvItem.TargetObject));

			// CustomItem, IItemTargetable.TargetTooltip(.) patches
			Patcher.Postfix(typeof(InvInterface), nameof(InvInterface.ShowTarget), new Type[] { typeof(InvItem) });
			Patcher.Postfix(typeof(InvInterface), nameof(InvInterface.ShowCursorText),
				new Type[] { typeof(string), typeof(string), typeof(PlayfieldObject), typeof(int) });
			Patcher.Postfix(typeof(InvInterface), nameof(InvInterface.HideCursorText));

			// CustomItem, IItemCombinable.CombineTooltip(.) patch
			Patcher.Postfix(typeof(InvSlot), nameof(InvSlot.SetColor));
		}

		/// <summary>
		///   <para><b>Postfix-patch.</b> Sets up and initializes the item's hooks.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="InvItem"/>.</param>
		public static void InvItem_SetupDetails(InvItem __instance)
		{
			foreach (IHookFactory<InvItem> factory in RogueLibsInternals.InvItemFactories)
				if (factory.CanCreate(__instance))
				{
					IHook<InvItem> hook = factory.CreateHook(__instance);
					__instance.AddHook(hook);
					hook.Initialize();
				}
		}

		/// <summary>
		///   <para><b>Prefix-patch (partial override).</b> Makes use of the complicated item usage system.</para>
		/// </summary>
		/// <param name="item">Item that is about to be used.</param>
		/// <param name="agent">Agent who is about to use the <paramref name="item"/>.</param>
		/// <param name="__state">Value of the <see cref="InvInterface.showingTarget"/>.</param>
		/// <returns><see langword="false"/>, if the <paramref name="item"/> is a custom item or if it didn't pass the <see cref="InventoryEvents"/> checks; otherwise, <see langword="true"/>. Partial override.</returns>
		public static bool ItemFunctions_UseItem(InvItem item, Agent agent, ref bool __state)
		{
			__state = item.invInterface.showingTarget;
			CustomItem custom = item.GetHook<CustomItem>();
			if (custom is IItemTargetable targetable)
			{
				item.invInterface.ShowOrHideTarget(item);
				return false;
			}

			if (custom?.ItemInfo.IgnoreDefaultChecks_UseItem != true)
			{ // ignore default checks OR original item
				if (agent.ghost)
				{
					agent.gc.audioHandler.Play(agent, "CantDo");
					return false;
				}
				else if (agent.statusEffects.hasTrait("CantInteract") && item.itemType != "Food")
				{
					agent.SayDialogue("CantInteract");
					agent.gc.audioHandler.Play(agent, "CantDo");
					return false;
				}
			}
			if (agent.localPlayer)
			{
				if (!agent.inventory.HasItem(item.invItemName) && agent.inventory.equippedSpecialAbility?.invItemName != item.invItemName)
					return false;
				else if ((item.Categories.Contains("Usable") || item.itemType == "Consumable") && !item.used)
				{
					item.used = true;
					if (agent.isPlayer > 0) agent.gc.sessionData.endStats[agent.isPlayer].itemsUsed++;
				}
			}

			if (InventoryEvents.onItemUseCheck.Raise(new OnItemUsedArgs(item, agent)))
			{
				if (!(custom is IItemUsable usable))
					return true;

				if (item.agent == agent) usable.UseItem();
				else
				{
					Agent prev = item.agent;
					item.agent = agent;
					usable.UseItem();
					item.agent = prev;
				}
			}
			return false;
		}
		/// <summary>
		///   <para><b>Postfix-patch.</b> Invokes the <see cref="InventoryEvents"/> events.</para>
		/// </summary>
		/// <param name="item">Item that was used.</param>
		/// <param name="agent">Agent who used the <paramref name="item"/>.</param>
		/// <param name="__state">Previously saved value of the <see cref="InvInterface.showingTarget"/>.</param>
		public static void ItemFunctions_UseItem_Postfix(InvItem item, Agent agent, ref bool __state)
		{
			if (__state == item.invInterface.showingTarget)
			{
				OnItemUsedArgs args = new OnItemUsedArgs(item, agent);
				InventoryEvents.Global.onItemUsed.Raise(args);
				item.database.GetEvents().onItemUsed.Raise(args);
			}
		}

		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Makes use of the complicated item combining system.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="InvItem"/>.</param>
		/// <param name="otherItem">Item that the current item is being combined with.</param>
		/// <param name="slotNum">Inventory slot's number, that the <paramref name="otherItem"/> is in.</param>
		/// <param name="myAgent">Agent who is combining the items.</param>
		/// <param name="combineType">Combine type.</param>
		/// <param name="__result">Return value of the method.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool InvItem_CombineItems(InvItem __instance, InvItem otherItem, int slotNum, Agent myAgent, string combineType, ref bool __result)
		{
			CustomItem custom = __instance.GetHook<CustomItem>();

			if (custom?.ItemInfo.IgnoreDefaultChecks_CombineFilter != true)
			{
				if (__instance.invItemName == otherItem.invItemName && __instance.stackable)
				{
					if (__instance.invItemName == "Syringe" && __instance.contents[0] != otherItem.contents[0])
					{
						__result = false;
						return false;
					}
					if (combineType == "Combine")
					{
						if (myAgent.controllerType != "Keyboard")
						{
							myAgent.gc.audioHandler.Play(myAgent, "BeginCombine");
						}
						otherItem.agent.mainGUI.invInterface.PutDraggedItemBack();
					}
					__result = true;
					return false;
				}
			}

			bool firstCheck;
			if (custom is IItemCombinable combinable)
			{
				if (__instance.agent == myAgent) firstCheck = combinable.CombineFilter(otherItem);
				else
				{
					Agent prev = __instance.agent;
					__instance.agent = myAgent;
					firstCheck = combinable.CombineFilter(otherItem);
					__instance.agent = prev;
				}
			}
			else firstCheck = __instance.itemFunctions.CombineItems(__instance, myAgent, otherItem, slotNum, string.Empty);

			__result = firstCheck && InventoryEvents.onItemsCombineCheck.Raise(new OnItemsCombinedArgs(__instance, otherItem, myAgent));

			if (__result && combineType == "Combine")
			{
				if (custom is IItemCombinable combinable2)
				{
					if (__instance.agent == myAgent) combinable2.CombineItems(otherItem);
					else
					{
						Agent prev = __instance.agent;
						__instance.agent = myAgent;
						combinable2.CombineItems(otherItem);
						__instance.agent = prev;
					}
				}
				else __instance.itemFunctions.CombineItems(__instance, myAgent, otherItem, slotNum, "Combine");

				if (custom?.ItemInfo.IgnoreDefaultChecks_CombineItems != true
					&& (__instance.invItemCount < 1 || !__instance.database.InvItemList.Contains(__instance)))
				{
					myAgent.mainGUI.invInterface.HideDraggedItem();
					myAgent.mainGUI.invInterface.HideTarget();
				}

				OnItemsCombinedArgs args = new OnItemsCombinedArgs(__instance, otherItem, myAgent);
				InventoryEvents.Global.onItemsCombined.Raise(args);
				__instance.database.GetEvents().onItemsCombined.Raise(args);
			}
			return false;
		}
		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Makes use of the complicated item targeting system.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="InvItem"/>.</param>
		/// <param name="otherObject">Object that the current item is being used on.</param>
		/// <param name="combineType">Combine type.</param>
		/// <param name="__result">Return value of the method.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool InvItem_TargetObject(InvItem __instance, PlayfieldObject otherObject, string combineType, ref bool __result)
		{
			CustomItem custom = __instance.GetHook<CustomItem>();

			if (custom?.ItemInfo.IgnoreDefaultChecks_TargetFilter != true)
			{
				if (Vector2.Distance(__instance.agent.curPosition, otherObject.curPosition) > 15f || otherObject.playfieldObjectType == "Agent" && (otherObject.playfieldObjectAgent.butlerBot || otherObject.playfieldObjectAgent.mechEmpty))
				{
					__result = false;
					return false;
				}
			}

			bool firstCheck = custom is IItemTargetable combinable
				? combinable.TargetFilter(otherObject)
				: __instance.itemFunctions.TargetObject(__instance, __instance.agent, otherObject, string.Empty);

			__result = firstCheck && InventoryEvents.onItemTargetCheck.Raise(new OnItemTargetedArgs(__instance, otherObject, __instance.agent));

			if (__result && combineType == "Combine")
			{
				if (custom is IItemTargetable combinable2) combinable2.TargetObject(otherObject);
				else __instance.itemFunctions.TargetObject(__instance, __instance.agent, otherObject, "Combine");

				if (custom?.ItemInfo.IgnoreDefaultChecks_TargetObject != true
					&& (__instance.invItemCount < 1 || !__instance.database.InvItemList.Contains(__instance)))
				{
					__instance.agent.mainGUI.invInterface.HideDraggedItem();
					__instance.agent.mainGUI.invInterface.HideTarget();
				}

				OnItemTargetedArgs args = new OnItemTargetedArgs(__instance, otherObject, __instance.agent);
				InventoryEvents.Global.onItemTargeted.Raise(args);
				__instance.database.GetEvents().onItemTargeted.Raise(args);
			}
			return false;
		}
		private static Color? targetTextColor;

		/// <summary>
		///   <para><b>Postfix-patch.</b> Sets the item's targeting tooltip for the highlighted object.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="InvInterface"/>.</param>
		/// <param name="item">Item that is being used.</param>
		public static void InvInterface_ShowTarget(InvInterface __instance, InvItem item)
		{
			if (item.itemType != "Combine")
			{
				if (targetTextColor == null) targetTextColor = __instance.cursorTextString3.color;
				CustomItem custom = item.GetHook<CustomItem>();
				if (custom is IItemTargetable targetable)
				{
					CustomTooltip tooltip = targetable.TargetTooltip(item.agent.target.playfieldObject);
					__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
					__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;
				}
			}
		}
		/// <summary>
		///   <para><b>Postfix-patch.</b> Updates the item's targeting tooltip for the highlighted object.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="InvInterface"/>.</param>
		/// <param name="myPlayfieldObject">Highlighted object.</param>
		public static void InvInterface_ShowCursorText(InvInterface __instance, PlayfieldObject myPlayfieldObject)
		{
			CustomItem custom = __instance.mainGUI.targetItem?.GetHook<CustomItem>();
			if (custom is IItemTargetable targetable)
			{
				CustomTooltip tooltip = targetable.TargetTooltip(myPlayfieldObject);
				__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
				__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;
			}
		}
		/// <summary>
		///   <para><b>Postfix-patch.</b> Sets the item's targeting tooltip to the default one.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="InvInterface"/>.</param>
		public static void InvInterface_HideCursorText(InvInterface __instance)
		{
			CustomItem custom = __instance.mainGUI.targetItem?.GetHook<CustomItem>();
			if (custom is IItemTargetable targetable)
			{
				CustomTooltip tooltip = targetable.TargetTooltip(null);
				__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
				__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;
			}
		}

		/// <summary>
		///   <para><b>Postfix-patch.</b> Sets the inventory slot's short combining tooltip.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="InvSlot"/>.</param>
		/// <param name="___itemText">Private field. Text that displays the short tooltip text.</param>
		public static void InvSlot_SetColor(InvSlot __instance, Text ___itemText)
		{
			InvItem combiner = __instance.mainGUI.targetItem ?? __instance.database.invInterface.draggedInvItem;
			if (combiner == null) return;
			InvItem combinee = __instance.curItemList[__instance.slotNumber];

			CustomItem custom = combiner.GetHook<CustomItem>();
			if (!(custom is IItemCombinable combinable)) return;

			if (__instance.slotType == "Player" || __instance.slotType == "Toolbar" || __instance.slotType == "Chest" || __instance.slotType == "NPCChest")
			{
				if (combinee.invItemName != null && combiner.itemType == "Combine")
				{
					if (combiner.CombineItems(combinee, __instance.slotNumber, string.Empty, __instance.agent) && __instance.slotType != "NPCChest")
					{
						__instance.myImage.color = new Color32(0, __instance.br, __instance.br, __instance.standardAlpha);
						__instance.itemImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
						__instance.myImage.sprite = __instance.invBoxCanUse;

						if (__instance.slotType != "NPCChest" && __instance.slotType != "Chest")
						{
							if (combineTextColor == null) combineTextColor = __instance.toolbarNumText.color;
							CustomTooltip tooltip = combinable.CombineTooltip(combinee);
							__instance.toolbarNumTextGo.SetActive(true);
							__instance.toolbarNumText.text = tooltip.Text ?? string.Empty;
							__instance.toolbarNumText.color = tooltip.Color ?? combineTextColor.Value;
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
				else if (__instance.slotType != "NPCChest" && (combinee.invItemName != null || combiner.itemType != "Combine"))
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
		private static Color? combineTextColor;
	}
}
