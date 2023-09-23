namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_PawnShopMachine()
        {
            Patch<PawnShopMachine>(Params2);
            PatchInteract<PawnShopMachine>();
            PatchInteractFar<PawnShopMachine>();

            RogueInteractions.CreateProvider<PawnShopMachine>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar)
                {
                    if (h.Object.hacked == 0)
                    {
                        h.AddButton("IncreasePawnShopMachinePrices", static m =>
                        {
                            m.gc.audioHandler.Play(m.Agent, "Success");
                            m.Object.IncreasePawnShopMachinePrices(m.Agent);
                        });
                    }
                }
                else
                {
                    h.AddImplicitButton("SellItems", static m =>
                    {
                        if (m.Object.moneyEarned >= m.Object.moneyLimit)
                        {
                            m.Agent.SayDialogue("PawnShopMachineOut");
                            m.gc.audioHandler.Play(m.Object, "CantDo");
                            return;
                        }
                        m.Object.moneyEarnedClient = m.Object.moneyEarned;
                        m.Object.ShowUseOn("SellItem");
                    });
                }
            });
        }
    }
}
