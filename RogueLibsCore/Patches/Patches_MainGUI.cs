using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchMainGUI()
        {
            Patcher.Postfix(typeof(MainGUI), nameof(MainGUI.HideEverything));
            Patcher.Prefix(typeof(MainGUI), nameof(MainGUI.ShowInventory));
            Patcher.Prefix(typeof(MainGUI), nameof(MainGUI.ShowQuestSheet));

            Patcher.Postfix(typeof(PlayerControl), nameof(PlayerControl.CancelThings));
            Patcher.Postfix(typeof(PlayerControl), "Update");

            Patcher.Transpiler(typeof(MainGUI), nameof(MainGUI.MainGUIUpdate));
            Patcher.Transpiler(typeof(CameraScript), "Update");

            Patcher.AnyErrors();
        }

        public static void MainGUI_HideEverything(MainGUI __instance)
            => HideInterfaces(__instance);
        public static void MainGUI_ShowInventory(MainGUI __instance)
            => HideInterfaces(__instance);
        public static void MainGUI_ShowQuestSheet(MainGUI __instance)
            => HideInterfaces(__instance);

        public static void PlayerControl_CancelThings(PlayerControl __instance, int i)
            => HideInterfaces(__instance.mainGUI[i]);
        public static void PlayerControl_Update(PlayerControl __instance)
        {
            GameController gc = GameController.gameController;
            if (!__instance.cantPressButtons && !gc.finishedLevel)
            {
                for (int i = 0; i < __instance.players; i++)
                {
                    if (i == 0 || gc.coopMode && i <= 1 || gc.fourPlayerMode)
                    {
                        if (!__instance.player[i].dead && !__instance.player[i].FellInHole() && !gc.mainGUI.menuGUI.onMenu
                         && __instance.cantPressGameplayButtonsP[i] == 0 && __instance.cantPressGameplayButtonsPB[i] == 0)
                        {
                            if (__instance.player[i].controllerType == "Keyboard")
                            {
                                if (!(!Input.GetMouseButtonDown(1) || __instance.cantRightClick
                                                                   || (__instance.mainGUI[i].overInterface
                                                                     || __instance.worldSpaceGUI[i].overInterface
                                                                     || __instance.rightClickSuccess)
                                                                    && !__instance.mainGUI[i].openedQuestSheet))
                                {
                                    MainGUI mainGUI = __instance.mainGUI[i];
                                    IHookController? controller = mainGUI.GetHookControllerIfExists();
                                    if (controller is null) return;
                                    foreach (IHook hook in controller.GetHooks())
                                        if (hook is CustomUserInterface ui && ui.IsOpened)
                                        {
                                            mainGUI.invInterface.justPressedAttackOnInterface = true;
                                            ui.HideInterface();
                                        }
                                }

                            }
                        }

                    }
                }
            }
        }

        private static void HideInterfaces(MainGUI mainGUI)
        {
            IHookController? controller = mainGUI.GetHookControllerIfExists();
            if (controller is null) return;
            foreach (IHook hook in controller.GetHooks())
                (hook as CustomUserInterface)?.HideInterface();
        }

        private static readonly FieldInfo openedInventoryField = AccessTools.Field(typeof(MainGUI), nameof(MainGUI.openedInventory));

        public static IEnumerable<CodeInstruction> MainGUI_MainGUIUpdate(IEnumerable<CodeInstruction> code)
            => code.ReplaceRegion(new Func<CodeInstruction, bool>[]
            {
                static i => i.LoadsField(openedInventoryField),
            }, new Func<CodeInstruction[], CodeInstruction>[]
            {
                static _ => new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RogueLibsPlugin), nameof(GetIsInterfaceOpen))),
            });
        private static bool GetIsInterfaceOpen(MainGUI mainGUI)
        {
            if (mainGUI.openedInventory) return true;
            IHookController? controller = mainGUI.GetHookControllerIfExists();
            if (controller is null) return false;
            return controller.GetHooks().Any(static h => h is CustomUserInterface ui && ui.IsOpened);
        }

        public static IEnumerable<CodeInstruction> CameraScript_Update(IEnumerable<CodeInstruction> code)
            => code.ReplaceRegion(new Func<CodeInstruction, bool>[]
            {
                static i => i.LoadsField(openedInventoryField),
            }, new Func<CodeInstruction[], CodeInstruction>[]
            {
                static _ => new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RogueLibsPlugin), nameof(GetIsCameraLocked))),
            });
        private static bool GetIsCameraLocked(MainGUI mainGUI)
        {
            if (mainGUI.openedInventory) return true;
            IHookController? controller = mainGUI.GetHookControllerIfExists();
            if (controller is null) return false;
            return controller.GetHooks().Any(static h => h is CustomUserInterface ui && ui.IsOpened && ui.LocksCamera);
        }

    }
}
