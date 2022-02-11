using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the custom trait's update coroutine args.</para>
    /// </summary>
    public class TraitUpdatedArgs : EventArgs
    {
        /// <summary>
        ///   <para>Gets or sets the coroutine's update delay, in seconds.</para>
        /// </summary>
        public float UpdateDelay { get; set; }
    }
}
