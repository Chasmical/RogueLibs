using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the <see cref="CustomTrait"/> type metadata.</para>
    /// </summary>
    [Obsolete("TraitInfo was renamed to CustomTraitMetadata in RogueLibs v4.0.0.")]
    public sealed class TraitInfo
    {
        private readonly CustomTraitMetadata Metadata;
        private TraitInfo(CustomTraitMetadata metadata) => Metadata = metadata;

        /// <summary>
        ///   <para>Gets the custom trait's name.</para>
        /// </summary>
        public string Name => Metadata.Name;

        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this trait's name.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this trait's name, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetName() => Metadata.GetName();
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this trait's description.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this trait's description, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetDescription() => Metadata.GetDescription();
        /// <summary>
        ///   <para>Returns an <see cref="TraitUnlock"/> associated with this trait.</para>
        /// </summary>
        /// <returns>The <see cref="TraitUnlock"/> associated with this trait, if found; otherwise, <see langword="null"/>.</returns>
        public TraitUnlock? GetUnlock() => Metadata.GetUnlock();
        /// <summary>
        ///   <para>Returns a <see cref="RogueSprite"/> that represents this trait. Note that it works only on sprites initialized with <see cref="TraitBuilder.WithSprite(byte[], Rect, float)"/> or one of its overloads.</para>
        /// </summary>
        /// <returns>The <see cref="RogueSprite"/> that represents this trait, if found; otherwise, <see langword="null"/>.</returns>
        public RogueSprite? GetSprite() => Metadata.GetSprite();

        // Maintain referential stability through a dictionary, just in case.
        private static readonly Dictionary<Type, TraitInfo> infos = new Dictionary<Type, TraitInfo>();
        /// <summary>
        ///   <para>Gets the specified <see cref="CustomTrait"/> <paramref name="type"/>'s metadata.</para>
        /// </summary>
        /// <param name="type">The <see cref="CustomTrait"/> type to get the metadata for.</param>
        /// <returns>The specified <paramref name="type"/>'s metadata.</returns>
        /// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomTrait"/>.</exception>
        public static TraitInfo Get(Type type)
            => infos.TryGetValue(type, out TraitInfo info) ? info : infos[type] = new TraitInfo(CustomTraitMetadata.Get(type));
        /// <summary>
        ///   <para>Gets the specified <typeparamref name="TTrait"/>'s metadata.</para>
        /// </summary>
        /// <typeparam name="TTrait">The <see cref="CustomTrait"/> type get the metadata for.</typeparam>
        /// <returns>The specified <typeparamref name="TTrait"/>'s metadata.</returns>
        public static TraitInfo Get<TTrait>() where TTrait : CustomTrait => Get(typeof(TTrait));

    }
}
