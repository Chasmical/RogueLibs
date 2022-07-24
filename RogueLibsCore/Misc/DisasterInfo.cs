using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the <see cref="CustomDisaster"/> type metadata.</para>
    /// </summary>
    public sealed class DisasterInfo
    {
        /// <summary>
        ///   <para>Gets the custom disaster's name.</para>
        /// </summary>
        public string Name { get; }

        public CustomName? GetName() => RogueLibs.NameProvider.FindEntry($"LevelFeeling{Name}_Name", NameTypes.Interface);
        public CustomName? GetDescription() => RogueLibs.NameProvider.FindEntry($"LevelFeeling{Name}_Desc", NameTypes.Description);
        public CustomName? GetMessage1() => RogueLibs.NameProvider.FindEntry($"LevelFeeling{Name}1", NameTypes.Description);
        public CustomName? GetMessage2() => RogueLibs.NameProvider.FindEntry($"LevelFeeling{Name}2", NameTypes.Description);

        private static readonly Dictionary<Type, DisasterInfo> infos = new Dictionary<Type, DisasterInfo>();
        /// <summary>
        ///   <para>Gets the specified <see cref="CustomDisaster"/> <paramref name="type"/>'s metadata.</para>
        /// </summary>
        /// <param name="type">The <see cref="CustomDisaster"/> type to get the metadata for.</param>
        /// <returns>The specified <paramref name="type"/>'s metadata.</returns>
        /// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomDisaster"/>.</exception>
        public static DisasterInfo Get(Type type) => infos.TryGetValue(type, out DisasterInfo info) ? info : infos[type] = new DisasterInfo(type);
        /// <summary>
        ///   <para>Gets the specified <typeparamref name="TDisaster"/>'s metadata.</para>
        /// </summary>
        /// <typeparam name="TDisaster">The <see cref="CustomDisaster"/> type get the metadata for.</typeparam>
        /// <returns>The specified <typeparamref name="TDisaster"/>'s metadata.</returns>
        public static DisasterInfo Get<TDisaster>() where TDisaster : CustomDisaster => Get(typeof(TDisaster));

        private DisasterInfo(Type type)
        {
            if (!typeof(CustomDisaster).IsAssignableFrom(type))
                throw new ArgumentException($"The specified type is not a {nameof(CustomDisaster)}!", nameof(type));

            DisasterNameAttribute? nameAttr = type.GetCustomAttributes<DisasterNameAttribute>().FirstOrDefault();
            Name = nameAttr?.Name ?? type.Name;
        }
    }
}
