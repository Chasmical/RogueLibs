namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_LoadoutMachine()
        {
            Patch<LoadoutMachine>(Params2);
            PatchInteract<LoadoutMachine>();
            PatchInteractFar<LoadoutMachine>();

            RogueInteractions.CreateProvider<LoadoutMachine>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                h.AddImplicitButton("BuyLoadoutItems", static m => m.Object.OpenChestInventory());
            });
        }
    }
}
