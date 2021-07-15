using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RogueLibsCore.Test
{
	public class GiantAbility : CustomAbility, IAbilityRechargeable
	{
		public static void Test()
			=> RogueLibs.CreateCustomAbility<GiantAbility>()
				.WithName(new CustomNameInfo("Giant"))
				.WithDescription(new CustomNameInfo("Transform into a giant and crush your enemies!"))
				.WithSprite(Properties.Resources.Batteries)
				.WithUnlock(new AbilityUnlock { UnlockCost = 15, CharacterCreationCost = 10, });

		public override void OnAdded() { }

		public void OnRecharging(AbilityRechargingArgs e) => e.UpdateDelay = 1f;

		public override void OnPressed()
		{
			if (Count == 0)
			{
				Owner.statusEffects.AddStatusEffect("Giant", 10);
				Owner.statusEffects.AddStatusEffect("Enraged", 10);
				Count = 20;
			}
		}
	}
}
