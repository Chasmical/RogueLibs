using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Turntables()
        {
            Patch<Turntables>(Params2);
            PatchInteract<Turntables>();
            PatchInteractFar<Turntables>();

            RogueInteractions.CreateProvider<Turntables>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar)
                {
                    h.AddButton("PlayBadMusic", static m => m.Object.PlayBadMusic());
                    h.AddButton("PlayBadMusic2", static m => m.Object.PlayBadMusic2());
                }
                else
                {
                    Agent? musician = h.Object.MusicianWatching();
                    if (musician is not null && musician != h.Agent)
                    {
                        h.SetStopCallback(_ => musician.SayDialogue(@"DontTouchTurntables"));
                        return;
                    }
                    if (!h.Object.SpeakersFunctional())
                    {
                        h.SetStopCallback(static m => m.Agent.SayDialogue("SpeakersBusted"));
                        return;
                    }
                    h.SetStopCallback(static m => m.Agent.SayDialogue("NoRecordsToPlay"));

                    if (h.Agent.inventory.HasItem("MayorEvidence") && !h.Object.playedEvidence)
                    {
                        h.AddButton("PlayMayorEvidence", static m => m.Object.PlayMayorEvidence(m.Agent));
                    }
                    if (h.Object.startingChunkRealDescription is not "MayorHouse")
                    {
                        List<Agent> agentsSpun = (List<Agent>)turntablesAgentsSpun.GetValue(h.Object);
                        if (agentsSpun.Contains(h.Agent))
                        {
                            h.SetStopCallback(static m => m.Agent.SayDialogue("AlreadySpunRecords"));
                            return;
                        }
                        h.AddButton("SpinRecords", $" ({h.Object.FindSpinRecordsPercentage(false)}%)",
                                    static m => m.Object.SpinRecords());
                    }
                }
            });
        }

        private static readonly FieldInfo turntablesAgentsSpun = AccessTools.Field(typeof(Turntables), "agentsSpun");
    }
}
