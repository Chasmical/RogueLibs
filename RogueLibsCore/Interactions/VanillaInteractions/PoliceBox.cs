namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_PoliceBox()
        {
            Patch<PoliceBox>(Params2);
            PatchInteract<PoliceBox>();
            PatchInteractFar<PoliceBox>();

            RogueInteractions.CreateProvider<PoliceBox>(static h =>
            {
                if (h.Helper.interactingFar)
                {
                    h.AddButton("HackTeleporterParameters", static m =>
                    {
                        m.gc.audioHandler.Play(m.Agent, "Success");
                        m.Object.HackTeleporterParameters(m.Agent);
                    });
                }
                else
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("CantOperatePoliceBox"));

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
            });
        }
    }
}
