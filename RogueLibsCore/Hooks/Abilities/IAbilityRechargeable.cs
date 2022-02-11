namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Indicates that a custom ability is rechargeable.</para>
    /// </summary>
    public interface IAbilityRechargeable
    {
        /// <summary>
        ///   <para>The method that is called as a part of the special ability's recharging coroutine.</para>
        /// </summary>
        /// <param name="e">The custom ability's recharging data.</param>
        void OnRecharging(AbilityRechargingArgs e);
    }
}
