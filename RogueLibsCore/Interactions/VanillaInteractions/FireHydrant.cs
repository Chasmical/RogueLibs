namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_FireHydrant()
        {
            Patch<FireHydrant>(Params2);
            PatchInteract<FireHydrant>();

            RogueInteractions.CreateProvider<FireHydrant>(static h =>
            {
                if (h.Helper.interactingFar) return;

                h.SetStopCallback(static m => m.Agent.SayDialogue("CantUseFireHydrant"));

                InvItem? waterCannon = h.Agent.inventory.equippedSpecialAbility;
                if (waterCannon?.invItemName is "WaterCannon" && waterCannon.invItemCount < waterCannon.initCount)
                {
                    h.AddButton("RefillWaterCannon", static m => m.Object.RefillWaterCannon());
                }
            });
        }
    }
}
