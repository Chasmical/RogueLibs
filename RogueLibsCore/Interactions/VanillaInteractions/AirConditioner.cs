namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_AirConditioner()
        {
            Patch<AirConditioner>(Params2);
            PatchInteract<AirConditioner>();

            RogueInteractions.CreateProvider<AirConditioner>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar) return;

                if (h.gc.gasesList.Exists(g => g.startingChunk == h.Object.startingChunk))
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("AlreadyGassing"));
                    return;
                }
                if (h.Agent.inventory.InvItemList.Exists(item => h.Object.playerHasUsableItem(item)))
                    h.AddButton("InsertItem", static m => m.Object.ShowUseOn("InsertItem"));
                else h.SetStopCallback(static m => m.Agent.SayDialogue("CantUseAirConditioner"));
            });
        }
    }
}
