using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Provides extension methods for the <see cref="Unlocks"/> class.</para>
    /// </summary>
    public static class UnlocksExtensions
    {
        /// <summary>
        ///   <para>Determines whether the unlocks should be unlockable anyway.</para>
        /// </summary>
        public static bool AllowUnlocksAnyway { get; set; }
        /// <summary>
        ///   <para>Forcefully unlocks an unlock with the specified <paramref name="unlockName"/> and <paramref name="unlockType"/>.</para>
        /// </summary>
        /// <param name="unlocks">The current unlocks.</param>
        /// <param name="unlockName">The name of the unlock to unlock.</param>
        /// <param name="unlockType">The type of the unlock to unlock.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unlocks"/> is <see langword="null"/>.</exception>
        public static void DoUnlockForced(this Unlocks unlocks, string unlockName, string unlockType)
        {
            if (unlocks is null) throw new ArgumentNullException(nameof(unlocks));

            bool prev = AllowUnlocksAnyway;
            AllowUnlocksAnyway = true;
            unlocks.DoUnlock(unlockName, unlockType);
            AllowUnlocksAnyway = prev;
            unlocks.SaveUnlockData(true);
        }
    }
}
