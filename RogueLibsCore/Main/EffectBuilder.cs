using System;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a <see cref="CustomEffect"/> builder, that attaches additional information to the effect.</para>
    /// </summary>
    public class EffectBuilder
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="EffectBuilder"/> class with the specified <paramref name="metadata"/>.</para>
        /// </summary>
        /// <param name="metadata">The effect metadata to use.</param>
        public EffectBuilder(CustomEffectMetadata metadata) => Metadata = metadata;
        /// <summary>
        ///   <para>The used effect metadata.</para>
        /// </summary>
        public CustomEffectMetadata Metadata { get; }

        /// <summary>
        ///   <para>Gets the effect's localizable name.</para>
        /// </summary>
        public CustomName? Name { get; private set; }
        /// <summary>
        ///   <para>Gets the effect's localizable description.</para>
        /// </summary>
        public CustomName? Description { get; private set; }
        /// <summary>
        ///   <para>Gets the effect's sprite.</para>
        /// </summary>
        public RogueSprite? Sprite { get; private set; }

        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the effect's name.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="EffectBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the effect's name already exists.</exception>
        public EffectBuilder WithName(CustomNameInfo info)
        {
            Name = RogueLibs.CreateCustomName(Metadata.Name, NameTypes.StatusEffect, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the effect's description.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="EffectBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the effect's description already exists.</exception>
        public EffectBuilder WithDescription(CustomNameInfo info)
        {
            Description = RogueLibs.CreateCustomName(Metadata.Name, NameTypes.Description, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the effect's sprite.</para>
        /// </summary>
        /// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
        /// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
        /// <returns>The current instance of <see cref="EffectBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
        public EffectBuilder WithSprite(byte[] rawData, float ppu = 64f)
        {
            Sprite = RogueLibs.CreateCustomSprite(Metadata.Name, SpriteScope.Extra, rawData, ppu);
            Metadata.sprite = Sprite;
            return this;
        }
        /// <summary>
        ///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the effect's sprite.</para>
        /// </summary>
        /// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
        /// <param name="region">The region of the texture for the sprite to use.</param>
        /// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
        /// <returns>The current instance of <see cref="EffectBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
        public EffectBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
        {
            Sprite = RogueLibs.CreateCustomSprite(Metadata.Name, SpriteScope.Extra, rawData, region, ppu);
            Metadata.sprite = Sprite;
            return this;
        }
    }
}
