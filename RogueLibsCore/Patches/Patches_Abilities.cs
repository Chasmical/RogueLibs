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

			try { custom.OnAdded(); }
			catch (Exception e)
			{
				RogueFramework.Logger.LogError($"Error in CustomAbility.OnAdded() - {custom} ({__instance.agent.specialAbility})");
				RogueFramework.Logger.LogError(e);
			}
			__instance.SpecialAbilityInterfaceCheck();
			__instance.RechargeSpecialAbility(custom.ItemInfo.Name);
		}

		public static void StatusEffects_PressedSpecialAbility(StatusEffects __instance)
		{
			CustomAbility custom = __instance.agent.GetAbility();
			if (custom is null) return;

			try { custom?.OnPressed(); }
			catch (Exception e)
			{
				RogueFramework.Logger.LogError($"Error in CustomAbility.OnPressed() - {custom} ({__instance.agent.specialAbility})");
				RogueFramework.Logger.LogError(e);
			}
		}
		public static void StatusEffects_HeldSpecialAbility(StatusEffects __instance)
		{
			CustomAbility custom = __instance.agent.GetAbility();
			if (custom is null) return;

			ref float held = ref GameController.gameController.playerControl.pressedSpecialAbilityTime[__instance.agent.isPlayer - 1];
			float prevHeld = held;

			OnAbilityHeldArgs args = new OnAbilityHeldArgs { HeldTime = prevHeld };
			try { custom.OnHeld(args); }
			catch (Exception e)
			{
				RogueFramework.Logger.LogError($"Error in CustomAbility.OnHeld() - {custom} ({__instance.agent.specialAbility})");
				RogueFramework.Logger.LogError(e);
			}

			held = args.HeldTime;
			custom.lastHeld = args.HeldTime;

			if (held is 0f) custom.OnReleased(new OnAbilityReleasedArgs(prevHeld));
		}
		public static void StatusEffects_ReleasedSpecialAbility(StatusEffects __instance)
		{
			CustomAbility custom = __instance.agent.GetAbility();
			if (custom is null) return;

			float prevHeld = custom.lastHeld;
			if (prevHeld is 0f) return;

			custom.lastHeld = 0f;
			try { custom.OnReleased(new OnAbilityReleasedArgs(prevHeld)); }
			catch (Exception e)
			{
				RogueFramework.Logger.LogError($"Error in CustomAbility.OnReleased() - {custom} ({__instance.agent.specialAbility})");
				RogueFramework.Logger.LogError(e);
			}
		}
	}
}
