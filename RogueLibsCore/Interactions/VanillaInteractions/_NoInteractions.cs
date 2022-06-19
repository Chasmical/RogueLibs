namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_NoInteractions()
        {
            PatchInteract<ExplodingBarrel>();
            PatchInteract<FireSpewer>();
            PatchInteract<FlameGrate>();
            PatchInteract<GasVent>();
            PatchInteract<MineCart>();
            PatchInteract<SawBlade>();
            PatchInteract<Train>();
            PatchInteract<Tube>();

        }
    }
}
