using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a custom effect's limitations.</para>
    /// </summary>
    [Flags]
    public enum EffectLimitations
    {
        /// <summary>
        ///   <para>No limitations.</para>
        /// </summary>
        None = 0,

        /// <summary>
        ///   <para>The effect will be removed on death.</para>
        /// </summary>
        RemoveOnDeath     = 1 << 0,
        /// <summary>
        ///   <para>The effect will be removed on knockout.</para>
        /// </summary>
        RemoveOnKnockOut  = 1 << 1,
        /// <summary>
        ///   <para>The effect will be removed on the next level.</para>
        /// </summary>
        RemoveOnNextLevel = 1 << 2,
    }
}
