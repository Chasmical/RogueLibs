using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	public class ItemUnlock : DisplayedUnlock, IUnlockInCC
	{
		public ItemUnlock() : this(null, false) { }
		public ItemUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
		public ItemUnlock(string name) : this(name, false) { }
		public ItemUnlock(string name, bool unlockedFromStart)
			: base(name, "Item", unlockedFromStart)
		{
			IsAvailableInCC = true;
			IsAvailableInItemTeleporter = true;
			CharacterCreationCost = 1;
			LoadoutCost = 1;
		}
		internal ItemUnlock(Unlock unlock) : base(unlock) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public bool IsAddedToCC
		{
			get => ((CustomCharacterCreation)Menu).CC.itemsChosen.Contains(Unlock);
			set
			{
				List<Unlock> list = ((CustomCharacterCreation)Menu).CC.itemsChosen;
				bool cur = list.Contains(Unlock);
				if (cur && !value) list.Remove(Unlock);
				else if (!cur && value) list.Add(Unlock);
			}
		}
		public bool IsSelectedLoadout
		{
			get => GetMyLoadouts().Contains(Name);
			set
			{
				List<string> myLoadouts = GetMyLoadouts();
				bool cur = myLoadouts.Contains(Name);
				if (cur && !value) myLoadouts.Remove(Name);
				else if (!cur && value) myLoadouts.Add(Name);
			}
		}

		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.itemUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.itemUnlocks.Remove(Unlock); Unlock.itemCount--; }
				else if (cur == false && value) { gc.sessionDataBig.itemUnlocks.Add(Unlock); Unlock.itemCount++; }
			}
		}
		public bool IsAvailableInCC
		{
			get => Unlock.onlyInCharacterCreation;
			set
			{
				Unlock.onlyInCharacterCreation = value;
				bool? cur = gc?.sessionDataBig?.itemUnlocksCharacterCreation?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.itemUnlocksCharacterCreation.Remove(Unlock); Unlock.itemCountCharacterCreation--; }
				else if (cur == false && value) { gc.sessionDataBig.itemUnlocksCharacterCreation.Add(Unlock); Unlock.itemCountCharacterCreation++; }
			}
		}
		public bool IsAvailableInItemTeleporter
		{
			get => Unlock.freeItem;
			set
			{
				Unlock.freeItem = value;
				bool? cur = gc?.sessionDataBig?.freeItemUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.freeItemUnlocks.Remove(Unlock); Unlock.itemCountFree--; }
				else if (cur == false && value) { gc.sessionDataBig.freeItemUnlocks.Add(Unlock); Unlock.itemCountFree++; }
			}
		}

		private List<string> GetMyLoadouts()
			=> Menu.Agent.isPlayer is 1 ? gc.sessionDataBig.loadouts1
			: Menu.Agent.isPlayer is 2 ? gc.sessionDataBig.loadouts2
			: Menu.Agent.isPlayer is 3 ? gc.sessionDataBig.loadouts3
			: gc.sessionDataBig.loadouts4;

		public override void UpdateButton()
		{
			if (Menu.Type == UnlocksMenuType.RewardsMenu)
				UpdateButton(IsEnabled, UnlockButtonState.Normal, UnlockButtonState.Disabled);
			else if (Menu.Type == UnlocksMenuType.ItemTeleporter)
				UpdateButton(false);
			else if (Menu.Type == UnlocksMenuType.Loadouts)
			{
				UpdateButton(IsSelectedLoadout);
				InvItem invItem = new InvItem { invItemName = Name };
				invItem.SetupDetails(false);
				if (invItem.rewardCount != 1 && !invItem.isArmor && !invItem.isArmorHead && invItem.itemType != "WeaponMelee")
					Text += $" ({invItem.rewardCount})";
				Text += $" - ${LoadoutCost}";
			}
			else if (Menu.Type == UnlocksMenuType.CharacterCreation)
				UpdateButton(IsAddedToCC);
		}
		public override void OnPushedButton()
		{
			if (IsUnlocked)
			{
				if (Menu.Type == UnlocksMenuType.RewardsMenu)
				{
					ScrollingMenu menu = ((CustomScrollingMenu)Menu).Menu;
					if (IsEnabled && menu.activeRewardCount <= menu.minRewards)
					{
						PlaySound("CantDo");
						menu.ActiveCountFlash();
					}
					else
					{
						PlaySound("ClickButton");
						IsEnabled = !IsEnabled;
						gc.unlocks.SaveUnlockData(true);
						UpdateButton();
						UpdateMenu();
					}
				}
				else if (Menu.Type == UnlocksMenuType.ItemTeleporter)
				{
					PlaySound("UseItemTeleporter");
					InvItem invItem = new InvItem() { invItemName = Name };
					invItem.SetupDetails(false);
					invItem.invItemCount = invItem.initCount;
					Menu.Agent.inventory.DontPlayPickupSounds(true);
					Menu.Agent.inventory.AddItemOrDrop(invItem);
					Menu.Agent.inventory.DontPlayPickupSounds(false);
					if (invItem.invItemName == "BombMaker" && !Menu.Agent.inventory.HasItem("BombTrigger"))
					{
						invItem = new InvItem() { invItemName = "BombTrigger" };
						invItem.SetupDetails(false);
						invItem.invItemCount = invItem.initCount;
						Menu.Agent.inventory.DontPlayPickupSounds(true);
						Menu.Agent.inventory.AddItemOrDrop(invItem);
						Menu.Agent.inventory.DontPlayPickupSounds(false);
					}
				}
				else if (Menu.Type == UnlocksMenuType.Loadouts)
				{
					if (IsSelectedLoadout)
					{
						PlaySound("BuyItem");
						gc.sessionDataBig.loadoutNuggetsSpent = 0;
						IsSelectedLoadout = false;
						gc.unlocks.AddNuggets(LoadoutCost);
						UpdateButton();
						UpdateMenu();
					}
					else
					{
						ItemUnlock selected = (ItemUnlock)Menu.Unlocks.Find(u => u is ItemUnlock item && item.IsSelectedLoadout);
						int availableNuggets = gc.sessionDataBig.nuggets;
						if (selected != null) availableNuggets += selected.LoadoutCost;
						if (LoadoutCost <= availableNuggets)
						{
							if (selected != null)
							{
								gc.sessionDataBig.nuggets += selected.LoadoutCost;
								selected.IsSelectedLoadout = false;
								selected.UpdateButton();
							}
							gc.sessionDataBig.loadoutNuggetsSpent = LoadoutCost;
							IsSelectedLoadout = true;
							gc.unlocks.SubtractNuggets(LoadoutCost);
							PlaySound("BuyItem");
							UpdateButton();
							UpdateMenu();
						}
						else PlaySound("CantDo");
					}
				}
				else if (Menu.Type == UnlocksMenuType.CharacterCreation)
				{
					PlaySound("ClickButton");
					if (IsAddedToCC = !IsAddedToCC)
						foreach (DisplayedUnlock du in GetCancellations())
							((IUnlockInCC)du).IsAddedToCC = false;
					UpdateButton();
					UpdateMenu();
				}
			}
			else if (Unlock.nowAvailable && UnlockCost <= gc.sessionDataBig.nuggets)
			{
				PlaySound("BuyUnlock");
				gc.unlocks.SubtractNuggets(UnlockCost);
				gc.unlocks.DoUnlockForced(Name, Type);
				UpdateAllUnlocks();
				UpdateMenu();
			}
			else PlaySound("CantDo");
		}

		public override Sprite GetImage() => (IsUnlocked || Unlock.nowAvailable)
			&& GameResources.gameResources.itemDic.TryGetValue(Name, out Sprite image) ? image : base.GetImage();
	}
}
