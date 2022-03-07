namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_CloneMachine()
        {
            Patch<CloneMachine>(Params2);
            PatchInteract<CloneMachine>();
            PatchInteractFar<CloneMachine>();

            RogueInteractions.CreateProvider<CloneMachine>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar)
                {
                    if (!h.Object.hacked)
                    {
                        h.AddButton("CloneRandomPerson", static m =>
                        {
                            if (m.Object.interactingAgent.CanHaveMoreFollowers(true, false, m.Object.hiredHackerHacking))
                            {
                                m.Object.CloneRandomPerson(m.Agent);
                            }
                        });
                    }
                }
                else
                {
                    h.AddButton("CloneItem", static m =>
                    {
                        if (m.Object.itemsCloned >= m.Object.itemLimit)
                        {
                            m.Agent.SayDialogue("CloneMachineOut");
                            m.gc.audioHandler.Play(m.Object, "CantDo");
                            return;
                        }
                        m.Object.itemsClonedClient = m.Object.itemsCloned;
                        m.Object.ShowUseOn("CloneItem");
                    });
                    h.AddButton("CloneSelf", h.Object.determineMoneyCost("CloneMachineAgent"), static m =>
                    {
                        if (m.Agent.CanHaveMoreFollowers(true) && m.Object.moneySuccess(m.Object.determineMoneyCost("CloneMachineAgent")))
                        {
                            m.Object.CloneSelf(m.Agent);
                        }
                    });
                }
            });
        }
    }
}
