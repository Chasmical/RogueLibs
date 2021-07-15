using UnityEngine;

namespace RogueLibsCore.Test
{
	public class Kamikaze : CustomAbility, IAbilityChargeable, IDoUpdate
	{
		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomAbility<Kamikaze>()
				.WithName(new CustomNameInfo("Kamikaze"))
				.WithDescription(new CustomNameInfo("Charge up and explode everything around you."))
				.WithSprite(Properties.Resources.Kamikaze)
				.WithUnlock(new AbilityUnlock { UnlockCost = 20, CharacterCreationCost = 20 });
		}

		public float Charge { get; private set; }
		public bool IsCharging { get; private set; }

		public override void OnAdded() { }
		public override void OnPressed()
		{
			IsCharging = true;
			gc.audioHandler.Play(Owner, "GeneratorHiss");
		}
		public override CustomTooltip GetCountString()
		{
			if (Charge is 0) return default;
			string text = $"{Charge:#.##}s";
			Color color = Color.Lerp(Color.white, Color.red, Charge / 10f);
			if (Charge > 10f) color = Time.deltaTime % 1f < 0.5f ? Color.white : Color.red;
			return new CustomTooltip(text, color);
		}
		public void OnHeld(AbilityHeldArgs e)
		{
			Charge += Time.deltaTime;
			e.HeldTime = Charge;
		}
		public void OnReleased(AbilityReleasedArgs e)
		{
			IsCharging = false;
			if (e.HeldTime > 10f)
			{
				Owner.AddEffect("Resurrection", new CreateEffectInfo(1) { DontShowText = true, IgnoreElectronic = true });
				gc.spawnerMain.SpawnExplosion(Owner, Owner.tr.position, "Huge", false, -1, false, true).noOwnCheck = true;
				Charge = 0f;
			}
			gc.audioHandler.Stop(Owner, "GeneratorHiss");
		}
		public void Update()
		{
			if (!IsCharging) Charge = Mathf.Max(Charge - Time.deltaTime * 5f, 0f);
		}
	}
}
