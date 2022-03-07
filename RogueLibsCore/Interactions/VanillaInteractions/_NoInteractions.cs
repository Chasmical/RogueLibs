namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_NoInteractions()
        {
            MakeInteractable<BarbedWire>();
            MakeInteractable<BarStool>();
            MakeInteractable<Bathtub>();
            MakeInteractable<Boulder>();
            MakeInteractable<BoulderSmall>();
            MakeInteractable<Chair>();
            MakeInteractable<Desk>();

            MakeInteractable<ExplodingBarrel>();
            PatchInteract<ExplodingBarrel>();

            MakeInteractable<Fireplace>();

            MakeInteractable<FireSpewer>();
            PatchInteract<FireSpewer>();

            MakeInteractable<FlameGrate>();
            PatchInteract<FlameGrate>();

            MakeInteractable<FlamingBarrel>();

            MakeInteractable<GasVent>();
            PatchInteract<GasVent>();

            MakeInteractable<Gravestone>();

            MakeInteractable<KillerPlant>();
            MakeInteractable<Lamp>();

            MakeInteractable<LockdownWall>();
            MakeInteractable<Manhole>();

            MakeInteractable<MineCart>();
            PatchInteract<MineCart>();

            MakeInteractable<MovieScreen>();
            MakeInteractable<Plant>();
            MakeInteractable<PoolTable>();


        }
    }
}
