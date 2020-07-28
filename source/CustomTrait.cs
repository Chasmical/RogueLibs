using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game trait.</para>
	/// </summary>
	public class CustomTrait : CustomUnlock, IComparable<CustomTrait>
	{
		internal CustomTrait(string id, CustomName name, CustomName description) : base(id, name, description) { }

		/// <summary>
		///   <para>Compares this <see cref="CustomTrait"/> with <paramref name="another"/>.</para>
		/// </summary>
		public int CompareTo(CustomTrait another) => base.CompareTo(another);

		/// <summary>
		///   <para>Type of this <see cref="CustomUnlock"/> - "Trait".</para>
		/// </summary>
		public override string Type => "Trait";

		private bool isActive = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomTrait"/> is active and will be obtainable in-game. (Default: <see langword="true"/>)</para>
		/// </summary>
		public bool IsActive
		{
			get => unlock != null ? (isActive = !unlock.notActive) : isActive;
			set
			{
				if (unlock != null)
					unlock.notActive = !value;
				isActive = value;
			}
		}

		private bool available = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomTrait"/> will be accessible in the Traits Menu and in-game. (Default: <see langword="true"/>)</para>
		/// </summary>
		public override bool Available
		{
			get => unlock != null ? (available = !unlock.unavailable) : available;
			set
			{
				if (unlock != null)
				{
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.traitUnlocks, unlock, value);
					if (available && !value) Unlock.traitCount--;
					else if (!available && value) Unlock.traitCount++;
					unlock.unavailable = !value;
				}
				available = value;
			}
		}

		private bool availableInCharacterCreation = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomTrait"/> will be accessible in the Character Creation menu. (Default: <see langword="true"/>)</para>
		/// </summary>
		public bool AvailableInCharacterCreation
		{
			get => unlock != null ? (availableInCharacterCreation = !unlock.unavailable || unlock.onlyInCharacterCreation) : availableInCharacterCreation;
			set
			{
				if (unlock != null)
				{
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.traitUnlocksCharacterCreation, unlock, value);
					if (available && !value) Unlock.traitCountCharacterCreation--;
					else if (!available && value) Unlock.traitCountCharacterCreation++;
					unlock.onlyInCharacterCreation = !available && value;
				}
				availableInCharacterCreation = value;
			}
		}

		private int costInCharacterCreation = 1;
		/// <summary>
		///   <para>Determines the cost of this <see cref="CustomTrait"/> in the Character Creation menu, in points. (Default: 1)</para>
		/// </summary>
		public int CostInCharacterCreation
		{
			get => unlock != null ? (costInCharacterCreation = unlock.cost3) : costInCharacterCreation;
			set
			{
				if (unlock != null)
					unlock.cost3 = value;
				costInCharacterCreation = value;
			}
		}

		private bool canRemove = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomTrait"/> can be removed in the Augmentation Booth.</para>
		/// </summary>
		public bool CanRemove
		{
			get => unlock != null ? (canRemove = !unlock.cantLose) : canRemove;
			set
			{
				if (unlock != null)
					unlock.cantLose = !value;
				canRemove = value;
			}
		}
		private bool canSwap = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomTrait"/> can be swapped in the Augmentation Booth.</para>
		/// </summary>
		public bool CanSwap
		{
			get => unlock != null ? (canSwap = !unlock.cantSwap) : canSwap;
			set
			{
				if (unlock != null)
					unlock.cantSwap = !value;
				canSwap = value;
			}
		}

		private string upgrade = null;
		/// <summary>
		///   <para>Determines the upgraded version of this <see cref="CustomTrait"/>. Set to <see langword="null"/> if it's not upgradeable. (Default: <see langword="null"/>)</para>
		/// </summary>
		public string Upgrade
		{
			get => unlock != null ? (upgrade = unlock.upgrade) : upgrade;
			set
			{
				if (unlock != null)
				{
					unlock.upgrade = value;
					UpgradeCheck(upgrade);
					UpgradeCheck(Id);
					UpgradeCheck(value);
				}
				upgrade = value;
			}
		}

		internal bool isUpgrade = false;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomTrait"/> is an upgrade.</para>
		/// </summary>
		public bool IsUpgrade => unlock != null ? (isUpgrade = unlock.isUpgrade) : isUpgrade;

		private List<string> specialAbilities = new List<string>();
		/// <summary>
		///   <para>Determines the special abilities that this <see cref="CustomTrait"/> can be obtained with.</para>
		/// </summary>
		public List<string> SpecialAbilities
		{
			get => unlock != null ? (specialAbilities = unlock.specialAbilities) : specialAbilities;
			set
			{
				if (unlock != null)
					unlock.specialAbilities = value;
				specialAbilities = value;
			}
		}

		internal static void UpgradeCheck(string trait)
		{
			if (string.IsNullOrEmpty(trait)) return;
			List<Unlock> unlocks = GameController.gameController.sessionDataBig.unlocks;
			Unlock thisTrait = unlocks.Find(u => u.unlockName == trait);
			if (thisTrait == null) return;
			thisTrait.isUpgrade = false;
			foreach (Unlock unlock in unlocks)
			{
				if (unlock.unlockName == thisTrait.upgrade && !string.IsNullOrEmpty(thisTrait.upgrade))
					unlock.isUpgrade = true;
				if (unlock.upgrade == trait)
					thisTrait.isUpgrade = true;
			}
		}

		/// <summary>
		///   <para>Method that will be used in the <see cref="ScrollingMenu.PushedButton(ButtonHelper)"/> patch.</para>
		///   <para><see cref="ScrollingMenu"/> arg1 is the current instance of <see cref="ScrollingMenu"/>;<br/><see cref="ButtonHelper"/> arg2 is this trait's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> result determines whether the original RogueLibs patch should be executed.</para>
		/// </summary>
		public Func<ScrollingMenu, ButtonHelper, bool> ScrollingMenu_PushedButton { get; set; }
		/// <summary>
		///   <para>Method that will be used in the <see cref="CharacterCreation.PushedButton(ButtonHelper)"/> patch.</para>
		///   <para><see cref="CharacterCreation"/> arg1 is the current instance of <see cref="CharacterCreation"/>;<br/><see cref="ButtonHelper"/> arg2 is this trait's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> result determines whether the original RogueLibs patch should be executed.</para>
		/// </summary>
		public Func<CharacterCreation, ButtonHelper, bool> CharacterCreation_PushedButton { get; set; }

		/// <summary>
		///   <para>Event that is invoked when this trait is toggled on/off in the Traits Menu.</para>
		///   <para><see cref="ScrollingMenu"/> arg1 is the current instance of <see cref="ScrollingMenu"/>;<br/><see cref="ButtonHelper"/> arg2 is this trait's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> arg3 is the new state.</para>
		/// </summary>
		public event Action<ScrollingMenu, ButtonHelper, bool> OnToggledInTraitsMenu;
		/// <summary>
		///   <para>Event that is invoked when this trait is unlocked in the Traits Menu.</para>
		///   <para><see cref="ScrollingMenu"/> arg1 is the current instance of <see cref="ScrollingMenu"/>;<br/><see cref="ButtonHelper"/> arg2 is this trait's <see cref="ButtonHelper"/>.</para>
		/// </summary>
		public event Action<ScrollingMenu, ButtonHelper> OnUnlockedInTraitsMenu;

		internal void InvokeOnToggledEvent(ScrollingMenu sm, ButtonHelper bh, bool newState) => OnToggledInTraitsMenu?.Invoke(sm, bh, newState);
		internal void InvokeOnUnlockedEvent(ScrollingMenu sm, ButtonHelper bh) => OnUnlockedInTraitsMenu?.Invoke(sm, bh);

		/// <summary>
		///   <para>Event that is invoked when this trait is added/removed in the Character Creation menu.</para>
		///   <para><see cref="CharacterCreation"/> arg1 is the current instance of <see cref="CharacterCreation"/>;<br/><see cref="ButtonHelper"/> arg2 is this trait's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> arg3 is the new state.</para>
		/// </summary>
		public event Action<CharacterCreation, ButtonHelper, bool> OnToggledInCharacterCreation;
		/// <summary>
		///   <para>Event that is invoked when this trait is unlocked in the Character Creation menu.</para>
		///   <para><see cref="CharacterCreation"/> arg1 is the current instance of <see cref="CharacterCreation"/>;<br/><see cref="ButtonHelper"/> arg2 is this trait's <see cref="ButtonHelper"/>.</para>
		/// </summary>
		public event Action<CharacterCreation, ButtonHelper> OnUnlockedInCharacterCreation;

		internal void InvokeOnToggledEvent(CharacterCreation cc, ButtonHelper bh, bool newState) => OnToggledInCharacterCreation?.Invoke(cc, bh, newState);
		internal void InvokeOnUnlockedEvent(CharacterCreation cc, ButtonHelper bh) => OnUnlockedInCharacterCreation?.Invoke(cc, bh);

	}
}
