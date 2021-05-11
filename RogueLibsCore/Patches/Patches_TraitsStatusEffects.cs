using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine.Networking;
using UnityEngine;

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

#pragma warning disable CS0618 // NetworkInstanceId is obsolete
			Patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.RemoveTrait), nameof(StatusEffects_RemoveTrait_Prefix),
				new Type[] { typeof(string), typeof(bool), typeof(NetworkInstanceId), typeof(bool) });
			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.RemoveTrait),
				new Type[] { typeof(string), typeof(bool), typeof(NetworkInstanceId), typeof(bool) });
#pragma warning restore CS0618

			Patcher.Transpiler(typeof(StatusEffects), nameof(StatusEffects.GetStatusEffectTime));
			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.GetStatusEffectHate));

			Patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.UpdateStatusEffect));
			Patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.UpdateTrait));
		}

		/// <summary>
		///   <para><b>Transpiler-patch.</b> Adds a <see cref="SetupEffectHook(StatusEffect, StatusEffects)"/> call right after initializing a new instance of <see cref="StatusEffect"/>.</para>
		/// </summary>
		/// <param name="codeEnumerable">Original method's code.</param>
		/// <returns>Modified code, with an added <see cref="SetupEffectHook(StatusEffect, StatusEffects)"/> call.</returns>
		public static IEnumerable<CodeInstruction> StatusEffects_AddStatusEffect(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.ReplaceRegion(
				new Func<CodeInstruction, bool>[]
				{
					i => i.opcode == OpCodes.Ldc_I4_1,
					i => i.IsStloc(),
					i => i.IsLdloc(),
					i => i.IsLdloc(),
					i => i.StoresField(typeof(StatusEffect).GetField(nameof(StatusEffect.curTime)))
				},
				new Func<CodeInstruction[], CodeInstruction>[]
				{
					a => a[0],
					a => a[1],
					a => a[2],
					a => a[3],
					_ => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(RefreshEffect)))
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
		/// <param name="effect">The status effect to set up and initialize hooks for.</param>
		/// <param name="parent">The <see cref="StatusEffects"/> that contains the <paramref name="effect"/> object.</param>
		public static void SetupEffectHook(StatusEffect effect, StatusEffects parent)
		{
			effect.__RogueLibsContainer = parent;
			foreach (IHookFactory<StatusEffect> factory in RogueLibsInternals.EffectFactories)
				if (factory.CanCreate(effect))
				{
					IHook<StatusEffect> hook = factory.CreateHook(effect);
					if (hook != null)
					{
						effect.AddHook(hook);
						hook.Initialize();
					}
				}
		}
		/// <summary>
		///   <para>Refreshes the custom status effect.</para>
		/// </summary>
		/// <param name="effect">The status effect to refresh.</param>
		/// <param name="newTime">The status effect's new time.</param>
		public static void RefreshEffect(StatusEffect effect, int newTime)
		{
			CustomEffect custom = effect.GetHook<CustomEffect>();
			if (custom is null) effect.curTime = newTime;
			else custom.OnRefreshed();
		}

		/// <summary>
		///   <para><b>Transpiler-patch.</b> Adds a <see cref="SetupTraitHook(Trait, StatusEffects)"/> call right after initializing a new instance of <see cref="Trait"/>.</para>
		/// </summary>
		/// <param name="codeEnumerable">Original method's code.</param>
		/// <returns>Modified code, with an added <see cref="SetupTraitHook(Trait, StatusEffects)"/> call.</returns>
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
		/// <summary>
		///   <para>Sets up and initializes <see cref="Trait"/>'s hooks.</para>
		/// </summary>
		/// <param name="trait">Trait to set up and initialize hooks for.</param>
		/// <param name="parent"><see cref="StatusEffects"/> that contains the <paramref name="trait"/> object.</param>
		public static void SetupTraitHook(Trait trait, StatusEffects parent)
		{
			trait.__RogueLibsContainer = parent;
			foreach (IHookFactory<Trait> factory in RogueLibsInternals.TraitFactories)
				if (factory.CanCreate(trait))
				{
					IHook<Trait> hook = factory.CreateHook(trait);
					if (hook != null)
					{
						trait.AddHook(hook);
						hook.Initialize();
					}
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
		///   <para><b>Postfix-patch.</b> Invokes the <see cref="CustomTrait.OnRemoved"/> method.</para>
		/// </summary>
		/// <param name="__state">Trait that will be removed.</param>
		public static void StatusEffects_RemoveTrait(Trait __state)
		{
			CustomTrait trait = __state?.GetHook<CustomTrait>();
			trait?.OnRemoved();
		}

		/// <summary>
		///   <para><b>Prefix-patch.</b> Stores the removed status effect in <paramref name="__state"/>.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="StatusEffects"/>.</param>
		/// <param name="statusEffectName">Name of the status effect that will be removed.</param>
		/// <param name="__state">Status effect that will be removed.</param>
		public static void StatusEffects_RemoveStatusEffect_Prefix(StatusEffects __instance, string statusEffectName, ref StatusEffect __state)
			=> __state = __instance.StatusEffectList?.Find(t => t.statusEffectName == statusEffectName);
		/// <summary>
		///   <para><b>Postfix-patch.</b> Invokes the <see cref="CustomEffect.OnRemoved"/> method.</para>
		/// </summary>
		/// <param name="__state">Status effect that will be removed.</param>
		public static void StatusEffects_RemoveStatusEffect(StatusEffect __state)
		{
			CustomEffect effect = __state?.GetHook<CustomEffect>();
			effect?.OnRemoved();
		}

		/// <summary>
		///   <para><b>Transpiler-patch.</b> Replaces a region of the code with <c>default:</c> case with <see cref="GetStatusEffectTime(StatusEffects, string)"/> call.</para>
		/// </summary>
		/// <param name="codeEnumerable">Original method's code.</param>
		/// <returns>Modified code, with an added <see cref="GetStatusEffectTime(StatusEffects, string)"/> call.</returns>
		public static IEnumerable<CodeInstruction> StatusEffects_GetStatusEffectTime(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.ReplaceRegion(
				new Func<CodeInstruction, bool>[]
				{
					i => i.opcode == OpCodes.Ldc_I4 && (int)i.operand == 9999,
					i => i.IsStloc(),
					i => i.opcode == OpCodes.Ldarg_0
				},
				new Func<CodeInstruction[], CodeInstruction>[]
				{
					a => new CodeInstruction(OpCodes.Ldarg_0).WithLabels(a[0]),
					_ => new CodeInstruction(OpCodes.Ldarg_1),
					_ => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(GetStatusEffectTime))),
					a => a[1],
					a => a[2]
				});
		/// <summary>
		///   <para>Gets the custom status effect's time.</para>
		/// </summary>
		/// <param name="instance">Instance of <see cref="StatusEffects"/>.</param>
		/// <param name="name">Name of the status effect to get time for.</param>
		/// <returns>Custom status effect's time, or 9999, if it's not a custom status effect.</returns>
		public static int GetStatusEffectTime(StatusEffects instance, string name)
		{
			StatusEffect effect = new StatusEffect { statusEffectName = name, __RogueLibsContainer = instance };

			CustomEffect custom = null;
			foreach (IHookFactory<StatusEffect> factory in RogueLibsInternals.EffectFactories)
				if (factory.CanCreate(effect))
				{
					IHook<StatusEffect> hook = factory.CreateHook(effect);
					if (hook is CustomEffect custom2) custom = custom2;
				}
			return custom?.GetEffectTime() ?? 9999;
		}
		/// <summary>
		///   <para><b>Postfix-patch.</b> Changes the <paramref name="__result"/> to the custom effect's hate factor.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="StatusEffects"/>.</param>
		/// <param name="statusEffectName">Name of the status effect to get hate factor for.</param>
		/// <param name="__result">The method' return value.</param>
		public static void StatusEffects_GetStatusEffectHate(StatusEffects __instance, string statusEffectName, ref int __result)
		{
			StatusEffect effect = new StatusEffect { statusEffectName = statusEffectName, __RogueLibsContainer = __instance };

			CustomEffect custom = null;
			foreach (IHookFactory<StatusEffect> factory in RogueLibsInternals.EffectFactories)
				if (factory.CanCreate(effect))
				{
					IHook<StatusEffect> hook = factory.CreateHook(effect);
					if (hook is CustomEffect custom2) custom = custom2;
				}
			if (custom != null)
			{
				__result = custom.GetEffectHate();
				__instance.agent.dontHate = __result == 0;
			}
		}

		public static bool StatusEffects_UpdateStatusEffect(StatusEffects __instance, StatusEffect myStatusEffect, bool showTextOnRemoval, ref IEnumerator __result)
		{
			CustomEffect custom = myStatusEffect.GetHook<CustomEffect>();
			if (custom is null) return true;
			__result = StatusEffectUpdateEnumerator(__instance, custom, showTextOnRemoval);
			return false;
		}
		public static IEnumerator StatusEffectUpdateEnumerator(StatusEffects __instance, CustomEffect customEffect, bool showTextOnRemoval)
		{
			float countSpeed = 1f;
			bool firstTick = true;
			bool flag = true;
			if (GameController.gameController.multiplayerMode && ((GameController.gameController.serverPlayer && __instance.agent.isPlayer > 0 && !__instance.agent.localPlayer) || (!GameController.gameController.serverPlayer && !__instance.agent.localPlayer)))
			{
				flag = false;
			}
			if (flag && __instance.StatusEffectList != null)
			{
				EffectUpdatedArgs args = null;
				while (args?.Cancel != true && (customEffect.CurrentTime > 0 && __instance.hasStatusEffect(customEffect.EffectInfo.Name) && (!__instance.agent.disappeared || __instance.agent.oma.notReadyToEnterLevel || __instance.agent.FellInHole() || __instance.agent.teleporting) || __instance.agent.FellInHole() || __instance.agent.teleporting || __instance.agent.KnockedOut()))
				{
					if (!__instance.agent.FellInHole() && !__instance.agent.teleporting && !__instance.agent.KnockedOut() && GameController.gameController.loadComplete && !GameController.gameController.cinematic)
					{
						if (!customEffect.Effect.infiniteTime)
							customEffect.Effect.prevTime = customEffect.CurrentTime;

						args = new EffectUpdatedArgs
						{
							Cancel = false,
							IsFirstTick = firstTick,
							UpdateDelay = countSpeed,
							ShowTextOnRemoval = showTextOnRemoval
						};
						customEffect.OnUpdated(args);
						countSpeed = args.UpdateDelay;
						showTextOnRemoval = args.ShowTextOnRemoval;
					}
					if (__instance.agent.isPlayer > 0 && __instance.agent.localPlayer && !customEffect.Effect.infiniteTime)
						__instance.myStatusEffectDisplay.RefreshStatusEffectText();
					firstTick = false;
					if (args?.Cancel != true) yield return new WaitForSeconds(countSpeed);
				}
				if (!customEffect.Effect.infiniteTime && (!__instance.agent.disappeared || __instance.agent.FellInHole() || __instance.agent.teleporting) && (!__instance.agent.dead || customEffect.EffectInfo.Name != "Resurrection"))
				{
					FieldInfo field = AccessTools.Field(typeof(StatusEffects), "removeStatusEffectOnUpdate");
					field.SetValue(__instance, true);
					__instance.RemoveStatusEffect(customEffect.EffectInfo.Name, showTextOnRemoval);
					field.SetValue(__instance, false);
				}
			}
		}
	}
}
