using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a trait unlock.</para>
    /// </summary>
    public class TraitUnlock : DisplayedUnlock, IUnlockInCC
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="TraitUnlock"/> class without a name.</para>
        /// </summary>
        public TraitUnlock() : this(null!, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="TraitUnlock"/> class without a name.</para>
        /// </summary>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public TraitUnlock(bool unlockedFromStart) : this(null!, unlockedFromStart) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="TraitUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The name of the unlock.</param>
        public TraitUnlock(string name) : this(name, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="TraitUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The name of the unlock.</param>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public TraitUnlock(string name, bool unlockedFromStart) : base(name, UnlockTypes.Trait, unlockedFromStart) => IsAvailableInCC = true;
        internal TraitUnlock(Unlock unlock) : base(unlock) { }

        /// <inheritdoc/>
        public override bool IsEnabled
        {
            get => !Unlock.notActive;
            set => Unlock.notActive = !value;
        }
        /// <inheritdoc/>
        public bool IsAddedToCC
        {
            get
            {
                if (Menu is not CustomCharacterCreation cc)
                    throw new InvalidOperationException("The unlock is not in the character creation menu.");
                return cc.CC.traitsChosen.Contains(Unlock);
            }
            set
            {
                if (Menu is not CustomCharacterCreation cc)
                    throw new InvalidOperationException("The unlock is not in the character creation menu.");
                List<Unlock> list = cc.CC.traitsChosen;
                bool cur = list.Contains(Unlock);
                if (cur && !value) list.Remove(Unlock);
                else if (!cur && value) list.Add(Unlock);
            }
        }

        /// <summary>
        ///   <para>Gets or sets the list containing the trait's required abilities.</para>
        /// </summary>
        public List<string> SpecialAbilities { get => Unlock.specialAbilities; set => Unlock.specialAbilities = value; }
        /// <summary>
        ///   <para>Gets or sets the list containing items, that increase the likelihood of the trait to appear on level-up.</para>
        /// </summary>
        public List<string> LeadingItems { get => Unlock.leadingItems; set => Unlock.leadingItems = value; }
        /// <summary>
        ///   <para>Gets or sets the list containing traits, that increase the likelihood of the trait to appear on level-up.</para>
        /// </summary>
        public List<string> LeadingTraits { get => Unlock.leadingTraits; set => Unlock.leadingTraits = value; }
        /// <summary>
        ///   <para>Gets or sets the list containing Big Quests, that increase the likelihood of the trait to appear on level-up.</para>
        /// </summary>
        public List<string> LeadingBigQuests { get => Unlock.leadingBigQuests; set => Unlock.leadingBigQuests = value; }

        /// <inheritdoc/>
        public override bool IsAvailable
        {
            get => !Unlock.unavailable;
            set
            {
                Unlock.unavailable = !value;
                // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
                bool? cur = gc?.sessionDataBig?.traitUnlocks?.Contains(Unlock);
                if (cur == true && !value) { gc!.sessionDataBig!.traitUnlocks!.Remove(Unlock); Unlock.traitCount--; }
                else if (cur == false && value) { gc!.sessionDataBig!.traitUnlocks!.Add(Unlock); Unlock.traitCount++; }
            }
        }
        /// <inheritdoc/>
        public bool IsAvailableInCC
        {
            get => Unlock.onlyInCharacterCreation;
            set
            {
                Unlock.onlyInCharacterCreation = value;
                // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
                bool? cur = gc?.sessionDataBig?.traitUnlocksCharacterCreation?.Contains(Unlock);
                if (cur == true && !value) { gc!.sessionDataBig!.traitUnlocksCharacterCreation!.Remove(Unlock); Unlock.traitCountCharacterCreation--; }
                else if (cur == false && value) { gc!.sessionDataBig!.traitUnlocksCharacterCreation!.Add(Unlock); Unlock.traitCountCharacterCreation++; }
            }
        }

        /// <summary>
        ///   <para>Gets the trait's upgrade cost, in money.</para>
        /// </summary>
        /// <returns>The trait's upgrade cost, in money.</returns>
        public virtual int GetUpgradeCost()
        {
            if (Menu is not CustomScrollingMenu menu)
                throw new InvalidOperationException("The unlock is not in the character creation menu.");
            return Mathf.Abs((gc.unlocks.GetUnlock(Unlock.upgrade, "Trait")?.cost3 ?? CharacterCreationCost) * menu.Menu.upgradeTraitAdjust);
        }
        /// <summary>
        ///   <para>Gets the trait's removal cost, in money.</para>
        /// </summary>
        /// <returns>The trait's removal cost, in money.</returns>
        public virtual int GetRemovalCost()
        {
            if (Menu is not CustomScrollingMenu menu)
                throw new InvalidOperationException("The unlock is not in the character creation menu.");
            return Mathf.Abs(CharacterCreationCost * menu.Menu.removeTraitAdjust);
        }
        /// <summary>
        ///   <para>Gets the trait's swap cost, in money.</para>
        /// </summary>
        /// <returns>The trait's swap cost, in money.</returns>
        public virtual int GetSwapCost()
        {
            if (Menu is not CustomScrollingMenu menu)
                throw new InvalidOperationException("The unlock is not in the character creation menu.");
            return Mathf.Abs(CharacterCreationCost * (CharacterCreationCost < 0
                                 ? menu.Menu.changeTraitRandomAdjustNegativeTrait
                                 : menu.Menu.changeTraitRandomAdjustPositiveTrait));
        }

        /// <inheritdoc/>
        public override void UpdateButton()
        {
            if (Menu!.Type == UnlocksMenuType.TraitsMenu)
                UpdateButton(IsEnabled, UnlockButtonState.Normal, UnlockButtonState.Disabled);
            else if (Menu.Type == UnlocksMenuType.CharacterCreation)
                UpdateButton(IsAddedToCC);
            else if (Menu.Type == UnlocksMenuType.AB_UpgradeTrait)
                Text = $"{GetName()} | ${GetUpgradeCost()}";
            else if (Menu.Type == UnlocksMenuType.AB_RemoveTrait)
                Text = $"{GetName()} | ${GetRemovalCost()}";
            else if (Menu.Type == UnlocksMenuType.AB_SwapTrait)
                Text = $"{GetName()} | ${GetSwapCost()}";
        }
        /// <inheritdoc/>
        public override void OnPushedButton()
        {
            if (Menu!.Type == UnlocksMenuType.NewLevelTraits)
            {
                ScrollingMenu menu = ((CustomScrollingMenu)Menu).Menu;
                if (menu.twitchCountdownOn) return;
                State = UnlockButtonState.Selected;
                UpdateMenu();
                if (gc.twitchMode || gc.sessionDataBig.twitchOn && gc.sessionDataBig.twitchTraits)
                    gc.twitchFunctions.ShowWinner(Name, "StatusEffect", Menu.Agent.isPlayer);
                if (Name == "EnduranceTrait")
                {
                    Menu.Agent.SetEndurance(Menu.Agent.enduranceStatMod + 1, true);
                    if (!Menu.Agent.finishedLevel)
                        gc.spawnerMain.SpawnStatusText(Menu.Agent, "BuffSpecial", "Endurance", "BuffSpecial", "");
                }
                else if (Name == "SpeedTrait")
                {
                    Menu.Agent.SetSpeed(Menu.Agent.speedStatMod + 1, true);
                    if (!Menu.Agent.finishedLevel)
                        gc.spawnerMain.SpawnStatusText(Menu.Agent, "BuffSpecial", "Speed", "BuffSpecial", "");
                }
                else if (Name == "StrengthTrait")
                {
                    Menu.Agent.SetStrength(Menu.Agent.strengthStatMod + 1, true);
                    if (!Menu.Agent.finishedLevel)
                        gc.spawnerMain.SpawnStatusText(Menu.Agent, "BuffSpecial", "Strength", "BuffSpecial", "");
                }
                else if (Name == "AccuracyTrait")
                {
                    Menu.Agent.SetAccuracy(Menu.Agent.accuracyStatMod + 1, true);
                    if (!Menu.Agent.finishedLevel)
                        gc.spawnerMain.SpawnStatusText(Menu.Agent, "BuffSpecial", "Accuracy", "BuffSpecial", "");
                }
                else
                {
                    Menu.Agent.statusEffects.AddTrait(Name);
                }
                Menu.Agent.addedEndLevelTrait = true;
                Menu.Agent.skillPoints.levelsGained--;
                gc.sessionData.levelsGained[Menu.Agent.isPlayer]--;
                PlaySound(VanillaAudio.AddTrait);
                Menu.Agent.objectMult.SendChatAnnouncement("ChoseTrait", Name, "");
                menu.canPressButtons = false;
                if (Menu.Agent.skillPoints.levelsGained is 0)
                {
                    if (gc.fourPlayerMode || gc.coopMode)
                    {
                        menu.StartCoroutine((IEnumerator)typeof(ScrollingMenu).GetMethod("PersonalMenuDelay")!.Invoke(menu, new object[0]));
                    }
                    else if (gc.levelFeelingsScript.DoesNextLevelHaveFeeling(false) && (gc.sessionDataBig.twitchOn || gc.twitchMode) && (gc.sessionDataBig.twitchLevelFeelings || gc.twitchMode) && (gc.sessionData.nextLevelFeeling?.Length is 0 || gc.sessionData.nextLevelFeeling is null) && !gc.challenges.Contains("NoLevelFeelings") && !gc.levelFeelingsScript.CanceledAllLevelFeelings() && gc.serverPlayer && gc.levelFeelingsScript.GetLevelFeeling() != "")
                    {
                        menu.StartCoroutine((IEnumerator)typeof(ScrollingMenu).GetMethod("ShowMenuDelay")!.Invoke(menu, new object[2] { "LevelFeelings", Menu.Agent }));
                    }
                    else
                    {
                        menu.StartCoroutine(menu.NextLevelDelay());
                    }
                }
                else
                {
                    foreach (ButtonData buttonData4 in menu.buttonsData)
                        buttonData4.isActive = false;
                    menu.Invoke("OpenScrollingMenu", 0.1f);
                }
            }
            else if (Menu.Type == UnlocksMenuType.AB_UpgradeTrait)
            {
                if (Menu.Agent.interactionHelper.interactionObjectReal.moneySuccess(GetUpgradeCost()))
                {
                    Menu.Agent.usingAugmentationBooth = true;
                    Menu.Agent.statusEffects.AddTrait(Unlock.upgrade);
                    PlaySound(VanillaAudio.AddTrait);
                    Menu.Agent.mainGUI.HideScrollingMenuPersonal();
                    Menu.Agent.usingAugmentationBooth = false;
                }
                else PlaySound(VanillaAudio.CantDo);
            }
            else if (Menu.Type == UnlocksMenuType.AB_RemoveTrait)
            {
                if (Menu.Agent.interactionHelper.interactionObjectReal.moneySuccess(GetRemovalCost()))
                {
                    Menu.Agent.usingAugmentationBooth = true;
                    Menu.Agent.statusEffects.RemoveTrait(Name);
                    Menu.Agent.mainGUI.HideScrollingMenuPersonal();
                    Menu.Agent.usingAugmentationBooth = false;
                }
                else PlaySound(VanillaAudio.CantDo);
            }
            else if (Menu.Type == UnlocksMenuType.AB_SwapTrait)
            {
                ScrollingMenu menu = ((CustomScrollingMenu)Menu).Menu;
                List<Unlock> list = Unlock.isUpgrade
                    ? gc.sessionDataBig.unlocks.FindAll(u => u.isUpgrade && Unlock.isUpgrade && !Menu.Agent.statusEffects.hasTrait(u.unlockName) && !u.cantSwap && !u.removal && u.specialAbilities.All(ab => Menu.Agent.statusEffects.hasSpecialAbility(ab)))
                    : CharacterCreationCost < 0
                        ? gc.sessionDataBig.traitUnlocksCharacterCreation.FindAll(u => u.cost3 == CharacterCreationCost && menu.TraitOK(u) && menu.HasNoCancellations(u) && !u.cantSwap && !u.removal && u.specialAbilities.All(ab => Menu.Agent.statusEffects.hasSpecialAbility(ab)) && u.recommendations.Count is 0)
                        : gc.sessionDataBig.traitUnlocks.FindAll(u => u.cost3 == CharacterCreationCost && menu.TraitOK(u) && menu.HasNoCancellations(u) && !u.cantSwap && !u.removal && u.specialAbilities.All(ab => Menu.Agent.statusEffects.hasSpecialAbility(ab)));
                if (list.Count is 0)
                {
                    Menu.Agent.SayDialogue("CantChangeTraitRandomEquivalent");
                    PlaySound(VanillaAudio.CantDo);
                }
                else if (Menu.Agent.interactionHelper.interactionObjectReal.moneySuccess(GetSwapCost()))
                {
                    Menu.Agent.usingAugmentationBooth = true;
                    Unlock unlock6 = list[UnityEngine.Random.Range(0, list.Count)];
                    Menu.Agent.statusEffects.RemoveTrait(Name);
                    Menu.Agent.statusEffects.AddTrait(unlock6.unlockName);
                    PlaySound(VanillaAudio.AddTrait);
                    Menu.Agent.mainGUI.HideScrollingMenuPersonal();
                    Menu.Agent.usingAugmentationBooth = false;
                }
                else PlaySound(VanillaAudio.CantDo);
            }
            else if (IsUnlocked)
            {
                if (Menu.Type == UnlocksMenuType.TraitsMenu)
                {
                    ScrollingMenu menu = ((CustomScrollingMenu)Menu).Menu;
                    if (IsEnabled && menu.activeTraitCount <= menu.minTraits)
                    {
                        PlaySound(VanillaAudio.CantDo);
                        menu.ActiveCountFlash();
                    }
                    else
                    {
                        PlaySound(VanillaAudio.ClickButton);
                        IsEnabled = !IsEnabled;
                        gc.unlocks.SaveUnlockData(true);
                        UpdateButton();
                        UpdateMenu();
                    }
                }
                else if (Menu.Type == UnlocksMenuType.CharacterCreation)
                {
                    PlaySound(VanillaAudio.ClickButton);
                    IsAddedToCC = !IsAddedToCC;
                    if (IsAddedToCC)
                        foreach (DisplayedUnlock du in EnumerateCancellations())
                            if (((IUnlockInCC)du).IsAddedToCC)
                            {
                                ((IUnlockInCC)du).IsAddedToCC = false;
                                du.UpdateButton();
                            }
                    UpdateButton();
                    UpdateMenu();
                }
            }
            else if (Unlock.nowAvailable && UnlockCost > 0 && UnlockCost <= gc.sessionDataBig.nuggets)
            {
                PlaySound(VanillaAudio.BuyUnlock);
                gc.unlocks.SubtractNuggets(UnlockCost);
                gc.unlocks.DoUnlockForced(Name, Type);
                UpdateAllUnlocks();
                UpdateMenu();
            }
            else PlaySound(VanillaAudio.CantDo);
        }
    }
}
