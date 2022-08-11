using UnityEngine;
using Random = System.Random;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Contains information about a melee attack. See RogueLibs' docs for more information on the default values.</para>
    /// </summary>
    public class MeleeAttackInfo
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="MeleeAttackInfo"/> class with the specified <paramref name="type"/> and <paramref name="hands"/>. The initial property values depend on these parameters and represent what a vanilla weapon with these would have (see <a href="https://sugarbarrel.github.io/RogueLibs/docs/dev/items/weapons/melee-weapons">RogueLibs' documentation</a> for more information).</para>
        /// </summary>
        /// <param name="type">The type of the melee attack.</param>
        /// <param name="hands">The hands used in the attack.</param>
        public MeleeAttackInfo(MeleeAttackType type, MeleeHands hands)
        {
            Type = type;
            if ((hands & MeleeHands.Alternating) is not 0)
                hands = (hands & ~MeleeHands.Alternating) | (rnd.Next(2) is 0 ? MeleeHands.Left : MeleeHands.Right);
            Hands = hands;
            Speed = hands == MeleeHands.Both ? 4f : 5f;

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

        /// <summary>
        ///   <para>The type of the melee attack.</para>
        /// </summary>
        public MeleeAttackType Type { get; }
        /// <summary>
        ///   <para>The hands used in the melee attack.</para>
        /// </summary>
        public MeleeHands Hands { get; }

        /// <summary>
        ///   <para>Specifies the speed of the attack's animation.</para>
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        ///   <para>The knocking force that will be used to propel the attacker forward. Default values: 20, 40 or 80.</para>
        /// </summary>
        public float KnockForce { get; set; }
        /// <summary>
        ///   <para>Determines whether this attack can be used as a backstab instead. Default value: <see langword="true"/>.</para>
        /// </summary>
        public bool CanBackstab { get; set; } = true;
        /// <summary>
        ///   <para>Determines whether the attacker can move during the attack. Default value: <see langword="false"/>.</para>
        /// </summary>
        public bool CanMoveDuringAttack { get; set; }
        /// <summary>
        ///   <para>Specifies the hit box of the weapon, with offset and size.</para>
        /// </summary>
        public Rect HitBox { get; set; }
        /// <summary>
        ///   <para>Specifies the hit sound effect, if any. Default value: "Normal".</para>
        /// </summary>
        public string? HitSound { get; set; } = "Normal";

        /// <summary>
        ///   <para>Specifies the animation parameters of the melee attack.</para>
        /// </summary>
        public AnimationInfo Animation;
        /// <summary>
        ///   <para>Specifies the particle parameters of the melee attack.</para>
        /// </summary>
        public ParticlesInfo Particles;

        /// <summary>
        ///   <para>Contains information about a melee attack's animation.</para>
        /// </summary>
        public struct AnimationInfo
        {
            /// <summary>
            ///   <para>Specifies the name of the animation.</para>
            /// </summary>
            public string? Name { get; set; }
            /// <summary>
            ///   <para>Specifies the sound used by the attack.</para>
            /// </summary>
            public string? Sound { get; set; }
        }
        /// <summary>
        ///   <para>Contains information about a melee attack's particle emission.</para>
        /// </summary>
        public struct ParticlesInfo
        {
            /// <summary>
            ///   <para>Specifies the name of the particles to emit.</para>
            /// </summary>
            public string? Name { get; set; }
            /// <summary>
            ///   <para>Specifies the offset of the particles.</para>
            /// </summary>
            public Vector2 Offset { get; set; }
            /// <summary>
            ///   <para>Specifies the angle of the particles.</para>
            /// </summary>
            public float Angle { get; set; }
        }

    }
}