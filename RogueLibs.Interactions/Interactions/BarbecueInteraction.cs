using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore.Interactions
{
	internal class BarbecueInteraction : CustomInteractionBase<Barbecue>
	{
		public override void Patch()
		{
			base.Patch();

			ObjectInteraction grillFud = RogueLibsInteractions.CreateOriginalInteraction("GrillFud", InteractionType.Button,
				(agent, obj) => obj is Barbecue b && !b.burntOut && b.ora.hasParticleEffect && b.interactingAgent.inventory.HasItem("Fud"));
			grillFud.Action = (agent, obj) =>
			{
				obj.StartCoroutine(obj.Operating(obj.interactingAgent, null, 2f, true, "Grilling"));
				return false;
			};

			ObjectInteraction lightBarbecue = RogueLibsInteractions.CreateOriginalInteraction("LightBarbecue", InteractionType.Button,
				(agent, obj) => obj is Barbecue b && !b.burntOut && !b.ora.hasParticleEffect && b.interactingAgent.inventory.HasItem("CigaretteLighter"));
			lightBarbecue.Action = (agent, obj) =>
			{
				((Barbecue)obj).StartFireInObject();
				return true;
			};
		}
		public static bool DetermineButtons2(Barbecue __instance)
		{
			DetermineButtons(__instance);
			if (__instance.buttons.Count == 0)
			{
				if (__instance.burntOut)
					__instance.interactingAgent.SayDialogue("BarbecueBurntOut");
				else if (__instance.ora.hasParticleEffect)
					__instance.interactingAgent.SayDialogue("CantGrillFud");
				else
					__instance.interactingAgent.SayDialogue("CantOperateBarbecue");
			}
			return false;
		}
	}
}
