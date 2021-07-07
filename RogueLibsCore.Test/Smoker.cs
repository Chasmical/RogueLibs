using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore.Test
{
	public class Smoker : CustomTrait
	{
		public static void Test()
		{
			RogueLibs.CreateCustomTrait<Smoker>()
				.WithName(new CustomNameInfo("Smoker"))
				.WithDescription(new CustomNameInfo("Randomly cough, alerting enemies"))
				.WithUnlock(new TraitUnlock { CharacterCreationCost = -4, });

			RogueLibs.CreateCustomName("Smoker_Cough1", "Dialogue", new CustomNameInfo("*Cough*"));
			RogueLibs.CreateCustomName("Smoker_Cough2", "Dialogue", new CustomNameInfo("*Cough* *CouGH*"));
			RogueLibs.CreateCustomName("Smoker_Cough3", "Dialogue", new CustomNameInfo("*coUGH* *COUgh*"));
		}

		public override void OnAdded()
		{
			Owner.SetEndurance(Owner.enduranceStatMod - 1);
			Owner.SetSpeed(Owner.speedStatMod - 1);
		}
		public override void OnRemoved()
		{
			Owner.SetEndurance(Owner.enduranceStatMod + 1);
			Owner.SetSpeed(Owner.speedStatMod + 1);
		}
		public override void OnUpdated(TraitUpdatedArgs e)
		{
			e.UpdateDelay = 5f;

			int rnd = new Random().Next(0, 5);
			if (rnd == 0)
			{
				rnd = new Random().Next(3) + 1;
				Owner.SayDialogue($"Smoker_Cough{rnd}");

				Noise noise = gc.spawnerMain.SpawnNoise(Owner.tr.position, 1f, Owner, "Attract", Owner);
				noise.distraction = true;
			}
		}
	}
}
