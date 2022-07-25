namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Well()
        {
            Patch<Well>(Params2);
            PatchInteract<Well>();

            RogueInteractions.CreateProvider<Well>(static h =>
            {
                if (h.Helper.interactingFar) return;

                if (h.Object.tossedAgents.Contains(h.Agent) && !h.gc.challenges.Contains("NoLimits"))
                {
                    h.SetStopCallback(static m =>
                    {
                        m.Agent.SayDialogue("CantTossAnotherCoin");
                        m.gc.audioHandler.Play(m.Agent, "CantDo");
                    });
                    return;
                }
                h.AddButton("TossCoin", 1, static m =>
                {
                    if (m.Object.moneySuccess(1))
                    {
                        UnityEngine.Debug.Log("Tossed Coin");
                        m.Object.tossedAgents.Add(m.Agent);
                        m.StopInteraction();
                    }
                });
                h.AddButton("TossCoin2", 30, static m =>
                {
                    if (m.Object.moneySuccess(30))
                    {
                        m.Object.tossedAgents.Add(m.Agent);
                        m.Agent.statusEffects.AddStatusEffect("FeelingLucky", true, true);
                        m.StopInteraction();
                    }
                });
            });
        }
    }
}
