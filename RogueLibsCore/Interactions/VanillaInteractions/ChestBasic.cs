namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_ChestBasic()
        {
            PatchInteract<ChestBasic>();

            RogueInteractions.CreateProvider<ChestBasic>(static h =>
            {
                if (h.Helper.interactingFar) return;
                h.AddImplicitButton("Open", static m =>
                {
                    m.Object.ShowChest();
                    m.Object.TreasureBonus(m.Agent);
                });
            });
        }
    }
}
