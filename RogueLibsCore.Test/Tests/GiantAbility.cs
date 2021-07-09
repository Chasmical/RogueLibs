using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RogueLibsCore.Test
{
	public class GiantAbility : CustomAbility, IDoUpdate
	{
		public static void Test()
		{
			RogueLibs.CreateCustomAbility<GiantAbility>()
				.WithName(new CustomNameInfo("Giant"))
				.WithDescription(new CustomNameInfo("Transform into a giant and crush your enemies!"))
				.WithSprite(Properties.Resources.Batteries)
				.WithUnlock(new AbilityUnlock { UnlockCost = 15, CharacterCreationCost = 10, });
		}

		public override void SetupDetails() { }
		public override string GetCountString() => recharge != 0f ? recharge.ToString() : base.GetCountString();

		public override void OnAdded() { }
		public override void OnHeld(OnAbilityHeldArgs e) { }
		public override void OnReleased(OnAbilityReleasedArgs e) { }
		public override void OnUpdated(OnAbilityUpdatedArgs e) { }
		public override PlayfieldObject FindTarget() => null;

		private float recharge;
		public void Update() => recharge = Mathf.Max(recharge - Time.deltaTime, 0f);

		public override void OnPressed()
		{
			if (recharge > 0f) return;

			Owner.statusEffects.AddStatusEffect("Giant", 15);
			Owner.statusEffects.AddStatusEffect("Enraged", 15);

			recharge = 30f;
		}
	}
}
