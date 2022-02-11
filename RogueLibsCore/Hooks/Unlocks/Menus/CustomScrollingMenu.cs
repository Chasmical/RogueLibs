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
            Type = type == "Challenges" ? UnlocksMenuType.MutatorMenu
                : type == "Floors" ? UnlocksMenuType.FloorsMenu
                : type == "Traits" ? UnlocksMenuType.NewLevelTraits
                : type == "Items" ? UnlocksMenuType.RewardsMenu
                : type == "FreeItems" ? UnlocksMenuType.ItemTeleporter
#pragma warning disable CS0618 // Type or member is obsolete
                : type == "CharacterSelect" ? UnlocksMenuType.CharacterSelect
#pragma warning restore CS0618 // Type or member is obsolete
                : type == "Loadouts" ? UnlocksMenuType.Loadouts
                : type == "TraitUnlocks" ? UnlocksMenuType.TraitsMenu
                : type == "Rewards" ? UnlocksMenuType.TwitchRewards
                : type == "LevelFeelings" ? UnlocksMenuType.TwitchDisasters
                : type == "UpgradeTrait" ? UnlocksMenuType.AB_UpgradeTrait
                : type == "RemoveTrait" ? UnlocksMenuType.AB_RemoveTrait
                : type == "ChangeTraitRandom" ? UnlocksMenuType.AB_SwapTrait
                : type == "RewardConfigs" ? UnlocksMenuType.RewardConfigs
                : type == "TraitConfigs" ? UnlocksMenuType.TraitConfigs
                : type == "MutatorConfigs" ? UnlocksMenuType.MutatorConfigs
                : UnlocksMenuType.Unknown;
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
            if (Type == UnlocksMenuType.RewardsMenu || Type == UnlocksMenuType.TraitsMenu)
                Menu.UpdateActiveCount();
            if (Type == UnlocksMenuType.MutatorMenu || Type == UnlocksMenuType.RewardsMenu || Type == UnlocksMenuType.TraitsMenu)
                Menu.UpdateOtherVisibleMenus(Menu.menuType);
            try { Menu.scrollerController.myScroller.RefreshActiveCellViews(); } catch { }
        }
    }
}
