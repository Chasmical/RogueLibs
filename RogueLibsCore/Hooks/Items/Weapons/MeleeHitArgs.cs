using System;
using System.Diagnostics.Eventing.Reader;
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
            pre = e;
            GameObject = e.GameObject;
            Target = e.Target;
            IsFirstHit = e.IsFirstHit;
            FromClient = e.FromClient;
        }
        private readonly MeleePreHitArgs pre;

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
        public float AICombatCooldown { get; set; } = -1f;
        public float AICombatCooldownClose { get; set; } = -1f;

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
            AICombatCooldown = -1f;
            AICombatCooldownClose = -1f;
            DepleteAmount = 0;
        }
        public bool IsDefaultPrevented { get; set; }

        public void MergeInto(MeleeHitArgs target)
        {
            #region Knockback and recoil
            if (KnockbackStrength > 0f)
            {
                // merge my knockback into target's recoil
                Vector2 knockbackVector = KnockbackDirection.normalized * KnockbackStrength;
                Vector2 recoilVector = target.RecoilDirection.normalized * target.RecoilStrength;
                Vector2 sumVector = knockbackVector + recoilVector;

                target.RecoilDirection = sumVector.normalized;
                target.RecoilStrength = sumVector.magnitude;

                KnockbackStrength = 0f; // neutralize this side's side effects
            }
            if (RecoilStrength > 0f)
            {
                // merge my recoil into target's knockback
                Vector2 recoilVector = RecoilDirection.normalized * RecoilStrength;
                Vector2 knockbackVector = target.KnockbackDirection.normalized * target.KnockbackStrength;
                Vector2 sumVector = recoilVector + knockbackVector;

                target.KnockbackDirection = sumVector.normalized;
                target.KnockbackStrength = sumVector.magnitude;

                RecoilStrength = 0f; // neutralize this side's side effects
            }
            #endregion
        }
        public void DoSideEffects(Melee melee, Agent myAgent)
        {
            GameController gc = melee.gc;

            // TODO: also use HitSound

            // set AI combat cooldown
            if (AICombatCooldown >= 0f) myAgent.combat.meleeJustHitCooldown = AICombatCooldown;
            if (AICombatCooldownClose >= 0f) myAgent.combat.meleeJustHitCloseCooldown = AICombatCooldownClose;

            #region Noise, own check and particles
            if (NoiseVolume > 0f)
                gc.spawnerMain.SpawnNoise(NoisePosition, NoiseVolume, null, null, myAgent);
            if (DoOwnCheck && gc.serverPlayer)
                gc.OwnCheck(myAgent, GameObject, "Normal", 1);
            if (Particles is not null)
                gc.spawnerMain.SpawnParticleEffect(Particles, ParticlesPosition, ParticlesAngle);
            #endregion

            #region Knockback and recoil
            if (KnockbackStrength > 0f)
            {
                float angle = Mathf.Atan2(KnockbackDirection.y, KnockbackDirection.x);
                Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
                if (Target is Agent agent3)
                {
                    if (!agent3.disappeared && !FromClient)
                        agent3.movement.KnockBackBullet(rotation, KnockbackStrength, true, myAgent);
                }
                // TODO: for other types
            }
            if (RecoilStrength > 0f)
            {
                float angle = Mathf.Atan2(RecoilDirection.y, RecoilDirection.x);
                Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
                if (!myAgent.disappeared && !FromClient)
                    myAgent.movement.KnockBackBullet(rotation, RecoilStrength, true, myAgent);
            }
            #endregion

            #region Screen shake, freeze frames, vibration and AlienFX
            if (ScreenShakeOffset > 0f)
                gc.ScreenShake(ScreenShakeTime, ScreenShakeOffset, myAgent.tr.position, myAgent);
            if (FreezeFrames > 0)
                gc.FreezeFrames(FreezeFrames - 1);
            if (VibrateControllerIntensity > 0)
                gc.playerControl.Vibrate(myAgent.isPlayer, VibrateControllerIntensity, VibrateControllerTime);
            if (AlienFX)
            {
                if (Target is ObjectReal) gc.alienFX.HitObject(myAgent);
                else if (Target is Agent) gc.alienFX.PlayerHitEnemy(myAgent);
                // TODO: for other types?
            }
            #endregion

        }

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
        public bool IgnoreSizeDifference { get; set; }

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
            IgnoreSizeDifference = true;
        }
        public bool IsDefaultPrevented { get; set; }

    }
}