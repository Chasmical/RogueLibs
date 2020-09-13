using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore.Interactions
{
	internal class AirConditionerInteraction : CustomInteractionBase<AirConditioner>
	{
		public override void Patch()
		{
			base.Patch();

			ObjectInteraction insertItem = RogueLibsInteractions.CreateOriginalInteraction("InsertItem", InteractionType.Button,
				(agent, obj) => obj is AirConditioner);
			insertItem.Action = (agent, obj) =>
			{
				obj.ShowUseOn("InsertItem");
				return false;
			};
		}
		public static bool Interact2(AirConditioner __instance, Agent agent)
		{
			Interact(__instance, agent);
			if (__instance.buttons.Count == 0)
			{
				for (int i = 0; i < __instance.gc.gasesList.Count; i++)
				{
					Gas gas = __instance.gc.gasesList[i];
					if (__instance.startingChunk == gas.startingChunk)
					{
						__instance.interactingAgent.SayDialogue("AlreadyGassing");
						__instance.StopInteraction();
						return false;
					}
				}
				if (!__instance.isBroken())
				{
					bool hasUsableItems = false;
					for (int j = 0; j < __instance.interactingAgent.inventory.InvItemList.Count; j++)
					{
						if (__instance.playerHasUsableItem(__instance.interactingAgent.inventory.InvItemList[j]))
						{
							hasUsableItems = true;
							break;
						}
					}
					if (!hasUsableItems)
					{
						__instance.interactingAgent.SayDialogue("CantUseAirConditioner");
						__instance.StopInteraction();
					}
				}
			}
			return false;
		}
	}
}
