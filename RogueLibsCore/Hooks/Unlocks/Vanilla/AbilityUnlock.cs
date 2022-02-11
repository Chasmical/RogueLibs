using System;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a special ability unlock.</para>
    /// </summary>
    public class AbilityUnlock : DisplayedUnlock, IUnlockInCC
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AbilityUnlock"/> class without a name.</para>
        /// </summary>
        public AbilityUnlock() : this(null!, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AbilityUnlock"/> class without a name.</para>
        /// </summary>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public AbilityUnlock(bool unlockedFromStart) : this(null!, unlockedFromStart) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AbilityUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The name of the unlock.</param>
        public AbilityUnlock(string name) : this(name, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AbilityUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The name of the unlock.</param>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public AbilityUnlock(string name, bool unlockedFromStart) : base(name, UnlockTypes.Ability, unlockedFromStart) => IsAvailableInCC = true;
        internal AbilityUnlock(Unlock unlock) : base(unlock) { }

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
                return cc.CC.abilityChosen == Name;
            }
            set
            {
                if (Menu is not CustomCharacterCreation cc)
                    throw new InvalidOperationException("The unlock is not in the character creation menu.");
                bool cur = IsAddedToCC;
                if (cur && !value) cc.CC.abilityChosen = "";
                else if (!cur && value) cc.CC.abilityChosen = Name;
            }
        }

        /// <inheritdoc/>
        public override bool IsAvailable
        {
            get => !Unlock.unavailable;
            set
            {
                Unlock.unavailable = !value;
                // ReSharper disable once ConstantConditionalAccessQualifier
                bool? cur = gc?.sessionDataBig?.abilityUnlocks?.Contains(Unlock);
                if (cur == true && !value) { gc!.sessionDataBig!.abilityUnlocks!.Remove(Unlock); Unlock.abilityCount--; }
                else if (cur == false && value) { gc!.sessionDataBig!.abilityUnlocks!.Add(Unlock); Unlock.abilityCount++; }
            }
        }
        /// <inheritdoc/>
        public bool IsAvailableInCC
        {
            get => Unlock.onlyInCharacterCreation;
            set => Unlock.onlyInCharacterCreation = value;
        }

        /// <inheritdoc/>
        public override void UpdateButton()
        {
            if (Menu!.Type == UnlocksMenuType.CharacterCreation)
                UpdateButton(IsAddedToCC);
        }
        /// <inheritdoc/>
        public override void OnPushedButton()
        {
            if (IsUnlocked)
            {
                if (Menu!.Type == UnlocksMenuType.CharacterCreation)
                {
                    PlaySound(VanillaAudio.ClickButton);
                    AbilityUnlock? previous = (AbilityUnlock?)Menu.Unlocks.Find(static u => u is AbilityUnlock { IsAddedToCC: true });
                    IsAddedToCC = !IsAddedToCC;
                    UpdateButton();
                    previous?.UpdateButton();
                    UpdateMenu();
                }
            }
            else if (Unlock.nowAvailable && UnlockCost <= gc.sessionDataBig.nuggets)
            {
                PlaySound(VanillaAudio.BuyUnlock);
                gc.unlocks.SubtractNuggets(UnlockCost);
                gc.unlocks.DoUnlockForced(Name, Type);
                UpdateAllUnlocks();
                UpdateMenu();
            }
            else PlaySound(VanillaAudio.CantDo);
        }

        /// <inheritdoc/>
        public override Sprite? GetImage() => GameResources.gameResources.itemDic.TryGetValue(Name, out Sprite image) ? image : base.GetImage();
    }
}
