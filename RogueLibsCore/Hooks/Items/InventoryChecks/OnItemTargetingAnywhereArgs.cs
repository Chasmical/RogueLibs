using System;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the item targeting anywhere inventory check args.</para>
    /// </summary>
    public class OnItemTargetingAnywhereArgs : RogueEventArgs
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="OnItemTargetingAnywhereArgs"/> class with the specified <paramref name="item"/>, <paramref name="position"/> and <paramref name="user"/>.</para>
        /// </summary>
        /// <param name="item">The item being used.</param>
        /// <param name="position">The position being targeted.</param>
        /// <param name="user">The agent using the item.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> or <paramref name="user"/> is <see langword="null"/>.</exception>
        public OnItemTargetingAnywhereArgs(InvItem item, Vector2 position, Agent user)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            Target = position;
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
        ///   <para>Gets or sets the position being targeted.</para>
        /// </summary>
        public Vector2 Target { get; set; }
        /// <summary>
        ///   <para>Gets or sets the agent using the item.</para>
        /// </summary>
        public Agent User { get; set; }
    }
}
