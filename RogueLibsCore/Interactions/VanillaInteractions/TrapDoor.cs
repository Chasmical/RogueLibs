﻿namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_TrapDoor()
        {
            Patch<TrapDoor>(Params1);
            PatchInteract<TrapDoor>();
            PatchInteractFar<TrapDoor>();

            RogueInteractions.CreateProvider<TrapDoor>(static h =>
            {
                if (!h.Helper.interactingFar) return;

                h.AddButton("OpenTrapDoor", static m => m.Object.OpenTrapDoor(false, false, true));
            });
        }
    }
}
