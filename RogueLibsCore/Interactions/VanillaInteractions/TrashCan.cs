namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_TrashCan()
        {
            PatchInteract<TrashCan>();

            RogueInteractions.CreateProvider<TrashCan>(static h =>
            {
                if (h.Helper.interactingFar) return;

                h.AddImplicitButton("Open", static m => m.Object.ShowChest());
            });
        }
    }
}
