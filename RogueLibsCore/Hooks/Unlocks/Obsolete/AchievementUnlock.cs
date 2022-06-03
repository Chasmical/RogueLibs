using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents an achievement unlock.</para>
    /// </summary>
    [Obsolete("This class is not used in the game. Use ExtraUnlock instead.")]
    public class AchievementUnlock : DisplayedUnlock
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AchievementUnlock"/> class without a name.</para>
        /// </summary>
        public AchievementUnlock() : this(null!, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AchievementUnlock"/> class without a name.</para>
        /// </summary>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public AchievementUnlock(bool unlockedFromStart) : this(null!, unlockedFromStart) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AchievementUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The name of the unlock.</param>
        public AchievementUnlock(string name) : this(name, false) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AchievementUnlock"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The name of the unlock.</param>
        /// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
        public AchievementUnlock(string name, bool unlockedFromStart) : base(name, "Achievement", unlockedFromStart) { }
        internal AchievementUnlock(Unlock unlock) : base(unlock) { }

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
                bool? cur = gc?.sessionDataBig?.achievementUnlocks?.Contains(Unlock);
                if (cur == true && !value) { gc!.sessionDataBig!.achievementUnlocks!.Remove(Unlock); Unlock.achievementCount--; }
                else if (cur == false && value) { gc!.sessionDataBig!.achievementUnlocks!.Add(Unlock); Unlock.achievementCount++; }
            }
        }

        /// <inheritdoc/>
        public override void OnPushedButton() => UpdateMenu();
    }
}
