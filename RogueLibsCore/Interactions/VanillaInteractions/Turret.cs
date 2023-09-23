namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Turret()
        {
            Patch<Turret>(Params2);
            PatchInteract<Turret>();
            PatchInteractFar<Turret>();

            RogueInteractions.CreateProvider<Turret>(static h =>
            {
                if (!h.Helper.interactingFar) return;

                h.AddButton("TurretAttackOwners", h.Object.targets == "Owners" ? " *" : null, static m =>
                {
                    m.Object.targets = "Owners";
                    if (m.gc.serverPlayer) m.Object.SetTargetRelationships();
                    else m.Agent.objectMult.ObjectAction(m.Object.objectNetID, "TurretAttackOwners");
                });
                h.AddButton("TurretAttackNonOwners", h.Object.targets == "NonOwners" ? " *" : null, static m =>
                {
                    m.Object.targets = "NonOwners";
                    if (m.gc.serverPlayer) m.Object.SetTargetRelationships();
                    else m.Agent.objectMult.ObjectAction(m.Object.objectNetID, "TurretAttackNonOwners");
                });
                h.AddButton("TurretAttackEveryone", h.Object.targets == "Everyone" ? " *" : null, static m =>
                {
                    m.Object.targets = "Everyone";
                    if (m.gc.serverPlayer) m.Object.SetTargetRelationships();
                    else m.Agent.objectMult.ObjectAction(m.Object.objectNetID, "TurretAttackEveryone");
                });
            });
        }
    }
}
