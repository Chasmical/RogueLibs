namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_ArcadeGame()
        {
            Patch<ArcadeGame>(Params1);
            PatchInteract<ArcadeGame>();
            PatchInteractFar<ArcadeGame>();

            RogueInteractions.CreateProvider<ArcadeGame>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar && !h.Object.isHighVolume)
                {
                    h.AddButton("IncreaseVolume", static m => m.Object.IncreaseVolume());
                }
            });
        }
    }
}
