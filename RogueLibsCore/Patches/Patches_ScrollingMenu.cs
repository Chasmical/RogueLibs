using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchScrollingMenu()
        {
            ClearAllMutators = new ClearAllMutatorsUnlock();
            ClearAllItems = new ClearAllItemsUnlock();
            ClearAllTraits = new ClearAllTraitsUnlock();
            ReRollLoadouts = new ReRollLoadoutsUnlock();

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

            Patcher.AnyErrors();
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

            if (__instance.menuType is "Challenges" or "FreeItems")
            {
                __instance.nuggetSlot.gameObject.SetActive(true);
            }
            else if (__instance.menuType == "Floors")
            {
                List<DisplayedUnlock> displayedUnlocks = GameController.gameController.sessionDataBig.floorUnlocks
                                                                       .Select(static u => (DisplayedUnlock)u.GetHook()!)
                                                                       .OrderBy(static d => d).ToList();
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
                List<DisplayedUnlock> displayedUnlocks = __instance.smallTraitList
                                                                   .Select(static u => (DisplayedUnlock)u.GetHook()!)
                                                                   .OrderBy(static d => d).ToList();
                CustomScrollingMenu menu = new CustomScrollingMenu(__instance, displayedUnlocks);

                foreach (DisplayedUnlock du in displayedUnlocks)
                    du.Menu = menu;

                foreach (ButtonData buttonData in __instance.buttonsData)
                    SetupUnlocks(buttonData, buttonData.scrollingButtonUnlock);
            }
            else if (__instance.menuType is "RemoveTrait" or "ChangeTraitRandom" or "UpgradeTrait")
            {
                __instance.numButtons = __instance.customTraitList.Count;
                List<DisplayedUnlock> displayedUnlocks = __instance.customTraitList
                                                                   .Select(static u => (DisplayedUnlock)u.GetHook()!)
                                                                   .OrderBy(static d => d).ToList();
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
            DisplayedUnlock du = (DisplayedUnlock)myUnlock.GetHook()!;
            HookSystem.SetHook(myButtonData, du);
            du.ButtonData = myButtonData;

            myButtonData.scrollingButtonUnlock = myUnlock;
            myButtonData.scrollingButtonType = myUnlock.unlockName;
            myButtonData.interactable = true;
            myButtonData.buttonText = du.GetFancyName();

            du.UpdateUnlock();
            du.UpdateButton();
            return false;
        }

        public static ClearAllMutatorsUnlock ClearAllMutators = null!; // initialized in PatchScrollingMenu()
        public static ClearAllItemsUnlock ClearAllItems = null!;
        public static ClearAllTraitsUnlock ClearAllTraits = null!;
        public static ReRollLoadoutsUnlock ReRollLoadouts = null!;

        public static bool ScrollingMenu_SortUnlocks(ScrollingMenu __instance, List<Unlock> myUnlockList, List<Unlock> ___listUnlocks)
        {
            List<DisplayedUnlock> displayedList = myUnlockList.ConvertAll(static u => (DisplayedUnlock)u.GetHook()!);
            if (__instance.menuType == "FreeItems")
                displayedList.RemoveAll(static u => u is ItemUnlock { IsAvailableInItemTeleporter: false });

            CustomScrollingMenu menu = new CustomScrollingMenu(__instance, displayedList);

            foreach (DisplayedUnlock du in menu.Unlocks)
                du.Menu = menu;
            menu.Unlocks.ForEach(static du => du.UpdateUnlock());
            menu.Unlocks.Sort();

            ___listUnlocks.Clear();
            ___listUnlocks.AddRange(menu.Unlocks.Select(static du => du.Unlock));

            if (menu.Type == UnlocksMenuType.Loadouts)
            {
                ReRollLoadouts.Menu = menu;
                ___listUnlocks.Insert(0, ReRollLoadouts.Unlock);
            }
            if (menu.Type == UnlocksMenuType.MutatorMenu)
            {
                __instance.nuggetSlot.gameObject.SetActive(true);
                ClearAllMutators.Menu = menu;
                ___listUnlocks.Insert(0, ClearAllMutators.Unlock);
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
            if (__instance.menuType.EndsWith("Configs", StringComparison.Ordinal)) return true;

            ButtonData buttonData = __instance.buttonsData[myButton.scrollingButtonNum];
            DisplayedUnlock du = (DisplayedUnlock)buttonData.GetHook()!;

            try { du.OnPushedButton(); }
            catch (Exception e) { RogueFramework.LogError(e, "DisplayedUnlock.OnPushedButton", du, du.Menu); }
            return false;
        }

        public static bool ScrollingMenu_ShowDetails(ScrollingMenu __instance, ButtonHelper myButton)
        {
            if (__instance.agent != null && myButton.scrollingButtonUnlock?.unlockType == "Trait" && __instance.agent.addedEndLevelTrait || !string.IsNullOrEmpty(myButton.scrollingButtonLevelFeeling) || !string.IsNullOrEmpty(myButton.scrollingButtonConfigName) || !string.IsNullOrEmpty(myButton.scrollingButtonAgentName))
                return true;
            DisplayedUnlock du = (DisplayedUnlock)myButton.scrollingButtonUnlock!.GetHook()!;

            bool show = du.IsUnlocked || du.Unlock.nowAvailable || du.Menu!.ShowLockedUnlocks;
            __instance.detailsTitle.text = show ? du.GetName() : "?????";
            __instance.detailsText.text = du.GetFancyDescription();
            __instance.detailsImage.sprite = show ? du.GetImage() : null;
            __instance.detailsImage.gameObject.SetActive(__instance.detailsImage.sprite != null);

            // Gamepad scrolling fix
            __instance.curSelectedButtonNum = myButton.scrollingButtonNum;
            if (__instance.menuType == "FreeItems" && __instance.setInitialSelectedChildFreeItems)
                __instance.curSelectedChildFreeItems = myButton.scrollingButtonNum;
            __instance.curSelectedButton = myButton;
            if (__instance.agent!.controllerType == "Gamepad")
            {
                if (!__instance.refreshing)
                {
                    __instance.scrollBar.value = Mathf.Clamp01(1f - __instance.yOffset / ((__instance.numButtons - __instance.numButtonsOnScreen + 1f) * __instance.yOffset) * (myButton.scrollingButtonNum - (__instance.numButtonsOnScreen / 2f - 1f)));
                }
                if (__instance.menuType is "TraitUnlocks" or "Items" && !__instance.isPersonal)
                {
                    __instance.instructionText2.text
                        = myButton.scrollingButtonUnlock.unlocked
                              ? __instance.gc.nameDB.GetName(myButton.scrollingButtonUnlock.notActive
                                                                 ? "AddToPool" : "RemoveFromPool", "Interface")
                              : __instance.gc.nameDB.GetName("ScrollingInstr4", "Interface");
                }
            }

            return false;
        }

        public static void ScrollingMenu_RefreshLoadouts(List<Unlock> ___loadoutList)
        {
            ___loadoutList.RemoveAt(0);
            foreach (Unlock unlock in ___loadoutList.ToArray())
            {
                if (unlock.GetHook() is null)
                {
                    Unlock? normalized = GameController.gameController.sessionDataBig.unlocks
                                                       .Find(u => u.unlockName == unlock.unlockName && u.unlockType == unlock.unlockType);
                    if (normalized is null) ___loadoutList.Remove(unlock);
                    else HookSystem.SetHook(unlock, normalized.GetHook()!);
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
                    Unlock? traitUnlock = RogueLibs.GetUnlock(trait.traitName, UnlockTypes.Trait)?.Unlock;
                    if (traitUnlock?.cancellations.Contains(myUnlock.unlockName) == true)
                    {
                        __result = false;
                        return;
                    }
                }
            }
        }
    }
}
