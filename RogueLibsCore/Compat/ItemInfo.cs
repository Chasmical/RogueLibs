using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the <see cref="CustomItem"/> type metadata.</para>
    /// </summary>
    [Obsolete("ItemInfo was renamed to CustomItemMetadata in RogueLibs v4.0.0.")]
    public sealed class ItemInfo
    {
        private readonly CustomItemMetadata Metadata;
        private ItemInfo(CustomItemMetadata metadata) => Metadata = metadata;

        /// <summary>
        ///   <para>Gets the custom item's name.</para>
        /// </summary>
        public string Name => Metadata.Name;
        /// <summary>
        ///   <para>Gets the custom item's categories.</para>
        /// </summary>
        public ReadOnlyCollection<string> Categories => Metadata.Categories;
        /// <summary>
        ///   <para>Gets the collection of inventory checks, ignored by the custom item.</para>
        /// </summary>
        public ReadOnlyCollection<string> IgnoredChecks => Metadata.IgnoredChecks;

        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this item's name.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this item's name, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetName() => Metadata.GetName();
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this item's description.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this item's description, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetDescription() => Metadata.GetDescription();
        /// <summary>
        ///   <para>Returns an <see cref="ItemUnlock"/> associated with this item.</para>
        /// </summary>
        /// <returns>The <see cref="ItemUnlock"/> associated with this item, if found; otherwise, <see langword="null"/>.</returns>
        public ItemUnlock? GetUnlock() => Metadata.GetUnlock();
        /// <summary>
        ///   <para>Returns a <see cref="RogueSprite"/> that represents this item. Note that it works only on sprites initialized with <see cref="ItemBuilder.WithSprite(byte[], Rect, float)"/> or one of its overloads.</para>
        /// </summary>
        /// <returns>The <see cref="RogueSprite"/> that represents this item, if found; otherwise, <see langword="null"/>.</returns>
        public RogueSprite? GetSprite() => Metadata.GetSprite();

        // Maintain referential stability through a dictionary, just in case.
        private static readonly Dictionary<Type, ItemInfo> infos = new Dictionary<Type, ItemInfo>();
        /// <summary>
        ///   <para>Gets the specified <see cref="CustomItem"/> <paramref name="type"/>'s metadata.</para>
        /// </summary>
        /// <param name="type">The <see cref="CustomItem"/> type to get the metadata for.</param>
        /// <returns>The specified <paramref name="type"/>'s metadata.</returns>
        /// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomItem"/>.</exception>
        public static ItemInfo Get(Type type)
            => infos.TryGetValue(type, out ItemInfo info) ? info : infos[type] = new ItemInfo(CustomItemMetadata.Get(type));
        /// <summary>
        ///   <para>Gets the specified <typeparamref name="TItem"/>'s metadata.</para>
        /// </summary>
        /// <typeparam name="TItem">The <see cref="CustomItem"/> type get the metadata for.</typeparam>
        /// <returns>The specified <typeparamref name="TItem"/>'s metadata.</returns>
        public static ItemInfo Get<TItem>() where TItem : CustomItem => Get(typeof(TItem));

    }
}
