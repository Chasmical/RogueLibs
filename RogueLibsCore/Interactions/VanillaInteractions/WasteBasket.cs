namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_WasteBasket()
        {
            PatchInteract<WasteBasket>();

            RogueInteractions.CreateProvider<WasteBasket>(static h =>
            {
                if (h.Helper.interactingFar || h.gc.levelType is "HomeBase") return;

                Quest? quest = h.Object.useForQuest ?? h.gc.quests.unchangingQuestList.Find(static q => q.questType is "PlantItem");
                if (quest is not null)
                {
                    InvItem? item = h.Agent.inventory.FindItem(quest.startingItem1.invItemName);
                    if (item is null)
                    {
                        h.SetStopCallback(static m => m.Agent.SayDialogue("CantPlant"));
                        return;
                    }
                    h.AddImplicitButton("PlantItem", m =>
                    {
                        m.Object.lastHitByAgent = m.Agent;
                        m.Agent.inventory.DestroyItem(item);
                        m.Object.objectInvDatabase.AddItem(item);
                        m.Object.PlantItem(m.Agent);
                        m.gc.OwnCheck(m.Agent, m.Object.go, "Normal", 0);
                        m.StopInteraction();
                    });
                }
            });
        }
    }
}
