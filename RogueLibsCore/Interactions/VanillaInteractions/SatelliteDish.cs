namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_SatelliteDish()
        {
            Patch<SatelliteDish>(Params2);
            PatchInteract<SatelliteDish>();
            PatchInteractFar<SatelliteDish>();

            RogueInteractions.CreateProvider<SatelliteDish>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar)
                {
                    if (!h.Object.adjustedSatellite)
                    {
                        h.AddButton("AdjustSatellite", static m => m.Object.AdjustSatellite(m.Agent));
                    }
                }
                else
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("CantOperateSatelliteDish"));

                    if (!h.Object.adjustedSatellite)
                    {
                        InvItem? wrench = h.Agent.inventory.FindItem("Wrench");
                        if (wrench is not null)
                        {
                            h.AddButton("UseWrenchToAdjustSatellite", $" ({wrench.invItemCount}) -30",
                                        static m => m.StartOperating("Wrench", 2f, true, "Tampering"));
                        }
                    }
                }
            });
        }
    }
}
