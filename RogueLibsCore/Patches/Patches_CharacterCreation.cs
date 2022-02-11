using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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

            List<DisplayedUnlock> displayedList = myUnlockList.Select(static u => u.__RogueLibsCustom).OfType<DisplayedUnlock>().ToList();
            if (unlockType is UnlockTypes.Ability or UnlockTypes.BigQuest)
                displayedList.RemoveAll(static u => u is IUnlockInCC { IsAvailableInCC: false });

            CustomCharacterCreation menu = new CustomCharacterCreation(__instance, displayedList);
            if (RogueFramework.IsDebugEnabled(DebugFlags.UnlockMenus))
                RogueFramework.LogDebug($"Setting up \"{menu.Type}\" menu.");

            foreach (DisplayedUnlock du in menu.Unlocks)
                du.Menu = menu;
            menu.Unlocks.ForEach(static du => du.UpdateUnlock());
            menu.Unlocks.Sort();

            List<Unlock> listUnlocks = unlockType == UnlockTypes.Item ? __instance.listUnlocksItems
                : unlockType == UnlockTypes.Trait ? __instance.listUnlocksTraits
                : unlockType == UnlockTypes.Ability ? __instance.listUnlocksAbilities
                : unlockType == UnlockTypes.BigQuest ? __instance.listUnlocksBigQuests
                : throw new InvalidOperationException("Unknown character creation menu type.");
            listUnlocks.Clear();
            listUnlocks.AddRange(menu.Unlocks.Select(static du => du.Unlock));

            if (unlockType == UnlockTypes.Item)
            {
                ClearAllItems.Menu = menu;
                listUnlocks.Insert(0, ClearAllItems.Unlock);
            }
            else if (unlockType == UnlockTypes.Trait)
            {
                ClearAllTraits.Menu = menu;
                listUnlocks.Insert(0, ClearAllTraits.Unlock);
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
                : type == UnlockTypes.BigQuest ? __instance.buttonsDataBigQuests
                : throw new InvalidOperationException("Unknown character creation menu type.");

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
            if (__instance.agent.controllerType == "Gamepad" && !__instance.refreshing)
            {
                __instance.scrollBarLoad.value = Mathf.Clamp01(1f - __instance.yOffset / ((__instance.numButtonsLoad - __instance.numButtonsOnScreen + 1f) * __instance.yOffset) * (myButton.scrollingButtonNum - (__instance.numButtonsOnScreen / 2f - 1f)));

                Scrollbar? bar;
                float numButtons;
                if (myButton.scrollingButtonUnlock.unlockType == UnlockTypes.Item)
                { bar = __instance.scrollBarItems; numButtons = __instance.numButtonsItems; }
                else if (myButton.scrollingButtonUnlock.unlockType == UnlockTypes.Trait)
                { bar = __instance.scrollBarTraits; numButtons = __instance.numButtonsTraits; }
                else if (myButton.scrollingButtonUnlock.unlockType == UnlockTypes.Ability)
                { bar = __instance.scrollBarAbilities; numButtons = __instance.numButtonsAbilities; }
                else if (myButton.scrollingButtonUnlock.unlockType == UnlockTypes.BigQuest)
                { bar = __instance.scrollBarBigQuests; numButtons = __instance.numButtonsBigQuests; }
                else
                { bar = null; numButtons = 0f; }

                if (bar != null)
                    bar.value = Mathf.Clamp01(1f - __instance.yOffset / ((numButtons - __instance.numButtonsOnScreen + 2f) * __instance.yOffset) * (myButton.scrollingButtonNum - (__instance.numButtonsOnScreen / 2f - 1f)));
            }

            Image? image = null; Text? title = null; Text? text = null;
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

                bool show = du.IsUnlocked || du.Unlock.nowAvailable || du.Menu!.ShowLockedUnlocks;
                title!.text = show ? du.GetName() : "?????";
                text!.text = du.GetFancyDescription();
                image.sprite = show ? du.GetImage() : null;
                image.gameObject.SetActive(image.sprite != null);
            }

            __instance.curSelectedButton = myButton;
            __instance.curSelectedButtonNum = myButton.scrollingButtonNum;
            return false;
        }
    }
}
