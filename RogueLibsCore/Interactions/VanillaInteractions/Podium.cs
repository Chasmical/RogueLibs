namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Podium()
        {
            Patch<Podium>(Params2);
            PatchInteract<Podium>();

            RogueInteractions.CreateProvider<Podium>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }

                h.SetStopCallback(static m => m.Agent.SayDialogue("CantMakeSpeech"));

                if (h.Agent.inventory.HasItem("MayorHat") || h.gc.debugMode || h.gc.debugControls)
                {
                    h.AddButton("MakeSpeech", static m => m.Object.MakeSpeech(m.Agent));
                }
            });
        }
    }
}
