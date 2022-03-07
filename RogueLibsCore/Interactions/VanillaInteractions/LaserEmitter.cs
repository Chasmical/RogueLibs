namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_LaserEmitter()
        {
            Patch<LaserEmitter>(Params2);
            PatchInteract<LaserEmitter>();

            RogueInteractions.CreateProvider<LaserEmitter>(static h =>
            {
                if (h.Helper.interactingFar)
                {
                    h.AddButton("Deactivate", static m => m.Object.MakeNonFunctional(m.Agent));
                }
                else
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("CantOperateLaserEmitter"));

                    if (!h.Object.startedFlashing && h.Object.functional && h.Object.emittingLaser)
                    {
                        InvItem? wrench = h.Agent.inventory.FindItem("Wrench");
                        if (wrench is not null)
                        {
                            h.AddButton("UseWrenchToDeactivate", $" ({wrench.invItemCount}) -30", static m =>
                            {
                                m.Object.StartCoroutine(m.Object.Operating(m.Agent, m.Agent.inventory.FindItem("Wrench"),
                                                                           2f, true, "Tampering"));
                            });
                        }
                    }
                }
            });
        }
    }
}
