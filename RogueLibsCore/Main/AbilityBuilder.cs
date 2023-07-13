using System;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a <see cref="CustomAbility"/> builder, that attaches additional information to the ability.</para>
    /// </summary>
    public class AbilityBuilder
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="ItemBuilder"/> class with the specified <paramref name="metadata"/>.</para>
        /// </summary>
        /// <param name="metadata">The item metadata to use.</param>
        public AbilityBuilder(CustomItemMetadata metadata) => Metadata = metadata;
        /// <summary>
        ///   <para>The used item metadata.</para>
        /// </summary>
        public CustomItemMetadata Metadata { get; }

        /// <summary>
        ///   <para>Gets the ability's localizable name.</para>
        /// </summary>
        public CustomName? Name { get; private set; }
        /// <summary>
        ///   <para>Gets the ability's localizable description.</para>
        /// </summary>
        public CustomName? Description { get; private set; }
        /// <summary>
        ///   <para>Gets the ability's sprite.</para>
        /// </summary>
        public RogueSprite? Sprite { get; private set; }
        /// <summary>
        ///   <para>Gets the ability's unlock.</para>
        /// </summary>
        public AbilityUnlock? Unlock { get; private set; }

        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the ability's name.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the ability's name already exists.</exception>
        public AbilityBuilder WithName(CustomNameInfo info)
        {
            Name = RogueLibs.CreateCustomName(Metadata.Name, NameTypes.Item, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the ability's description.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the ability's description already exists.</exception>
        public AbilityBuilder WithDescription(CustomNameInfo info)
        {
            Description = RogueLibs.CreateCustomName(Metadata.Name, NameTypes.Description, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the ability's sprite.</para>
        /// </summary>
        /// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
        /// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
        /// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
        public AbilityBuilder WithSprite(byte[] rawData, float ppu = 64f)
        {
            Sprite = RogueLibs.CreateCustomSprite(Metadata.Name, SpriteScope.Items, rawData, ppu);
            return this;
        }
        /// <summary>
        ///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the ability's sprite.</para>
        /// </summary>
        /// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
        /// <param name="region">The region of the texture for the sprite to use.</param>
        /// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
        /// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
        public AbilityBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
        {
            Sprite = RogueLibs.CreateCustomSprite(Metadata.Name, SpriteScope.Items, rawData, region, ppu);
            return this;
        }
        /// <summary>
        ///   <para>Creates a default <see cref="AbilityUnlock"/> for the ability, that is unlocked by default.</para>
        /// </summary>
        /// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
        public AbilityBuilder WithUnlock() => WithUnlock(new AbilityUnlock(Metadata.Name, true));
        /// <summary>
        ///   <para>Creates the specified <paramref name="unlock"/> for the ability.</para>
        /// </summary>
        /// <param name="unlock">The unlock information to initialize.</param>
        /// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="unlock"/> is <see langword="null"/>.</exception>
        public AbilityBuilder WithUnlock(AbilityUnlock unlock)
        {
            if (unlock is null) throw new ArgumentNullException(nameof(unlock));
            unlock.Unlock.unlockName = Metadata.Name;
            RogueLibs.CreateCustomUnlock(unlock);
            Unlock = unlock;
            return this;
        }
    }
}
