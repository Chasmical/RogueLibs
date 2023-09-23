namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Toilet()
        {
            Patch<Toilet>(Params2);
            PatchInteract<Toilet>();

            RogueInteractions.CreateProvider<Toilet>(static h =>
            {
                if (h.Helper.interactingFar || h.gc.levelType == "HomeBase") return;

                h.SetStopCallback(static m => m.Agent.SayDialogue("ToiletWontGo"));

                if ((h.Agent.statusEffects.hasTrait("Diminutive") || h.Agent.statusEffects.hasStatusEffect("Shrunk"))
                    && !h.Agent.statusEffects.hasStatusEffect("Giant"))
                {
                    h.AddButton("FlushYourself", static m => m.Object.FlushYourself());
                }
                if (h.Object.hasPurgeStatusEffects())
                {
                    h.AddButton("PurgeStatusEffects", static m => m.Object.PurgeStatusEffects());
                }
            });
        }
    }
}
