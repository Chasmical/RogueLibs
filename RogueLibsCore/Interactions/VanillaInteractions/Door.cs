using UnityEngine;

namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Door()
        {
            Patch<Door>(Params1);
            PatchInteract<Door>();
            PatchInteractFar<Door>();

            RogueInteractions.CreateProvider<Door>(static h =>
            {
                if (h.Helper.interactingFar) // hacking remotely
                {
                    if (h.Object.placedDetonatorInitial == 1)
                    {
                        h.AddButton("AttemptDisarmDoorDetonator", $" ({h.Object.FindDisarmPercentage(false)}%)",
                                    static m => m.Object.AttemptDisarm());
                    }
                    return;
                }

                if (h.Object.justInteractedImmediate)
                {
                    h.Model.StopInteraction(true);
                    h.Object.justInteractedImmediate = false;
                    return;
                }

                // not interactions for automatic and panic room doors
                if (h.Object.doorType is "DoorAutomatic" or "DoorPanicRoom") return;

                if (h.Object.open) // if the door's open, add just the implicit "Close" button
                {
                    h.AddImplicitButton("Close", static m =>
                    {
                        if (m.Object.doorCooldown <= 0f && !m.Object.DoorBlocked(false))
                            m.Object.CloseDoor(m.Agent);
                        m.StopInteraction();
                    });
                    return;
                }

                // the door's closed, set the stop callback
                h.SetStopCallback(static m => m.Agent.SayDialogue("CantOpenDoor"));

                if (h.Object.placedDetonatorInitial == 1 && !h.Agent.isHoisting) // if there's a detonator, add the "Disarm" button
                {
                    h.AddButton("AttemptDisarmDoorDetonator", $" ({h.Object.FindDisarmPercentage(false)}%)",
                                static m => m.StartOperating(2f, true, "DisarmingDetonator"));
                    return;
                }

                bool onInside = h.Object.direction is "E" or "W"
                    ? Mathf.Abs(h.Object.doorHelper.tr.position.x - h.Agent.tr.position.x) < 0.5f
                    : Mathf.Abs(h.Object.doorHelper.tr.position.y - h.Agent.tr.position.y) < 0.5f;

                bool isSpecialLevel = h.gc.levelType is "Tutorial" or "HomeBase";

                static void OpenButton(InteractionModel<Door> m)
                {
                    if (m.Object.doorCooldown <= 0f)
                        m.Object.OpenDoor(m.Agent);
                    m.StopInteraction();
                }

                if (h.Object.locked) // the door is locked
                {
                    if (onInside && h.gc.levelShape == 0 && !isSpecialLevel)
                    {
                        // if the player's inside of a locked room, add an implicit "Open" button
                        h.AddImplicitButton("Open", OpenButton);
                        return;
                    }
                    // can't open, the door is locked
                }
                else if (h.Object.doorType == "DoorNoEntry") // the door leads to a prohibited area
                {
                    if (onInside && h.gc.levelShape == 0 || isSpecialLevel || !h.Object.outsideDoor)
                    {
                        // if the player is inside the prohibited area, or if the door is IN the prohibited area
                        // (in either case we wouldn't want to prompt the player to open the door)
                        h.AddImplicitButton("Open", OpenButton);
                        return;
                    }
                    h.AddButton("Open", OpenButton); // prompt the player to go into the prohibited area
                }
                else // some other kind of door
                {
                    h.AddImplicitButton("Open", OpenButton);
                    return;
                }

                // at this point, the "Open" button either is not present or is explicit

                if (h.Object.prisonObject == 0 && h.gc.levelShape == 0 && h.Object.extraVar != 7 && !isSpecialLevel)
                {
                    h.AddButton("Knock", static m =>
                    {
                        m.Object.KnockOnDoor(m.Agent);
                        m.StopInteraction();
                    });
                }

                if (h.Object.locked) // if the door's locked, show options to open it
                {
                    if (h.Agent.inventory.InvItemList.Exists(i => i.invItemName is "Key" or "KeyCard"
                                                                  && (i.chunks.Contains(h.Object.startingChunk)
                                                                      || h.Object.startingSector != 0
                                                                      && i.sectors.Contains(h.Object.startingSector))))
                    {
                        // if there's a key for this specific door, show it as an only option
                        h.AddButton("UseKey", static m =>
                        {
                            m.Object.Unlock();
                            m.Object.OpenDoor(m.Agent);
                            m.StopInteraction();
                        });
                    }
                    else
                    {
                        // add the Skeleton Key interaction
                        if (h.Agent.inventory.HasItem("SkeletonKey"))
                        {
                            h.AddButton("UseSkeletonKey", static m =>
                            {
                                m.Object.Unlock();
                                m.Object.OpenDoor(m.Agent);
                                m.StopInteraction();
                            });
                        }

                        // add the Lockpick interaction
                        InvItem? lockpick = h.Agent.inventory.FindItem("Lockpick");
                        if (lockpick is not null && !h.Agent.isHoisting)
                        {
                            h.AddButton("UseLockpick", $" ({lockpick.invItemCount})",
                                        static m => m.StartOperating("Lockpick", 2f, true, "Unlocking"));
                        }

                        // add the Crowbar interaction
                        InvItem? crowbar = h.Agent.inventory.FindItem("Crowbar");
                        if (crowbar is not null && !h.Agent.isHoisting)
                        {
                            h.AddButton("UseCrowbar", $" ({crowbar.invItemCount}) -30",
                                        static m => m.StartOperating("Crowbar", 2f, true, "Unlocking"));
                        }
                    }
                }

                // add the Door Detonator interaction
                InvItem? doorDetonator = h.Agent.inventory.FindItem("DoorDetonator");
                if (!h.Object.hasDetonator && doorDetonator is not null && !h.Agent.isHoisting)
                {
                    h.AddButton("PlaceDetonator", $" ({doorDetonator.invItemCount})", static m
                                    => m.StartOperating("DoorDetonator", 2f, true, "PlacingDetonator"));
                }

            });

            // run the Tutorial trigger separately, to make sure it always runs
            RogueInteractions.CreateProvider<Door>(static h =>
            {
                if (h.Helper.interactingFar || h.Object.justInteractedImmediate) return;

                if (h.gc.levelType == "Tutorial")
                    h.gc.tutorial.InteractedDoor();
            });

        }
    }
}
