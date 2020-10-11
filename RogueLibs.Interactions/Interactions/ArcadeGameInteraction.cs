namespace RogueLibsCore.Interactions
{
	internal class ArcadeGameInteraction : CustomInteractionBase<ArcadeGame>
	{
		public override void Patch()
		{
			base.Patch();

			ObjectInteraction increaseVolume = RogueLibsInteractions.CreateOriginalInteraction("IncreaseVolume", InteractionType.Button,
				(agent, obj) => obj is ArcadeGame a && agent.interactionHelper.interactingFar && !a.isHighVolume);
			increaseVolume.Action = (_, obj) =>
			{
				(obj as ArcadeGame)?.IncreaseVolume();
				return false;
			};

			ObjectInteraction hackExplode = RogueLibsInteractions.CreateOriginalInteraction("HackExplode", InteractionType.Button,
				(agent, obj) => obj is ArcadeGame a && !a.isBroken() && !a.tempNoOperating && agent.interactionHelper.interactingFar && ((agent.oma.superSpecialAbility && agent.agentName == "Hacker") || agent.statusEffects.hasTrait("HacksBlowUpObjects")));
			// action is defined in ObjectReal.PressedButton
		}
		public static bool Interact2(ArcadeGame __instance, Agent agent)
		{
			Interact(__instance, agent);

			return false;
		}
	}
}
