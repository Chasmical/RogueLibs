using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a melee weapon hit. Can be used to alter the default behaviour.</para>
    /// </summary>
    public sealed class MeleeHitArgs
    {
        internal MeleeHitArgs(MeleePreHitArgs e)
        {
            GameObject = e.GameObject;
            Target = e.Target;
            IsFirstHit = e.IsFirstHit;
            FromClient = e.FromClient;
        }

        /// <summary>
        ///   <para>Gets the main <see cref="UnityEngine.GameObject"/> of the hit object.</para>
        /// </summary>
        public GameObject GameObject { get; }
        /// <summary>
        ///   <para>Gets the hit object.</para>
        /// </summary>
        public PlayfieldObject Target { get; }

        public int DamageDealt { get; internal set; }

        // Visuals and sounds
        /// <summary>
        ///   <para>Gets or sets whether to highlight the hit object for just a moment.</para>
        /// </summary>
        public bool DoFlash { get; set; }
        public string? Particles { get; set; }
        public Vector2 ParticlesPosition { get; set; }
        public float ParticlesAngle { get; set; }

        /// <summary>
        ///   <para>Gets or sets the sound that the hit should make.</para>
        /// </summary>
        public string? HitSound { get; set; }
        public Vector2 HitSoundPosition { get; set; }
        public float NoiseVolume { get; set; }
        public Vector2 NoisePosition { get; set; }

        // Input response
        public float ScreenShakeTime { get; set; }
        public float ScreenShakeOffset { get; set; }
        public float VibrateControllerIntensity { get; set; }
        public float VibrateControllerTime { get; set; }
        public int FreezeFrames { get; set; }
        public bool AlienFX { get; set; }

        // Knockback
        public Vector2 KnockbackDirection { get; set; }
        public float KnockbackStrength { get; set; }
        public Vector2 RecoilDirection { get; set; }
        public float RecoilStrength { get; set; }

        public bool DoOwnCheck { get; set; }
        public float AICombatCooldown { get; set; }

        public int DepleteAmount { get; set; }



        /// <summary>
        ///   <para>Gets or sets whether the object can be hit again in the same swing.</para>
        /// </summary>
        public bool CanHitAgain { get; set; }
        /// <summary>
        ///   <para>Determines whether this hit was the first one on this object (used with <see cref="CanHitAgain"/>).</para>
        /// </summary>
        public bool IsFirstHit { get; }
        public bool FromClient { get; }

        /// <summary>
        ///   <para>Prevents any default behaviour of the melee weapon hit.</para>
        /// </summary>
        public void PreventDefault()
        {
            IsDefaultPrevented = true;

            DoFlash = false;
            Particles = null;
            HitSound = null;
            NoiseVolume = 0f;

            ScreenShakeOffset = 0f;
            VibrateControllerIntensity = 0f;
            FreezeFrames = 0;
            AlienFX = false;

            KnockbackStrength = 0f;
            RecoilStrength = 0f;
            DoOwnCheck = false;
            AICombatCooldown = 0f;
            DepleteAmount = 0;
        }
        public bool IsDefaultPrevented { get; set; }

    }
    public sealed class MeleePreHitArgs
    {
        internal MeleePreHitArgs(GameObject gameObject, PlayfieldObject target,
                              GameObject originalGameObject, PlayfieldObject originalTarget,
                              bool isFirstHit, bool fromClient)
        {
            GameObject = gameObject;
            Target = target;
            OriginalGameObject = originalGameObject;
            OriginalTarget = originalTarget;
            IsFirstHit = isFirstHit;
            FromClient = fromClient;
        }

        /// <summary>
        ///   <para>Gets the main <see cref="UnityEngine.GameObject"/> of the hit object.</para>
        /// </summary>
        public GameObject GameObject { get; }
        /// <summary>
        ///   <para>Gets or sets the hit object.</para>
        /// </summary>
        public PlayfieldObject Target { get; set; }

        public GameObject OriginalGameObject { get; }
        public PlayfieldObject OriginalTarget { get; }

        public int WeaponDamage { get; set; }

        // Mechanics
        public bool IgnoreLineOfSight { get; set; }
        public bool IgnoreAlignedCheck { get; set; }

        /// <summary>
        ///   <para>Determines whether this hit was the first one on this object (used with <see cref="CanHitAgain"/>).</para>
        /// </summary>
        public bool IsFirstHit { get; }
        public bool FromClient { get; }

        /// <summary>
        ///   <para>Prevents any default behaviour of the melee weapon.</para>
        /// </summary>
        public void PreventDefault()
        {
            IsDefaultPrevented = true;

            WeaponDamage = 0;
            IgnoreLineOfSight = true;
            IgnoreAlignedCheck = true;
        }
        public bool IsDefaultPrevented { get; set; }

    }
}