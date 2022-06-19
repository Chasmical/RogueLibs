namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Altar()
        {
            Patch<Altar>(Params2);
            PatchInteract<Altar>();
            PatchInteractFar<Altar>();

            RogueInteractions.CreateProvider<Altar>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar) return;

                h.AddButton("MakeOffering", static m =>
                {
                    if (m.Object.offeringsMade >= m.Object.offeringLimit)
                    {
                        m.gc.audioHandler.Play(m.Object, "CantDo");
                        m.Object.StopInteraction();
                        return;
                    }
                    m.Agent.SayDialogue("OfferingMustBeInBuilding");
                    m.Object.commander = m.Agent;
                    m.Agent.mainGUI.invInterface.ShowTarget(m.Object, "MakeOffering");
                    m.Object.StartCoroutine("MakingOffer");
                });
            });
        }
    }
}
