namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_CapsuleMachine()
        {
            Patch<CapsuleMachine>(Params2);
            PatchInteract<CapsuleMachine>();
            PatchInteractFar<CapsuleMachine>();

            RogueInteractions.CreateProvider<CapsuleMachine>(static h =>
            {
                if (!h.Object.functional || h.Object.numPurchases >= 3 && !h.gc.challenges.Contains("NoLimits"))
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar)
                {
                    if (!h.Object.hacked)
                    {
                        h.AddButton("LowerCapsuleMachinePrice", static m =>
                        {
                            m.gc.audioHandler.Play(m.Agent, "Success");
                            m.Object.LowerCapsuleMachinePrice(m.Agent);
                        });
                    }
                }
                else
                {
                    h.AddButton("SpawnCapsuleItem", h.Object.determineMoneyCost("CapsuleMachine"), static m =>
                    {
                        m.Object.SpawnCapsuleItem();
                    });
                }
            });
        }
    }
}
