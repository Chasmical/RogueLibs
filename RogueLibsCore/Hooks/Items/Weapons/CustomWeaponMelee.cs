using System;
using UnityEngine;
using Random = System.Random;

namespace RogueLibsCore
{
    public abstract class CustomWeaponMelee : CustomItem, ICustomItemSetupHelper
    {
        void ICustomItemSetupHelper.BeforeSetup()
        {
            Item.itemType = ItemTypes.WeaponMelee;
            Item.weaponCode = weaponType.WeaponMelee;
            Item.isWeapon = true;
            Item.meleeDamage = RogueFramework.SpecialInt;
        }
        void ICustomItemSetupHelper.AfterSetup()
        {
            if (Item.meleeDamage is RogueFramework.SpecialInt)
            {
                Item.meleeDamage = 0;
                RogueFramework.LogWarning($"Custom item {GetType()} doesn't set the Item.meleeDamage field!");
            }
        }

        public abstract MeleeAttackInfo? StartAttack();
        public abstract void EndAttack();

        public abstract void Hit(MeleeHitArgs e);




    }
    public sealed class MeleeHitArgs
    {
        internal MeleeHitArgs(PlayfieldObject target, float knockbackStrength, string hitSound)
        {
            Target = target;
            KnockbackStrength = knockbackStrength;
            HitSound = hitSound;
        }
        public PlayfieldObject Target { get; set; }
        public float KnockbackStrength { get; set; }
        public string? HitSound { get; set; }
        public bool CanHitAgain { get; set; }
    }
    public class MeleeAttackInfo
    {
        public MeleeAttackInfo(MeleeAttackType type, MeleeHands hands)
        {
            Type = type;
            if ((hands & MeleeHands.Alternating) is not 0)
                hands = (hands & ~MeleeHands.Alternating) | (rnd.Next(2) is 0 ? MeleeHands.Left : MeleeHands.Right);
            Hands = hands;
            Animation.Speed = hands == MeleeHands.Both ? 4f : 5f;

            switch (type)
            {
                case MeleeAttackType.Fist:
                    KnockForce = 20f;
                    HitBox = new Rect(0f, 0f, 0.16f, 0.16f);
                    Animation.Name = "Melee-Punch";
                    Animation.Sound = "SwingWeaponSmall";
                    break;
                case MeleeAttackType.Claw:
                    KnockForce = 20f;
                    HitBox = new Rect(0f, 0f, 0.16f, 0.16f);
                    Animation.Name = "Melee-SwingClawBig";
                    Animation.Sound = "SwingWeaponFist";
                    break;
                case MeleeAttackType.Stab:
                    KnockForce = 40f;
                    HitBox = new Rect(0f, -0.02f, 0.16f, 0.36f);
                    Animation.Name = "Melee-Knife";
                    Animation.Sound = "SwingWeaponSmall";
                    break;
                case MeleeAttackType.Swing:
                    KnockForce = 80f;
                    HitBox = new Rect(0f, -0.02f, 0.16f, 0.36f);
                    Animation.Name = "Melee-SwingShort";
                    Animation.Sound = "SwingWeaponLarge";
                    break;
                default:
                    KnockForce = 40f;
                    HitBox = new Rect(0f, 0f, 0.16f, 0.16f);
                    Animation.Name = "Melee-Punch";
                    Animation.Sound = "SwingWeaponFist";
                    break;
            }
            Particles.Name = type == MeleeAttackType.Swing ? "MeleeTrail" : null;
            Particles.Offset = new Vector2(-0.12f, 0.12f);

        }
        private static readonly Random rnd = new Random();

        public MeleeAttackType Type { get; }
        public MeleeHands Hands { get; }

        public float Cooldown { get; set; } = 1f;

        public float KnockForce { get; set; }
        public bool CanBackstab { get; set; } = true;
        public bool CanMoveDuringAttack { get; set; }
        public Rect HitBox { get; set; }
        public string? HitSound { get; set; } = "Normal";

        public AnimationInfo Animation;
        public ParticlesInfo Particles;

        public struct AnimationInfo
        {
            public string? Name { get; set; }
            public float Speed { get; set; }
            public string? Sound { get; set; }
        }
        public struct ParticlesInfo
        {
            public string? Name { get; set; }
            public Vector2 Offset { get; set; }
            public float Angle { get; set; }
        }

    }
    public enum MeleeAttackType
    {
        Stab,
        Swing,
        Fist,
        Claw,
    }
    [Flags]
    public enum MeleeHands : byte
    {
        None  = 0b_00,
        Left  = 0b_10,
        Right = 0b_01,
        Both  = 0b_11,
        Alternating = 0b_100,
    }
}
