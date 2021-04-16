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
			Patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.RemoveTrait), nameof(StatusEffects_RemoveTrait_Prefix),
				new Type[] { typeof(string), typeof(bool) });
			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.RemoveTrait),
				new Type[] { typeof(string), typeof(bool) });
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
					i => i.IsLdloc(),
					i => i.opcode == OpCodes.Ldarg_3,
					i => i.opcode == OpCodes.Stfld && i.StoresField(typeof(StatusEffect).GetField(nameof(StatusEffect.causingAgent)))
				},
				new Func<CodeInstruction[], CodeInstruction>[]
				{
					(a) => a[0],
					(_) => new CodeInstruction(OpCodes.Ldarg_0),
					(_) => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(SetupEffectHook)))
				});
		/// <summary>
		///   <para>Sets up and initializes <see cref="StatusEffect"/>'s hooks.</para>
		/// </summary>
		/// <param name="effect">Effect to set up and initialize hooks for.</param>
		/// <param name="parent"><see cref="StatusEffects"/> that contains the <paramref name="effect"/> object.</param>
		public static void SetupEffectHook(StatusEffect effect, StatusEffects parent)
		{
			effect.__RogueLibsContainer = parent;
			foreach (IHookFactory<StatusEffect> factory in RogueLibsInternals.StatusEffectFactories)
				if (factory.CanCreate(effect))
				{
					IHook<StatusEffect> hook = factory.CreateHook(effect);
					effect.AddHook(hook);
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
	}
}
