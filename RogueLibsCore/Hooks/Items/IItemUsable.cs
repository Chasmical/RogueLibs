namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Indicates that a custom item is usable.</para>
    /// </summary>
    public interface IItemUsable
    {
        /// <summary>
        ///   <para>Uses the item. The return value indicates whether the usage succeeded or failed.</para>
        /// </summary>
        /// <returns><see langword="true"/>, if the current item was successfully used; otherwise, <see langword="false"/>.</returns>
        bool UseItem();
    }
}
