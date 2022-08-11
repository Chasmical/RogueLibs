namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Defines the type of a melee weapon attack.</para>
    /// </summary>
    public enum MeleeAttackType : byte
    {
        /// <summary>
        ///   <para>A stabbing, usually potentially piercing attack.<br/>Examples: Knife is the only weapon that uses this type.</para>
        /// </summary>
        Stab,
        /// <summary>
        ///   <para>A swinging attack.<br/>Examples: Baseball Bat, Sledgehammer, Wrench and basically any other weapon in the game.</para>
        /// </summary>
        Swing,
        /// <summary>
        ///   <para>A fist-based attack.<br/>Examples: Fist, Chloroform Hankie, Sticky Glove.</para>
        /// </summary>
        Fist,
        /// <summary>
        ///   <para>A claw attack. Pretty similar to <see cref="Fist"/>.<br/>Examples: Werewolf Claws are the only weapon that uses this type.</para>
        /// </summary>
        Claw,
    }
}