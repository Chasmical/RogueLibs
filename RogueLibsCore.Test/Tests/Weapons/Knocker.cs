using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
                     .WithSprite()
                     .WithUnlock(new ItemUnlock
                     {
                         UnlockCost = 5,
                         LoadoutCost = 3,
                         CharacterCreationCost = 3,
                     });
        }

        public override void SetupDetails()
        {

        }

        public override MeleeAttackInfo? StartAttack()
        {
            return new MeleeAttackInfo(MeleeAttackType.Swing, MeleeHands.Both)
            {
                Cooldown = 2f,
                Animation = { Speed = 2f },
                CanBackstab = false,
                KnockForce = 0f,
            };
        }
        public override void EndAttack()
        {

        }
        public override void Hit(MeleeHitArgs e)
        {

        }

    }
}
