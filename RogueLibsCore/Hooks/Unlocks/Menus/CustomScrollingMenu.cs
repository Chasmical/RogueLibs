using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The <see cref="ScrollingMenu"/> implementation of the <see cref="UnlocksMenu"/> class.</para>
    /// </summary>
    public class CustomScrollingMenu : UnlocksMenu
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomScrollingMenu"/> class with the specified <paramref name="menu"/> and <paramref name="unlocks"/> list.</para>
        /// </summary>
        /// <param name="menu">The <see cref="ScrollingMenu"/> instance.</param>
        /// <param name="unlocks">The list of unlocks displayed in the menu.</param>
        public CustomScrollingMenu(ScrollingMenu menu, List<DisplayedUnlock> unlocks)
            : base(unlocks)
        {
            Menu = menu;
            string type = menu.menuType;
            Type = type switch
            {
                "Challenges" => UnlocksMenuType.MutatorMenu,
                "Floors" => UnlocksMenuType.FloorsMenu,
                "Traits" => UnlocksMenuType.NewLevelTraits,
                "Items" => UnlocksMenuType.RewardsMenu,
                "FreeItems" => UnlocksMenuType.ItemTeleporter,
#pragma warning disable CS0618
                "CharacterSelect" => UnlocksMenuType.CharacterSelect,
#pragma warning restore CS0618
                "Loadouts" => UnlocksMenuType.Loadouts,
                "TraitUnlocks" => UnlocksMenuType.TraitsMenu,
                "Rewards" => UnlocksMenuType.TwitchRewards,
                "LevelFeelings" => UnlocksMenuType.TwitchDisasters,
                "UpgradeTrait" => UnlocksMenuType.AB_UpgradeTrait,
                "RemoveTrait" => UnlocksMenuType.AB_RemoveTrait,
                "ChangeTraitRandom" => UnlocksMenuType.AB_SwapTrait,
                "RewardConfigs" => UnlocksMenuType.RewardConfigs,
                "TraitConfigs" => UnlocksMenuType.TraitConfigs,
                "MutatorConfigs" => UnlocksMenuType.MutatorConfigs,
                _ => UnlocksMenuType.Unknown,
            };
            if (Type == UnlocksMenuType.Unknown)
                RogueFramework.LogWarning($"Unknown ScrollingMenu type: \"{type}\"!");
        }
        /// <summary>
        ///   <para>Gets the <see cref="ScrollingMenu"/> instance.</para>
        /// </summary>
        public ScrollingMenu Menu { get; }
        /// <inheritdoc/>
        public override Agent Agent => Menu.agent;

        /// <inheritdoc/>
        public override void PlaySound(string clipName) => GameController.gameController.audioHandler.Play(Agent, clipName);
        /// <inheritdoc/>
        public override void UpdateMenu()
        {
            if (Type == UnlocksMenuType.MutatorMenu)
            {
                GameController gc = GameController.gameController;
                gc.sessionDataBig.challenges = gc.challenges;
                gc.sessionDataBig.originalChallenges = gc.originalChallenges;
                gc.SetDailyRunText();
            }
            if (Type is UnlocksMenuType.RewardsMenu or UnlocksMenuType.TraitsMenu)
                Menu.UpdateActiveCount();
            if (Type is UnlocksMenuType.MutatorMenu or UnlocksMenuType.RewardsMenu or UnlocksMenuType.TraitsMenu)
                Menu.UpdateOtherVisibleMenus(Menu.menuType);
            try { Menu.scrollerController.myScroller.RefreshActiveCellViews(); }
            catch { /* I have no idea why it's suppressed */ }
        }
    }
}
