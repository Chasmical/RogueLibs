namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Generator2()
        {
            Patch<Generator2>(Params2);
            PatchInteract<Generator2>();

            RogueInteractions.CreateProvider<Generator2>(static h =>
            {
                if (h.Helper.interactingFar || h.gc.levelType is "HomeBase") return;
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
                            m.StartOperating("Wrench", 2f, true, "Tampering");
                        });
                    }
                }
            });
        }
    }
}
