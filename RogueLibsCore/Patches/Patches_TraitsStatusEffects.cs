using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine.Networking;

namespace RogueLibsCore
{
	public partial class RogueLibsPlugin
	{
		/// <summary>
		///   <para>Applies the patches to <see cref="StatusEffects"/>.</para>
		/// </summary>
		public void PatchTraitsAndStatusEffects()
		{
#pragma warning disable CS0618 // NetworkInstanceId is obsolete
			Patcher.Transpiler(typeof(StatusEffects), nameof(StatusEffects.AddStatusEffect),
				new Type[] { typeof(string), typeof(bool), typeof(Agent), typeof(NetworkInstanceId), typeof(bool), typeof(int) });
#pragma warning restore CS0618
			Patcher.Transpiler(typeof(StatusEffects), nameof(StatusEffects.AddTrait),
				new Type[] { typeof(string), typeof(bool), typeof(bool) });

			Patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.RemoveTrait), nameof(StatusEffects_RemoveTrait_Prefix),
				new Type[] { typeof(string), typeof(bool) });
			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.RemoveTrait),
				new Type[] { typeof(string), typeof(bool) });

			Patcher.Transpiler(typeof(StatusEffects), nameof(StatusEffects.GetStatusEffectTime));
		}
		/// <summary>
		///   <para><b>Transpiler-patch.</b> Adds a status effect initialization right after initializing a new instance of <see cref="StatusEffect"/>.</para>
		/// </summary>
		/// <param name="codeEnumerable">Original method's code.</param>
		/// <returns>Modified code, with an added status effect initialization.</returns>
		public static IEnumerable<CodeInstruction> StatusEffects_AddStatusEffect(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.AddRegionAfter(
				new Func<CodeInstruction, bool>[]
				{
					i => i.opcode == OpCodes.Ldarg_0,
					i => i.opcode == OpCodes.Ldarg_1,
					i => i.opcode == OpCodes.Call && i.Calls(typeof(StatusEffects).GetMethod(nameof(StatusEffects.GetStatusEffectTime))),
					i => i.IsStloc()
				},
				new Func<CodeInstruction[], CodeInstruction>[]
				{

				}).AddRegionAfter(
				new Func<CodeInstruction, bool>[]
				{
					i => i.IsLdloc(),
					i => i.opcode == OpCodes.Ldarg_3,
					i => i.opcode == OpCodes.Stfld && i.StoresField(typeof(StatusEffect).GetField(nameof(StatusEffect.causingAgent)))
				},
				new Func<CodeInstruction[], CodeInstruction>[]
				{
					a => a[0],
					_ => new CodeInstruction(OpCodes.Ldarg_0),
					_ => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(SetupEffectHook)))
				});
		/// <summary>
		///   <para>Sets up and initializes <see cref="StatusEffect"/>'s hooks.</para>
		/// </summary>
		/// <param name="effect">Effect to set up and initialize hooks for.</param>
		/// <param name="parent"><see cref="StatusEffects"/> that contains the <paramref name="effect"/> object.</param>
		public static void SetupEffectHook(StatusEffect effect, StatusEffects parent)
		{
			effect.__RogueLibsContainer = parent;
			foreach (IHookFactory<StatusEffect> factory in RogueLibsInternals.EffectFactories_Init.Concat(RogueLibsInternals.EffectFactories))
				if (factory.CanCreate(effect))
				{
					IHook<StatusEffect> hook = factory.CreateHook(effect);
					effect.AddHook(hook);
					hook.Initialize();
				}
		}

		public static IEnumerable<CodeInstruction> StatusEffects_AddTrait(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.AddRegionAfter(
				new Func<CodeInstruction, bool>[]
				{
					i => i.IsLdloc(),
					i => i.opcode == OpCodes.Ldarg_1,
					i => i.opcode == OpCodes.Stfld && i.StoresField(typeof(Trait).GetField(nameof(Trait.traitName)))
				},
				new Func<CodeInstruction[], CodeInstruction>[]
				{
					a => a[0],
					_ => new CodeInstruction(OpCodes.Ldarg_0),
					_ => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(SetupTraitHook)))
				});
		public static void SetupTraitHook(Trait trait, StatusEffects parent)
		{
			trait.__RogueLibsContainer = parent;
			foreach (IHookFactory<Trait> factory in RogueLibsInternals.TraitFactories_Init.Concat(RogueLibsInternals.TraitFactories))
				if (factory.CanCreate(trait))
				{
					IHook<Trait> hook = factory.CreateHook(trait);
					trait.AddHook(hook);
					hook.Initialize();
				}
		}

		/// <summary>
		///   <para><b>Prefix-patch.</b> Stores the removed trait in <paramref name="__state"/>.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="StatusEffects"/>.</param>
		/// <param name="traitName">Name of the trait that will be removed.</param>
		/// <param name="__state">Trait that will be removed.</param>
		public static void StatusEffects_RemoveTrait_Prefix(StatusEffects __instance, string traitName, ref Trait __state)
			=> __state = __instance.TraitList?.Find(t => t.traitName == traitName);
		/// <summary>
		///   <para><b>Postfix-patch.</b> Invokes the <see cref="CustomEffect.OnRemoved"/> method.</para>
		/// </summary>
		/// <param name="__state">Trait that will be removed.</param>
		public static void StatusEffects_RemoveTrait(Trait __state)
		{
			CustomTrait trait = __state?.GetHook<CustomTrait>();
			trait?.OnRemoved();
		}

		public static IEnumerable<CodeInstruction> StatusEffects_GetStatusEffectTime(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.ReplaceRegion(
				new Func<CodeInstruction, bool>[]
				{
					i => i.opcode == OpCodes.Ldc_I4 && i.operand is 9999,
					i => i.IsStloc(),
					i => i.opcode == OpCodes.Ldarg_0
				},
				new Func<CodeInstruction[], CodeInstruction>[]
				{
					_ => new CodeInstruction(OpCodes.Ldarg_0),
					_ => new CodeInstruction(OpCodes.Ldarg_1),
					_ => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(GetStatusEffectTime))),
					a => a[1],
					a => a[2]
				});

		public static int GetStatusEffectTime(StatusEffects instance, string name)
		{
			StatusEffect effect = new StatusEffect { statusEffectName = name, __RogueLibsContainer = instance };

			CustomEffect custom = null;
			foreach (IHookFactory<StatusEffect> factory in RogueLibsInternals.EffectFactories_Init)
				if (factory.CanCreate(effect))
				{
					IHook<StatusEffect> hook = factory.CreateHook(effect);
					if (hook is CustomEffect custom2) custom = custom2;
				}
			return custom?.GetEffectTime() ?? 9999;
		}
	}
}
