using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a menu that can display unlocks.</para>
    /// </summary>
    public abstract class UnlocksMenu
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="UnlocksMenu"/> class with the specified <paramref name="unlocks"/> list.</para>
        /// </summary>
        /// <param name="unlocks">The list of unlocks displayed in the menu.</param>
        protected UnlocksMenu(List<DisplayedUnlock> unlocks) => Unlocks = unlocks;

        /// <summary>
        ///   <para>Gets the menu's type.</para>
        /// </summary>
        public UnlocksMenuType Type { get; protected set; }
        /// <summary>
        ///   <para>Gets the menu's unlocks list.</para>
        /// </summary>
        public List<DisplayedUnlock> Unlocks { get; }
        /// <summary>
        ///   <para>When overriden in a derived class, gets the agent associated with the menu.</para>
        /// </summary>
        public abstract Agent Agent { get; }

        /// <summary>
        ///   <para>When overriden in a derived class, plays an audio clip with the specified <paramref name="clipName"/> in the menu.</para>
        /// </summary>
        /// <param name="clipName">The name of an audio clip to play.</param>
        public abstract void PlaySound(string clipName);
        /// <summary>
        ///   <para>When overriden in a derived class, updates the contents of the menu.</para>
        /// </summary>
        public abstract void UpdateMenu();

        public virtual bool ShowLockedUnlocks => Type == UnlocksMenuType.Loadouts
                                              || Type == UnlocksMenuType.NewLevelTraits
                                              || Type == UnlocksMenuType.AB_RemoveTrait
                                              || Type == UnlocksMenuType.AB_SwapTrait
                                              || Type == UnlocksMenuType.AB_UpgradeTrait
                                              || Type == UnlocksMenuType.TwitchRewards
                                              || Type == UnlocksMenuType.TwitchDisasters;
    }
}
