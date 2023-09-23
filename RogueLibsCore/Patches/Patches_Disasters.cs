using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchDisasters()
        {
            // use CustomDisaster.AllowTeleport
            Patcher.Transpiler(typeof(Agent), nameof(Agent.CanTeleport));

            // inject custom disasters into the mix (CustomDisaster.Test and TestForced)
            Patcher.Transpiler(typeof(LevelFeelings), nameof(LevelFeelings.GetLevelFeeling));
            Patcher.Prefix(typeof(RandomSelection), nameof(RandomSelection.RandomSelect));

            // starting the custom disaster updates
            Patcher.Postfix(typeof(LevelFeelings), "StartAfterNotification");
            // starting the custom disaster
            Patcher.Postfix(typeof(LevelFeelings), nameof(LevelFeelings.StartLevelFeelings));
            // finishing the custom disaster
            Patcher.Transpiler(typeof(LevelTransition), nameof(LevelTransition.ChangeLevel));

            Patcher.Prefix(typeof(LevelFeelings), nameof(LevelFeelings.CanceledAllLevelFeelings));

            Patcher.AnyErrors();
        }

        private static readonly FieldInfo playfieldObjectGcField = typeof(PlayfieldObject).GetField(nameof(PlayfieldObject.gc));
        private static readonly FieldInfo gcLevelFeelingField = typeof(GameController).GetField(nameof(GameController.levelFeeling));

        private static bool Agent_CanTeleport_Helper(string disasterName, string b)
        {
            // true  = can't teleport
            // false = can teleport
            if (disasterName == b) return false; // if disasterName is ""
            CustomDisaster? disaster = RogueFramework.GetActiveDisaster();
            return disaster?.AllowTeleport is not true; // the disaster is not custom or it doesn't allow teleportation
        }
        public static IEnumerable<CodeInstruction> Agent_CanTeleport(IEnumerable<CodeInstruction> code)
            => code.ReplaceRegion(new Func<CodeInstruction, bool>[]
            {
                static i => i.opcode == OpCodes.Ldarg_0,
                static i => i.opcode == OpCodes.Ldfld && (FieldInfo)i.operand == playfieldObjectGcField,
                static i => i.opcode == OpCodes.Ldfld && (FieldInfo)i.operand == gcLevelFeelingField,
                static i => i.opcode == OpCodes.Ldstr && (string)i.operand == "",
                static i => i.opcode == OpCodes.Call && ((MethodInfo)i.operand).Name == "op_Inequality",
            }, new Func<CodeInstruction[], CodeInstruction>[]
            {
                static m => m[0],
                static m => m[1],
                static m => m[2],
                static m => m[3],
                static _ => new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RogueLibsPlugin), nameof(Agent_CanTeleport_Helper))),
            });

        private static bool LevelFeelings_GetLevelFeeling_Helper(string disasterName)
        {
            // returns initial value for the 'flag' variable
            CustomDisaster? custom = RogueFramework.CustomDisasters.Find(d => d.Metadata.Name == disasterName);
            RogueFramework.LogWarning($"Found custom disaster : {custom} - {disasterName}");
            return custom?.Test() is not false; // not a custom disaster, or the custom disaster passed the check
        }
        public static IEnumerable<CodeInstruction> LevelFeelings_GetLevelFeeling(IEnumerable<CodeInstruction> code)
            => code.ReplaceRegion(new Func<CodeInstruction, bool>[]
            {
                static i0 => i0.opcode == OpCodes.Ldc_I4_1, // true
                static i1 => i1.IsStloc(), // set flag
                static i2 => i2.opcode == OpCodes.Ldarg_0, // this
                static i3 => i3.opcode == OpCodes.Ldfld, // GameController LevelFeelings.gc
                static i4 => i4.opcode == OpCodes.Ldfld, // List<string> GameController.challenges
                static i5 => i5.opcode == OpCodes.Ldstr && (string)i5.operand == "NoD_",
                static i6 => i6.IsLdloc(), // load text
            }, new Func<CodeInstruction[], CodeInstruction>[]
            {
                static m => m[6], // load text
                static _ => new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RogueLibsPlugin), nameof(LevelFeelings_GetLevelFeeling_Helper))),
                static m => m[1], // set flag
                static m => m[2], // this
                static m => m[3], // GameController LevelFeelings.gc
                static m => m[4], // List<string> GameController.challenges
                static m => m[5], // "NoD_"
                static m => m[6], // load text
            });

        public static bool RandomSelection_RandomSelect(RandomSelection __instance, string rName, string rCategory, ref string __result)
        {
            if (rName != "LevelFeelings" || rCategory != "Scenarios") return true;

            RandomList random = __instance.randomListTable[rName];
            CustomDisaster? forced = RogueFramework.CustomDisasters.FindLast(static d => d.TestForced());
            if (forced is not null)
            {
                __result = forced.Metadata.Name;
            }
            else
            {
                List<CustomDisaster> custom = RogueFramework.CustomDisasters.FindAll(static d => d.Test());
                int index = UnityEngine.Random.Range(0, random.elementList.Count + custom.Count);
                RogueFramework.LogWarning($"Randomizing, {index} index ({random.elementList.Count} vanilla + {custom.Count} custom).");
                __result = index < random.elementList.Count
                    ? random.elementList[index].rName
                    : custom[index - random.elementList.Count].Metadata.Name;
                RogueFramework.LogWarning($"Selected {__result}.");
            }
            return false;
        }

        public static void LevelFeelings_StartAfterNotification(LevelFeelings __instance, ref IEnumerator __result)
        {
            __result = NewEnumerator(__instance, __result);

            static IEnumerator NewEnumerator(LevelFeelings __instance, IEnumerator __result)
            {
                // execute the entirety of the original enumerator
                while (__result.MoveNext()) yield return __result.Current;

                CustomDisaster? custom = RogueFramework.GetActiveDisaster();
                if (custom is not null && GameController.gameController.serverPlayer)
                {
                    IEnumerator? updating = custom.Updating();
                    if (updating is not null)
                        __instance.StartCoroutine(updating);
                }
            }
        }
        public static void LevelFeelings_StartLevelFeelings()
        {
            CustomDisaster? custom = RogueFramework.GetActiveDisaster();
            custom?.Start();
        }

        private static readonly FieldInfo gcLevelFeelingsScriptField
            = typeof(GameController).GetField(nameof(GameController.levelFeelingsScript));
        private static readonly MethodInfo monoBehaviourStopAllCoroutines
            = typeof(MonoBehaviour).GetMethod(nameof(StopAllCoroutines))!;

        public static IEnumerable<CodeInstruction> LevelTransition_ChangeLevel(IEnumerable<CodeInstruction> code)
            => code.AddRegionAfter(new Func<CodeInstruction, bool>[]
            {
                static i0 => i0.LoadsField(gcLevelFeelingsScriptField),
                static i1 => i1.Calls(monoBehaviourStopAllCoroutines),
            }, new CodeInstruction[]
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RogueLibsPlugin), nameof(LevelTransition_ChangeLevel_Helper))),
            });
        private static void LevelTransition_ChangeLevel_Helper()
        {
            CustomDisaster? custom = RogueFramework.GetActiveDisaster();
            custom?.Finish();
        }

        public static bool LevelFeelings_CanceledAllLevelFeelings(out bool __result)
        {
            __result = RogueFramework.Unlocks.TrueForAll(
                static u => !u.Name.StartsWith("NoD_", StringComparison.Ordinal) || ((MutatorUnlock)u).IsEnabled);
            return false;
        }

    }
}
