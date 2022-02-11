namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Indicates that a custom item is combinable.</para>
    /// </summary>
    public interface IItemCombinable
    {
        /// <summary>
        ///   <para>Determines whether to highlight the <paramref name="other"/> item in the inventory when combining the current item.</para>
        /// </summary>
        /// <param name="other">The other item.</param>
        /// <returns><see langword="true"/>, if the current item can be combined with the <paramref name="other"/> item; otherwise, <see langword="false"/>.</returns>
        bool CombineFilter(InvItem other);
        /// <summary>
        ///   <para>Combines the current item with the <paramref name="other"/> item. The return value indicates whether the combining succeeded or failed.</para>
        /// </summary>
        /// <param name="other">The other item.</param>
        /// <returns><see langword="true"/>, if the current item was successfully combined with the <paramref name="other"/> item; otherwise, <see langword="false"/>.</returns>
        bool CombineItems(InvItem other);
        /// <summary>
        ///   <para>Determines the cursor text when hovering over the <paramref name="other"/> item.</para>
        /// </summary>
        /// <param name="other">The other item.</param>
        /// <returns>The cursor text to display, or <see langword="null"/> to display the default cursor text.</returns>
        CustomTooltip CombineCursorText(InvItem other);
        /// <summary>
        ///   <para>Determines the combine tooltip in the <paramref name="other"/> item's slot.</para>
        /// </summary>
        /// <param name="other">The other item.</param>
        /// <returns>The combine tooltip to display, or <see langword="null"/> to not display anything.</returns>
        CustomTooltip CombineTooltip(InvItem other);
    }
}
