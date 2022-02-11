using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a Home Base unlock.</para>
    /// </summary>
    [Obsolete("This class is not used in the game.")]
    public class HomeBaseUnlock : UnlockWrapper
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="HomeBaseUnlock"/> class without a name.</para>
        /// </summary>
        public HomeBaseUnlock() : this(null, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="HomeBaseUnlock"/> class without a name.</para>
        /// </summary>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public HomeBaseUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="HomeBaseUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The unlock's name.</param>
        public HomeBaseUnlock(string name) : this(name, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="HomeBaseUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The unlock's name.</param>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public HomeBaseUnlock(string name, bool unlockedFromStart) : base(name, "HomeBase", unlockedFromStart) { }
        internal HomeBaseUnlock(Unlock unlock) : base(unlock) { }

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
                bool? cur = gc?.sessionDataBig?.homeBaseUnlocks?.Contains(Unlock);
                if (cur == true && !value) { gc.sessionDataBig.homeBaseUnlocks.Remove(Unlock); Unlock.homeBaseCount--; }
                else if (cur == false && value) { gc.sessionDataBig.homeBaseUnlocks.Add(Unlock); Unlock.homeBaseCount++; }
            }
        }
    }
}
