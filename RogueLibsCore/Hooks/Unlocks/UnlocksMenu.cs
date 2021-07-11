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
	}
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
	/// <summary>
	///   <para>The <see cref="CharacterCreation"/> implementation of the <see cref="UnlocksMenu"/> class.</para>
	/// </summary>
	public class CustomCharacterCreation : UnlocksMenu
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="CustomCharacterCreation"/> class with the specified <paramref name="cc"/> and <paramref name="unlocks"/> list.</para>
		/// </summary>
		/// <param name="cc">The <see cref="CharacterCreation"/> instance.</param>
		/// <param name="unlocks">The list of unlocks displayed in the menu.</param>
		public CustomCharacterCreation(CharacterCreation cc, List<DisplayedUnlock> unlocks)
			: base(unlocks)
		{
			CC = cc;
			Type = UnlocksMenuType.CharacterCreation;
		}
		/// <summary>
		///   <para>Gets the <see cref="CharacterCreation"/> instance.</para>
		/// </summary>
		public CharacterCreation CC { get; }
		/// <inheritdoc/>
		public override Agent Agent => CC.agent;

		/// <inheritdoc/>
		public override void PlaySound(string clipName) => GameController.gameController.audioHandler.PlayMust(Agent, clipName);
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
	public class CustomLevelEditor : UnlocksMenu
	{
		public CustomLevelEditor(LevelEditor levelEditor, List<DisplayedUnlock> unlocks) : base(unlocks) => Editor = levelEditor;
		public LevelEditor Editor { get; }
		public override Agent Agent => GameController.gameController.playerAgent;

		public override void UpdateMenu() => throw new NotImplementedException();
	}
	*/
	/// <summary>
	///   <para>Represents an unlocks menu type.</para>
	/// </summary>
	public enum UnlocksMenuType
	{
		/// <summary>
		///   <para>An unknown menu type.</para>
		/// </summary>
		Unknown,

		/// <summary>
		///   <para>The Mutators Menu at the Home Base.</para>
		/// </summary>
		MutatorMenu,
		/// <summary>
		///   <para>The Rewards Menu at the Home Base.</para>
		/// </summary>
		RewardsMenu,
		/// <summary>
		///   <para>The Traits Menu at the Home Base.</para>
		/// </summary>
		TraitsMenu,

		/// <summary>
		///   <para>The Mutator Configs Menu at the Home Base.</para>
		/// </summary>
		MutatorConfigs,
		/// <summary>
		///   <para>The Reward Configs Menu at the Home Base.</para>
		/// </summary>
		RewardConfigs,
		/// <summary>
		///   <para>The Trait Configs Menu at the Home Base.</para>
		/// </summary>
		TraitConfigs,

		/// <summary>
		///   <para>The Floor Selection Menu at the Home Base.</para>
		/// </summary>
		FloorsMenu,
		/// <summary>
		///   <para>The New Level Trait Selection Menu.</para>
		/// </summary>
		NewLevelTraits,
		/// <summary>
		///   <para>The Item Teleporter Menu.</para>
		/// </summary>
		ItemTeleporter,
		/// <summary>
		///   <para>The Loadout Menu at the Home Base.</para>
		/// </summary>
		Loadouts,
		/// <summary>
		///   <para>The Twitch Rewards Menu.</para>
		/// </summary>
		TwitchRewards,
		/// <summary>
		///   <para>The Twitch Disasters Menu.</para>
		/// </summary>
		TwitchDisasters,

		/// <summary>
		///   <para>The Upgrade Trait Menu in the Augmentation Booth.</para>
		/// </summary>
		AB_UpgradeTrait,
		/// <summary>
		///   <para>The Remove Trait Menu in the Augmentation Booth.</para>
		/// </summary>
		AB_RemoveTrait,
		/// <summary>
		///   <para>The Swap Trait Menu in the Augmentation Booth.</para>
		/// </summary>
		AB_SwapTrait,

		/// <summary>
		///   <para>The Character Selection Menu.</para>
		/// </summary>
		[Obsolete("This value is no longer used in the game.")]
		CharacterSelect,
		/// <summary>
		///   <para>The Achievements Menu.</para>
		/// </summary>
		[Obsolete("This value is no longer used in the game.")]
		Achievements,

		/// <summary>
		///   <para>The Character Creation Menu.</para>
		/// </summary>
		CharacterCreation,
	}
	/// <summary>
	///   <para>Represents the unlock's button state.</para>
	/// </summary>
	public enum UnlockButtonState
	{
		/// <summary>
		///   <para>The normal state. Dark-blue button.</para>
		/// </summary>
		Normal,
		/// <summary>
		///   <para>The selected state. Cyan button.</para>
		/// </summary>
		Selected,
		/// <summary>
		///   <para>The purchasable state. Light-blue button.</para>
		/// </summary>
		Purchasable,
		/// <summary>
		///   <para>The locked state. Purplish red button.</para>
		/// </summary>
		Locked,
		/// <summary>
		///   <para>The disabled state. Gray button.</para>
		/// </summary>
		Disabled,
	}
}
