using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the <see cref="CustomEffect"/> type metadata.</para>
    /// </summary>
    [Obsolete("EffectInfo was renamed to CustomEffectMetadata in RogueLibs v4.0.0.")]
    public sealed class EffectInfo
    {
        private readonly CustomEffectMetadata Metadata;
        private EffectInfo(CustomEffectMetadata metadata) => Metadata = metadata;

        /// <summary>
        ///   <para>Gets the custom effect's name.</para>
        /// </summary>
        public string Name => Metadata.Name;
        /// <summary>
        ///   <para>Gets the custom effect's limitations flags.</para>
        /// </summary>
        public EffectLimitations Limitations => Metadata.Limitations;
        /// <summary>
        ///   <para>Determines whether the status effect is removed on death.</para>
        /// </summary>
        public bool RemoveOnDeath => Metadata.RemoveOnDeath;
        /// <summary>
        ///   <para>Determines whether the status effect is removed on knockout.</para>
        /// </summary>
        public bool RemoveOnKnockOut => Metadata.RemoveOnKnockOut;
        /// <summary>
        ///   <para>Determines whether the status effect is removed between levels.</para>
        /// </summary>
        public bool RemoveOnNextLevel => Metadata.RemoveOnNextLevel;

        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this effect's name.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this effect's name, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetName() => Metadata.GetName();
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this effect's description.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this effect's description, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetDescription() => Metadata.GetDescription();
        /// <summary>
        ///   <para>Returns a <see cref="RogueSprite"/> that represents this effect. Note that it works only on sprites initialized with <see cref="EffectBuilder.WithSprite(byte[], Rect, float)"/> or one of its overloads.</para>
        /// </summary>
        /// <returns>The <see cref="RogueSprite"/> that represents this effect, if found; otherwise, <see langword="null"/>.</returns>
        public RogueSprite? GetSprite() => Metadata.GetSprite();

        // Maintain referential stability through a dictionary, just in case.
        private static readonly Dictionary<Type, EffectInfo> infos = new Dictionary<Type, EffectInfo>();
        /// <summary>
        ///   <para>Gets the specified <see cref="CustomEffect"/> <paramref name="type"/>'s metadata.</para>
        /// </summary>
        /// <param name="type">The <see cref="CustomEffect"/> type to get the metadata for.</param>
        /// <returns>The specified <paramref name="type"/>'s metadata.</returns>
        /// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomEffect"/>.</exception>
        public static EffectInfo Get(Type type)
            => infos.TryGetValue(type, out EffectInfo info) ? info : infos[type] = new EffectInfo(CustomEffectMetadata.Get(type));
        /// <summary>
        ///   <para>Gets the specified <typeparamref name="TEffect"/>'s metadata.</para>
        /// </summary>
        /// <typeparam name="TEffect">The <see cref="CustomEffect"/> type get the metadata for.</typeparam>
        /// <returns>The specified <typeparamref name="TEffect"/>'s metadata.</returns>
        public static EffectInfo Get<TEffect>() where TEffect : CustomEffect => Get(typeof(TEffect));

    }
}
