using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the <see cref="CustomEffect"/> type metadata.</para>
    /// </summary>
    public sealed class CustomEffectMetadata
    {
        public Type Type { get; }
        /// <summary>
        ///   <para>Gets the custom effect's name.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///   <para>Gets the custom effect's limitations flags.</para>
        /// </summary>
        public EffectLimitations Limitations { get; }
        /// <summary>
        ///   <para>Determines whether the status effect is removed on death.</para>
        /// </summary>
        public bool RemoveOnDeath { get; }
        /// <summary>
        ///   <para>Determines whether the status effect is removed on knockout.</para>
        /// </summary>
        public bool RemoveOnKnockOut { get; }
        /// <summary>
        ///   <para>Determines whether the status effect is removed between levels.</para>
        /// </summary>
        public bool RemoveOnNextLevel { get; }

        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this effect's name.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this effect's name, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetName() => RogueLibs.NameProvider.FindEntry(Name, NameTypes.StatusEffect);
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this effect's description.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this effect's description, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetDescription() => RogueLibs.NameProvider.FindEntry(Name, NameTypes.Description);
        internal RogueSprite? sprite;
        /// <summary>
        ///   <para>Returns a <see cref="RogueSprite"/> that represents this effect. Note that it works only on sprites initialized with <see cref="EffectBuilder.WithSprite(byte[], Rect, float)"/> or one of its overloads.</para>
        /// </summary>
        /// <returns>The <see cref="RogueSprite"/> that represents this effect, if found; otherwise, <see langword="null"/>.</returns>
        public RogueSprite? GetSprite() => sprite;

        private static readonly Dictionary<Type, CustomEffectMetadata> infos = new Dictionary<Type, CustomEffectMetadata>();
        /// <summary>
        ///   <para>Gets the specified <see cref="CustomEffect"/> <paramref name="type"/>'s metadata.</para>
        /// </summary>
        /// <param name="type">The <see cref="CustomEffect"/> type to get the metadata for.</param>
        /// <returns>The specified <paramref name="type"/>'s metadata.</returns>
        /// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomEffect"/>.</exception>
        public static CustomEffectMetadata Get(Type type) => infos.TryGetValue(type, out CustomEffectMetadata info) ? info : infos[type] = new CustomEffectMetadata(type);
        /// <summary>
        ///   <para>Gets the specified <typeparamref name="TEffect"/>'s metadata.</para>
        /// </summary>
        /// <typeparam name="TEffect">The <see cref="CustomEffect"/> type get the metadata for.</typeparam>
        /// <returns>The specified <typeparamref name="TEffect"/>'s metadata.</returns>
        public static CustomEffectMetadata Get<TEffect>() where TEffect : CustomEffect => Get(typeof(TEffect));

        private CustomEffectMetadata(Type type)
        {
            if (!typeof(CustomEffect).IsAssignableFrom(type))
                throw new ArgumentException($"The specified {nameof(type)} is not a {nameof(CustomEffect)}.", nameof(type));

            Type = type;
            EffectNameAttribute? attr = type.GetCustomAttributes<EffectNameAttribute>().FirstOrDefault();
            Name = attr?.Name ?? type.Name;

            EffectParametersAttribute? parsAttr = type.GetCustomAttributes<EffectParametersAttribute>().FirstOrDefault();
            if (parsAttr is null)
                RogueFramework.LogWarning($"Type {type} does not have a {nameof(EffectParametersAttribute)}!");

            Limitations = parsAttr?.Limitations ?? EffectLimitations.RemoveOnDeath;
            RemoveOnDeath = (Limitations & EffectLimitations.RemoveOnDeath) != 0;
            RemoveOnKnockOut = (Limitations & EffectLimitations.RemoveOnKnockOut) != 0;
            RemoveOnNextLevel = (Limitations & EffectLimitations.RemoveOnNextLevel) != 0;
        }
    }
}
