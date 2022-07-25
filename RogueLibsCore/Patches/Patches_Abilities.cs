using System;
using System.Collections;
using UnityEngine;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchAbilities()
        {
            Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.GiveSpecialAbility));

            Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.PressedSpecialAbility));
            Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.HeldSpecialAbility));
            Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.ReleasedSpecialAbility));

            Patcher.Prefix(typeof(StatusEffects), "RechargeSpecialAbility2");
            Patcher.Prefix(typeof(StatusEffects), "SpecialAbilityInterfaceCheck2");

            Patcher.Postfix(typeof(SpecialAbilityIndicator), nameof(SpecialAbilityIndicator.ShowIndicator),
                new Type[3] { typeof(PlayfieldObject), typeof(string), typeof(string) });

            Patcher.AnyErrors();
        }

        public static void StatusEffects_GiveSpecialAbility(StatusEffects __instance)
        {
            if (GameController.gameController.levelType == "HomeBase"
                && !__instance.agent.isDummy && __instance.agent.agentName != VanillaAgents.MechEmpty) return;
            CustomAbility? custom = __instance.agent.GetAbility();
            if (custom is null) return;

            if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
                RogueFramework.LogDebug($"Giving ability {custom} ({__instance.agent.specialAbility}, {__instance.agent.agentName}).");

            try { custom.OnAdded(); }
            catch (Exception e) { RogueFramework.LogError(e, "CustomAbility.OnAdded", custom, __instance.agent); }

            if (custom is IAbilityTargetable)
                __instance.SpecialAbilityInterfaceCheck();
            if (custom is IAbilityRechargeable)
                __instance.RechargeSpecialAbility(custom.ItemInfo.Name);
        }

        public static void StatusEffects_PressedSpecialAbility(StatusEffects __instance)
        {
            CustomAbility? custom = __instance.agent.GetAbility();
            if (custom is null) return;
            if (custom.Item.invItemName != __instance.agent.specialAbility) return;

            if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
                RogueFramework.LogDebug($"Pressing ability ability {custom} ({__instance.agent.specialAbility}, {__instance.agent.agentName}).");

            try { custom.OnPressed(); }
            catch (Exception e) { RogueFramework.LogError(e, "CustomAbility.OnPressed", custom, __instance.agent); }
            if (custom.Count > 0)
                __instance.agent.inventory.buffDisplay.specialAbilitySlot.MakeNotUsable();
        }
        public static void StatusEffects_HeldSpecialAbility(StatusEffects __instance)
        {
            CustomAbility? custom = __instance.agent.GetAbility();
            if (custom is not IAbilityChargeable chargeable) return;
            if (custom.Item.invItemName != __instance.agent.specialAbility) return;

            ref float held = ref GameController.gameController.playerControl.pressedSpecialAbilityTime[__instance.agent.isPlayer - 1];
            float prevHeld = held;

            if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
                RogueFramework.LogDebug($"Holding ability {custom} for {prevHeld}s ({__instance.agent.specialAbility}, {__instance.agent.agentName}).");

            AbilityHeldArgs args = new AbilityHeldArgs { HeldTime = prevHeld };
            try { chargeable.OnHeld(args); }
            catch (Exception e) { RogueFramework.LogError(e, "CustomAbility.OnHeld", custom, __instance.agent); }

            held = args.HeldTime;
            custom.lastHeld = prevHeld;
            if (held == 0f)
                __instance.ReleasedSpecialAbility();
        }
        public static void StatusEffects_ReleasedSpecialAbility(StatusEffects __instance)
        {
            CustomAbility? custom = __instance.agent.GetAbility();
            if (custom is not IAbilityChargeable chargeable) return;
            if (custom.Item.invItemName != __instance.agent.specialAbility) return;

            float prevHeld = custom.lastHeld;
            if (prevHeld is 0f) return;

            if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
                RogueFramework.LogDebug($"Releasing ability {custom} - {prevHeld}s ({__instance.agent.specialAbility}, {__instance.agent.agentName}).");

            custom.lastHeld = 0f;
            try { chargeable.OnReleased(new AbilityReleasedArgs(prevHeld)); }
            catch (Exception e) { RogueFramework.LogError(e, "CustomAbility.OnReleased", custom, __instance.agent); }
        }

        public static bool StatusEffects_RechargeSpecialAbility2(StatusEffects __instance, ref IEnumerator __result)
        {
            CustomAbility? custom = __instance.agent.inventory.equippedSpecialAbility.GetHook<CustomAbility>();
            if (custom is not IAbilityRechargeable) return true;
            if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
                RogueFramework.LogDebug($"Starting {custom} recharge coroutine ({custom.Item.invItemName}, {__instance.agent.agentName}).");
            __result = AbilityRechargeEnumerator(__instance, custom);
            return false;
        }
        public static IEnumerator AbilityRechargeEnumerator(StatusEffects __instance, CustomAbility ability)
        {
            __instance.startedRechargeSpecialAbility = true;
            __instance.rechargesSpecialAbility = true;
            float countSpeed = 1f;
            bool showBuffText = true;
            while (__instance.agent.inventory.equippedSpecialAbility == ability.Item)
            {
                InvItem item = __instance.agent.inventory.equippedSpecialAbility;
                if (item.invItemCount > 0)
                {
                    AbilityRechargingArgs args = new AbilityRechargingArgs { UpdateDelay = countSpeed, ShowRechargedText = showBuffText };
                    ((IAbilityRechargeable)ability).OnRecharging(args);
                    countSpeed = args.UpdateDelay;
                    showBuffText = args.ShowRechargedText;

                    yield return countSpeed > 0 ? new WaitForSeconds(countSpeed) : null;

                    if (__instance.agent.inventory.equippedSpecialAbility != ability.Item) break;
                    if (item.invItemCount == 0)
                    {
                        if (showBuffText)
                        {
                            __instance.CreateBuffText("Recharged", __instance.agent.objectNetID);
                            GameController.gameController.audioHandler.Play(__instance.agent, VanillaAudio.Recharge);
                        }

                        if (ability is not IAbilityTargetable)
                            __instance.agent.inventory.buffDisplay?.specialAbilitySlot.MakeUsable();
                    }
                }
                else yield return null;
            }
            __instance.startedRechargeSpecialAbility = false;
            __instance.rechargesSpecialAbility = false;
        }

        public static bool StatusEffects_SpecialAbilityInterfaceCheck2(StatusEffects __instance, ref IEnumerator __result)
        {
            CustomAbility? custom = __instance.agent.inventory.equippedSpecialAbility.GetHook<CustomAbility>();
            if (custom is not IAbilityTargetable) return true;
            if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
                RogueFramework.LogDebug($"Starting {custom} indicator coroutine ({custom.Item.invItemName}, {__instance.agent.agentName}).");
            __result = AbilityIndicatorEnumerator(__instance, custom);
            return false;
        }
        public static IEnumerator AbilityIndicatorEnumerator(StatusEffects __instance, CustomAbility ability)
        {
            __instance.startedSpecialAbilityInterfaceCheck = true;
            while (__instance.agent.inventory.equippedSpecialAbility == ability.Item)
            {
                InvItem item = __instance.agent.inventory.equippedSpecialAbility;

                ability.CurrentTarget = ((IAbilityTargetable)ability).FindTarget();

                if (GameController.gameController.loadComplete && __instance.agent.specialAbilityIndicator != null && !__instance.agent.disappearedArcade && __instance.agent.inventory.buffDisplay.specialAbilitySlot != null && !__instance.agent.ghost)
                {
                    if ((item.invItemCount == 0 || ability is not IAbilityRechargeable) && __instance.CanShowSpecialAbilityIndicator()
                                                                                        && ability.CurrentTarget != null)
                    {
                        abilitySlot = __instance.agent.inventory.buffDisplay.specialAbilitySlot;
                        __instance.agent.specialAbilityIndicator.ShowIndicator(ability.CurrentTarget, ability.Item.invItemName);
                        abilitySlot.MakeUsable();
                        abilitySlot = null;
                    }
                    else
                    {
                        __instance.agent.specialAbilityIndicator.Revert();
                    }
                }
                yield return new WaitForSeconds(0.1f);
            }
            __instance.startedSpecialAbilityInterfaceCheck = false;
        }
        private static EquippedItemSlot? abilitySlot;

        public static void SpecialAbilityIndicator_ShowIndicator(SpecialAbilityIndicator __instance)
        {
            CustomAbility? ability = abilitySlot?.item.GetHook<CustomAbility>();
            if (ability != null)
            {
                Sprite? spr = ability.GetIndicator();
                __instance.image.sprite = spr;
                __instance.image.enabled = spr != null;
            }
        }
    }
}
