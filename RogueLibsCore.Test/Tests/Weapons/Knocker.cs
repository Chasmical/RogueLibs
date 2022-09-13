namespace RogueLibsCore.Test
{
    public class Knocker : CustomWeaponMelee
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomItem<Knocker>()
                     .WithName(new CustomNameInfo("Ultimate Knocker"))
                     .WithDescription(new CustomNameInfo("The weapon that will knock the hell out of you!"))
                     .WithSprite(Properties.Resources.Knocker)
                     .WithUnlock(new ItemUnlock
                     {
                         UnlockCost = 5,
                         LoadoutCost = 3,
                         CharacterCreationCost = 3,
                     });
        }

        public override void SetupDetails()
        {
            Item.meleeDamage = 5;
        }

        public override MeleeAttackInfo StartAttack()
        {
            TestPlugin.Log.LogWarning("StartAttack");
            return new MeleeAttackInfo(MeleeAttackType.Swing, MeleeHands.Both)
            {
                Speed = 4f,
                CanBackstab = false,
                KnockForce = 0f,
            };
        }
        public override void EndAttack()
        {
            TestPlugin.Log.LogWarning("EndAttack");
        }
        public override void Hit(MeleeHitArgs e)
        {
            TestPlugin.Log.LogWarning("Hit");
            e.KnockbackStrength *= 5f;
        }

    }
}
