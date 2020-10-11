namespace RogueLibsCore.Interactions
{
	internal class BarbecueInteraction : CustomInteractionBase<Barbecue>
	{
		public override void Patch()
		{
			base.Patch();

			ObjectInteraction grillFud = RogueLibsInteractions.CreateOriginalInteraction("GrillFud", InteractionType.Button,
				(_, obj) => obj is Barbecue b && !b.burntOut && b.ora.hasParticleEffect && b.interactingAgent.inventory.HasItem("Fud"));
			grillFud.Action = (_, obj) =>
			{
				obj.StartCoroutine(obj.Operating(obj.interactingAgent, null, 2f, true, "Grilling"));
				return false;
			};

			ObjectInteraction lightBarbecue = RogueLibsInteractions.CreateOriginalInteraction("LightBarbecue", InteractionType.Button,
				(_, obj) => obj is Barbecue b && !b.burntOut && !b.ora.hasParticleEffect && b.interactingAgent.inventory.HasItem("CigaretteLighter"));
			lightBarbecue.Action = (_, obj) =>
			{
				((Barbecue)obj).StartFireInObject();
				return true;
			};
		}
		public static bool Interact2(Barbecue __instance, Agent agent)
		{
			Interact(__instance, agent);
			if (__instance.buttonsHaveTooltips)
			{
				__instance.buttonsHaveTooltips = false;
				if (__instance.burntOut)
					agent.SayDialogue("BarbecueBurntOut");
				else if (__instance.ora.hasParticleEffect)
					agent.SayDialogue("CantGrillFud");
				else
					agent.SayDialogue("CantOperateBarbecue");
				__instance.StopInteraction();
			}
			return false;
		}
	}
}
