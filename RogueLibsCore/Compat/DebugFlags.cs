﻿using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the debugging flags.</para>
    /// </summary>
    [Flags, Obsolete("DebugFlags enum and all related functionality were removed in RogueLibs v4.0.0.")]
    public enum DebugFlags
    {
        /// <summary>
        ///   <para>No debug flags specified.</para>
        /// </summary>
        None = 0,

        /// <summary>
        ///   <para>Specifies that names stuff should be logged.</para>
        /// </summary>
        Names        = 1 << 0,
        /// <summary>
        ///   <para>Specifies that unlocks stuff should be logged.</para>
        /// </summary>
        Unlocks      = 1 << 1,
        /// <summary>
        ///   <para>Specifies that unlock menus stuff should be logged.</para>
        /// </summary>
        UnlockMenus  = 1 << 2,
        /// <summary>
        ///   <para>Specifies that sprites stuff should be logged.</para>
        /// </summary>
        Sprites      = 1 << 3,
        /// <summary>
        ///   <para>Specifies that items stuff should be logged.</para>
        /// </summary>
        Items        = 1 << 4,
        /// <summary>
        ///   <para>Specifies that traits stuff should be logged.</para>
        /// </summary>
        Traits       = 1 << 5,
        /// <summary>
        ///   <para>Specifies that effects stuff should be logged.</para>
        /// </summary>
        Effects      = 1 << 6,
        /// <summary>
        ///   <para>Specifies that abilities stuff should be logged.</para>
        /// </summary>
        Abilities    = 1 << 7,
        /// <summary>
        ///   <para>Specifies that interactions stuff should be logged.</para>
        /// </summary>
        Interactions = 1 << 8,
        /// <summary>
        ///   <para>Specifies that disasters stuff should be logged.</para>
        /// </summary>
        Disasters    = 1 << 9,
        /// <summary>
        ///   <para>Specifies that objects stuff should be logged.</para>
        /// </summary>
        Objects      = 1 << 10,

        /// <summary>
        ///   <para>Specifies that agent stuff should be logged.</para>
        /// </summary>
        Agents = 1 << 11,

        /// <summary>
        ///   <para>Specifies that various potentially annoying debug hints should be enabled, such as "I am patched!" buttons in the interactions.</para>
        /// </summary>
        EnableHints  = 1 << 30,
        /// <summary>
        ///   <para>Specifies that various debug tools should be enabled.</para>
        /// </summary>
        EnableTools  = 1 << 31,

        /// <summary>
        ///   <para>Specifies all debug flags. Expect a giant wall of constantly flowing text.</para>
        /// </summary>
        All = -1,
    }
}
