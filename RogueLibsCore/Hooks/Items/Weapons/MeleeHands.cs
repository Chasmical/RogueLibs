using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Defines what hands are used in a melee attack.</para>
    /// </summary>
    [Flags]
    public enum MeleeHands : byte
    {
        /// <summary>
        ///   <para>Specifies that no hands should be used in the attack.</para>
        /// </summary>
        None  = 0b_00,
        /// <summary>
        ///   <para>Specifies that the left hand should be used in the attack.</para>
        /// </summary>
        Left  = 0b_10,
        /// <summary>
        ///   <para>Specifies that the right hand should be used in the attack.</para>
        /// </summary>
        Right = 0b_01,
        /// <summary>
        ///   <para>Specifies that both hands should be used in the attack.</para>
        /// </summary>
        Both  = 0b_11,
        /// <summary>
        ///   <para>Specifies that the hand should be randomly chosen between <see cref="Left"/> and <see cref="Right"/>.</para>
        /// </summary>
        Alternating = 0b_100,
    }
}