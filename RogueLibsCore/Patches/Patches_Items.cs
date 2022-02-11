using System;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchItems()
        {
            // Create and initialize item hooks
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
            Patcher.Postfix(typeof(InvSlot), "LateUpdate");
            Patcher.Postfix(typeof(EquippedItemSlot), nameof(EquippedItemSlot.LateUpdateEquippedItemSlot));

            // CustomItem, IItemTargetableAnywhere patches
            Patcher.Postfix(typeof(InvInterface), nameof(InvInterface.TargetAnywhere));

            Patcher.AnyErrors();

            DefaultInventoryChecks.SubscribeChecks();
        }

        public static void InvItem_SetupDetails(InvItem __instance)
        {
            bool debug = RogueFramework.IsDebugEnabled(DebugFlags.Items);
            bool debug2 = RogueFramework.IsDebugEnabled(DebugFlags.Abilities);
            foreach (IHookFactory<InvItem> factory in RogueFramework.ItemFactories)
                if (factory.TryCreate(__instance, out IHook<InvItem>? hook))
                {
                    if (debug2 && hook is CustomAbility)
                        RogueFramework.LogDebug($"Initializing custom ability {hook} ({__instance.invItemName}).");
                    else if (debug)
                    {
                        RogueFramework.LogDebug(hook is CustomItem
                                                    ? $"Initializing custom item {hook} ({__instance.invItemName})."
                                                    : $"Initializing item hook {hook} for \"{__instance.invItemName}\".");
                    }
                    __instance.AddHook(hook!);
                }
        }

        public static bool ItemFunctions_UseItem(InvItem item, Agent agent)
        {
            bool debug = RogueFramework.IsDebugEnabled(DebugFlags.Items);
            CustomItem? custom = item.GetHook<CustomItem>();
            if (custom is IItemTargetable or IItemTargetableAnywhere)
            {
                if (debug) RogueFramework.LogDebug($"Showing target for {custom} ({item.invItemName}).");
                item.invInterface.ShowOrHideTarget(item);
                return false;
            }

            if (debug) RogueFramework.LogDebug($"Using {custom} ({item.invItemName}):");

            Agent originalAgent = agent;
            OnItemUsingArgs args = new OnItemUsingArgs(item, agent);
            if (InventoryChecks.onItemUsing.Raise(args, custom?.ItemInfo.IgnoredChecks))
            {
                agent = args.User;
                // in case an inventory check redirected the use of an item on someone else
                using (new AgentSwapper(item, agent))
                {
                    if (agent.localPlayer)
                    {
                        if (!originalAgent.inventory.HasItem(item.invItemName)
                            && originalAgent.inventory.equippedSpecialAbility?.invItemName != item.invItemName)
                            return false;
                        if (!item.used && (item.Categories.Contains(RogueCategories.Usable) || item.itemType == ItemTypes.Consumable))
                        {
                            item.used = true;
                            if (agent.isPlayer > 0) agent.gc.sessionData.endStats[agent.isPlayer].itemsUsed++;
                        }
                    }
                    // if it's not a custom item, run the original method
                    if (custom is not IItemUsable usable)
                    {
                        if (debug) RogueFramework.LogDebug("---- Running the original method.");
                        return true;
                    }

                    bool success = usable.UseItem();
                    if (debug) RogueFramework.LogDebug($"---- Usage {(success ? "was successful" : "failed")}.");
                    if (success) new ItemFunctions().UseItemAnim(item, agent);
                }
            }
            else
            {
                if (debug) RogueFramework.LogDebug("---- Usage was prevented by an inventory check.");
            }
            return false;
        }

        public static bool InvItem_CombineItems(InvItem __instance, InvItem otherItem, int slotNum, Agent myAgent, string combineType, out bool __result)
        {
            bool debug = RogueFramework.IsDebugEnabled(DebugFlags.Items);
            bool actualCombining = combineType == "Combine";
            CustomItem? custom = __instance.GetHook<CustomItem>();

            if (debug && actualCombining) RogueFramework.LogDebug($"Combining {custom} ({__instance.invItemName}) with {otherItem.invItemName}:");

            if (__instance.stackable && __instance.invItemName == otherItem.invItemName
                && InventoryChecks.IsCheckAllowed(custom, "AutoStacking"))
            {
                if (__instance.invItemName == VanillaItems.Syringe && __instance.contents[0] != otherItem.contents[0])
                {
                    __result = false;
                    return false;
                }
                if (actualCombining)
                {
                    if (debug)
                    {
                        RogueFramework.LogDebug("---- Triggered \"AutoStacking\" inventory check.");
                        RogueFramework.LogDebug("---- Combining was prevented by an inventory check.");
                    }
                    if (myAgent.controllerType != "Keyboard")
                        myAgent.gc.audioHandler.Play(myAgent, VanillaAudio.BeginCombine);
                    otherItem.agent.mainGUI.invInterface.PutDraggedItemBack();
                }
                __result = true;
                return false;
            }

            if (custom is IItemCombinable combinable)
            {
                using (new AgentSwapper(__instance, myAgent))
                    __result = combinable.CombineFilter(otherItem);
            }
            else __result = new ItemFunctions().CombineItems(__instance, myAgent, otherItem, slotNum, string.Empty);

            if (actualCombining)
            {
                OnItemsCombiningArgs args = new OnItemsCombiningArgs(__instance, otherItem, myAgent);
                if (InventoryChecks.onItemsCombining.Raise(args, custom?.ItemInfo.IgnoredChecks))
                {
                    myAgent = args.Combiner;
                    otherItem = args.OtherItem;
                    if (custom is IItemCombinable combinable2)
                    {
                        using (new AgentSwapper(__instance, myAgent))
                        {
                            bool success = combinable2.CombineItems(otherItem);
                            if (debug) RogueFramework.LogDebug($"---- Combining {(success ? "was successful" : "failed")}.");
                            if (success) new ItemFunctions().UseItemAnim(__instance, myAgent);
                        }
                    }
                    else
                    {
                        if (debug) RogueFramework.LogDebug("---- Running the original method.");
                        new ItemFunctions().CombineItems(__instance, myAgent, otherItem, slotNum, "Combine");
                    }

                    if (__instance.invItemCount < 1 || !__instance.database.InvItemList.Contains(__instance)
                        && InventoryChecks.IsCheckAllowed(custom, "StopOnZero"))
                    {
                        if (debug) RogueFramework.LogDebug("---- Triggered \"StopOnZero\" inventory check.");
                        myAgent.mainGUI.invInterface.HideDraggedItem();
                        myAgent.mainGUI.invInterface.HideTarget();
                    }
                }
                else
                {
                    if (debug) RogueFramework.LogDebug("---- Combining was prevented by an inventory check.");
                }
            }
            return false;
        }
        public static bool InvItem_TargetObject(InvItem __instance, PlayfieldObject otherObject, string combineType, out bool __result)
        {
            bool debug = RogueFramework.IsDebugEnabled(DebugFlags.Items);
            bool actualCombining = combineType == "Combine";
            CustomItem? custom = __instance.GetHook<CustomItem>();

            if (debug && actualCombining) RogueFramework.LogDebug($"Targeting {custom} ({__instance.invItemName}) on {otherObject.objectName}:");

            if (Vector2.Distance(__instance.agent.curPosition, otherObject.curPosition) > 15f
                && InventoryChecks.IsCheckAllowed(custom, "Distance"))
            {
                if (debug && actualCombining)
                {
                    RogueFramework.LogDebug("---- Triggered \"Distance\" inventory check.");
                    RogueFramework.LogDebug("---- Targeting was prevented by an inventory check.");
                }
                __result = false;
                return false;
            }
            if ((otherObject as Agent)?.butlerBot == true && InventoryChecks.IsCheckAllowed(custom, "ButlerBot"))
            {
                if (debug && actualCombining)
                {
                    RogueFramework.LogDebug("---- Triggered \"ButlerBot\" inventory check.");
                    RogueFramework.LogDebug("---- Targeting was prevented by an inventory check.");
                }
                __result = false;
                return false;
            }
            if ((otherObject as Agent)?.mechEmpty == true && InventoryChecks.IsCheckAllowed(custom, "EmptyMech"))
            {
                if (debug && actualCombining)
                {
                    RogueFramework.LogDebug("---- Triggered \"EmptyMech\" inventory check.");
                    RogueFramework.LogDebug("---- Targeting was prevented by an inventory check.");
                }
                __result = false;
                return false;
            }

            __result = custom is IItemTargetable targetable
                ? targetable.TargetFilter(otherObject)
                : new ItemFunctions().TargetObject(__instance, __instance.agent, otherObject, string.Empty);

            if (actualCombining)
            {
                OnItemTargetingArgs args = new OnItemTargetingArgs(__instance, otherObject, __instance.agent);
                if (InventoryChecks.onItemTargeting.Raise(args, custom?.ItemInfo.IgnoredChecks))
                {
                    otherObject = args.Target;
                    using (new AgentSwapper(__instance, args.User))
                    {
                        if (custom is IItemTargetable targetable2)
                        {
                            bool success = targetable2.TargetObject(otherObject);
                            if (debug) RogueFramework.LogDebug($"---- Targeting {(success ? "was successful" : "failed")}.");
                            if (success) new ItemFunctions().UseItemAnim(__instance, __instance.agent);
                        }
                        else
                        {
                            if (debug) RogueFramework.LogDebug("---- Running the original method.");
                            new ItemFunctions().TargetObject(__instance, __instance.agent, otherObject, "Combine");
                        }

                        if (__instance.invItemCount < 1 || !__instance.database.InvItemList.Contains(__instance)
                            && InventoryChecks.IsCheckAllowed(custom, "StopOnZero"))
                        {
                            if (debug) RogueFramework.LogDebug("---- Triggered \"StopOnZero\" inventory check.");
                            __instance.agent.mainGUI.invInterface.HideDraggedItem();
                            __instance.agent.mainGUI.invInterface.HideTarget();
                        }
                    }
                }
                else
                {
                    if (debug) RogueFramework.LogDebug("---- Targeting was prevented by an inventory check.");
                }
            }
            return false;
        }

        public static void InvInterface_ShowTarget(InvInterface __instance, InvItem item)
        {
            __instance.cursorTextString3.color = Color.white;

            if (item.itemType != ItemTypes.Combine)
            {
                CustomItem? custom = item.GetHook<CustomItem>();
                if (custom is IItemTargetable targetable)
                {
                    CustomTooltip tooltip = targetable.TargetCursorText(item.agent.target.playfieldObject);
                    __instance.cursorTextCanvas3.enabled = !string.IsNullOrEmpty(tooltip.Text);
                    __instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
                    __instance.cursorTextString3.color = tooltip.Color ?? Color.white;
                }
            }
        }
        public static void InvInterface_ShowCursorText(InvInterface __instance, PlayfieldObject myPlayfieldObject)
        {
            __instance.cursorTextString3.color = Color.white;

            CustomItem? custom = __instance.mainGUI.targetItem?.GetHook<CustomItem>();
            if (custom is IItemTargetable targetable)
            {
                CustomTooltip tooltip = targetable.TargetCursorText(myPlayfieldObject);
                __instance.cursorTextCanvas3.enabled = !string.IsNullOrEmpty(tooltip.Text);
                __instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
                __instance.cursorTextString3.color = tooltip.Color ?? Color.white;
            }
        }
        public static void InvInterface_HideCursorText(InvInterface __instance)
        {
            CustomItem? custom = __instance.mainGUI.targetItem?.GetHook<CustomItem>();
            if (custom is IItemTargetable targetable)
            {
                CustomTooltip tooltip = targetable.TargetCursorText(null);
                __instance.cursorTextCanvas3.enabled = !string.IsNullOrEmpty(tooltip.Text);
                __instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
                __instance.cursorTextString3.color = tooltip.Color ?? Color.white;
            }
        }

        public static void InvSlot_SetColor(InvSlot __instance)
        {
            // set default color
            __instance.toolbarNumText.color = new Color32(255, 237, 0, 255);

            InvItem combiner = __instance.mainGUI.targetItem ?? __instance.database.invInterface.draggedInvItem;
            if (combiner is null) return;
            InvItem combinee = __instance.curItemList[__instance.slotNumber];

            CustomItem? custom = combiner.GetHook<CustomItem>();
            if (custom is not IItemCombinable combinable) return;

            if (__instance.slotType is "Player" or "Toolbar" or "Chest" or "NPCChest")
            {
                if (combinee.invItemName != null && combiner.itemType == ItemTypes.Combine)
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

                    if (__instance.slotType is not "NPCChest" and not "Chest")
                    {
                        CustomTooltip tooltip = combinable.CombineTooltip(combinee);
                        __instance.toolbarNumTextGo.SetActive(true);
                        __instance.toolbarNumText.text = tooltip.Text ?? string.Empty;
                        __instance.toolbarNumText.color = tooltip.Color ?? new Color32(255, 237, 0, 255);
                    }
                }
                else if (__instance.slotType != "NPCChest" && (combinee.invItemName != null || combiner.itemType != ItemTypes.Combine))
                {
                    __instance.myImage.color = __instance.overSlot
                        ? new Color32(0, __instance.br, __instance.br, __instance.standardAlpha)
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

        public static void InvSlot_LateUpdate(InvSlot __instance, Text ___itemText)
        {
            CustomItem? custom = __instance.item?.GetHook<CustomItem>();
            if (custom != null)
            {
                ___itemText.enabled = true;
                CustomTooltip tooltip = custom.GetCountString();
                ___itemText.text = tooltip.Text ?? string.Empty;
                ___itemText.color = tooltip.Color ?? Color.white;
            }
        }
        public static void EquippedItemSlot_LateUpdateEquippedItemSlot(EquippedItemSlot __instance)
        {
            CustomItem? custom = __instance.item?.GetHook<CustomItem>();
            if (custom != null)
            {
                __instance.countText.enabled = true;
                __instance.countText.rectTransform.localScale = new Vector3(0.2f, 0.2f, 1f);
                CustomTooltip tooltip = custom.GetCountString();
                __instance.countText.text = tooltip.Text ?? string.Empty;
                __instance.countText.color = tooltip.Color ?? Color.white;
            }
        }

        public static void InvInterface_TargetAnywhere(InvInterface __instance, Vector2 myPos, bool pressedButton)
        {
            __instance.cursorTextString3.color = Color.white;

            bool debug = RogueFramework.IsDebugEnabled(DebugFlags.Items);
            InvItem invItem = __instance.mainGUI.targetItem;
            if (invItem != null)
            {
                CustomItem? custom = invItem.GetHook<CustomItem>();
                __instance.cursorHighlightTargetObjects = custom is IItemTargetable;
                if (custom is IItemTargetableAnywhere targetable)
                {
                    if (debug && pressedButton)
                        RogueFramework.LogDebug($"Targeting {custom} ({invItem.invItemName}) anywhere:");

                    bool filter = targetable.TargetFilter(myPos);
                    __instance.cursorHighlight = filter;
                    __instance.cursorHighlightTargetAnywhere = filter;
                    __instance.mainGUI.agent.targetImage.tr.localScale = Vector3.one;

                    CustomTooltip tooltip = targetable.TargetCursorText(myPos);
                    __instance.cursorTextCanvas3.enabled = !string.IsNullOrEmpty(tooltip.Text);
                    __instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
                    __instance.cursorTextString3.color = tooltip.Color ?? Color.white;

                    if (pressedButton)
                    {
                        OnItemTargetingAnywhereArgs args = new OnItemTargetingAnywhereArgs(invItem, myPos, invItem.agent);
                        if (InventoryChecks.onItemTargetingAnywhere.Raise(args, custom.ItemInfo.IgnoredChecks))
                        {
                            myPos = args.Target;
                            using (new AgentSwapper(invItem, args.User))
                            {
                                bool success = targetable.TargetPosition(myPos);
                                if (debug) RogueFramework.LogDebug($"---- Targeting {(success ? "was successful" : "failed")}.");
                                if (success) new ItemFunctions().UseItemAnim(invItem, invItem.agent);

                                if (custom.Count < 1 || !custom.Inventory!.InvItemList.Contains(custom.Item)
                                    && InventoryChecks.IsCheckAllowed(custom, "StopOnZero"))
                                {
                                    if (debug) RogueFramework.LogDebug("---- Triggered \"StopOnZero\" inventory check.");
                                    __instance.HideDraggedItem();
                                    __instance.HideTarget();
                                }
                            }
                        }
                        else
                        {
                            if (debug) RogueFramework.LogDebug("---- Targeting was prevented by an inventory check.");
                        }
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
            public readonly InvItem Item;
            public readonly Agent OriginalAgent;
            public void Dispose() => Item.agent = OriginalAgent;
        }
    }
}
