namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_PowerBox()
        {
            Patch<PowerBox>(Params2);
            PatchInteract<PowerBox>();
            PatchInteractFar<PowerBox>();

            RogueInteractions.CreateProvider<PowerBox>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }

                if (h.Helper.interactingFar)
                {
                    h.AddButton("HackPowerBox", static m =>
                    {
                        m.Object.ShutDown();
                        m.StopInteraction();
                    });
                }
                else
                {
                    if (h.Agent.statusEffects.hasTrait("NoTechSkill"))
                    {
                        h.SetStopCallback(static m => m.Agent.SayDialogue("CantUseTech"));
                        return;
                    }
                    h.AddButton("ShutDownPowerBox", static m => m.StartOperating(2f, true, "ShuttingDown"));
                }
            });
        }
    }
}
