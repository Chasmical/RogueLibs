using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BepInEx;
using HarmonyLib;

namespace RogueLibsCore
{
	public partial class RogueLibsPlugin
	{
		public void PatchAbilities()
		{
			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.GiveSpecialAbility));

			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.PressedSpecialAbility));
			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.HeldSpecialAbility));
			Patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.ReleasedSpecialAbility));

		}

		public static void StatusEffects_GiveSpecialAbility(StatusEffects __instance)
		{
			if (GameController.gameController.levelType == "HomeBase"
				&& !__instance.agent.isDummy && __instance.agent.agentName != "MechEmpty") return;
			CustomAbility custom = __instance.agent.GetAbility();
			if (custom is null) return;

			if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
				RogueFramework.LogDebug($"Giving ability {custom} ({__instance.agent.specialAbility}, {__instance.agent.agentName}).");

			try { custom.OnAdded(); }
			catch (Exception e) { RogueFramework.LogError(e, "CustomAbility.OnAdded", custom, __instance.agent); }

			__instance.SpecialAbilityInterfaceCheck();
			__instance.RechargeSpecialAbility(custom.ItemInfo.Name);
		}

		public static void StatusEffects_PressedSpecialAbility(StatusEffects __instance)
		{
			CustomAbility custom = __instance.agent.GetAbility();
			if (custom is null) return;

			if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
				RogueFramework.LogDebug($"Pressing ability ability {custom} ({__instance.agent.specialAbility}, {__instance.agent.agentName}).");

			try { custom.OnPressed(); }
			catch (Exception e) { RogueFramework.LogError(e, "CustomAbility.OnPressed", custom, __instance.agent); }
		}
		public static void StatusEffects_HeldSpecialAbility(StatusEffects __instance)
		{
			CustomAbility custom = __instance.agent.GetAbility();
			if (custom is null) return;

			ref float held = ref GameController.gameController.playerControl.pressedSpecialAbilityTime[__instance.agent.isPlayer - 1];
			float prevHeld = held;

			if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
				RogueFramework.LogDebug($"Holding ability {custom} for {prevHeld}s ({__instance.agent.specialAbility}, {__instance.agent.agentName}).");

			OnAbilityHeldArgs args = new OnAbilityHeldArgs { HeldTime = prevHeld };
			try { custom.OnHeld(args); }
			catch (Exception e) { RogueFramework.LogError(e, "CustomAbility.OnHeld", custom, __instance.agent); }

			held = args.HeldTime;
			custom.lastHeld = prevHeld;
			__instance.ReleasedSpecialAbility();
		}
		public static void StatusEffects_ReleasedSpecialAbility(StatusEffects __instance)
		{
			CustomAbility custom = __instance.agent.GetAbility();
			if (custom is null) return;

			float prevHeld = custom.lastHeld;
			if (prevHeld is 0f) return;

			if (RogueFramework.IsDebugEnabled(DebugFlags.Abilities))
				RogueFramework.LogDebug($"Releasing ability {custom} - {prevHeld}s ({__instance.agent.specialAbility}, {__instance.agent.agentName}).");

			custom.lastHeld = 0f;
			try { custom.OnReleased(new OnAbilityReleasedArgs(prevHeld)); }
			catch (Exception e) { RogueFramework.LogError(e, "CustomAbility.OnReleased", custom, __instance.agent); }
		}
	}
}
