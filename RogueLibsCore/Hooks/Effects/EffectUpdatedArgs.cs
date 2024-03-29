﻿using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the custom effect's update coroutine args.</para>
    /// </summary>
    public class EffectUpdatedArgs : EventArgs
    {
        /// <summary>
        ///   <para>Gets or sets the update delay of the coroutine, in seconds.</para>
        /// </summary>
        public float UpdateDelay { get; set; }
        /// <summary>
        ///   <para>Gets or sets whether to display the removal text, when the custom effect is removed.</para>
        /// </summary>
        public bool ShowTextOnRemoval { get; set; }
        /// <summary>
        ///   <para>Gets or sets whether it's the first tick of the coroutine.</para>
        /// </summary>
        public bool IsFirstTick { get; set; }
    }
}
