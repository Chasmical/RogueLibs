using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a melee weapon hit. Can be used to alter the default behaviour.</para>
    /// </summary>
    public sealed class MeleeHitArgs
    {
        internal MeleeHitArgs(GameObject gameObject, PlayfieldObject target)
        {
            GameObject = gameObject;
            Target = target;
        }

        /// <summary>
        ///   <para>Gets the main <see cref="UnityEngine.GameObject"/> of the hit object.</para>
        /// </summary>
        public GameObject GameObject { get; }
        /// <summary>
        ///   <para>Gets or sets the hit object.</para>
        /// </summary>
        public PlayfieldObject Target { get; set; }

        /// <summary>
        ///   <para>Gets or sets the knockback strength.</para>
        /// </summary>
        public float KnockbackStrength { get; set; }
        /// <summary>
        ///   <para>Gets or sets the knockback direction. The vector is normalized after the method returns.</para>
        /// </summary>
        public Vector2 KnockbackDirection { get; set; }
        /// <summary>
        ///   <para>Gets or sets the sound that the hit should make.</para>
        /// </summary>
        public string? HitSound { get; set; }
        /// <summary>
        ///   <para>Gets or sets the amount of durability that will be depleted from the weapon.</para>
        /// </summary>
        public int DepleteCount { get; set; }
        /// <summary>
        ///   <para>Gets or sets whether the object can be hit again in the same swing.</para>
        /// </summary>
        public bool CanHitAgain { get; set; }
        /// <summary>
        ///   <para>Determines whether this hit was the first one on this object (used with <see cref="CanHitAgain"/>).</para>
        /// </summary>
        public bool IsFirstHit { get; }

    }
}