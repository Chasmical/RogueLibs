using System.Reflection;
using HarmonyLib;

namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Computer()
        {
            Patch<Computer>(Params1);
            PatchInteract<Computer>();
            PatchInteractFar<Computer>();

            RogueInteractions.CreateProvider<Computer>(static h =>
            {
                if (h.gc.levelType is "HomeBase") return;
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
                h.Object.hackingToolUsed = false;

                if (h.Object.startingChunkRealDescription == "MayorOffice"
                    && !h.Object.electionHacked && (h.Agent.statusEffects.hasTrait("TechExpert") || h.Object.hiredHackerHacking))
                {
                    h.AddButton("HackElection", static m => m.Object.HackElection(m.Agent));
                }

                bool justTurnedOn = (bool)computerJustTurnedOn.GetValue(h.Object);
                bool justTurnedOff = (bool)computerJustTurnedOff.GetValue(h.Object);

                bool hasActiveTraps = false;
                bool hasDisabledTraps = false;
                foreach (ObjectReal obj in h.gc.objectRealList)
                {
                    if ((h.Object.startingChunk == obj.startingChunk
                         || h.Object.startingSector == obj.startingSector && h.Object.startingSector != 0)
                        && (h.Agent.statusEffects.hasTrait("TechExpert") || h.Object.hiredHackerHacking))
                    {
                        if (obj is LaserEmitter laser)
                        {
                            if ((laser.emittingLaser || justTurnedOn) && h.gc.levelType != "Tutorial" && !justTurnedOff)
                            {
                                hasActiveTraps = true;
                                break;
                            }
                            if (h.gc.levelType != "Tutorial" && !justTurnedOff)
                                hasDisabledTraps = true;
                        }
                        else if (obj is SwitchFloor sw)
                        {
                            if ((!sw.switchOn || justTurnedOn) && h.gc.levelType != "Tutorial" && !justTurnedOff)
                            {
                                hasActiveTraps = true;
                                break;
                            }
                        }
                        else if (obj is SecurityCam or FireSpewer or Crusher or SawBlade or FlameGrate)
                        {
                            if ((obj.functional || justTurnedOn) && h.gc.levelType != "Tutorial" && !justTurnedOff)
                            {
                                hasActiveTraps = true;
                                break;
                            }
                            if (h.gc.levelType != "Tutorial" && !justTurnedOff)
                                hasDisabledTraps = true;
                        }
                    }
                }
                if (hasActiveTraps)
                    h.AddButton("TurnOffSecuritySystem", static m => m.Object.TurnOffSecuritySystem(m.Agent));
                else if (hasDisabledTraps)
                    h.AddButton("TurnOnSecuritySystem", static m => m.Object.TurnOnSecuritySystem(m.Agent));

                bool justOpenedDoors = (bool)computerJustOpenedDoors.GetValue(h.Object);
                if ((h.gc.levelType != "Tutorial" || !h.Object.openedTutorialDoor) && !justOpenedDoors)
                {
                    if (h.gc.objectRealList.Exists(o => o is Door { wasLocked: true, open: false } door
                                                        && (door.startingChunk == h.Object.startingChunk || h.Object.startingSector != 0
                                                            && h.Object.startingSector == door.startingSector)))
                    {
                        h.AddButton("OpenDoors", static m =>
                        {
                            m.Object.OpenDoors(m.Agent);
                            if (m.gc.levelType == "Tutorial")
                            {
                                m.Object.openedTutorialDoor = true;
                                m.gc.tutorial.TargetSomething();
                            }
                        });
                    }
                }

                bool justOpenedSafe = (bool)computerJustUnlockedSafe.GetValue(h.Object);
                if (!justOpenedSafe)
                {
                    if (h.gc.objectRealList.Exists(o => o is Safe { locked: true }
                                                        && (o.startingChunk == h.Object.startingChunk || h.Object.startingSector != 0
                                                            && h.Object.startingSector == o.startingSector)))
                    {
                        h.AddButton("UnlockSafe", static m => m.Object.UnlockSafe(m.Agent));
                    }
                }

                foreach (ObjectReal obj in h.gc.objectRealList)
                {
                    if (obj is GasVent vent && (h.Object.startingChunk == obj.startingChunk
                         || h.Object.startingSector == obj.startingSector && h.Object.startingSector != 0))
                    {
                        if (!vent.releasedGas && (h.Agent.statusEffects.hasTrait("TechExpert") || h.Object.hiredHackerHacking))
                        {
                            h.AddButton("ReleaseGas", static m =>
                            {
                                if (m.gc.gasesList.Exists(g => g.startingChunk == m.Object.startingChunk))
                                {
                                    m.Agent.SayDialogue("AlreadyGassing");
                                    return;
                                }
                                m.Object.ReleaseGas(m.Agent);
                            });
                            break;
                        }
                        if (vent.constantSpew && !vent.stoppedGas)
                        {
                            h.AddButton("TurnOffGas", static m => m.Object.TurnOffGas(m.Agent));
                            break;
                        }
                    }
                }

                if (h.Object.canPoison) h.AddButton("PoisonWater", static m => m.Object.PoisonWater(m.Agent));

                foreach (ObjectReal obj in h.gc.objectRealList)
                {
                    if (obj is TrapDoor && (h.Object.startingChunk == obj.startingChunk
                                            || h.Object.startingSector == obj.startingSector && h.Object.startingSector != 0)
                                        && (h.Agent.statusEffects.hasTrait("TechExpert") || h.Object.hiredHackerHacking))
                    {
                        h.AddButton("OpenTrapDoors", static m => m.Object.OpenTrapDoors(m.Agent));
                        break;
                    }
                }
                foreach (ObjectReal obj in h.gc.objectRealList)
                {
                    if (obj is Crusher && (h.Object.startingChunk == obj.startingChunk
                                           || h.Object.startingSector == obj.startingSector && h.Object.startingSector != 0)
                                       && (h.Agent.statusEffects.hasTrait("TechExpert") || h.Object.hiredHackerHacking))
                    {
                        h.AddButton("OperateCrushers", static m => m.Object.OperateCrushers(m.Agent));
                        break;
                    }
                }

                bool addedBroadcast = false;
                bool addedBroadcastHappy = false;
                foreach (ObjectReal obj in h.gc.objectRealList)
                {
                    if (obj is SatelliteDish dish && (h.Object.startingChunk == obj.startingChunk
                                                      || h.Object.startingSector == obj.startingSector && h.Object.startingSector != 0)
                                                  && (h.Agent.statusEffects.hasTrait("TechExpert") || h.Object.hiredHackerHacking))
                    {
                        if (!dish.broadcasted && !addedBroadcast)
                        {
                            h.AddButton("SatelliteBroadcast", static m => m.Object.SatelliteBroadcast(m.Agent));
                            addedBroadcast = true;
                        }
                        if (!dish.broadcastedHappy && !addedBroadcastHappy)
                        {
                            h.AddButton("SatelliteBroadcastHappy", static m => m.Object.SatelliteBroadcastHappy(m.Agent));
                            addedBroadcastHappy = true;
                        }
                    }
                }

                bool justInstalledMalware = (bool)computerJustInstalledMalware.GetValue(h.Object);
                if (h.Agent.bigQuest == "Hacker" && h.Agent.oma.bigQuestObjectCount == 0
                                                 && !justInstalledMalware && !h.gc.loadLevel.LevelContainsMayor())
                {
                    h.AddButton("InstallMalware", static m => m.Object.InstallMalware(m.Agent));
                }
                h.AddButton("ReadEmail", static m =>
                {
                    m.Agent.SayDialogue("ComputerCheckEmail");
                });
            });

        }
        private static readonly FieldInfo computerJustInstalledMalware = AccessTools.Field(typeof(Computer), "justInstalledMalware");
        private static readonly FieldInfo computerJustOpenedDoors = AccessTools.Field(typeof(Computer), "justOpenedDoors");
        private static readonly FieldInfo computerJustTurnedOff = AccessTools.Field(typeof(Computer), "justTurnedOffSecuritySystem");
        private static readonly FieldInfo computerJustTurnedOn = AccessTools.Field(typeof(Computer), "justTurnedOnSecuritySystem");
        private static readonly FieldInfo computerJustUnlockedSafe = AccessTools.Field(typeof(Computer), "justUnlockedSafe");
    }
}
