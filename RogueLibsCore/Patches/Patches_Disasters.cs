using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace RogueLibsCore
{
    public sealed partial class RogueLibsPlugin
    {
        public void PatchDisasters()
        {
            // use CustomDisaster.AllowTeleport
            Patcher.Transpiler(typeof(Agent), nameof(Agent.CanTeleport));

            // inject custom disasters into the mix (CustomDisaster.Test and TestForced)
            Patcher.Transpiler(typeof(LevelFeelings), nameof(LevelFeelings.GetLevelFeeling));
            Patcher.Prefix(typeof(RandomSelection), nameof(RandomSelection.RandomSelect));

            // starting the custom disaster
            Patcher.Postfix(typeof(LevelFeelings), nameof(LevelFeelings.StartLevelFeelings));
            // finishing the custom disaster
            Patcher.Prefix(typeof(LevelFeelings), nameof(LevelFeelings.EndLevelFeeling));

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
            CustomDisaster? custom = RogueFramework.CustomDisasters.Find(d => d.DisasterInfo.Name == disasterName);
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
            if (rName is not "LevelFeelings" || rCategory is not "Scenarios") return true;

            RandomList random = __instance.randomListTable[rName];
            CustomDisaster? forced = RogueFramework.CustomDisasters.FindLast(static d => d.TestForced());
            if (forced is not null)
            {
                __result = forced.DisasterInfo.Name;
            }
            else
            {
                List<CustomDisaster> custom = RogueFramework.CustomDisasters.FindAll(static d => d.Test());
                int index = UnityEngine.Random.Range(0, random.elementList.Count + custom.Count);
                __result = index < random.elementList.Count
                    ? random.elementList[index].rName
                    : custom[index - random.elementList.Count].DisasterInfo.Name;
            }
            return false;
        }

        public static void LevelFeelings_StartLevelFeelings(LevelFeelings __instance)
        {
            CustomDisaster? custom = RogueFramework.GetActiveDisaster();
            // ReSharper disable once UseNullPropagationWhenPossible
            if (custom is not null)
            {
                custom.Start();
                IEnumerator? updating = (IEnumerator?)custom.Updating();
                if (updating is not null)
                    custom.updatingCoroutine = __instance.StartCoroutine(updating);

            }
        }
        public static void LevelFeelings_EndLevelFeeling(LevelFeelings __instance)
        {
            CustomDisaster? custom = RogueFramework.GetActiveDisaster();
            // ReSharper disable once UseNullPropagationWhenPossible
            if (custom is not null)
            {
                if (custom.updatingCoroutine is not null)
                {
                    __instance.StopCoroutine(custom.updatingCoroutine);
                    custom.updatingCoroutine = null;
                }
                custom.Finish();
            }
        }

    }
}
