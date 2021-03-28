using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using HarmonyLib;

namespace RogueLibsCore
{
	public partial class RogueLibsPlugin
	{
		/// <summary>
		///   <para>Applies the patches to <see cref="StatusEffects"/>.</para>
		/// </summary>
		public void PatchTraitsAndStatusEffects()
		{

		}
		private static OpCode statusEffectLdloc;
		private static object statusEffectNum;
		public static IEnumerable<CodeInstruction> StatusEffects_AddStatusEffect(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.AddRegionAfter(
				new Func<CodeInstruction, bool>[]
				{
					i => { bool res = i.IsLdloc(); if (res) { statusEffectNum = i.operand; statusEffectLdloc = i.opcode; } return res; },
					i => i.opcode == OpCodes.Ldarg_3,
					i => i.opcode == OpCodes.Stfld && i.StoresField(typeof(StatusEffect).GetField(nameof(StatusEffect.causingAgent)))
				},
				new Func<CodeInstruction>[]
				{
					() => new CodeInstruction(statusEffectLdloc, statusEffectNum),
					() => new CodeInstruction(OpCodes.Call, setupEffectHookMethod)
				}
				);
		private static readonly MethodInfo setupEffectHookMethod = SymbolExtensions.GetMethodInfo((StatusEffect effect) => SetupEffectHook(effect));
		public static void SetupEffectHook(StatusEffect effect)
		{
			// attach hook, if the name matches + other stuff
		}
	}
}
