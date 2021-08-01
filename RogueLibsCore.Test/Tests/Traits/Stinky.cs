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

			RogueLibs.CreateCustomName("StinkReaction1", NameTypes.Dialogue, new CustomNameInfo("Ew!"));
			RogueLibs.CreateCustomName("StinkReaction2", NameTypes.Dialogue, new CustomNameInfo("Ew! You stink!"));
			RogueLibs.CreateCustomName("StinkReaction3", NameTypes.Dialogue, new CustomNameInfo("ARGHH! Get away from me!"));
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }

		private const float stinkRange = 1f;
		public void OnUpdated(TraitUpdatedArgs e)
		{
			e.UpdateDelay = 2f;
			foreach (Agent agent in gc.agentList.Where(a => Vector2.Distance(a.curPosition, Owner.curPosition) <= stinkRange))
			{
				if (agent == Owner) continue;
				agent.relationships.AddStrikes(Owner, 1);
				agent.SayDialogue($"StinkReaction{new System.Random().Next(3) + 1}");
				try { gc.spawnerMain.SpawnDanger(Owner, "Targeted", "AnnoyedAgent", agent); }
				catch { }
			}
		}
	}
}
