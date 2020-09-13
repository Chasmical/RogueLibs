using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore.Interactions
{
	internal class CustomInteractionBase<T> where T : PlayfieldObject
	{
		public virtual void Patch()
		{
			Harmony harmony = new Harmony(RogueLibsInteractions.pluginGuid);

			MethodInfo original = AccessTools.DeclaredMethod(typeof(T), "DetermineButtons");
			MethodInfo patch;
			if (original != null)
			{
				patch = AccessTools.DeclaredMethod(GetType(), "DetermineButtons2");
				if (patch == null) patch = AccessTools.Method(GetType().BaseType, "DetermineButtons");
				if (patch != null)
					harmony.Patch(original, new HarmonyMethod(patch));
			}

			original = AccessTools.DeclaredMethod(typeof(T), "Interact");
			if (original != null)
			{
				patch = AccessTools.DeclaredMethod(GetType(), "Interact2");
				if (patch == null) patch = AccessTools.Method(GetType().BaseType, "Interact");
				if (patch != null)
					harmony.Patch(original, new HarmonyMethod(patch));
			}
			
			original = AccessTools.DeclaredMethod(typeof(T), "InteractFar");
			if (original != null)
			{
				patch = AccessTools.DeclaredMethod(GetType(), "InteractFar2");
				if (patch == null) patch = AccessTools.Method(GetType().BaseType, "InteractFar");
				if (patch != null)
					harmony.Patch(original, new HarmonyMethod(patch));
			}

			original = AccessTools.DeclaredMethod(typeof(T), "PressedButton", new Type[] { typeof(string) });
			if (original != null)
			{
				patch = AccessTools.DeclaredMethod(GetType(), "PressedButton2", new Type[] { typeof(string) });
				if (patch == null) patch = AccessTools.Method(GetType().BaseType, "PressedButton", new Type[] { typeof(string) });
				if (patch != null)
					harmony.Patch(original, new HarmonyMethod(patch));
			}

			original = AccessTools.DeclaredMethod(typeof(T), "PressedButton", new Type[] { typeof(string), typeof(int) });
			if (original != null)
			{
				patch = AccessTools.DeclaredMethod(GetType(), "PressedButton2", new Type[] { typeof(string), typeof(int) });
				if (patch == null) patch = AccessTools.Method(GetType().BaseType, "PressedButton", new Type[] { typeof(string), typeof(int) });
				if (patch != null)
					harmony.Patch(original, new HarmonyMethod(patch));
			}
		}

		public static bool DetermineButtons(T __instance)
		{
			MethodInfo baseMethod = AccessTools.DeclaredMethod(__instance.GetType().BaseType, "DetermineButtons");
			baseMethod.GetBaseMethod<Action>(__instance).Invoke();

			while (__instance.buttonPrices.Count < __instance.buttons.Count)
				__instance.buttonPrices.Add(0);
			while (__instance.buttonsExtra.Count < __instance.buttons.Count)
				__instance.buttonsExtra.Add(string.Empty);

			List<ObjectInteraction> allInteractions = RogueLibsInteractions.ObjectInteractions.FindAll(i => i.Condition?.Invoke(__instance.interactingAgent, __instance) ?? false);
			foreach (ObjectInteraction interaction in allInteractions)
			{
				if ((interaction.Type & InteractionType.Button) != 0)
				{
					ObjectInteractionInfo? info = interaction.GetButtonInfo?.Invoke(__instance.interactingAgent, __instance);
					__instance.buttons.Add(interaction.Id);
					__instance.buttonPrices.Add(info?.Cost ?? 0);
					__instance.buttonsExtra.Add(info?.ExtraText ?? string.Empty);
				}
			}
			return false;
		}
		public static bool Interact(T __instance, Agent agent)
		{
			MethodInfo baseMethod = AccessTools.DeclaredMethod(__instance.GetType().BaseType, "Interact");
			baseMethod.GetBaseMethod<Action<Agent>>(__instance).Invoke(agent);

			List<ObjectInteraction> allInteractions = RogueLibsInteractions.ObjectInteractions.FindAll(i => i.Condition?.Invoke(__instance.interactingAgent, __instance) ?? false);
			List<ObjectInteraction> actionsOnly = allInteractions.FindAll(i => i.Type == InteractionType.Interact);
			List<ObjectInteraction> possibleButtons = allInteractions.FindAll(i => i.Type == InteractionType.InteractOrButton);
			List<ObjectInteraction> buttonsOnly = allInteractions.FindAll(i => i.Type == InteractionType.Button);

			foreach (ObjectInteraction action in actionsOnly)
				action.Action?.Invoke(__instance.interactingAgent, __instance);

			if (possibleButtons.Count == 1 && buttonsOnly.Count == 0)
			{
				possibleButtons[0].Action?.Invoke(__instance.interactingAgent, __instance);
				__instance.StopInteraction();
			}
			else if (possibleButtons.Count > 0 || buttonsOnly.Count > 0)
				__instance.ShowObjectButtons();
			else __instance.StopInteraction();
			return false;
		}
		public static bool InteractFar(T __instance, Agent agent) => Interact(__instance, agent);
		public static bool PressedButton(T __instance, string buttonText) => PressedButton(__instance, buttonText, 0);
		public static bool PressedButton(T __instance, string buttonText, int buttonPrice)
		{
			ObjectInteraction interaction = RogueLibsInteractions.GetObjectInteraction(buttonText);
			if (interaction == null)
			{
				Debug.LogError("Unknown interaction \"" + buttonText + "\" for " + typeof(T).Name);
				__instance.StopInteraction();
				return true;
			}

			MethodInfo baseMethod = AccessTools.DeclaredMethod(__instance.GetType().BaseType, "PressedButton", new Type[] { typeof(string), typeof(int) });
			baseMethod.GetBaseMethod<Action<string, int>>(__instance).Invoke(buttonText, buttonPrice);

			if (interaction.Action?.Invoke(__instance.interactingAgent, __instance) ?? false)
				__instance.StopInteraction();
			else __instance.RefreshButtons();
			return false;
		}

	}
	public static class SSS
	{
		public static T GetBaseMethod<T>(this MethodInfo method, object callFrom)
			where T : Delegate
		{
			IntPtr ptr = method.MethodHandle.GetFunctionPointer();
			return (T)Activator.CreateInstance(typeof(T), callFrom, ptr);
		}
	}
}
