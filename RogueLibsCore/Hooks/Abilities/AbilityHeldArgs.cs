using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the custom ability's holding args.</para>
    /// </summary>
    public class AbilityHeldArgs : EventArgs
    {
        /// <summary>
        ///   <para>Gets or sets the current holding time, in seconds.</para>
        /// </summary>
        public float HeldTime { get; set; }
        /// <summary>
        ///   <para>Interrupts the custom ability's holding.</para>
        /// </summary>
        public void Interrupt() => HeldTime = 0f;
    }
}
