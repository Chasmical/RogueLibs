namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Indicates that a custom ability is targetable.</para>
    /// </summary>
    public interface IAbilityTargetable
    {
        /// <summary>
        ///   <para>The method that is called to determine what the special ability owner can use the ability on.</para>
        /// </summary>
        /// <returns>The target object, if the special ability can be used; otherwise, <see langword="null"/>.</returns>
        PlayfieldObject FindTarget();
    }
}
