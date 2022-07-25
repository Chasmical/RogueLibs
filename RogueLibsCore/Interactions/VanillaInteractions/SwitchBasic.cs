namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_SwitchBasic()
        {
            PatchInteract<SwitchBasic>();

            // See "Press" in AlarmButton.cs
            RogueInteractions.CreateProvider<SwitchBasic>(static h =>
            {
                if (h.Helper.interactingFar) return;
                h.AddImplicitButton("Press", static m =>
                {
                    m.Object.lastHitByAgent = m.Agent;
                    m.Object.ToggleSwitch();
                    m.StopInteraction();
                });
            });
        }
    }
}
