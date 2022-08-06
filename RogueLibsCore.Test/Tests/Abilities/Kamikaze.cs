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
            gc.audioHandler.Play(Owner, VanillaAudio.GeneratorHiss);
            Owner!.objectMult.chargingSpecialLunge = true;
        }
        public override CustomTooltip GetCountString()
        {
            if (Charge is 0) return default;
            string text = $"{Charge:#.#}s";
            Color color = Color.Lerp(Color.white, Color.red, Charge / 10f);
            if (Charge > 10f)
            {
                text = "BOOM!";
                color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time * 5, 1f));
            }
            return new CustomTooltip(text, color);
        }
        public void OnHeld(AbilityHeldArgs e)
        {
            Charge += Time.deltaTime;
            e.HeldTime = Charge;
            if (Charge > 10f)
            {
                Owner!.objectMult.chargingSpecialLunge = true;
            }
        }
        public void OnReleased(AbilityReleasedArgs e)
        {
            IsCharging = false;
            Owner!.objectMult.chargingSpecialLunge = false;
            if (e.HeldTime > 10f)
            {
                Owner.AddEffect(VanillaEffects.Resurrection, new CreateEffectInfo(1) { DontShowText = true, IgnoreElectronic = true });
                gc.spawnerMain.SpawnExplosion(Owner, Owner.tr.position, "Huge", false, -1, false, true).noOwnCheck = true;
                Charge = 0f;
            }
            gc.audioHandler.Stop(Owner, VanillaAudio.GeneratorHiss);
        }
        public void Update()
        {
            if (!IsCharging) Charge = Mathf.Max(Charge - Time.deltaTime * 5f, 0f);
        }
    }
}
