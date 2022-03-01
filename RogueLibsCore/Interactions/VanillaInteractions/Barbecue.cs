namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Barbecue()
        {
            Patch<Barbecue>(Params2);
            PatchInteract<Barbecue>();
            RogueInteractions.CreateProvider<Barbecue>(static h =>
            {
                if (!h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                    return;
                }
                if (h.Helper.interactingFar) return;

                if (h.Object.burntOut)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("BarbecueBurntOut"));
                }
                else if (h.Object.ora.hasParticleEffect)
                {
                    if (h.Agent.inventory.HasItem(VanillaItems.Fud))
                        h.AddButton("GrillFud", static m => m.Object.StartCoroutine(m.Object.Operating(m.Agent, null, 2f, true, "Grilling")));
                    else h.SetStopCallback(static m => m.Agent.SayDialogue("CantGrillFud"));
                }
                else
                {
                    if (h.Agent.inventory.HasItem(VanillaItems.CigaretteLighter))
                    {
                        h.AddButton("LightBarbecue", static m => m.Object.StartFireInObject());
                    }
                    else h.SetStopCallback(static m => m.Agent.SayDialogue("CantOperateBarbecue"));
                }
            });
        }
    }
}
