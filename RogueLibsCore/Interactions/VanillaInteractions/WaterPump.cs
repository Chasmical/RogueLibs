namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_WaterPump()
        {
            Patch<WaterPump>(Params2);
            PatchInteract<WaterPump>();

            RogueInteractions.CreateProvider<WaterPump>(static h =>
            {
                if (h.Helper.interactingFar) return;

                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                h.SetStopCallback(static m => m.Agent.SayDialogue("CantUseAirConditioner"));

                if (h.Agent.inventory.InvItemList.Exists(i => h.Object.playerHasUsableItem(i)))
                {
                    h.AddButton("InsertItem", static m => m.Object.ShowUseOn("InsertItem"));
                }
            });
        }
    }
}
