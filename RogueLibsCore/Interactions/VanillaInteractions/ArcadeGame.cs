namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_ArcadeGame()
        {
            Patch<ArcadeGame>(Params1);
            PatchInteract<ArcadeGame>();
            RogueInteractions.CreateProvider<ArcadeGame>(static h =>
            {
                if (h.Helper.interactingFar && !h.Object.isHighVolume)
                {
                    h.AddButton("IncreaseVolume", static m => m.Object.IncreaseVolume());
                }
            });
        }
    }
}
