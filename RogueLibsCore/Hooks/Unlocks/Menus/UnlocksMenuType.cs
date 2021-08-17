using System;

namespace RogueLibsCore
{
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
}
