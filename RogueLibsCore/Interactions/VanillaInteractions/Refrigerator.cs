namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Refrigerator()
        {
            Patch<Refrigerator>(Params1);
            PatchInteract<Refrigerator>();
            PatchInteractFar<Refrigerator>();

            RogueInteractions.CreateProvider<Refrigerator>(static h =>
            {
                if (h.gc.levelType is "HomeBase") return;
                if (h.Helper.interactingFar)
                {
                    if (!h.Object.functional)
                    {
                        h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                        return;
                    }
                    h.AddButton("RefrigeratorRun", static m =>
                    {
                        m.gc.audioHandler.Play(m.Agent, "Success");
                        m.Object.RefrigeratorRun(m.Agent);
                        m.StopInteraction();
                    });
                }
                else
                {
                    h.AddImplicitButton("Open", static m => m.Object.ShowChest());
                }
            });
        }
    }
}
