namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Bush()
        {
            PatchInteract<Bush>();

            RogueLibs.CreateCustomName("HideInBush", NameTypes.Interface, new CustomNameInfo
            {
                English = "Hide",
                Russian = @"Спрятаться",
            });
            RogueInteractions.CreateProvider<Bush>(static h =>
            {
                h.AddImplicitButton("HideInBush", static m =>
                {
                    m.Agent.statusEffects.BecomeHidden(m.Object);
                    m.StopInteraction();
                });
            });
        }
    }
}
