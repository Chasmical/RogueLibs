namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Safe()
        {
            Patch<Safe>(Params1);
            PatchInteract<Safe>();
            PatchInteractFar<Safe>();

            RogueInteractions.CreateProvider<Safe>(static h =>
            {
                if (h.Helper.interactingFar)
                {
                    if (h.Object.locked)
                    {
                        h.AddButton("HackSafe", static m =>
                        {
                            m.gc.audioHandler.Play(m.Agent, "Success");
                            m.Object.UnlockSafe();
                        });
                    }
                }
                else
                {
                    if (h.Object.locked)
                        h.SetStopCallback(static m => m.Agent.SayDialogue("CantOpenSafe"));
                    else
                    {
                        h.AddImplicitButton("Open", static m =>
                        {
                            m.Object.ShowChest();
                            m.Object.TreasureBonus(m.Agent);
                        });
                    }

                    if (h.Object.locked)
                    {
                        if (h.Agent.inventory.InvItemList.Exists(i => i.invItemName is "SafeCombination"
                                                                      && i.chunks.Contains(h.Object.startingChunk)))
                        {
                            h.AddButton("UseSafeCombination", static m =>
                            {
                                m.Object.UnlockSafe();
                                m.Object.ShowChest();
                                m.Object.TreasureBonus(m.Agent);
                            });
                        }
                        else
                        {
                            if (h.Agent.inventory.HasItem("SafeCrackingTool"))
                            {
                                h.AddButton("UseSafeCrackingTool",
                                            static m => m.StartOperating("SafeCrackingTool", 2f, true, "Unlocking"));
                            }
                            InvItem? safeBuster = h.Agent.inventory.FindItem("SafeBuster");
                            if (safeBuster is not null)
                            {
                                h.AddButton("UseSafeBuster", $" ({safeBuster.invItemCount})",
                                            static m => m.StartOperating("SafeBuster", 2f, true, "Unlocking"));
                            }
                        }
                    }
                }
            });
        }
    }
}
