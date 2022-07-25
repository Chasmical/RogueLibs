namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Jukebox()
        {
            Patch<Jukebox>(Params2);
            PatchInteract<Jukebox>();
            PatchInteractFar<Jukebox>();

            RogueInteractions.CreateProvider<Jukebox>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Object.jukeboxPlaying)
                {
                    h.SetStopCallback(static m =>
                    {
                        m.Agent.SayDialogue("JukeboxAlreadyPlaying");
                        m.gc.audioHandler.Play(m.Object, "CantDo");
                    });
                    return;
                }
                if (h.Helper.interactingFar)
                {
                    h.AddButton("HackJukebox", static m =>
                    {
                        if (m.Object.jukeboxPlaying)
                        {
                            m.Agent.SayDialogue("JukeboxAlreadyPlaying");
                            m.gc.audioHandler.Play(m.Object, "CantDo");
                            m.Object.StopInteraction();
                            return;
                        }
                        m.Object.HackJukebox();
                    });
                }
                else
                {
                    h.AddButton("JukeboxPlay", 15, static m =>
                    {
                        if (m.Object.jukeboxPlaying)
                        {
                            m.Agent.SayDialogue("JukeboxAlreadyPlaying");
                            m.gc.audioHandler.Play(m.Object, "CantDo");
                            m.Object.StopInteraction();
                            return;
                        }
                        if (m.Object.moneySuccess(15))
                            m.Object.JukeboxPlay(false);
                    });
                }
            });
        }
    }
}
