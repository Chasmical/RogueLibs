using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the custom trait's update coroutine args.</para>
    /// </summary>
    public class TraitUpdatedArgs : EventArgs
    {
        /// <summary>
        ///   <para>Gets or sets the update delay of the coroutine, in seconds.</para>
        /// </summary>
        public float UpdateDelay { get; set; }
    }
}
