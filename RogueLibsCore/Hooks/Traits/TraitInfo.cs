using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the <see cref="CustomTrait"/> type metadata.</para>
    /// </summary>
    public sealed class TraitInfo
    {
        /// <summary>
        ///   <para>Gets the custom trait's name.</para>
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this trait's name.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this trait's name, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetName() => RogueLibs.NameProvider.FindEntry(Name, NameTypes.StatusEffect);
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this trait's description.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this trait's description, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetDescription() => RogueLibs.NameProvider.FindEntry(Name, NameTypes.Description);
        /// <summary>
        ///   <para>Returns an <see cref="TraitUnlock"/> associated with this trait.</para>
        /// </summary>
        /// <returns>The <see cref="TraitUnlock"/> associated with this trait, if found; otherwise, <see langword="null"/>.</returns>
        public TraitUnlock? GetUnlock() => RogueLibs.GetUnlock<TraitUnlock>(Name);
        internal RogueSprite? sprite;
        /// <summary>
        ///   <para>Returns a <see cref="RogueSprite"/> that represents this trait. Note that it works only on sprites initialized with <see cref="TraitBuilder.WithSprite(byte[], Rect, float)"/> or one of its overloads.</para>
        /// </summary>
        /// <returns>The <see cref="RogueSprite"/> that represents this trait, if found; otherwise, <see langword="null"/>.</returns>
        public RogueSprite? GetSprite() => sprite;

        private static readonly Dictionary<Type, TraitInfo> infos = new Dictionary<Type, TraitInfo>();
        /// <summary>
        ///   <para>Gets the specified <see cref="CustomTrait"/> <paramref name="type"/>'s metadata.</para>
        /// </summary>
        /// <param name="type">The <see cref="CustomTrait"/> type to get the metadata for.</param>
        /// <returns>The specified <paramref name="type"/>'s metadata.</returns>
        /// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomTrait"/>.</exception>
        public static TraitInfo Get(Type type) => infos.TryGetValue(type, out TraitInfo info) ? info : infos[type] = new TraitInfo(type);
        /// <summary>
        ///   <para>Gets the specified <typeparamref name="TTrait"/>'s metadata.</para>
        /// </summary>
        /// <typeparam name="TTrait">The <see cref="CustomTrait"/> type get the metadata for.</typeparam>
        /// <returns>The specified <typeparamref name="TTrait"/>'s metadata.</returns>
        public static TraitInfo Get<TTrait>() where TTrait : CustomTrait => Get(typeof(TTrait));

        private TraitInfo(Type type)
        {
            if (!typeof(CustomTrait).IsAssignableFrom(type))
                throw new ArgumentException($"The specified type is not a {nameof(CustomTrait)}!", nameof(type));

            TraitNameAttribute? nameAttr = type.GetCustomAttributes<TraitNameAttribute>().FirstOrDefault();
            Name = nameAttr?.Name ?? type.Name;
        }
    }
}
