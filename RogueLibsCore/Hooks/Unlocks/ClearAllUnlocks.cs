using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	public class ClearAllMutatorsUnlock : MutatorUnlock
	{
		public ClearAllMutatorsUnlock() : base("ClearAll", true) { }
		public override bool IsAvailable { get; set; } = true;
		public override bool IsEnabled { get => false; set { } }

		public override void OnPushedButton()
		{
			if (IsUnlocked && gc.serverPlayer)
			{
				PlaySound("ClickButton");
				foreach (DisplayedUnlock du in Menu.Unlocks)
					if (du.IsEnabled != (du.IsEnabled = false)) du.UpdateButton();
				UpdateMenu();
			}
			else PlaySound("CantDo");
		}
	}
	public class ClearAllItemsUnlock : ItemUnlock
	{
		public ClearAllItemsUnlock() : base("ClearAllItems", true) { }
		public override bool IsAvailable { get; set; } = true;
		public override bool IsEnabled { get => false; set { } }

		public override void OnPushedButton()
		{
			if (IsUnlocked && gc.serverPlayer)
			{
				PlaySound("ClickButton");
				if (Menu.Type == UnlocksMenuType.RewardsMenu)
				{
					foreach (DisplayedUnlock du in Menu.Unlocks)
						if (du.IsEnabled != (du.IsEnabled = false)) du.UpdateButton();
				}
				else if (Menu.Type == UnlocksMenuType.CharacterCreation)
				{
					foreach (DisplayedUnlock du in Menu.Unlocks)
					{
						if (!(du is IUnlockInCC inCC)) continue;
						if (inCC.IsAddedToCC != (inCC.IsAddedToCC = false)) du.UpdateButton();
					}
				}
				UpdateMenu();
			}
			else PlaySound("CantDo");
		}
	}
	public class ClearAllTraitsUnlock : TraitUnlock
	{
		public ClearAllTraitsUnlock() : base("ClearAllTraits", true) { }
		public override bool IsAvailable { get; set; } = true;
		public override bool IsEnabled { get => false; set { } }

		public override void OnPushedButton()
		{
			if (IsUnlocked && gc.serverPlayer)
			{
				PlaySound("ClickButton");
				if (Menu.Type == UnlocksMenuType.TraitsMenu)
				{
					foreach (DisplayedUnlock du in Menu.Unlocks)
						if (du.IsEnabled != (du.IsEnabled = false)) du.UpdateButton();
				}
				else if (Menu.Type == UnlocksMenuType.CharacterCreation)
				{
					foreach (DisplayedUnlock du in Menu.Unlocks)
					{
						if (!(du is IUnlockInCC inCC)) continue;
						if (inCC.IsAddedToCC != (inCC.IsAddedToCC = false)) du.UpdateButton();
					}
				}
				UpdateMenu();
			}
			else PlaySound("CantDo");
		}
	}
}
