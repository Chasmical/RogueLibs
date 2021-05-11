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
	///   <para>Item unlock wrapper.</para>
	/// </summary>
	public class ItemUnlock : DisplayedUnlock, IUnlockInCC
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="ItemUnlock"/> class.</para>
		/// </summary>
		public ItemUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="FloorUnlock"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id. <b>Must be the same as the item's name/id.</b></param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		public ItemUnlock(string name, bool unlockedFromStart = false)
			: base(name, "Item", unlockedFromStart)
		{
			IsAvailableInCC = true;
			IsAvailableInItemTeleporter = true;
		}
		internal ItemUnlock(Unlock unlock) : base(unlock) { }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		/// <inheritdoc/>
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
		/// <summary>
		///   <para>Gets/sets whether the item is selected as a loadout.</para>
		/// </summary>
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

		/// <inheritdoc/>
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
		/// <inheritdoc/>
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
		/// <summary>
		///   <para>Gets/sets whether the item is available in the Item Teleporter menu.</para>
		/// </summary>
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

		private List<string> GetMyLoadouts() => Menu.Agent.isPlayer == 1 ? gc.sessionDataBig.loadouts1
			: Menu.Agent.isPlayer == 2 ? gc.sessionDataBig.loadouts2
			: Menu.Agent.isPlayer == 3 ? gc.sessionDataBig.loadouts3
			: gc.sessionDataBig.loadouts4;

		/// <inheritdoc/>
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
		/// <inheritdoc/>
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
					Menu.Agent.agentInvDatabase.AddItemOrDrop(invItem);
					Menu.Agent.inventory.DontPlayPickupSounds(false);
					if (invItem.invItemName == "BombMaker" && !Menu.Agent.agentInvDatabase.HasItem("BombTrigger"))
					{
						invItem = new InvItem() { invItemName = "BombTrigger" };
						invItem.SetupDetails(false);
						invItem.invItemCount = invItem.initCount;
						Menu.Agent.inventory.DontPlayPickupSounds(true);
						Menu.Agent.agentInvDatabase.AddItemOrDrop(invItem);
						Menu.Agent.inventory.DontPlayPickupSounds(false);
					}
				}
				else if (Menu.Type == UnlocksMenuType.Loadouts)
				{
					if (IsSelectedLoadout)
					{
						PlaySound("BuyItem");
						gc.unlocks.AddNuggets(LoadoutCost);
						gc.sessionDataBig.loadoutNuggetsSpent = 0;
						IsSelectedLoadout = false;
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
							}
							gc.unlocks.SubtractNuggets(LoadoutCost);
							gc.sessionDataBig.loadoutNuggetsSpent = LoadoutCost;
							IsSelectedLoadout = true;
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
				gc.unlocks.DoUnlock(Name, Type);
				UpdateAllUnlocks();
				UpdateMenu();
			}
			else PlaySound("CantDo");
		}

		/// <inheritdoc/>
		public override Sprite GetImage() => (IsUnlocked || Unlock.nowAvailable) && GameResources.gameResources.itemDic.TryGetValue(Name, out Sprite image) ? image : base.GetImage();
	}
}
