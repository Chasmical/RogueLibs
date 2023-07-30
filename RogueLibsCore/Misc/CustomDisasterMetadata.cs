using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the <see cref="CustomDisaster"/> type metadata.</para>
    /// </summary>
    public sealed class CustomDisasterMetadata
    {
        public Type Type { get; }
        /// <summary>
        ///   <para>Gets the custom disaster's name.</para>
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this disaster's name.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this disaster's name, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetName() => RogueLibs.NameProvider.FindEntry($"LevelFeeling{Name}_Name", NameTypes.Interface);
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this disaster's description.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this disaster's description, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetDescription() => RogueLibs.NameProvider.FindEntry($"LevelFeeling{Name}_Desc", NameTypes.Description);
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this disaster's first message.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this disaster's first message, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetMessage1() => RogueLibs.NameProvider.FindEntry($"LevelFeeling{Name}1", NameTypes.Description);
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this disaster's second message.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this disaster's second message, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetMessage2() => RogueLibs.NameProvider.FindEntry($"LevelFeeling{Name}2", NameTypes.Description);

        private static readonly Dictionary<Type, CustomDisasterMetadata> infos = new Dictionary<Type, CustomDisasterMetadata>();
        /// <summary>
        ///   <para>Gets the specified <see cref="CustomDisaster"/> <paramref name="type"/>'s metadata.</para>
        /// </summary>
        /// <param name="type">The <see cref="CustomDisaster"/> type to get the metadata for.</param>
        /// <returns>The specified <paramref name="type"/>'s metadata.</returns>
        /// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomDisaster"/>.</exception>
        public static CustomDisasterMetadata Get(Type type) => infos.TryGetValue(type, out CustomDisasterMetadata info) ? info : infos[type] = new CustomDisasterMetadata(type);
        /// <summary>
        ///   <para>Gets the specified <typeparamref name="TDisaster"/>'s metadata.</para>
        /// </summary>
        /// <typeparam name="TDisaster">The <see cref="CustomDisaster"/> type get the metadata for.</typeparam>
        /// <returns>The specified <typeparamref name="TDisaster"/>'s metadata.</returns>
        public static CustomDisasterMetadata Get<TDisaster>() where TDisaster : CustomDisaster => Get(typeof(TDisaster));

        private CustomDisasterMetadata(Type type)
        {
            if (!typeof(CustomDisaster).IsAssignableFrom(type))
                throw new ArgumentException($"The specified type is not a {nameof(CustomDisaster)}!", nameof(type));

            Type = type;
            DisasterNameAttribute? nameAttr = type.GetCustomAttributes<DisasterNameAttribute>().FirstOrDefault();
            Name = nameAttr?.Name ?? type.Name;
        }
    }
}
