using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents the <see cref="CustomAgent"/> type metadata.</para>
    /// </summary>
    public sealed class AgentInfo
    {
        /// <summary>
        ///   <para>Gets the custom agent's name.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///   <para>Returns a <see cref="CustomName"/> associated with this agent's name.</para>
        /// </summary>
        /// <returns>The <see cref="CustomName"/> associated with this agent's name, if found; otherwise, <see langword="null"/>.</returns>
        public CustomName? GetName() => RogueLibs.NameProvider.FindEntry(Name, NameTypes.Agent);
        internal RogueSprite[]? headSprite;
        internal RogueSprite[]? bodySprite;
        /// <summary>
        ///   <para>Returns a array <see cref="RogueSprite"/> that represents this agent head. Note that it works only on sprites initialized with <see cref="AgentBuilder.WithHeadSprite(byte[])"/> or one of its overloads.</para>
        /// </summary>
        /// <returns>The array <see cref="RogueSprite"/> that represents this agent head, if found; otherwise, <see langword="null"/>.</returns>
        public RogueSprite[]? GetHeadSprites() => headSprite;
        /// <summary>
        ///   <para>Returns a array <see cref="RogueSprite"/> that represents this agent body. Note that it works only on sprites initialized with <see cref="AgentBuilder.WithBodySprite(byte[])"/> or one of its overloads.</para>
        /// </summary>
        /// <returns>The array <see cref="RogueSprite"/> that represents this agent body, if found; otherwise, <see langword="null"/>.</returns>
        public RogueSprite[]? GetBodySprites() => bodySprite;


        private static readonly Dictionary<Type, AgentInfo> infos = new Dictionary<Type, AgentInfo>();
        /// <summary>
        ///   <para>Gets the specified <see cref="CustomAgent"/> <paramref name="type"/>'s metadata.</para>
        /// </summary>
        /// <param name="type">The <see cref="CustomAgent"/> type to get the metadata for.</param>
        /// <returns>The specified <paramref name="type"/>'s metadata.</returns>
        /// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomAgent"/>.</exception>
        public static AgentInfo Get(Type type) => infos.TryGetValue(type, out AgentInfo info) ? info : infos[type] = new AgentInfo(type);
        /// <summary>
        ///   <para>Gets the specified <typeparamref name="TAgent"/>'s metadata.</para>
        /// </summary>
        /// <typeparam name="TAgent">The <see cref="CustomAgent"/> type get the metadata for.</typeparam>
        /// <returns>The specified <typeparamref name="TAgent"/>'s metadata.</returns>
        public static AgentInfo Get<TAgent>() where TAgent : CustomAgent => Get(typeof(TAgent));
        private AgentInfo(Type type)
        {
            if (!typeof(CustomAgent).IsAssignableFrom(type))
                throw new ArgumentException($"{nameof(type)} does not inherit from {nameof(CustomAgent)}!", nameof(type));

            Name = type.Name;
        }
    }
}