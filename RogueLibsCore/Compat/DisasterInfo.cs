using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the <see cref="CustomDisaster"/> type metadata.</para>
    /// </summary>
    [Obsolete("DisasterInfo was renamed to CustomDisasterMetadata in RogueLibs v4.0.0.")]
    public sealed class DisasterInfo
    {
        private readonly CustomDisasterMetadata Metadata;
        private DisasterInfo(CustomDisasterMetadata metadata) => Metadata = metadata;

        /// <summary>
        ///   <para>Gets the custom disaster's name.</para>
        /// </summary>
        public string Name => Metadata.Name;

        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this disaster's name.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this disaster's name, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetName() => Metadata.GetName();
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this disaster's description.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this disaster's description, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetDescription() => Metadata.GetDescription();
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this disaster's first message.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this disaster's first message, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetMessage1() => Metadata.GetMessage1();
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this disaster's second message.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this disaster's second message, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetMessage2() => Metadata.GetMessage2();

        // Maintain referential stability through a dictionary, just in case.
        private static readonly Dictionary<Type, DisasterInfo> infos = new Dictionary<Type, DisasterInfo>();
        /// <summary>
        ///   <para>Gets the specified <see cref="CustomDisaster"/> <paramref name="type"/>'s metadata.</para>
        /// </summary>
        /// <param name="type">The <see cref="CustomDisaster"/> type to get the metadata for.</param>
        /// <returns>The specified <paramref name="type"/>'s metadata.</returns>
        /// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomDisaster"/>.</exception>
        public static DisasterInfo Get(Type type)
            => infos.TryGetValue(type, out DisasterInfo info) ? info : infos[type] = new DisasterInfo(CustomDisasterMetadata.Get(type));
        /// <summary>
        ///   <para>Gets the specified <typeparamref name="TDisaster"/>'s metadata.</para>
        /// </summary>
        /// <typeparam name="TDisaster">The <see cref="CustomDisaster"/> type get the metadata for.</typeparam>
        /// <returns>The specified <typeparamref name="TDisaster"/>'s metadata.</returns>
        public static DisasterInfo Get<TDisaster>() where TDisaster : CustomDisaster => Get(typeof(TDisaster));

    }
}
