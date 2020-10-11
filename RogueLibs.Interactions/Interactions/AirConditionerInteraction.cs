namespace RogueLibsCore.Interactions
{
	internal class AirConditionerInteraction : CustomInteractionBase<AirConditioner>
	{
		public override void Patch()
		{
			base.Patch();

			ObjectInteraction insertItem = RogueLibsInteractions.CreateOriginalInteraction("InsertItem", InteractionType.Button,
				(_, obj) => obj is AirConditioner);
			insertItem.Action = (_, obj) =>
			{
				obj.ShowUseOn("InsertItem");
				return false;
			};

		}
		public static bool Interact2(AirConditioner __instance, Agent agent)
		{
			Interact(__instance, agent);
			if (__instance.buttonsHaveTooltips)
			{
				__instance.buttonsHaveTooltips = false;
				for (int i = 0; i < __instance.gc.gasesList.Count; i++)
				{
					Gas gas = __instance.gc.gasesList[i];
					if (__instance.startingChunk == gas.startingChunk)
					{
						agent.SayDialogue("AlreadyGassing");
						__instance.StopInteraction();
						return false;
					}
				}
				if (!__instance.isBroken())
				{
					bool hasUsableItems = false;
					for (int j = 0; j < agent.inventory.InvItemList.Count; j++)
						if (__instance.playerHasUsableItem(agent.inventory.InvItemList[j]))
						{
							hasUsableItems = true;
							break;
						}
					if (!hasUsableItems)
					{
						agent.SayDialogue("CantUseAirConditioner");
						__instance.StopInteraction();
					}
				}
			}
			return false;
		}
	}
}
