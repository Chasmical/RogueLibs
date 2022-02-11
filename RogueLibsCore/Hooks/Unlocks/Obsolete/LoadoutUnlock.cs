using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a Loadout unlock.</para>
    /// </summary>
    [Obsolete("This class is not used in the game.")]
    public class LoadoutUnlock : UnlockWrapper
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="LoadoutUnlock"/> class without a name.</para>
        /// </summary>
        public LoadoutUnlock() : this(null, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="LoadoutUnlock"/> class without a name.</para>
        /// </summary>
        public LoadoutUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="LoadoutUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The unlock's name.</param>
        public LoadoutUnlock(string name) : this(name, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="LoadoutUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The unlock's name.</param>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public LoadoutUnlock(string name, bool unlockedFromStart) : base(name, "Loadout", unlockedFromStart) { }
        internal LoadoutUnlock(Unlock unlock) : base(unlock) { }

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
                bool? cur = gc?.sessionDataBig?.loadoutUnlocks?.Contains(Unlock);
                if (cur == true && !value) { gc.sessionDataBig.loadoutUnlocks.Remove(Unlock); Unlock.loadoutCount--; }
                else if (cur == false && value) { gc.sessionDataBig.loadoutUnlocks.Add(Unlock); Unlock.loadoutCount++; }
            }
        }
    }
}
