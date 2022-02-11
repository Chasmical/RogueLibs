using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a <see cref="UnlockWrapper"/> builder, that attaches additional information to the unlock.</para>
    /// </summary>
    public class UnlockBuilder
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="UnlockBuilder"/> class with the specified <paramref name="unlock"/>.</para>
        /// </summary>
        /// <param name="unlock">The unlock wrapper to use.</param>
        public UnlockBuilder(UnlockWrapper unlock) => Unlock = unlock;
        /// <summary>
        ///   <para>The used unlock wrapper.</para>
        /// </summary>
        public UnlockWrapper Unlock { get; }

        /// <summary>
        ///   <para>Gets the localizable name of the unlock.</para>
        /// </summary>
        public CustomName? Name { get; private set; }
        /// <summary>
        ///   <para>Gets the localizable description of the unlock.</para>
        /// </summary>
        public CustomName? Description { get; private set; }

        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the name of the unlock.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="UnlockBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the name of the unlock already exists.</exception>
        public UnlockBuilder WithName(CustomNameInfo info)
        {
            Name = RogueLibs.CreateCustomName(Unlock.Name, Unlock.Unlock.unlockNameType, info);
            return this;
        }
        /// <summary>
        ///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the description of the unlock.</para>
        /// </summary>
        /// <param name="info">The localization data to initialize the localizable string with.</param>
        /// <returns>The current instance of <see cref="UnlockBuilder"/>, for chaining purposes.</returns>
        /// <exception cref="ArgumentException">A localizable string that acts as the description of the unlock already exists.</exception>
        public UnlockBuilder WithDescription(CustomNameInfo info)
        {
            Description = RogueLibs.CreateCustomName(Unlock is MutatorUnlock or BigQuestUnlock ? "D_" + Unlock.Name : Unlock.Name,
                Unlock is BigQuestUnlock ? NameTypes.Unlock : Unlock.Unlock.unlockDescriptionType, info);
            return this;
        }
    }
}
