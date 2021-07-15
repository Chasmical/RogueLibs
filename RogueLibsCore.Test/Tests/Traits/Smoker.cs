using System;

namespace RogueLibsCore.Test
{
	public class Smoker : CustomTrait, ITraitUpdateable
	{
		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Smoker>()
				.WithName(new CustomNameInfo("Smoker"))
				.WithDescription(new CustomNameInfo("Randomly cough, alerting enemies"))
				.WithUnlock(new TraitUnlock { CharacterCreationCost = -4, });

			RogueLibs.CreateCustomName("Smoker_Cough1", "Dialogue", new CustomNameInfo("*Cough*"));
			RogueLibs.CreateCustomName("Smoker_Cough2", "Dialogue", new CustomNameInfo("*Cough* *CouGH*"));
			RogueLibs.CreateCustomName("Smoker_Cough3", "Dialogue", new CustomNameInfo("*coUGH* *COUgh*"));
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
		public void OnUpdated(TraitUpdatedArgs e)
		{
			e.UpdateDelay = 5f;

			int rnd = new Random().Next(0, 5);
			if (rnd == 0)
			{
				rnd = new Random().Next(3) + 1;
				Owner.SayDialogue($"Smoker_Cough{rnd}");
				gc.audioHandler.Play(Owner, "AgentAnnoyed");

				Noise noise = gc.spawnerMain.SpawnNoise(Owner.tr.position, 1f, Owner, "Attract", Owner);
				noise.distraction = true;
			}
		}
	}
}
