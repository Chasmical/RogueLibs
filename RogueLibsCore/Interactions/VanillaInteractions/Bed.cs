namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Bed()
        {
            Patch<Bed>(Params1);
            PatchInteract<Bed>();

            RogueInteractions.CreateProvider<Bed>(static h =>
            {
                if (h.Helper.interactingFar || h.gc.levelType is "HomeBase") return;
                h.SetStopCallback(static m => m.Agent.SayDialogue("BedWontSleep"));
            });
        }
    }
}
