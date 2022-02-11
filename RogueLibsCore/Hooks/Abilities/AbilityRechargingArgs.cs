using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the custom ability's recharging args.</para>
    /// </summary>
    public class AbilityRechargingArgs : EventArgs
    {
        /// <summary>
        ///   <para>Gets or sets the update delay of the recharging coroutine, in seconds.</para>
        /// </summary>
        public float UpdateDelay { get; set; }
        /// <summary>
        ///   <para>Gets or sets whether to display the Recharged text, when the custom ability is recharged.</para>
        /// </summary>
        public bool ShowRechargedText { get; set; }
    }
}
