using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game trait.</para>
	/// </summary>
	public class CustomTrait : CustomUnlock, IComparable<CustomTrait>
	{
		internal CustomTrait(string id, CustomName name, CustomName description) : base(id, name, description) { }

		public int CompareTo(CustomTrait other) => base.CompareTo(other);

		public override string Type => "Trait";

		private bool isActive = true;
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

		private bool cantLose = false;
		public bool CantLose
		{
			get => unlock != null ? (cantLose = unlock.cantLose) : cantLose;
			set
			{
				if (unlock != null)
					unlock.cantLose = value;
				cantLose = value;
			}
		}
		private bool cantSwap = false;
		public bool CantSwap
		{
			get => unlock != null ? (cantSwap = unlock.cantSwap) : cantSwap;
			set
			{
				if (unlock != null)
					unlock.cantSwap = value;
				cantSwap = value;
			}
		}

		private string upgrade = null;
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
		public bool IsUpgrade => unlock != null ? (isUpgrade = unlock.isUpgrade) : isUpgrade;
		
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
	}
}
