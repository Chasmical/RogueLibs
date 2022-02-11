namespace RogueLibsCore
{
    internal class GiveNuggetsButton : MutatorUnlock
    {
        public GiveNuggetsButton() : base("GiveNuggetsDebug", true) { }

        public override string GetFancyName() => $"<color=cyan>{GetName()}</color>";
        public override void OnPushedButton()
        {
            if (RogueFramework.IsDebugEnabled(DebugFlags.UnlockMenus))
                RogueFramework.LogDebug("Added 10 nuggets with the debug tool.");
            gc.unlocks.AddNuggets(10);
            PlaySound(VanillaAudio.BuyItem);
            UpdateMenu();
        }
    }
}
