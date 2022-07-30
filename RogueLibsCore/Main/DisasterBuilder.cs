using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a <see cref="CustomDisaster"/> builder, that attaches additional information to the disaster.</para>
    /// </summary>
    public class DisasterBuilder
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="DisasterBuilder"/> class with the specified <paramref name="info"/>.</para>
        /// </summary>
        /// <param name="info">The disaster metadata to use.</param>
        public DisasterBuilder(DisasterInfo info) => Info = info;
        /// <summary>
        ///   <para>The used disaster metadata.</para>
        /// </summary>
        public DisasterInfo Info { get; }

        /// <summary>
        ///   <para>Gets the disaster's localizable name.</para>
        /// </summary>
        public CustomName? Name { get; private set; }
        /// <summary>
        ///   <para>Gets the disaster's localizable description.</para>
        /// </summary>
        public CustomName? Description { get; private set; }
        /// <summary>
        ///   <para>Gets the disaster's localizable first message.</para>
        /// </summary>
        public CustomName? Message1 { get; private set; }
        /// <summary>
        ///   <para>Gets the disaster's localizable second message.</para>
        /// </summary>
        public CustomName? Message2 { get; private set; }

        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the disaster's name.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="DisasterBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the disaster's name already exists.</exception>
        public DisasterBuilder WithName(CustomNameInfo info)
        {
            Name = RogueLibs.CreateCustomName($"LevelFeeling{Info.Name}_Name", NameTypes.Interface, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the disaster's description.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="DisasterBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the disaster's description already exists.</exception>
        public DisasterBuilder WithDescription(CustomNameInfo info)
        {
            Description = RogueLibs.CreateCustomName($"LevelFeeling{Info.Name}_Desc", NameTypes.Description, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the disaster's message. Can be repeated to create up to two messages.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="DisasterBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the disaster's message already exists.</exception>
        /// <exception cref="InvalidOperationException">The maximum of two localizable messages have already been created.</exception>
        public DisasterBuilder WithMessage(CustomNameInfo info)
        {
            if (Message1 is null) Message1 = RogueLibs.CreateCustomName($"LevelFeeling{Info.Name}1", NameTypes.Description, info);
            else if (Message2 is null) Message2 = RogueLibs.CreateCustomName($"LevelFeeling{Info.Name}2", NameTypes.Description, info);
            else throw new InvalidOperationException("You can't specify more than two messages for a custom disaster!");
            return this;
        }
        /// <summary>
        ///   <para>Creates a removal mutator for this disaster.</para>
        /// </summary>
        /// <returns>The current instance of <see cref="DisasterBuilder"/>, for chaining purposes.</returns>
        public DisasterBuilder WithRemovalMutator()
        {
            RogueLibs.CreateCustomUnlock(new MutatorUnlock("NoD_" + Info.Name, true));
            return this;
        }

    }
}
