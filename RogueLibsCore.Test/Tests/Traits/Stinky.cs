using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueLibsCore.Test
{
	public class Stinky : CustomTrait, ITraitUpdateable
	{
		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Stinky>()
				.WithName(new CustomNameInfo("Stinky"))
				.WithDescription(new CustomNameInfo("You smell really bad for some reason"))
				.WithUnlock(new TraitUnlock { CharacterCreationCost = -5 });

			RogueLibs.CreateCustomName("StinkReaction1", "Dialogue", new CustomNameInfo("Ew! You stink!"));
			RogueLibs.CreateCustomName("StinkReaction2", "Dialogue", new CustomNameInfo("Ew! You smell really bad!"));
			RogueLibs.CreateCustomName("StinkReaction3", "Dialogue", new CustomNameInfo("ARGHH! Get away from me!"));
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }

		private const float stinkRange = 1f;
		public void OnUpdated(TraitUpdatedArgs e)
		{
			e.UpdateDelay = 1f;
			foreach (Agent agent in gc.agentList.Where(a => Vector2.Distance(a.curPosition, Owner.curPosition) <= stinkRange))
			{
				agent.relationships.AddStrikes(Owner, 1);
				agent.SayDialogue($"StinkReaction{new System.Random().Next(3) + 1}");
				gc.spawnerMain.SpawnDanger(agent, "Targeted", "AnnoyedAgent", Owner);
			}
		}

		public class Smeller
		{
			public Agent Agent;
			public int Duration;
		}
	}
}
