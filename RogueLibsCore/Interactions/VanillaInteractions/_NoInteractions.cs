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
        }
    }
}
