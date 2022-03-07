namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_ATMMachine()
        {
            Patch<ATMMachine>(Params2);
            PatchInteract<ATMMachine>();
            PatchInteractFar<ATMMachine>();

            RogueInteractions.CreateProvider<ATMMachine>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar)
                {
                    if (!h.Object.didSpitOutMoney)
                        h.AddButton("SpitOutMoney", static m =>
                        {
                            m.gc.audioHandler.Play(m.Agent, "Success");
                            m.Object.SpitOutMoney(m.Agent);
                        });
                }
                else
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("NoReasonToUse"));

                    if (h.Object.readyForDelivery
                        && (h.Agent.inventory.HasItem("CourierPackage") || h.Agent.inventory.HasItem("CourierPackageBroken")))
                    {
                        h.AddButton("DeliverPackage", static m => m.Object.DeliverPackage(m.Agent, false, false, 0));
                    }
                    if (!h.gc.challenges.Contains("Sandbox") && !h.gc.challenges.Contains("SpeedRun") && !h.gc.challenges.Contains("SpeedRun2")
                        && !h.gc.customCampaign && !h.gc.wasLevelEditing)
                    {
                        h.AddButton("StoreItem", static m =>
                        {
                            m.Object.ShowUseOn("StoreItem");
                            m.Object.Say("ATMInstruction");
                        });
                    }
                    if (!h.Object.specialInvDatabase.isEmpty() && !h.gc.challenges.Contains("SpeedRun") && !h.gc.challenges.Contains("SpeedRun2")
                        && !h.gc.customCampaign && !h.gc.wasLevelEditing)
                    {
                        h.AddButton("RetrieveStoredItem", static m =>
                        {
                            m.Object.destroyingItem = false;
                            m.Object.ShowNPCChest();
                        });
                        h.AddButton("DestroyItem", static m =>
                        {
                            m.Object.destroyingItem = true;
                            m.Object.ShowNPCChest();
                        });
                    }
                    if (h.Agent.HasEffect("InDebt") || h.Agent.HasEffect("InDebt2") || h.Agent.HasEffect("InDebt3"))
                        h.AddButton("PayBackDebt", h.Agent.CalculateDebt(), static m => m.Object.PayBackDebt());

                    if (h.Agent.HasEffect("OweCops1"))
                        h.AddButton("PayCops", h.Object.determineMoneyCost("OweCops1"), static m => m.Object.PayCops());
                    else if (h.Agent.HasEffect("OweCops2"))
                        h.AddButton("PayCops", h.Object.determineMoneyCost("OweCops2"), static m => m.Object.PayCops());

                    if (h.Agent.bigQuest == "Hobo" && !h.gc.loadLevel.LevelContainsMayor())
                    {
                        h.AddButton("PutMoneyTowardHome", h.Object.determineMoneyCost("PutMoneyTowardHome"),
                                    static m => m.Object.PutMoneyTowardHome());
                    }
                }
            });
        }
    }
}
