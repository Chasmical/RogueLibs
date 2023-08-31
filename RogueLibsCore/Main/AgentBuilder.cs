using RogueLibsCore;
using System;
using System.Collections.Generic;
using UnityEngine;
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
        ///   <para>Initializes a new instance of the <see cref="ItemBuilder"/> class with the specified <paramref name="info"/>.</para>
        /// </summary>
        /// <param name="info">The item metadata to use.</param>
        public AgentBuilder(AgentInfo info) => Info = info;
        /// <summary>
        ///   <para>The used item metadata.</para>
        /// </summary>
        public AgentInfo Info { get; }
        /// <summary>
        ///   <para>Gets the item's localizable name.</para>
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
        ///   <para>Gets the agent's animated head prite.</para>
        /// </summary>
        public RogueSprite[][]? animatedHeadSprite { get; private set; }
        /// <summary>
        ///   <para>Gets the agent's animated body sprite.</para>
        /// </summary>
        public RogueSprite[][]? animatedBodySprite { get; private set; }
        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the agent's name.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="AgentBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the agent's name already exists.</exception>
        public AgentBuilder WithName(CustomNameInfo info)
        {
            Name = RogueLibs.CreateCustomName(Info.Name, NameTypes.Agent, info);
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
            Rect Area(int x, int y) => new Rect(x * rectSize, y * rectSize, rectSize, rectSize);

            headSprite = new RogueSprite[]
            {
                RogueLibs.CreateCustomSprite(Info.Name + "N", SpriteScope.Hair, rawData, Area(1, 0), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "NE", SpriteScope.Hair, rawData, Area(2, 0), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "E", SpriteScope.Hair, rawData, Area(2, 1), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "SE", SpriteScope.Hair, rawData, Area(2, 2), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "S", SpriteScope.Hair, rawData, Area(1, 2), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "SW", SpriteScope.Hair, rawData, Area(0, 2), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "W", SpriteScope.Hair, rawData, Area(0, 1), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "NW", SpriteScope.Hair, rawData, Area(0, 0), 64f),
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
            Rect Area(int x, int y) => new Rect(x * rectSize, y * rectSize, rectSize, rectSize);

            bodySprite = new RogueSprite[]
            {
                RogueLibs.CreateCustomSprite(Info.Name + "N", SpriteScope.Hair, rawData, Area(1, 0), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "NE", SpriteScope.Hair, rawData, Area(2, 0), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "E", SpriteScope.Hair, rawData, Area(2, 1), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "SE", SpriteScope.Hair, rawData, Area(2, 2), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "S", SpriteScope.Hair, rawData, Area(1, 2), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "SW", SpriteScope.Hair, rawData, Area(0, 2), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "W", SpriteScope.Hair, rawData, Area(0, 1), 64f),
                RogueLibs.CreateCustomSprite(Info.Name + "NW", SpriteScope.Hair, rawData, Area(0, 0), 64f),
            };
            return this;
        }
        /// <summary>
        ///   <para>Creates a array of arrays <see cref="RogueSprite"/> with a texture from <paramref name="spriteNames"/> to act as the agent's animated head sprites.</para>
        /// </summary>
        /// <param name="animationFrames">The count of frames (count of arrays) used for animation.</param>
        /// <returns>The current instance of <see cref="AgentBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="animationFrames"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="spriteNames"/> is <see langword="null"/>.</exception>
        public AgentBuilder WithAnimatedHeadSprite(int animationFrames, string spriteNames)
        {
            List<RogueSprite[]> animation = new();

            for (int i = 0; i < animationFrames; i++)
            {
                Rect Area(int x, int y) => new Rect(x * rectSize, y * rectSize, rectSize, rectSize);

                RogueSprite[] animationFrame = new RogueSprite[]
                {
                RogueLibs.CreateCustomSprite(spriteNames + i + "N", SpriteScope.Hair, rawData, Area(1, 0), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "NE", SpriteScope.Hair, rawData, Area(2, 0), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "E", SpriteScope.Hair, rawData, Area(2, 1), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "SE", SpriteScope.Hair, rawData, Area(2, 2), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "S", SpriteScope.Hair, rawData, Area(1, 2), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "SW", SpriteScope.Hair, rawData, Area(0, 2), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "W", SpriteScope.Hair, rawData, Area(0, 1), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "NW", SpriteScope.Hair, rawData, Area(0, 0), 64f),
                };
                animation.Add(animationFrame);
            }
            animatedHeadSprite = animation.ToArray();
            return this;
        }
        /// <summary>
        ///   <para>Creates a array of arrays <see cref="RogueSprite"/> with a texture from <paramref name="spriteNames"/> to act as the agent's animated body sprites.</para>
        /// </summary>
        /// <param name="animationFrames">The count of frames (count of arrays) used for animation.</param>
        /// <returns>The current instance of <see cref="AgentBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="animationFrames"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="spriteNames"/> is <see langword="null"/>.</exception>
        public AgentBuilder WithAnimatedBodySprite(int animationFrames, string spriteNames)
        {
            List<RogueSprite[]> animation = new();

            for (int i = 0; i < animationFrames; i++)
            {
                Rect Area(int x, int y) => new Rect(x * rectSize, y * rectSize, rectSize, rectSize);

                RogueSprite[] animationFrame = new RogueSprite[]
                {
                RogueLibs.CreateCustomSprite(spriteNames + i + "N", SpriteScope.Hair, rawData, Area(1, 0), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "NE", SpriteScope.Hair, rawData, Area(2, 0), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "E", SpriteScope.Hair, rawData, Area(2, 1), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "SE", SpriteScope.Hair, rawData, Area(2, 2), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "S", SpriteScope.Hair, rawData, Area(1, 2), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "SW", SpriteScope.Hair, rawData, Area(0, 2), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "W", SpriteScope.Hair, rawData, Area(0, 1), 64f),
                RogueLibs.CreateCustomSprite(spriteNames + i + "NW", SpriteScope.Hair, rawData, Area(0, 0), 64f),
                };
                animation.Add(animationFrame);
            }
            animatedBodySprite = animation.ToArray();
            return this;
        }
    }
}