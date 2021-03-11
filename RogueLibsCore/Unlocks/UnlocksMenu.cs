using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Base class for unlocks menus.</para>
	/// </summary>
	public abstract class UnlocksMenu
	{
		/// <summary>
		///   <para>Initializes a new instance of the current type with the specified <paramref name="unlocks"/> list.</para>
		/// </summary>
		/// <param name="unlocks">Unlocks displayed in the menu.</param>
		protected UnlocksMenu(List<DisplayedUnlock> unlocks) => Unlocks = unlocks;

		/// <summary>
		///   <para>Gets the menu's type.</para>
		/// </summary>
		public UnlocksMenuType Type { get; protected set; }
		/// <summary>
		///   <para>Gets the unlocks displayed in the menu.</para>
		/// </summary>
		public List<DisplayedUnlock> Unlocks { get; }
		/// <summary>
		///   <para>Updates the menu.</para>
		/// </summary>
		public abstract void UpdateMenu();
		/// <summary>
		///   <para>Gets the agent, that this menu belongs to.</para>
		/// </summary>
		public abstract Agent Agent { get; }
	}
	/// <summary>
	///   <para><see cref="ScrollingMenu"/> unlocks menu wrapper.</para>
	/// </summary>
	public class CustomScrollingMenu : UnlocksMenu
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomScrollingMenu"/> with the specified <paramref name="menu"/> and <paramref name="unlocks"/>.</para>
		/// </summary>
		/// <param name="menu"><see cref="ScrollingMenu"/> that this unlocks menu is associated with.</param>
		/// <param name="unlocks">Unlocks displayed in the menu.</param>
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
				: type == "CharacterSelect" ? UnlocksMenuType.CharacterSelect
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
		}
		/// <summary>
		///   <para><see cref="ScrollingMenu"/> that this unlocks menu is associated with.</para>
		/// </summary>
		public ScrollingMenu Menu { get; }
		/// <inheritdoc/>
		public override Agent Agent => Menu.agent;

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
	/// <summary>
	///   <para><see cref="CharacterCreation"/> unlocks menu wrapper.</para>
	/// </summary>
	public class CustomCharacterCreation : UnlocksMenu
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomCharacterCreation"/> with the specified <paramref name="cc"/> and <paramref name="unlocks"/>.</para>
		/// </summary>
		/// <param name="cc"><see cref="CharacterCreation"/> that this unlocks menu is associated with.</param>
		/// <param name="unlocks">Unlocks displayed in the menu.</param>
		public CustomCharacterCreation(CharacterCreation cc, List<DisplayedUnlock> unlocks)
			: base(unlocks)
		{
			CC = cc;
			Type = UnlocksMenuType.CharacterCreation;
		}
		/// <summary>
		///   <para><see cref="CharacterCreation"/> that this unlocks menu is associated with.</para>
		/// </summary>
		public CharacterCreation CC { get; }
		/// <inheritdoc/>
		public override Agent Agent => CC.agent;

		/// <inheritdoc/>
		public override void UpdateMenu()
		{
			(CC.selectedSpace == "Items" ? CC.scrollerControllerItems
			: CC.selectedSpace == "Traits" ? CC.scrollerControllerTraits
			: CC.selectedSpace == "Abilities" ? CC.scrollerControllerAbilities
			: CC.selectedSpace == "BigQuest" ? CC.scrollerControllerBigQuests
			: CC.selectedSpace == "Load" ? CC.scrollerControllerLoad
			: null)?.myScroller.RefreshActiveCellViews();

			CC.CreatePointTallyText();
		}
	}
	/*
	/// <summary>
	///   <para><see cref="LevelEditor"/> unlocks menu wrapper.</para>
	/// </summary>
	public class CustomLevelEditor : UnlocksMenu
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomLevelEditor"/> with the specified <paramref name="levelEditor"/> and <paramref name="unlocks"/>.</para>
		/// </summary>
		/// <param name="levelEditor"><see cref="LevelEditor"/> that this unlocks menu is associated with.</param>
		/// <param name="unlocks">Unlocks displayed in the menu.</param>
		public CustomLevelEditor(LevelEditor levelEditor, List<DisplayedUnlock> unlocks) : base(unlocks) => Editor = levelEditor;
		/// <summary>
		///   <para><see cref="LevelEditor"/> that this unlocks menu is associated with.</para>
		/// </summary>
		public LevelEditor Editor { get; }
		/// <inheritdoc/>
		public override Agent Agent => GameController.gameController.playerAgent;

		/// <inheritdoc/>
		public override void UpdateMenu() => throw new NotImplementedException();
	}
	*/
	/// <summary>
	///   <para>Represents an unlocks menu type.</para>
	/// </summary>
	public enum UnlocksMenuType
	{
		/// <summary>
		///   <para>Unknown unlocks menu type.</para>
		/// </summary>
		Unknown,

		/// <summary>
		///   <para>Mutators Menu at Home Base.</para>
		/// </summary>
		MutatorMenu,
		/// <summary>
		///   <para>Rewards Menu at Home Base.</para>
		/// </summary>
		RewardsMenu,
		/// <summary>
		///   <para>Traits Menu at Home Base.</para>
		/// </summary>
		TraitsMenu,

		/// <summary>
		///   <para>Mutator Configs Menu at Home Base.</para>
		/// </summary>
		MutatorConfigs,
		/// <summary>
		///   <para>Reward Configs Menu at Home Base.</para>
		/// </summary>
		RewardConfigs,
		/// <summary>
		///   <para>Trait Configs Menu at Home Base.</para>
		/// </summary>
		TraitConfigs,

		/// <summary>
		///   <para>Floor Selection Menu at Home Base.</para>
		/// </summary>
		FloorsMenu,
		/// <summary>
		///   <para>New Level Traits menu.</para>
		/// </summary>
		NewLevelTraits,
		/// <summary>
		///   <para>Item Teleporter menu.</para>
		/// </summary>
		ItemTeleporter,
		/// <summary>
		///   <para>Loadouts menu at Home Base.</para>
		/// </summary>
		Loadouts,
		/// <summary>
		///   <para>Twitch Rewards menu.</para>
		/// </summary>
		TwitchRewards, // *
		/// <summary>
		///   <para>Twitch Disasters menu.</para>
		/// </summary>
		TwitchDisasters, // *

		/// <summary>
		///   <para>Upgrade Trait menu in the Augmentation Booth.</para>
		/// </summary>
		AB_UpgradeTrait,
		/// <summary>
		///   <para>Remove Trait menu in the Augmentation Booth.</para>
		/// </summary>
		AB_RemoveTrait,
		/// <summary>
		///   <para>Swap Trait menu in the Augmentation Booth.</para>
		/// </summary>
		AB_SwapTrait,

		/// <summary>
		///   <para>Unused menu.</para>
		/// </summary>
		CharacterSelect, // ?
		/// <summary>
		///   <para>Unused menu.</para>
		/// </summary>
		Achievements, // ?

		/// <summary>
		///   <para>Character Creation menu.</para>
		/// </summary>
		CharacterCreation
	}
	/// <summary>
	///   <para>Represents an unlock button's state.</para>
	/// </summary>
	public enum UnlockButtonState
	{
		/// <summary>
		///   <para>Normal, dark blue button.</para>
		/// </summary>
		Normal = 0,
		/// <summary>
		///   <para>Selected, cyan button.</para>
		/// </summary>
		Selected = 1,
		/// <summary>
		///   <para>Purchasable, light blue button.</para>
		/// </summary>
		Purchasable = 2,
		/// <summary>
		///   <para>Locked, purple button.</para>
		/// </summary>
		Locked = 3,
		/// <summary>
		///   <para>Disabled, gray button.</para>
		/// </summary>
		Disabled = 4
	}
}
