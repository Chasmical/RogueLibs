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
using System.Diagnostics;
using static UnityEngine.Random;

namespace RogueLibsCore
{
	internal sealed partial class RogueLibsPlugin
	{
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
			Patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.RemoveStatusEffect), nameof(StatusEffects_RemoveStatusEffect_Prefix),
				new Type[] { typeof(string), typeof(bool), typeof(NetworkInstanceId), typeof(bool) });
			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.RemoveStatusEffect),
				new Type[] { typeof(string), typeof(bool), typeof(NetworkInstanceId), typeof(bool) });
#pragma warning restore CS0618

			Patcher.Transpiler(typeof(StatusEffects), nameof(StatusEffects.GetStatusEffectTime));
			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.GetStatusEffectHate));

			Patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.UpdateStatusEffect));
			Patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.UpdateTrait));

			Patcher.AnyErrors();
		}

		public static IEnumerable<CodeInstruction> StatusEffects_AddStatusEffect(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.ReplaceRegion(
				new Func<CodeInstruction, bool>[]
				{
					i => i.opcode == OpCodes.Ldc_I4_1,
					i => i.IsStloc(),
					i => i.IsLdloc(),
					i => i.IsLdloc(),
					i => i.StoresField(StatusEffect_curTime)
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
					i => i.opcode == OpCodes.Stfld && i.StoresField(StatusEffect_causingAgent)
				},
				new Func<CodeInstruction[], CodeInstruction>[]
				{
					a => a[0],
					_ => new CodeInstruction(OpCodes.Ldarg_0),
					_ => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(SetupEffectHook)))
				});
		private static readonly FieldInfo StatusEffect_curTime = typeof(StatusEffect).GetField(nameof(StatusEffect.curTime));
		private static readonly FieldInfo StatusEffect_causingAgent = typeof(StatusEffect).GetField(nameof(StatusEffect.causingAgent));
		public static void SetupEffectHook(StatusEffect effect, StatusEffects parent)
		{
			bool debug = RogueFramework.IsDebugEnabled(DebugFlags.Effects);
			effect.__RogueLibsContainer = parent;
			foreach (IHookFactory<StatusEffect> factory in RogueFramework.EffectFactories)
				if (factory.TryCreate(effect, out IHook<StatusEffect> hook))
				{
					if (debug)
					{
						if (hook is CustomEffect)
							RogueFramework.LogDebug($"Initializing custom effect {hook} ({effect.statusEffectName}, {parent.agent.agentName}).");
						else RogueFramework.LogDebug($"Initializing effect hook {hook} ({effect.statusEffectName}, {parent.agent.agentName}).");
					}
					effect.AddHook(hook);
					// CustomEffect does not call OnAdded when initialized,
					// because of the GetStatusEffectTime/Hate patches
					if (hook is CustomEffect custom) custom.OnAdded();
				}
		}
		public static void RefreshEffect(StatusEffect effect, int newTime)
		{
			CustomEffect custom = effect.GetHook<CustomEffect>();
			float oldTime = effect.curTime;
			if (custom is null) effect.curTime = newTime;
			else custom.OnRefreshed();
			if (RogueFramework.IsDebugEnabled(DebugFlags.Effects))
				RogueFramework.LogDebug($"Refreshed {custom} ({effect.statusEffectName}, {effect.GetStatusEffects().agent.agentName}): {oldTime} > {effect.curTime}.");
		}

		public static IEnumerable<CodeInstruction> StatusEffects_AddTrait(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.AddRegionAfter(
				new Func<CodeInstruction, bool>[]
				{
					i => i.IsLdloc(),
					i => i.opcode == OpCodes.Ldarg_1,
					i => i.opcode == OpCodes.Stfld && i.StoresField(Trait_traitName)
				},
				new Func<CodeInstruction[], CodeInstruction>[]
				{
					a => a[0],
					_ => new CodeInstruction(OpCodes.Ldarg_0),
					_ => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(SetupTraitHook)))
				});
		private static readonly FieldInfo Trait_traitName = typeof(Trait).GetField(nameof(Trait.traitName));
		public static void SetupTraitHook(Trait trait, StatusEffects parent)
		{
			bool debug = RogueFramework.IsDebugEnabled(DebugFlags.Traits);
			bool updateable = false;
			trait.__RogueLibsContainer = parent;
			foreach (IHookFactory<Trait> factory in RogueFramework.TraitFactories)
				if (factory.TryCreate(trait, out IHook<Trait> hook))
				{
					if (debug)
					{
						if (hook is CustomTrait)
							RogueFramework.LogDebug($"Initializing custom trait {hook} ({trait.traitName}, {parent.agent.agentName}).");
						else RogueFramework.LogDebug($"Initializing trait hook {hook} ({trait.traitName}, {parent.agent.agentName}).");
					}
					trait.AddHook(hook);
					if (hook is CustomTrait && hook is ITraitUpdateable)
						updateable = true;
				}

			if (updateable && parent.agent.name != "DummyAgent" && !parent.agent.name.Contains("Backup"))
			{
				parent.StartCoroutine(parent.UpdateTrait(trait));
				trait.requiresUpdates = true;
			}
		}

		public static void StatusEffects_RemoveTrait_Prefix(StatusEffects __instance, string traitName, ref Trait __state)
			=> __state = __instance.TraitList?.Find(t => t.traitName == traitName);
		public static void StatusEffects_RemoveTrait(Trait __state)
		{
			CustomTrait trait = __state?.GetHook<CustomTrait>();
			if (__state != null && RogueFramework.IsDebugEnabled(DebugFlags.Traits))
				RogueFramework.LogDebug($"Removing trait {trait} ({__state.traitName}, {__state.GetStatusEffects().agent.agentName}).");
			trait?.OnRemoved();
		}

		public static void StatusEffects_RemoveStatusEffect_Prefix(StatusEffects __instance, string statusEffectName, ref StatusEffect __state)
			=> __state = __instance.StatusEffectList?.Find(t => t.statusEffectName == statusEffectName);
		public static void StatusEffects_RemoveStatusEffect(StatusEffect __state)
		{
			CustomEffect effect = __state?.GetHook<CustomEffect>();
			if (__state != null && RogueFramework.IsDebugEnabled(DebugFlags.Effects))
				RogueFramework.LogDebug($"Removing effect {effect} ({__state.statusEffectName}, {__state.GetStatusEffects().agent.agentName}).");
			effect?.OnRemoved();
		}

		public static IEnumerable<CodeInstruction> StatusEffects_GetStatusEffectTime(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.ReplaceRegion(
				new Func<CodeInstruction, bool>[]
				{
					i => i.opcode == OpCodes.Ldc_I4 && (int)i.operand is 9999,
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
		public static int GetStatusEffectTime(StatusEffects instance, string name)
		{
			StatusEffect effect = new StatusEffect { statusEffectName = name, __RogueLibsContainer = instance };

			CustomEffect custom = null;
			foreach (IHookFactory<StatusEffect> factory in RogueFramework.EffectFactories)
				if (factory.TryCreate(effect, out IHook<StatusEffect> hook))
				{
					if (hook is CustomEffect custom2)
						custom = custom2;
				}
			return custom?.GetEffectTime() ?? 9999;
		}
		public static void StatusEffects_GetStatusEffectHate(StatusEffects __instance, string statusEffectName, ref int __result)
		{
			StatusEffect effect = new StatusEffect { statusEffectName = statusEffectName, __RogueLibsContainer = __instance };

			CustomEffect custom = null;
			foreach (IHookFactory<StatusEffect> factory in RogueFramework.EffectFactories)
				if (factory.TryCreate(effect, out IHook<StatusEffect> hook))
				{
					if (hook is CustomEffect custom2)
						custom = custom2;
				}
			if (custom != null)
			{
				__result = custom.GetEffectHate();
				__instance.agent.dontHate = __result is 0;
			}
		}

		public static bool StatusEffects_UpdateStatusEffect(StatusEffects __instance, StatusEffect myStatusEffect, bool showTextOnRemoval, ref IEnumerator __result)
		{
			CustomEffect custom = myStatusEffect.GetHook<CustomEffect>();
			if (custom is null) return true;
			if (RogueFramework.IsDebugEnabled(DebugFlags.Effects))
				RogueFramework.LogDebug($"Starting {custom} update coroutine ({myStatusEffect.statusEffectName}, {myStatusEffect.GetStatusEffects().agent.agentName}).");
			__result = StatusEffectUpdateEnumerator(__instance, custom, showTextOnRemoval);
			return false;
		}
		private static readonly FieldInfo removeEffectOnUpdateField = AccessTools.Field(typeof(StatusEffects), "removeStatusEffectOnUpdate");
		public static IEnumerator StatusEffectUpdateEnumerator(StatusEffects __instance, CustomEffect customEffect, bool showTextOnRemoval)
		{
			float countSpeed = 1f;
			bool firstTick = true;
			if (!GameController.gameController.multiplayerMode || (!GameController.gameController.serverPlayer || __instance.agent.isPlayer <= 0 || __instance.agent.localPlayer) && (GameController.gameController.serverPlayer || __instance.agent.localPlayer))
			{
				if (__instance.StatusEffectList != null)
				{
					while (customEffect.CurrentTime > 0 && __instance.hasStatusEffect(customEffect.EffectInfo.Name) && (!__instance.agent.disappeared || __instance.agent.oma.notReadyToEnterLevel || __instance.agent.FellInHole() || __instance.agent.teleporting) || __instance.agent.FellInHole() || __instance.agent.teleporting || __instance.agent.KnockedOut())
					{
						if (!__instance.agent.FellInHole() && !__instance.agent.teleporting && !__instance.agent.KnockedOut() && GameController.gameController.loadComplete && !GameController.gameController.cinematic)
						{
							if (!customEffect.Effect.infiniteTime)
								customEffect.Effect.prevTime = customEffect.CurrentTime;

							EffectUpdatedArgs args = new EffectUpdatedArgs
							{
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

						if (customEffect.CurrentTime > 0)
							yield return countSpeed > 0 ? new WaitForSeconds(countSpeed) : null;
					}
					if (!customEffect.Effect.infiniteTime && (!__instance.agent.disappeared || __instance.agent.FellInHole() || __instance.agent.teleporting) && (!__instance.agent.dead || customEffect.EffectInfo.Name != "Resurrection"))
					{
						removeEffectOnUpdateField.SetValue(__instance, true);
						__instance.RemoveStatusEffect(customEffect.EffectInfo.Name, showTextOnRemoval);
						removeEffectOnUpdateField.SetValue(__instance, false);
					}
				}
			}
		}

		public static bool StatusEffects_UpdateTrait(StatusEffects __instance, Trait myTrait, ref IEnumerator __result)
		{
			CustomTrait custom = myTrait.GetHook<CustomTrait>();
			if (!(custom is ITraitUpdateable)) return true;
			if (RogueFramework.IsDebugEnabled(DebugFlags.Effects))
				RogueFramework.LogDebug($"Starting {custom} update coroutine ({myTrait.traitName}, {myTrait.GetStatusEffects().agent.agentName}).");
			__result = TraitUpdateEnumerator(__instance, custom);
			return false;
		}
		public static IEnumerator TraitUpdateEnumerator(StatusEffects __instance, CustomTrait customTrait)
		{
			yield return null;
			float countSpeed = 1f;
			if (!GameController.gameController.multiplayerMode || (!GameController.gameController.serverPlayer || __instance.agent.isPlayer <= 0 || __instance.agent.localPlayer) && (GameController.gameController.serverPlayer || __instance.agent.localPlayer))
			{
				if (__instance.TraitList != null)
				{
					while (__instance.TraitList.Contains(customTrait.Trait))
					{
						if (GameController.gameController.loadComplete && !GameController.gameController.mainGUI.questNotification.gameIsOver && !__instance.agent.disappearedArcade)
						{
							TraitUpdatedArgs e = new TraitUpdatedArgs { UpdateDelay = countSpeed };
							((ITraitUpdateable)customTrait).OnUpdated(e);
							countSpeed = e.UpdateDelay;
						}
						yield return countSpeed > 0 ? new WaitForSeconds(countSpeed) : null;
					}
				}
			}
		}

	}
}
