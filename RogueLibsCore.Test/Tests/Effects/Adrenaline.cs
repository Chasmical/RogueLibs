namespace RogueLibsCore.Test
{
    [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
    public class Adrenaline : CustomEffect
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomEffect<Adrenaline>()
                 .WithName(new CustomNameInfo("Adrenaline"))
                 .WithDescription(new CustomNameInfo("Gives you a ton of boosts for a short period of time."));
        }

        public override int GetEffectTime() => 15;
        public override int GetEffectHate() => 0;
        public override void OnAdded()
        {
            Owner.ChangeHealth(20);
            Owner.SetStrength(Owner.strengthStatMod + 2);
            Owner.SetEndurance(Owner.enduranceStatMod + 2);
            Owner.SetAccuracy(Owner.accuracyStatMod - 1);
            Owner.SetSpeed(Owner.speedStatMod + 2);
            Owner.critChance += 30;
        }
        public override void OnRemoved()
        {
            Owner.SetStrength(Owner.strengthStatMod - 2);
            Owner.SetEndurance(Owner.enduranceStatMod - 2);
            Owner.SetAccuracy(Owner.accuracyStatMod + 1);
            Owner.SetSpeed(Owner.speedStatMod - 2);
            Owner.critChance -= 30;
        }
        public override void OnUpdated(EffectUpdatedArgs e)
        {
            e.UpdateDelay = 1f;
            CurrentTime--;
        }
    }
}
