namespace RogueLibsCore.Interactions
{
	internal class AlarmButtonInteraction : CustomInteractionBase<AlarmButton>
	{
		public override void Patch()
		{
			base.Patch();

			ObjectInteraction allAccess = RogueLibsInteractions.CreateOriginalInteraction("AllAccessAlarmButton", InteractionType.Button,
				(agent, obj) => obj is AlarmButton a && agent.interactionHelper.interactingFar && !a.hacked);
			allAccess.Action = (_, obj) =>
			{
				AlarmButton alarmButton = (AlarmButton)obj;

				alarmButton.hacked = true;
				if (!alarmButton.gc.serverPlayer)
					alarmButton.gc.playerAgent.objectMult.ObjectAction(alarmButton.objectNetID, "AllAccess");
				alarmButton.StopInteraction();
				return true;
			};

			ObjectInteraction pressAlarmButton = RogueLibsInteractions.CreateOriginalInteraction("PressAlarmButton", InteractionType.InteractOrButton,
				new CustomNameInfo("Call a Supercop",
				null, null, null, null,
				"Вызвать Суперкопа",
				null, null),
				(agent, obj) => obj is AlarmButton a && !a.isBroken() && (agent.upperCrusty || a.hacked));
			pressAlarmButton.Action = (agent, obj) =>
			{
				((AlarmButton)obj).ToggleSwitch(agent, null);
				return true;
			};

		}
		public static bool Interact2(AlarmButton __instance, Agent agent)
		{
			Interact(__instance, agent);
			if (__instance.buttonsHaveTooltips)
			{
				__instance.buttonsHaveTooltips = false;
				if (!agent.upperCrusty && !__instance.hacked)
					__instance.Say("CantUseAlarmButton");
				__instance.StopInteraction();
			}
			return false;
		}
	}
}
