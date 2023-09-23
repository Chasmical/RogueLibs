namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_SlotMachine()
        {
            Patch<SlotMachine>(Params2);
            PatchInteract<SlotMachine>();
            PatchInteractFar<SlotMachine>();

            RogueInteractions.CreateProvider<SlotMachine>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar)
                {
                    if (h.Object.advantage == 0)
                    {
                        h.AddButton("IncreaseSlotMachineOdds", static m =>
                        {
                            m.gc.audioHandler.Play(m.Agent, "Success");
                            m.Object.IncreaseSlotMachineOdds(m.Agent);
                        });
                    }
                }
                else
                {
                    h.AddButton("Play5", 5, static m => m.Object.Gamble(5));
                    h.AddButton("Play20", 20, static m => m.Object.Gamble(20));
                    h.AddButton("Play50", 50, static m => m.Object.Gamble(50));
                }
            });
        }
    }
}
