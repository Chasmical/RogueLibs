using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore.Interactions
{
	internal class Interaction<T>
		where T : PlayfieldObject
	{
		public void Patch()
		{
			RoguePatcher patcher = new RoguePatcher(RogueLibsInteractions.PluginInstance, GetType());
			patcher.Prefix(typeof(T), "DetermineButtons");
			patcher.Prefix(typeof(T), "Interact");
			patcher.Prefix(typeof(T), "PressedButton");
		}
		public virtual bool DetermineButtons(T __instance)
		{
			while (__instance.buttonPrices.Count < __instance.buttons.Count)
				__instance.buttonPrices.Add(0);
			while (__instance.buttonsExtra.Count < __instance.buttons.Count)
				__instance.buttonsExtra.Add(string.Empty);

			List<CustomInteraction> allInteractions = RogueLibsInteractions.CustomInteractions.FindAll(i => i.Condition?.Invoke(__instance.interactingAgent, __instance) ?? false);
			foreach (CustomInteraction interaction in allInteractions)
			{
				if ((interaction.Type & InteractionType.Button) != 0)
				{
					InteractionButtonInfo? info = interaction.GetButtonInfo(__instance.interactingAgent, __instance);
					__instance.buttons.Add(interaction.Id);
					__instance.buttonPrices.Add(info?.Cost ?? 0);
					__instance.buttonsExtra.Add(info?.ExtraText ?? string.Empty);
				}
			}
			return false;
		}
		public virtual bool Interact(T __instance, Agent agent)
		{
			MethodInfo baseMethod = AccessTools.Method(__instance.GetType().BaseType, "Interact");
			baseMethod.Invoke(__instance, new object[] { agent });

			List<CustomInteraction> allInteractions = RogueLibsInteractions.CustomInteractions.FindAll(i => i.Condition?.Invoke(__instance.interactingAgent, __instance) ?? false);
			List<CustomInteraction> actionsOnly = allInteractions.FindAll(i => i.Type == InteractionType.Interact);
			List<CustomInteraction> possibleButtons = allInteractions.FindAll(i => i.Type == InteractionType.InteractOrButton);
			List<CustomInteraction> buttonsOnly = allInteractions.FindAll(i => i.Type == InteractionType.Button);
			__instance.DetermineButtons();
			List<string> origButtons = __instance.buttons;

			foreach (CustomInteraction action in actionsOnly)
			{
				action.Action?.Invoke(__instance.interactingAgent, __instance);
				__instance.StopInteraction();
			}
			if (possibleButtons.Count == 1 && (buttonsOnly.Count == 0 && origButtons.Count == 0))
			{
				possibleButtons[0].Action?.Invoke(__instance.interactingAgent, __instance);
				__instance.StopInteraction();
			}
			else if (possibleButtons.Count > 0 || (buttonsOnly.Count > 0 || origButtons.Count > 0))
			{
				__instance.ShowObjectButtons();
			}
			return false;

		}
		public virtual bool PressedButton(T __instance, string buttonText, int buttonPrice)
		{
			CustomInteraction interaction = RogueLibsInteractions.GetCustomInteraction(buttonText);
			if (interaction == null) return true;
			bool stopInteracting = interaction.Action?.Invoke(__instance.interactingAgent, __instance) ?? false;
			if (stopInteracting) __instance.StopInteraction();
			else __instance.RefreshButtons();
			return false;
		}
	}
}
