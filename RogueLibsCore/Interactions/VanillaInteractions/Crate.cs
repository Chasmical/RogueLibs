namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Crate()
        {
            Patch<Crate>(Params2);
            PatchInteract<Crate>();

            RogueInteractions.CreateProvider<Crate>(static h =>
            {
                if (h.Helper.interactingFar) return;

                if (h.Object.locked)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("CantOpenDoor"));

                    InvItem? crowbar = h.Agent.inventory.FindItem("Crowbar");
                    if (crowbar is not null && !h.Object.startedFlashing)
                    {
                        h.AddButton("UseCrowbar", $" ({crowbar.invItemCount}) -30",
                                    static m => m.StartOperating("Crowbar", 2f, true, "Opening"));
                    }
                }
                else
                {
                    h.AddImplicitButton("Open", static m =>
                    {
                        m.Object.ShowChest();
                        m.Object.TreasureBonus(m.Agent);
                    });
                }
            });
        }
    }
}
