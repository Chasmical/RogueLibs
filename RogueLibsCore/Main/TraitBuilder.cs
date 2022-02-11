using System;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a <see cref="CustomTrait"/> builder, that attaches additional information to the trait.</para>
    /// </summary>
    public class TraitBuilder
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="TraitBuilder"/> class with the specified <paramref name="info"/>.</para>
        /// </summary>
        /// <param name="info">The trait metadata to use.</param>
        public TraitBuilder(TraitInfo info) => Info = info;
        /// <summary>
        ///   <para>The used trait metadata.</para>
        /// </summary>
        public TraitInfo Info { get; }

        /// <summary>
        ///   <para>Gets the trait's localizable name.</para>
        /// </summary>
        public CustomName Name { get; private set; }
        /// <summary>
        ///   <para>Gets the trait's localizable description.</para>
        /// </summary>
        public CustomName Description { get; private set; }
        /// <summary>
        ///   <para>Gets the trait's sprite.</para>
        /// </summary>
        public RogueSprite Sprite { get; private set; }
        /// <summary>
        ///   <para>Gets the trait's unlock.</para>
        /// </summary>
        public TraitUnlock Unlock { get; private set; }

        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the trait's name.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the trait's name already exists.</exception>
        public TraitBuilder WithName(CustomNameInfo info)
        {
            Name = RogueLibs.CreateCustomName(Info.Name, NameTypes.StatusEffect, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the trait's description.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the trait's description already exists.</exception>
        public TraitBuilder WithDescription(CustomNameInfo info)
        {
            Description = RogueLibs.CreateCustomName(Info.Name, NameTypes.Description, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the trait's sprite.</para>
        /// </summary>
        /// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
        /// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
        /// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
        public TraitBuilder WithSprite(byte[] rawData, float ppu = 64f)
        {
            Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, ppu);
            Info.sprite = Sprite;
            return this;
        }
        /// <summary>
        ///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the trait's sprite.</para>
        /// </summary>
        /// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
        /// <param name="region">The region of the texture for the sprite to use.</param>
        /// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
        /// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
        public TraitBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
        {
            Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, region, ppu);
            Info.sprite = Sprite;
            return this;
        }
        /// <summary>
        ///   <para>Creates a default <see cref="TraitUnlock"/> for the trait, that is unlocked by default.</para>
        /// </summary>
        /// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
        public TraitBuilder WithUnlock() => WithUnlock(new TraitUnlock(Info.Name, true));
        /// <summary>
        ///   <para>Creates the specified <paramref name="unlock"/> for the trait.</para>
        /// </summary>
        /// <param name="unlock">The unlock information to initialize.</param>
        /// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="unlock"/> is <see langword="null"/>.</exception>
        public TraitBuilder WithUnlock(TraitUnlock unlock)
        {
            if (unlock is null) throw new ArgumentNullException(nameof(unlock));
            unlock.Name = Info.Name;
            RogueLibs.CreateCustomUnlock(unlock);
            Unlock = unlock;
            return this;
        }
    }
}
