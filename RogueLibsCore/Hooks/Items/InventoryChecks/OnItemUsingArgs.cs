using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the item usage inventory check args.</para>
    /// </summary>
    public class OnItemUsingArgs : RogueEventArgs
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="OnItemUsingArgs"/> class with the specified <paramref name="item"/> and <paramref name="user"/>.</para>
        /// </summary>
        /// <param name="item">The item being used.</param>
        /// <param name="user">The agent using the item.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> or <paramref name="user"/> is <see langword="null"/>.</exception>
        public OnItemUsingArgs(InvItem item, Agent user)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
        /// <summary>
        ///   <para>Gets the item's inventory.</para>
        /// </summary>
        public InvDatabase Inventory => Item.database;
        /// <summary>
        ///   <para>Gets the item being used.</para>
        /// </summary>
        public InvItem Item { get; }
        /// <summary>
        ///   <para>Gets or sets the agent using the item.</para>
        /// </summary>
        public Agent User { get; set; }
    }
}
