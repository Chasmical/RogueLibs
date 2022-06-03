namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents an extra unlock, that is used for achievements in the game.</para>
    /// </summary>
    public class ExtraUnlock : UnlockWrapper
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="ExtraUnlock"/> class without a name.</para>
        /// </summary>
        public ExtraUnlock() : this(null!, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="ExtraUnlock"/> class without a name.</para>
        /// </summary>
        public ExtraUnlock(bool unlockedFromStart) : this(null!, unlockedFromStart) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="ExtraUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The name of the unlock.</param>
        public ExtraUnlock(string name) : this(name, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="ExtraUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The name of the unlock.</param>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public ExtraUnlock(string name, bool unlockedFromStart) : base(name, UnlockTypes.Extra, unlockedFromStart) { }
        internal ExtraUnlock(Unlock unlock) : base(unlock) { }

        /// <inheritdoc/>
        public override bool IsEnabled
        {
            get => !Unlock.notActive;
            set => Unlock.notActive = !value;
        }
        /// <inheritdoc/>
        public override bool IsAvailable
        {
            get => !Unlock.unavailable;
            set
            {
                Unlock.unavailable = !value;
                // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
                bool? cur = gc?.sessionDataBig?.extraUnlocks?.Contains(Unlock);
                if (cur == true && !value) { gc!.sessionDataBig!.extraUnlocks!.Remove(Unlock); Unlock.extraCount--; }
                else if (cur == false && value) { gc!.sessionDataBig!.extraUnlocks!.Add(Unlock); Unlock.extraCount++; }
            }
        }
    }
}
