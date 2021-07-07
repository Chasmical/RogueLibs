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
		public void PatchItems()
		{
			// create and initialize item hooks
			Patcher.Postfix(typeof(InvItem), nameof(InvItem.SetupDetails));

			// CustomItem, IItemUsable patch
			Patcher.Prefix(typeof(ItemFunctions), nameof(ItemFunctions.UseItem));

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
			// CustomItem.GetCount(.) patch
			Patcher.Postfix(typeof(InvSlot), nameof(InvSlot.UpdateInvSlot));

			// CustomItem, IItemTargetableAnywhere patches
			Patcher.Postfix(typeof(InvInterface), nameof(InvInterface.TargetAnywhere));

			DefaultInventoryChecks.SubscribeChecks();
		}

		public static void InvItem_SetupDetails(InvItem __instance)
		{
			foreach (IHookFactory<InvItem> factory in RogueFramework.ItemFactories)
				if (factory.TryCreate(__instance, out IHook<InvItem> hook))
				{
					__instance.AddHook(hook);
					hook.Initialize();
				}
		}

		public static bool ItemFunctions_UseItem(InvItem item, Agent agent)
		{
			CustomItem custom = item.GetHook<CustomItem>();
			if (custom is IItemTargetable || custom is IItemTargetableAnywhere)
			{
				item.invInterface.ShowOrHideTarget(item);
				return false;
			}

			Agent originalAgent = agent;
			OnItemUsingArgs args = new OnItemUsingArgs(item, agent);
			if (InventoryChecks.onItemUsing.Raise(args, custom?.ItemInfo.IgnoredChecks))
			{
				agent = args.User;
				// in case an inventory check redirected the use of an item on someone else
				using (AgentSwapper swapper = new AgentSwapper(item, agent))
				{
					if (agent.localPlayer)
					{
						if (!originalAgent.inventory.HasItem(item.invItemName)
							&& originalAgent.inventory.equippedSpecialAbility?.invItemName != item.invItemName)
							return false;
						else if (!item.used && (item.Categories.Contains("Usable") || item.itemType == "Consumable"))
						{
							item.used = true;
							if (agent.isPlayer > 0) agent.gc.sessionData.endStats[agent.isPlayer].itemsUsed++;
						}
					}
					// if it's not a custom item, run the original method
					if (!(custom is IItemUsable usable))
						return true;

					bool success = usable.UseItem();
					if (success) new ItemFunctions().UseItemAnim(item, agent);
				}
			}
			return false;
		}

		public static bool InvItem_CombineItems(InvItem __instance, InvItem otherItem, int slotNum, Agent myAgent, string combineType, ref bool __result)
		{
			CustomItem custom = __instance.GetHook<CustomItem>();

			if (__instance.stackable && __instance.invItemName == otherItem.invItemName
				&& InventoryChecks.IsCheckAllowed(custom, "AutoStacking"))
			{
				if (__instance.invItemName == "Syringe" && __instance.contents[0] != otherItem.contents[0])
				{
					__result = false;
					return false;
				}
				if (combineType == "Combine")
				{
					if (myAgent.controllerType != "Keyboard")
						myAgent.gc.audioHandler.Play(myAgent, "BeginCombine");
					otherItem.agent.mainGUI.invInterface.PutDraggedItemBack();
				}
				__result = true;
				return false;
			}

			bool filterResult;
			if (custom is IItemCombinable combinable)
			{
				using (AgentSwapper swapper = new AgentSwapper(__instance, myAgent))
					filterResult = combinable.CombineFilter(otherItem);
			}
			else filterResult = new ItemFunctions().CombineItems(__instance, myAgent, otherItem, slotNum, string.Empty);

			OnItemsCombiningArgs args = new OnItemsCombiningArgs(__instance, otherItem, myAgent);
			__result = filterResult && InventoryChecks.onItemsCombining.Raise(args, custom?.ItemInfo.IgnoredChecks);

			if (__result && combineType == "Combine")
			{
				myAgent = args.Combiner;
				otherItem = args.OtherItem;
				if (custom is IItemCombinable combinable2)
				{
					using (AgentSwapper swapper = new AgentSwapper(__instance, myAgent))
					{
						bool success = combinable2.CombineItems(otherItem);
						if (success) new ItemFunctions().UseItemAnim(__instance, myAgent);
					}
				}
				else new ItemFunctions().CombineItems(__instance, myAgent, otherItem, slotNum, "Combine");

				if (__instance.invItemCount < 1 || !__instance.database.InvItemList.Contains(__instance)
					&& InventoryChecks.IsCheckAllowed(custom, "StopOnZero"))
				{
					myAgent.mainGUI.invInterface.HideDraggedItem();
					myAgent.mainGUI.invInterface.HideTarget();
				}
			}
			return false;
		}
		public static bool InvItem_TargetObject(InvItem __instance, PlayfieldObject otherObject, string combineType, ref bool __result)
		{
			CustomItem custom = __instance.GetHook<CustomItem>();

			if (Vector2.Distance(__instance.agent.curPosition, otherObject.curPosition) > 15f
				&& InventoryChecks.IsCheckAllowed(custom, "Distance"))
			{
				__result = false;
				return false;
			}
			if ((otherObject as Agent)?.butlerBot == true && InventoryChecks.IsCheckAllowed(custom, "ButlerBot"))
			{
				__result = false;
				return false;
			}
			if ((otherObject as Agent)?.mechEmpty == true && InventoryChecks.IsCheckAllowed(custom, "EmptyMech"))
			{
				__result = false;
				return false;
			}

			bool firstCheck = custom is IItemTargetable targetable
				? targetable.TargetFilter(otherObject)
				: new ItemFunctions().TargetObject(__instance, __instance.agent, otherObject, string.Empty);

			OnItemTargetingArgs args = new OnItemTargetingArgs(__instance, otherObject, __instance.agent);
			__result = firstCheck && InventoryChecks.onItemTargeting.Raise(args, custom?.ItemInfo.IgnoredChecks);

			if (__result && combineType == "Combine")
			{
				otherObject = args.Target;
				using (AgentSwapper swapper = new AgentSwapper(__instance, args.User))
				{
					if (custom is IItemTargetable targetable2) targetable2.TargetObject(otherObject);
					else new ItemFunctions().TargetObject(__instance, __instance.agent, otherObject, "Combine");

					if (__instance.invItemCount < 1 || !__instance.database.InvItemList.Contains(__instance)
						&& InventoryChecks.IsCheckAllowed(custom, "StopOnZero"))
					{
						__instance.agent.mainGUI.invInterface.HideDraggedItem();
						__instance.agent.mainGUI.invInterface.HideTarget();
					}
				}
			}
			return false;
		}

		private static Color? targetTextColor;
		public static void InvInterface_ShowTarget(InvInterface __instance, InvItem item)
		{
			if (item.itemType != "Combine")
			{
				if (targetTextColor is null) targetTextColor = __instance.cursorTextString3.color;

				CustomItem custom = item.GetHook<CustomItem>();
				if (custom is IItemTargetable targetable)
				{
					CustomTooltip tooltip = targetable.TargetCursorText(item.agent.target.playfieldObject);
					__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
					__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;
				}
			}
		}
		public static void InvInterface_ShowCursorText(InvInterface __instance, PlayfieldObject myPlayfieldObject)
		{
			CustomItem custom = __instance.mainGUI.targetItem?.GetHook<CustomItem>();
			if (custom is IItemTargetable targetable)
			{
				if (targetTextColor is null) targetTextColor = __instance.cursorTextString3.color;

				CustomTooltip tooltip = targetable.TargetCursorText(myPlayfieldObject);
				__instance.cursorTextCanvas3.enabled = true;
				__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
				__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;
				if (string.IsNullOrEmpty(tooltip.Text)) __instance.cursorTextCanvas3.enabled = false;
			}
		}
		public static void InvInterface_HideCursorText(InvInterface __instance)
		{
			CustomItem custom = __instance.mainGUI.targetItem?.GetHook<CustomItem>();
			if (custom is IItemTargetable targetable)
			{
				CustomTooltip tooltip = targetable.TargetCursorText(null);
				__instance.cursorTextCanvas3.enabled = true;
				__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
				__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;
				if (string.IsNullOrEmpty(tooltip.Text)) __instance.cursorTextCanvas3.enabled = false;
			}
		}

		private static Color? combineTextColor;
		public static void InvSlot_SetColor(InvSlot __instance)
		{
			InvItem combiner = __instance.mainGUI.targetItem ?? __instance.database.invInterface.draggedInvItem;
			if (combiner is null) return;
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
					}
					else if ((__instance.slotType != "Toolbar" || __instance.mainGUI.openedInventory) && __instance.slotType != "NPCChest")
					{
						__instance.myImage.color = new Color32(__instance.br, 0, __instance.br, __instance.standardAlpha);
						__instance.itemImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, __instance.fadedItemAlpha);
						__instance.myImage.sprite = __instance.invBoxNormal;
						__instance.toolbarNumTextGo.SetActive(false);
					}

					if (__instance.slotType != "NPCChest" && __instance.slotType != "Chest")
					{
						if (combineTextColor is null) combineTextColor = __instance.toolbarNumText.color;

						CustomTooltip tooltip = combinable.CombineTooltip(combinee);
						__instance.toolbarNumTextGo.SetActive(true);
						__instance.toolbarNumText.text = tooltip.Text ?? string.Empty;
						__instance.toolbarNumText.color = tooltip.Color ?? combineTextColor.Value;
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

		private static Color? countTextColor;
		public static void InvSlot_UpdateInvSlot(InvSlot __instance, Text ___itemText)
		{
			CustomItem custom = __instance.item?.GetHook<CustomItem>();
			if (custom != null)
			{
				if (countTextColor is null) countTextColor = ___itemText.color;

				CustomTooltip tooltip = custom.GetCountString();
				if (tooltip.Text != null)
				{
					___itemText.enabled = true;
					___itemText.text = tooltip.Text;
					___itemText.color = tooltip.Color ?? countTextColor.Value;
				}
			}
		}

		public static void InvInterface_TargetAnywhere(InvInterface __instance, Vector2 myPos, bool pressedButton)
		{
			if (__instance.mainGUI.targetItem != null)
			{
				CustomItem custom = __instance.mainGUI.targetItem.GetHook<CustomItem>();
				__instance.cursorHighlightTargetObjects = custom is IItemTargetable;
				if (custom is IItemTargetableAnywhere targetable)
				{
					if (targetTextColor is null) targetTextColor = __instance.cursorTextString3.color;

					bool filter = targetable.TargetFilter(myPos);
					__instance.cursorHighlight = filter;
					__instance.cursorHighlightTargetAnywhere = filter;
					__instance.mainGUI.agent.targetImage.tr.localScale = Vector3.one;

					CustomTooltip tooltip = targetable.TargetCursorText(myPos);
					__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
					__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;

					if (pressedButton)
					{
						targetable.TargetPosition(myPos);
						if (custom.Count < 1 || !custom.Inventory.InvItemList.Contains(custom.Item))
						{
							__instance.HideDraggedItem();
							__instance.HideTarget();
						}
						__instance.HideTarget();
					}
				}
			}
		}

		private class AgentSwapper : IDisposable
		{
			public AgentSwapper(InvItem item, Agent targetAgent)
			{
				Item = item;
				OriginalAgent = item.agent;
				item.agent = targetAgent;
			}
			public InvItem Item;
			public Agent OriginalAgent;
			public void Dispose() => Item.agent = OriginalAgent;
		}
	}
	public static class DefaultInventoryChecks
	{
		internal static void SubscribeChecks()
		{
			InventoryChecks.AddItemUsingCheck("Ghost", GhostCheck);
			InventoryChecks.AddItemUsingCheck("PeaBrained", PeaBrainedCheck);
			InventoryChecks.AddItemUsingCheck("OnlyOil", OnlyOilCheck);
			InventoryChecks.AddItemUsingCheck("OnlyOilMedicine", OnlyOilMedicineCheck);
			InventoryChecks.AddItemUsingCheck("OnlyBlood", OnlyBloodCheck);
			InventoryChecks.AddItemUsingCheck("OnlyBloodMedicine", OnlyBloodMedicineCheck);
			InventoryChecks.AddItemUsingCheck("OnlyCharge", OnlyChargeCheck);
			InventoryChecks.AddItemUsingCheck("OnlyChargeMedicine", OnlyChargeMedicineCheck);
			InventoryChecks.AddItemUsingCheck("OnlyHumanFlesh", OnlyHumanFleshCheck);
			InventoryChecks.AddItemUsingCheck("FullHealth", FullHealthCheck);
		}

		public static void GhostCheck(OnItemUsingArgs e)
		{
			if (e.User.ghost)
			{
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
		public static void PeaBrainedCheck(OnItemUsingArgs e)
		{
			if (e.Item.itemType != ItemTypes.Food && e.User.HasTrait("CantInteract"))
			{
				e.User.SayDialogue("CantInteract");
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
		public static void OnlyOilCheck(OnItemUsingArgs e)
		{
			if (e.Item.itemType == ItemTypes.Food && (e.Item.Categories.Contains("Food") || e.Item.Categories.Contains("Alcohol"))
				&& e.User.HasTrait("OilRestoresHealth"))
			{
				e.User.SayDialogue("OnlyOilGivesHealth");
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
		public static void OnlyOilMedicineCheck(OnItemUsingArgs e)
		{
			if (e.Item.itemType == ItemTypes.Consumable && e.Item.Categories.Contains("Health")
				&& e.User.HasTrait("OilRestoresHealth"))
			{
				e.User.SayDialogue("OnlyOilGivesHealth");
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
		public static void OnlyBloodCheck(OnItemUsingArgs e)
		{
			if (e.Item.itemType == ItemTypes.Food && (e.Item.Categories.Contains("Food") || e.Item.Categories.Contains("Alcohol"))
				&& e.User.HasTrait("BloodRestoresHealth"))
			{
				e.User.SayDialogue("OnlyBloodGivesHealth");
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
		public static void OnlyBloodMedicineCheck(OnItemUsingArgs e)
		{
			if (e.Item.itemType == ItemTypes.Consumable && e.Item.Categories.Contains("Health")
				&& e.User.HasTrait("BloodRestoresHealth"))
			{
				e.User.SayDialogue("OnlyBloodGivesHealth2");
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
		public static void OnlyChargeCheck(OnItemUsingArgs e)
		{
			if (e.User.electronic && e.Item.itemType == ItemTypes.Food && e.Item.Categories.Contains("Food"))
			{
				e.User.SayDialogue("OnlyChargeGivesHealth");
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
		public static void OnlyChargeMedicineCheck(OnItemUsingArgs e)
		{
			if (e.User.electronic && e.Item.itemType == ItemTypes.Consumable && e.Item.Categories.Contains("Health"))
			{
				e.User.SayDialogue("OnlyChargeGivesHealth");
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
		public static void OnlyHumanFleshCheck(OnItemUsingArgs e)
		{
			if (e.Item.itemType == ItemTypes.Food && e.Item.Categories.Contains("Food")
				&& e.User.HasTrait("CannibalizeRestoresHealth"))
			{
				e.User.SayDialogue("OnlyCannibalizeGivesHealth");
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
		public static void FullHealthCheck(OnItemUsingArgs e)
		{
			if (e.Item.healthChange > 0 && e.User.health == e.User.healthMax)
			{
				e.User.SayDialogue("HealthFullCantUseItem");
				e.User.gc.audioHandler.Play(e.User, "CantDo");
				e.Cancel = e.Handled = true;
			}
		}
	}
}
