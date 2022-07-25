namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_AugmentationBooth()
        {
            Patch<AugmentationBooth>(Params2);
            PatchInteract<AugmentationBooth>();

            RogueInteractions.CreateProvider<AugmentationBooth>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar) return;
                if (h.Agent.mechFilled)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("CantMechUseAugmentationBooth"));
                    return;
                }
                if (h.Agent.possessing)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("CantAugmentPossessing"));
                    return;
                }
                h.AddButton("UpgradeTrait", static m =>
                {
                    m.Agent.mainGUI.scrollingMenuPersonalScript.agent = m.Agent;
                    m.Agent.mainGUI.scrollingMenuPersonalScript.GetTraitsUpgradeTrait();
                    if (m.Agent.mainGUI.scrollingMenuPersonalScript.customTraitList.Count > 0)
                    {
                        m.Agent.mainGUI.ShowScrollingMenuPersonal("UpgradeTrait", null);
                        return;
                    }
                    m.Agent.SayDialogue("CantUpgradeTrait");
                    m.StopInteraction();
                });
                h.AddButton("RemoveTrait", static m =>
                {
                    m.Agent.mainGUI.scrollingMenuPersonalScript.agent = m.Agent;
                    m.Agent.mainGUI.scrollingMenuPersonalScript.GetTraitsRemoveTrait();
                    if (m.Agent.mainGUI.scrollingMenuPersonalScript.customTraitList.Count > 0)
                    {
                        m.Agent.mainGUI.ShowScrollingMenuPersonal("RemoveTrait", null);
                        return;
                    }
                    m.Agent.SayDialogue("CantRemoveTrait");
                    m.StopInteraction();
                });
                h.AddButton("ChangeTraitRandom", static m =>
                {
                    m.Agent.mainGUI.scrollingMenuPersonalScript.agent = m.Agent;
                    UnityEngine.Random.InitState(m.gc.loadLevel.randomSeedNum
                                                 + m.gc.sessionDataBig.curLevelEndless
                                                 + (m.gc.streamingWorld ? m.Object.streamingChunkObjectID : m.Object.objectRealID));
                    m.Agent.mainGUI.scrollingMenuPersonalScript.GetTraitsChangeTraitRandom();
                    if (m.Agent.mainGUI.scrollingMenuPersonalScript.customTraitList.Count > 0)
                    {
                        m.Agent.mainGUI.ShowScrollingMenuPersonal("ChangeTraitRandom", null);
                        return;
                    }
                    m.Agent.SayDialogue("CantChangeTraitRandom");
                    m.StopInteraction();
                });
            });
        }
    }
}
