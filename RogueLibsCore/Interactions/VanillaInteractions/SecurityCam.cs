namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_SecurityCam()
        {
            Patch<SecurityCam>(Params2);
            PatchInteract<SecurityCam>();
            PatchInteractFar<SecurityCam>();

            RogueInteractions.CreateProvider<SecurityCam>(static h =>
            {
                if (h.Helper.interactingFar)
                {
                    if (h.Object.functional)
                    {
                        h.AddButton("TurnCameraOff", static m =>
                        {
                            if (m.gc.serverPlayer) m.Object.MakeNonFunctional(null);
                            else m.Agent.objectMult.ObjectAction(m.Object.objectNetID, "TurnCameraOff");
                        });
                    }
                    else
                    {
                        h.AddButton("TurnCameraOn", static m =>
                        {
                            m.Object.MakeFunctional();
                            if (!m.gc.serverPlayer) m.Agent.objectMult.ObjectAction(m.Object.objectNetID, "TurnCameraOn");
                        });
                    }

                    h.AddButton("CamerasCaptureOwners", h.Object.targets == "Owners" ? " *" : null, static m =>
                    {
                        m.Object.targets = "Owners";
                        if (!m.gc.serverPlayer) m.Agent.objectMult.ObjectAction(m.Object.objectNetID, "CamerasCaptureOwners");
                    });
                    h.AddButton("CamerasCaptureNonOwners", h.Object.targets == "NonOwners" ? " *" : null, static m =>
                    {
                        m.Object.targets = "NonOwners";
                        if (!m.gc.serverPlayer) m.Agent.objectMult.ObjectAction(m.Object.objectNetID, "CamerasCaptureNonOwners");
                    });
                    h.AddButton("CamerasCaptureEveryone", h.Object.targets == "Everyone" ? " *" : null, static m =>
                    {
                        m.Object.targets = "Everyone";
                        if (!m.gc.serverPlayer) m.Agent.objectMult.ObjectAction(m.Object.objectNetID, "CamerasCaptureEveryone");
                    });
                }
                else
                {
                    if (!h.Object.functional)
                    {
                        h.SetStopCallback(static m => m.Agent.SayDialogue("ObjectBroken"));
                        return;
                    }
                    if (h.Agent.statusEffects.hasTrait("NoTechSkill"))
                    {
                        h.SetStopCallback(static m => m.Agent.SayDialogue("CantUseTech"));
                        return;
                    }
                    h.AddButton("AttemptTurnOffSecurityCam", $" ({h.Object.FindDisarmPercentage(false)}%)",
                                static m => m.StartOperating(2f, true, "TurningOffSecurityCam"));
                }
            });
        }
    }
}
