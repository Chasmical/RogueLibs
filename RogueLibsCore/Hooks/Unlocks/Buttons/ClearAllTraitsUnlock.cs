namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a "Clear All" button in the Character Creation Traits Menu.</para>
    /// </summary>
    public class ClearAllTraitsUnlock : TraitUnlock
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="ClearAllTraitsUnlock"/> class.</para>
        /// </summary>
        public ClearAllTraitsUnlock() : base("ClearAllTraits", true)
        {
            UnlockCost = 0;
            CharacterCreationCost = 0;
            LoadoutCost = 0;
        }
        /// <inheritdoc/>
        public override bool IsAvailable { get; set; } = true;
        /// <inheritdoc/>
        public override bool IsEnabled { get => false; set { } }

        /// <inheritdoc/>
        public override void OnPushedButton()
        {
            if (IsUnlocked && gc.serverPlayer)
            {
                PlaySound(VanillaAudio.ClickButton);
                if (Menu!.Type == UnlocksMenuType.TraitsMenu)
                {
                    foreach (DisplayedUnlock du in Menu.Unlocks)
                        if (du.IsEnabled != (du.IsEnabled = false)) du.UpdateButton();
                }
                else if (Menu.Type == UnlocksMenuType.CharacterCreation)
                {
                    foreach (DisplayedUnlock du in Menu.Unlocks)
                    {
                        if (du is not IUnlockInCC inCC) continue;
                        if (inCC.IsAddedToCC != (inCC.IsAddedToCC = false)) du.UpdateButton();
                    }
                }
                UpdateMenu();
            }
            else PlaySound(VanillaAudio.CantDo);
        }
    }
}
