using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore.Interactions
{
	internal class AltarInteraction : CustomInteractionBase<AlarmButton>
	{
		public override void Patch()
		{
			base.Patch();

			ObjectInteraction makeOferring = RogueLibsInteractions.CreateOriginalInteraction("MakeOffering", InteractionType.Button,
				(agent, obj) => obj is Altar a && !agent.interactionHelper.interactingFar);
			makeOferring.Action = (Agent, obj) =>
			{
				Altar altar = (Altar)obj;
				if (altar.offeringsMade >= altar.offeringLimit)
				{
					altar.gc.audioHandler.Play(altar, "CantDo");
					return true;
				}
				altar.interactingAgent.SayDialogue("OfferingMustBeInBuilding");
				altar.commander = altar.interactingAgent;
				altar.interactingAgent.mainGUI.invInterface.ShowTarget(altar, "MakeOffering");
				IEnumerator enumerator = (IEnumerator)AccessTools.Method(typeof(Altar), "MakingOffer").Invoke(altar, new object[0]);
				altar.StartCoroutine(enumerator);
				return false;
			};

		}
		public static bool Interact2(AlarmButton __instance, Agent agent)
		{
			Interact(__instance, agent);
			if (__instance.buttonsHaveTooltips)
			{
				__instance.buttonsHaveTooltips = false;
				agent.SayDialogue("NoReasonToUse");
				__instance.StopInteraction();
			}
			return false;
		}
	}
}
