namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_TrashCan()
        {
            PatchInteract<TrashCan>();

            RogueInteractions.CreateProvider<TrashCan>(static h =>
            {
                if (h.Helper.interactingFar || h.gc.levelType == "HomeBase") return;

                h.AddImplicitButton("Open", static m => m.Object.ShowChest());
            });
        }
    }
}
