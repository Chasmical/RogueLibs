namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Generator()
        {
            Patch<Generator>(Params2);
            PatchInteract<Generator>();

            RogueInteractions.CreateProvider<Generator>(static h =>
            {
                if (h.Helper.interactingFar) return;
                if (h.Object.timer <= 0f && !h.Object.startedFlashing)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("CantOperateGenerator"));

                    InvItem? wrench = h.Agent.inventory.FindItem("Wrench");
                    if (wrench is not null)
                    {
                        h.AddButton("UseWrenchToDetonate", $" ({wrench.invItemCount}) -30", static m =>
                        {
                            if (m.Object.startedFlashing)
                            {
                                m.StopInteraction();
                                return;
                            }
                            m.Object.StartCoroutine(m.Object.Operating(m.Agent, m.Agent.inventory.FindItem("Wrench"),
                                                                       2f, true, "Tampering"));
                        });
                    }
                }
            });
        }
    }
}
