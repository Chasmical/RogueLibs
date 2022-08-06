namespace RogueLibsCore.Test
{
    public class Titan : CustomAbility, IAbilityRechargeable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomAbility<Titan>()
                .WithName(new CustomNameInfo("Titan"))
                .WithDescription(new CustomNameInfo("Willpower alone isn't enough in battle."))
                .WithSprite(Properties.Resources.Titan)
                .WithUnlock(new AbilityUnlock
                {
                    UnlockCost = 10,
                    CharacterCreationCost = 10,
                    Prerequisites = { VanillaItems.Giantizer },
                });
        }

        public override void OnAdded() { }
        public override void OnPressed()
        {
            if (Count != 0)
            {
                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);
                return;
            }
            Owner!.statusEffects.AddStatusEffect(VanillaEffects.Giant, 15);
            Count = 30;
        }
        public void OnRecharging(AbilityRechargingArgs e)
        {
            e.UpdateDelay = 1f;
            Count--;
        }
    }
}
