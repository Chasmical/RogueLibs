using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Provides data for the <see cref="InventoryChecks.AddItemsCombiningCheck"/> event.</para>
    /// </summary>
    public class OnItemsCombiningArgs : RogueEventArgs
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="OnItemsCombiningArgs"/> class with the specified <paramref name="item"/>, <paramref name="otherItem"/> and <paramref name="combiner"/>.</para>
        /// </summary>
        /// <param name="item">The item being combined.</param>
        /// <param name="otherItem">The item being combined with.</param>
        /// <param name="combiner">The agent combining the two items.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>, <paramref name="otherItem"/> or <paramref name="combiner"/> is <see langword="null"/>.</exception>
        public OnItemsCombiningArgs(InvItem item, InvItem otherItem, Agent combiner)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            OtherItem = otherItem ?? throw new ArgumentNullException(nameof(otherItem));
            Combiner = combiner ?? throw new ArgumentNullException(nameof(combiner));
        }
        /// <summary>
        ///   <para>Gets the item's inventory.</para>
        /// </summary>
        public InvDatabase Inventory => Item.database;
        /// <summary>
        ///   <para>Gets the item being combined.</para>
        /// </summary>
        public InvItem Item { get; }
        /// <summary>
        ///   <para>Gets or sets the item being combined with.</para>
        /// </summary>
        public InvItem OtherItem { get; set; }
        /// <summary>
        ///   <para>Gets or sets the agent combining the two items.</para>
        /// </summary>
        public Agent Combiner { get; set; }
    }
}
