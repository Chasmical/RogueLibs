using System;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a <see cref="CustomAgent"/> builder, that attaches additional information to the agent.</para>
    /// </summary>
    public class AgentBuilder
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AgentBuilder"/> class with the specified <paramref name="metadata"/>.</para>
        /// </summary>
        /// <param name="metadata">The agent metadata to use.</param>
        public AgentBuilder(CustomAgentMetadata metadata) => MetaData = metadata;
        /// <summary>
        ///   <para>The used agent metadata.</para>
        /// </summary>
        public CustomAgentMetadata MetaData { get; }
        /// <summary>
        ///   <para>Gets the agent's localizable name.</para>
        /// </summary>
        public CustomName? Name { get; private set; }
        /// <summary>
        ///   <para>Gets the agent's head sprite.</para>
        /// </summary>
        public RogueSprite[]? headSprite { get; private set; }
        /// <summary>
        ///   <para>Gets the agent's body sprite.</para>
        /// </summary>
        public RogueSprite[]? bodySprite { get; private set; }
        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the agent's name.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="AgentBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the agent's name already exists.</exception>
        public AgentBuilder WithName(CustomNameInfo info)
        {
            Name = RogueLibs.CreateCustomName(MetaData.Name, NameTypes.Agent, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a array <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> to act as the agent's head sprites.</para>
        /// </summary>
        /// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
        /// <returns>The current instance of <see cref="AgentBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
        public AgentBuilder WithHeadSprite(byte[] rawData)
        {
            Rect Area(int x, int y) => new Rect(x * 64f, y * 64f, 64f, 64f);

            headSprite = new RogueSprite[]
            {
                RogueLibs.CreateCustomSprite(MetaData.Name + "Head" + "N", SpriteScope.Hair, rawData, Area(1, 0), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Head" + "NE", SpriteScope.Hair, rawData, Area(2, 0), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Head" + "E", SpriteScope.Hair, rawData, Area(2, 1), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Head" + "SE", SpriteScope.Hair, rawData, Area(2, 2), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Head" + "S", SpriteScope.Hair, rawData, Area(1, 2), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Head" + "SW", SpriteScope.Hair, rawData, Area(0, 2), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Head" + "W", SpriteScope.Hair, rawData, Area(0, 1), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Head" + "NW", SpriteScope.Hair, rawData, Area(0, 0), 64f),
            };
            return this;
        }
        /// <summary>
        ///   <para>Creates a array <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> to act as the agent's body sprites.</para>
        /// </summary>
        /// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
        /// <returns>The current instance of <see cref="AgentBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
        public AgentBuilder WithBodySprite(byte[] rawData)
        {
            Rect Area(int x, int y) => new Rect(x * 64f, y * 64f, 64f, 64f);

            bodySprite = new RogueSprite[]
            {
                RogueLibs.CreateCustomSprite(MetaData.Name + "Body" + "N", SpriteScope.Hair, rawData, Area(1, 0), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Body" + "NE", SpriteScope.Hair, rawData, Area(2, 0), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Body" + "E", SpriteScope.Hair, rawData, Area(2, 1), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Body" + "SE", SpriteScope.Hair, rawData, Area(2, 2), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Body" + "S", SpriteScope.Hair, rawData, Area(1, 2), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Body" + "SW", SpriteScope.Hair, rawData, Area(0, 2), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Body" + "W", SpriteScope.Hair, rawData, Area(0, 1), 64f),
                RogueLibs.CreateCustomSprite(MetaData.Name + "Body" + "NW", SpriteScope.Hair, rawData, Area(0, 0), 64f),
            };
            return this;
        }
    }
}
