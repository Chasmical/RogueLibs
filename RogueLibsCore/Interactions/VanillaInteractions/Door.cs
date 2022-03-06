using UnityEngine;

namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Door()
        {
            Patch<Door>(Params1);
            PatchInteract<Door>();
            PatchInteractFar<Door>();

            RogueInteractions.CreateProvider<Door>(static h =>
            {
                if (h.Helper.interactingFar)
                {
                    if (h.Object.placedDetonatorInitial is 1)
                    {
                        h.AddButton("AttemptDisarmDoorDetonator", $" ({h.Object.FindDisarmPercentage(false)}%)",
                                    static m => m.Object.AttemptDisarm());
                    }
                    return;
                }

                if (h.Object.justInteractedImmediate)
                {
                    h.StopInteraction();
                    h.Object.justInteractedImmediate = false;
                    return;
                }

                if (h.Object.doorType is "DoorAutomatic" or "DoorPanicRoom") return;

                if (h.Object.open)
                {
                    h.AddImplicitButton("Close", static m =>
                    {
                        if (!m.Object.DoorBlocked(false))
                            m.Object.CloseDoor(m.Agent);
                        m.StopInteraction();
                    });
                    return;
                }

                bool canReach = h.Object.direction is "E" or "W"
                    ? Mathf.Abs(h.Object.doorHelper.tr.position.x - h.Agent.tr.position.x) < 0.5f
                    : Mathf.Abs(h.Object.doorHelper.tr.position.y - h.Agent.tr.position.y) < 0.5f;

                if (!canReach) return;

                h.SetStopCallback(static m => m.Agent.SayDialogue("CantOpenDoor"));

                if (!h.Object.locked)
                {
                    h.AddImplicitButton("Open", static m =>
                    {
                        if (m.Object.doorCooldown <= 0f)
                            m.Object.OpenDoor(m.Agent);
                        m.StopInteraction();
                    });
                }

                if (h.Object.placedDetonatorInitial is 1 && !h.Agent.isHoisting)
                {
                    h.AddButton("AttemptDisarmDoorDetonator", $" ({h.Object.FindDisarmPercentage(false)}%)", static m =>
                    {
                        m.Object.StartCoroutine(m.Object.Operating(m.Agent, null, 2f, true, "DisarmingDetonator"));
                    });
                }
                if (h.Object.prisonObject is 0 && h.gc.levelShape is 0 && h.Object.extraVar is not 7
                    && h.gc.levelType is not "Tutorial" and not "HomeBase")
                {
                    h.AddButton("Knock", static m =>
                    {
                        m.Object.KnockOnDoor(m.Agent);
                        m.StopInteraction();
                    });
                }

                InvItem? doorDetonator = h.Agent.inventory.FindItem("DoorDetonator");
                if (!h.Object.hasDetonator && doorDetonator is not null && !h.Agent.isHoisting)
                {
                    h.AddButton("PlaceDetonator", $" ({doorDetonator.invItemCount})", static m =>
                    {
                        m.Object.StartCoroutine(m.Object.Operating(m.Agent, m.Agent.inventory.FindItem("DoorDetonator"),
                                                                   2f, true, "PlacingDetonator"));
                    });
                }

                if (!h.Agent.inventory.InvItemList.Exists(i => i.invItemName is "Key" or "KeyCard"
                                                               && (i.chunks.Contains(h.Object.startingChunk)
                                                                   || h.Object.startingSector is not 0
                                                                   && i.sectors.Contains(h.Object.startingSector))))
                {
                    h.AddButton("UseKey", static m =>
                    {
                        m.Object.Unlock();
                        m.Object.OpenDoor(m.Agent);
                        m.StopInteraction();
                    });
                }
                else
                {
                    if (h.Agent.inventory.HasItem("SkeletonKey"))
                    {
                        h.AddButton("UseSkeletonKey", static m =>
                        {
                            m.Object.Unlock();
                            m.Object.OpenDoor(m.Agent);
                            m.StopInteraction();
                        });
                    }
                    InvItem? lockpick = h.Agent.inventory.FindItem("Lockpick");
                    if (lockpick is not null && !h.Agent.isHoisting)
                    {
                        h.AddButton("UseLockpick", $" ({lockpick.invItemCount})", static m =>
                        {
                            m.Object.StartCoroutine(m.Object.Operating(m.Agent, m.Agent.inventory.FindItem("Lockpick"),
                                                                       2f, true, "Unlocking"));
                        });
                    }
                    InvItem? crowbar = h.Agent.inventory.FindItem("Crowbar");
                    if (crowbar is not null && !h.Agent.isHoisting)
                    {
                        h.AddButton("UseCrowbar", $" ({crowbar.invItemCount}) -30", static m =>
                        {
                            m.Object.StartCoroutine(m.Object.Operating(m.Agent, m.Agent.inventory.FindItem("Crowbar"),
                                                                       2f, true, "Unlocking"));
                        });
                    }
                }
                if (h.gc.levelType == "Tutorial")
                    h.gc.tutorial.InteractedDoor();
            });
        }
    }
}
