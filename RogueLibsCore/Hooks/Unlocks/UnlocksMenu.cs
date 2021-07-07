using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	public abstract class UnlocksMenu
	{
		protected UnlocksMenu(List<DisplayedUnlock> unlocks) => Unlocks = unlocks;

		public UnlocksMenuType Type { get; protected set; }
		public List<DisplayedUnlock> Unlocks { get; }
		public abstract Agent Agent { get; }

		public abstract void PlaySound(string clipName);
		public abstract void UpdateMenu();
	}
	public class CustomScrollingMenu : UnlocksMenu
	{
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
		public ScrollingMenu Menu { get; }
		public override Agent Agent => Menu.agent;

		public override void PlaySound(string clipName) => GameController.gameController.audioHandler.Play(Agent, clipName);
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
	public class CustomCharacterCreation : UnlocksMenu
	{
		public CustomCharacterCreation(CharacterCreation cc, List<DisplayedUnlock> unlocks)
			: base(unlocks)
		{
			CC = cc;
			Type = UnlocksMenuType.CharacterCreation;
		}
		public CharacterCreation CC { get; }
		public override Agent Agent => CC.agent;

		public override void PlaySound(string clipName) => GameController.gameController.audioHandler.PlayMust(Agent, clipName);
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
	public enum UnlocksMenuType
	{
		Unknown,

		MutatorMenu,
		RewardsMenu,
		TraitsMenu,

		MutatorConfigs,
		RewardConfigs,
		TraitConfigs,

		FloorsMenu,
		NewLevelTraits,
		ItemTeleporter,
		Loadouts,
		TwitchRewards, // *
		TwitchDisasters, // *

		AB_UpgradeTrait,
		AB_RemoveTrait,
		AB_SwapTrait,

		CharacterSelect, // ?
		Achievements, // ?

		CharacterCreation
	}
	public enum UnlockButtonState
	{
		Normal = 0,
		Selected = 1,
		Purchasable = 2,
		Locked = 3,
		Disabled = 4
	}
}
