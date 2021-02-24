using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
	public abstract class UnlockWrapper
	{
		protected UnlockWrapper(string name, string type, bool unlockedFromStart)
		{
			Name = name;
			Type = type;
			Unlock = new Unlock(name, type, unlockedFromStart) { __RogueLibsCustom = this };
		}

		public string Name { get; }
		public string Type { get; }

		public Unlock Unlock { get; internal set; }
		public bool IsUnlocked { get => Unlock.unlocked; set => Unlock.unlocked = value; }
		public int UnlockCost { get => Unlock.cost; set => Unlock.cost = value; }
		public int LoadoutCost { get => Unlock.cost2; set => Unlock.cost2 = value; }
		public int CharacterCreationCost { get => Unlock.cost3; set => Unlock.cost3 = value; }

		public abstract bool IsEnabled { get; set; }
		public abstract bool IsAvailable { get; set; }

		public List<string> Cancellations { get => Unlock.cancellations; set => Unlock.cancellations = value; }
		public List<string> Recommendations { get => Unlock.recommendations; set => Unlock.recommendations = value; }
		public List<string> Prerequisites { get => Unlock.prerequisites; set => Unlock.prerequisites = value; }

		public virtual void SetupUnlock() { }
		public virtual bool CanBeUnlocked() => UnlockCost > -1
			&& Unlock.prerequisites.All(c => gc.sessionDataBig.unlocks.Exists(u => u.unlockName == c && u.unlocked));
		public virtual void UpdateUnlock()
		{
			if ((Unlock.nowAvailable = !Unlock.unlocked && CanBeUnlocked()) && UnlockCost == 0)
				IsUnlocked = true;
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public static GameController gc => GameController.gameController;
	}
	public abstract class DisplayedUnlock : UnlockWrapper, IComparable<DisplayedUnlock>
	{
		protected DisplayedUnlock(string name, string type, bool unlockedFromStart) : base(name, type, unlockedFromStart) { }

		public UnlocksMenu Menu { get; internal set; }
		public ButtonData ButtonData { get; internal set; }
		public UnlockButtonState State { get => ButtonData.GetState(); set => ButtonData.SetState(value); }
		public string Text { get => ButtonData.buttonText; set => ButtonData.buttonText = value; }

		public int SortingOrder { get; set; }
		public int SortingIndex { get; set; }
		public virtual int CompareTo(DisplayedUnlock other)
		{
			int res = SortingOrder.CompareTo(other.SortingOrder);
			if (res != 0) return res;
			res = SortingIndex.CompareTo(other.SortingIndex);
			return res != 0 ? res : Unlock.CompareTo(other.Unlock);
		}

		public virtual void UpdateButton() => UpdateButton(IsEnabled, UnlockButtonState.Selected, UnlockButtonState.Normal);
		protected void UpdateButton(bool isEnabledOrSelected) => UpdateButton(isEnabledOrSelected, UnlockButtonState.Selected, UnlockButtonState.Normal);
		protected void UpdateButton(bool isEnabledOrSelected, UnlockButtonState selected, UnlockButtonState normal)
		{
			Text = GetName();
			if (IsUnlocked)
			{
				State = isEnabledOrSelected ? selected : normal;
				if (Menu.Type == UnlocksMenuType.CharacterCreation && CharacterCreationCost != 0) Text +=
						$" | <color={(CharacterCreationCost < 0 ? "lime" : "orange")}>{CharacterCreationCost}</color>";
			}
			else if (Unlock.nowAvailable && UnlockCost > -1)
			{
				State = UnlockButtonState.Purchasable;
				Text += $" - ${UnlockCost}";
			}
			else State = UnlockButtonState.Locked;
		}
		public abstract void OnPushedButton();
		public virtual string GetName() => IsUnlocked || Unlock.nowAvailable ? gc.nameDB.GetName(Name, Unlock.unlockNameType) : "?????";
		public virtual string GetDescription()
		{
			if (IsUnlocked || Unlock.nowAvailable)
			{
				string text = gc.nameDB.GetName(Name, Unlock.unlockDescriptionType);
				AddCancellationsTo(ref text);
				AddRecommendationsTo(ref text);
				return text;
			}
			else
			{
				string text = "?????";
				AddPrerequisitesTo(ref text);
				return text;
			}
		}
		public virtual Sprite GetImage() => RogueLibs.extraSprites.TryGetValue(Name, out Sprite image) ? image : null;

		protected void AddCancellationsTo(ref string text)
		{
			if (Unlock.cancellations.Count > 0)
			{
				text += $"\n\n<color=orange>{gc.nameDB.GetName("Cancels", "Interface")}:</color>\n" +
					string.Join(", ", Unlock.cancellations.ConvertAll(unlockName =>
					{
						DisplayedUnlock unlock = (DisplayedUnlock)gc.sessionDataBig.unlocks.Find(u => u.unlockName == unlockName)?.__RogueLibsCustom;
						return unlock?.GetName();
					}));
			}
		}
		protected void AddRecommendationsTo(ref string text)
		{
			if (Unlock.recommendations.Count > 0)
			{
				text += $"\n\n<color=cyan>{gc.nameDB.GetName("Recommends", "Interface")}:</color>\n" +
					string.Join(", ", Unlock.recommendations.ConvertAll(unlockName =>
					{
						DisplayedUnlock unlock = (DisplayedUnlock)gc.sessionDataBig.unlocks.Find(u => u.unlockName == unlockName)?.__RogueLibsCustom;
						return unlock?.GetName();
					}));
			}
		}
		protected void AddPrerequisitesTo(ref string text)
		{
			if (Unlock.prerequisites.Count > 0)
			{
				text += $"\n\n<color=cyan>{gc.nameDB.GetName("Prerequisites", "Unlock")}:</color>\n" +
					string.Join(", ", Unlock.prerequisites.ConvertAll(unlockName =>
					{
						DisplayedUnlock unlock = (DisplayedUnlock)gc.sessionDataBig.unlocks.Find(u => u.unlockName == unlockName).__RogueLibsCustom;
						string name = unlock.GetName();
						if (unlock.IsUnlocked) name = $"<color=grey>{name}</color>";
						return name;
					}));
			}
			if (Unlock.cost == -2)
			{
				text += $"\n\n<color=cyan>{gc.nameDB.GetName("Prerequisites", "Unlock")}:</color>\n" +
					gc.unlocks.GetSpecialUnlockInfo(Name, Unlock);
			}
			else if (Unlock.cost > 0)
			{
				text += $"\n\n<color=cyan>{gc.nameDB.GetName("UnlockFor", "Unlock")} ${Unlock.cost}</color>";
			}
		}

		public void PlaySound(string clipName) => gc.audioHandler.Play(Menu.Agent, clipName);
		public void SendAnnouncementInChat(string msg1, string msg2 = "", string msg3 = "")
		{
			if (gc.serverPlayer && gc.multiplayerMode)
				Menu.Agent.objectMult.SendChatAnnouncement(msg1, msg2, msg3);
		}
		public void UpdateMenu() => Menu.UpdateMenu();
		public void UpdateAllUnlocks()
		{
			foreach (DisplayedUnlock unlock in Menu.Unlocks)
			{
				unlock.UpdateUnlock();
				unlock.UpdateButton();
			}
		}
		public virtual void DoCancellations()
		{
			foreach (DisplayedUnlock unlock in Menu.Unlocks)
				if (unlock.Unlock.cancellations.Contains(Name) || Unlock.cancellations.Contains(unlock.Name))
				{
					unlock.IsEnabled = false;
					unlock.UpdateButton();
				}
		}
	}
	public class MutatorUnlock : DisplayedUnlock
	{
		public MutatorUnlock(string name, bool unlockedFromStart = false) : base(name, "Challenge", unlockedFromStart) { }

		public override bool IsEnabled
		{
			get => gc.challenges.Contains(Name);
			set
			{
				if (IsEnabled)
				{
					if (!value)
					{
						gc.challenges.Remove(Name);
						if (Menu.Type == UnlocksMenuType.MutatorMenu)
							gc.originalChallenges.Remove(Name);
					}
				}
				else if (value)
				{
					gc.challenges.Add(Name);
					if (Menu.Type == UnlocksMenuType.MutatorMenu)
						gc.originalChallenges.Add(Name);
				}
			}
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.challengeUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.challengeUnlocks.Remove(Unlock); Unlock.challengeCount--; }
				else if (cur == false && value) { gc.sessionDataBig.challengeUnlocks.Add(Unlock); Unlock.challengeCount++; }
			}
		}

		public override void OnPushedButton()
		{
			if (IsUnlocked)
			{
				if (gc.serverPlayer)
				{
					PlaySound("ClickButton");
					if (IsEnabled = !IsEnabled) DoCancellations();
					SendAnnouncementInChat(IsEnabled ? "AddedChallenge" : "RemovedChallenge", Name);
					UpdateButton();
					UpdateMenu();
				}
				else PlaySound("CantDo");
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

		public override string GetName()
		{
			if (IsUnlocked || Unlock.nowAvailable)
			{
				if (!Name.Contains("NoD_")) return gc.nameDB.GetName(Name, Unlock.unlockNameType);
				return gc.nameDB.GetName("Remove", "Interface") + " - " + gc.nameDB.GetName("LevelFeeling" + Name.Replace("NoD_", "") + "_Name", "Interface");
			}
			else return "?????";
		}
		public override string GetDescription()
		{
			if (IsUnlocked || Unlock.nowAvailable)
			{
				string text = gc.nameDB.GetName("D_" + Name, Unlock.unlockDescriptionType);
				AddCancellationsTo(ref text);
				AddRecommendationsTo(ref text);
				if (!IsUnlocked) AddPrerequisitesTo(ref text);
				return text;
			}
			else
			{
				string text = "?????";
				AddPrerequisitesTo(ref text);
				return text;
			}
		}
	}
	public class ClearAllMutatorsUnlock : MutatorUnlock
	{
		public ClearAllMutatorsUnlock() : base("ClearAll") { }
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
		public override bool IsAvailable { get; set; } = true;
		public override bool IsEnabled { get => false; set { } }
	}
	public class ClearAllItemsUnlock : ItemUnlock
	{
		public ClearAllItemsUnlock() : base("ClearAllItems") { }
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
		public override bool IsAvailable { get; set; } = true;
		public override bool IsEnabled { get => false; set { } }
	}
	public class ClearAllTraitsUnlock : TraitUnlock
	{
		public ClearAllTraitsUnlock() : base("ClearAllTraits") { }
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
		public override bool IsAvailable { get; set; } = true;
		public override bool IsEnabled { get => false; set { } }
	}
	public class ItemUnlock : DisplayedUnlock, IUnlockInCC
	{
		public ItemUnlock(string name, bool unlockedFromStart = false)
			: base(name, "Item", unlockedFromStart)
		{
			IsAvailableInCC = true;
			IsAvailableInItemTeleporter = true;
		}

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

		private List<string> GetMyLoadouts() => Menu.Agent.isPlayer == 1 ? gc.sessionDataBig.loadouts1
			: Menu.Agent.isPlayer == 2 ? gc.sessionDataBig.loadouts2
			: Menu.Agent.isPlayer == 3 ? gc.sessionDataBig.loadouts3
			: gc.sessionDataBig.loadouts4;

		public override void UpdateButton()
		{
			if (Menu.Type == UnlocksMenuType.RewardsMenu)
				UpdateButton(IsEnabled);
			else if (Menu.Type == UnlocksMenuType.ItemTeleporter)
				UpdateButton(false);
			else if (Menu.Type == UnlocksMenuType.Loadouts)
				UpdateButton(IsSelectedLoadout);
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
					if (IsAddedToCC = !IsAddedToCC) DoCancellations();
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

		public override Sprite GetImage() => GameResources.gameResources.itemDic.TryGetValue(Name, out Sprite image) ? image : base.GetImage();
	}
	public class TraitUnlock : DisplayedUnlock, IUnlockInCC
	{
		public TraitUnlock(string name, bool unlockedFromStart = false) : base(name, "Trait", unlockedFromStart) => IsAvailableInCC = true;

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public bool IsAddedToCC
		{
			get => ((CustomCharacterCreation)Menu).CC.traitsChosen.Contains(Unlock);
			set
			{
				List<Unlock> list = ((CustomCharacterCreation)Menu).CC.traitsChosen;
				bool cur = list.Contains(Unlock);
				if (cur && !value) list.Remove(Unlock);
				else if (!cur && value) list.Add(Unlock);
			}
		}

		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.traitUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.traitUnlocks.Remove(Unlock); Unlock.traitCount--; }
				else if (cur == false && value) { gc.sessionDataBig.traitUnlocks.Add(Unlock); Unlock.traitCount++; }
			}
		}
		public bool IsAvailableInCC
		{
			get => Unlock.onlyInCharacterCreation;
			set
			{
				Unlock.onlyInCharacterCreation = value;
				bool? cur = gc?.sessionDataBig?.traitUnlocksCharacterCreation?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.traitUnlocksCharacterCreation.Remove(Unlock); Unlock.traitCountCharacterCreation--; }
				else if (cur == false && value) { gc.sessionDataBig.traitUnlocksCharacterCreation.Add(Unlock); Unlock.traitCountCharacterCreation++; }
			}
		}

		public virtual int GetUpgradeCost() => Mathf.Abs((gc.unlocks.GetUnlock(Unlock.upgrade, "Trait")?.cost3 ?? CharacterCreationCost) * ((CustomScrollingMenu)Menu).Menu.upgradeTraitAdjust);
		public virtual int GetRemovalCost() => Mathf.Abs(CharacterCreationCost * ((CustomScrollingMenu)Menu).Menu.removeTraitAdjust);
		public virtual int GetSwapCost() => Mathf.Abs(CharacterCreationCost * (CharacterCreationCost < 0 ? ((CustomScrollingMenu)Menu).Menu.changeTraitRandomAdjustNegativeTrait : ((CustomScrollingMenu)Menu).Menu.changeTraitRandomAdjustPositiveTrait));

		public override void UpdateButton()
		{
			if (Menu.Type == UnlocksMenuType.TraitsMenu)
				UpdateButton(IsEnabled);
			else if (Menu.Type == UnlocksMenuType.CharacterCreation)
				UpdateButton(IsAddedToCC);
			else if (Menu.Type == UnlocksMenuType.NewLevelTraits)
				UpdateButton(false);
			else if (Menu.Type == UnlocksMenuType.AB_UpgradeTrait)
				Text = $"{GetName()} | ${GetUpgradeCost()}";
			else if (Menu.Type == UnlocksMenuType.AB_RemoveTrait)
				Text = $"{GetName()} | ${GetRemovalCost()}";
			else if (Menu.Type == UnlocksMenuType.AB_SwapTrait)
				Text = $"{GetName()} | ${GetSwapCost()}";
		}
		public override void OnPushedButton()
		{
			if (IsUnlocked)
			{
				if (Menu.Type == UnlocksMenuType.TraitsMenu)
				{
					ScrollingMenu menu = ((CustomScrollingMenu)Menu).Menu;
					if (IsEnabled && menu.activeTraitCount <= menu.minTraits)
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
				else if (Menu.Type == UnlocksMenuType.CharacterCreation)
				{
					PlaySound("ClickButton");
					if (IsAddedToCC = !IsAddedToCC) DoCancellations();
					UpdateButton();
					UpdateMenu();
				}
				else if (Menu.Type == UnlocksMenuType.NewLevelTraits)
				{
					ScrollingMenu menu = ((CustomScrollingMenu)Menu).Menu;
					if (menu.twitchCountdownOn) return;
					State = UnlockButtonState.Selected;
					if (gc.twitchMode || (gc.sessionDataBig.twitchOn && gc.sessionDataBig.twitchTraits))
					{
						gc.twitchFunctions.ShowWinner(Name, "StatusEffect", Menu.Agent.isPlayer);
					}
					if (Name == "EnduranceTrait")
					{
						Menu.Agent.SetEndurance(Menu.Agent.enduranceStatMod + 1, true);
						if (!Menu.Agent.finishedLevel)
							gc.spawnerMain.SpawnStatusText(Menu.Agent, "BuffSpecial", "Endurance", "BuffSpecial", "");
					}
					else if (Name == "SpeedTrait")
					{
						Menu.Agent.SetSpeed(Menu.Agent.speedStatMod + 1, true);
						if (!Menu.Agent.finishedLevel)
							gc.spawnerMain.SpawnStatusText(Menu.Agent, "BuffSpecial", "Speed", "BuffSpecial", "");
					}
					else if (Name == "StrengthTrait")
					{
						Menu.Agent.SetStrength(Menu.Agent.strengthStatMod + 1, true);
						if (!Menu.Agent.finishedLevel)
							gc.spawnerMain.SpawnStatusText(Menu.Agent, "BuffSpecial", "Strength", "BuffSpecial", "");
					}
					else if (Name == "AccuracyTrait")
					{
						Menu.Agent.SetAccuracy(Menu.Agent.accuracyStatMod + 1, true);
						if (!Menu.Agent.finishedLevel)
							gc.spawnerMain.SpawnStatusText(Menu.Agent, "BuffSpecial", "Accuracy", "BuffSpecial", "");
					}
					else
					{
						Menu.Agent.statusEffects.AddTrait(Name);
					}
					Menu.Agent.addedEndLevelTrait = true;
					Menu.Agent.skillPoints.levelsGained--;
					gc.sessionData.levelsGained[Menu.Agent.isPlayer]--;
					PlaySound("AddTrait");
					Menu.Agent.objectMult.SendChatAnnouncement("ChoseTrait", Name, "");
					menu.canPressButtons = false;
					if (Menu.Agent.skillPoints.levelsGained == 0)
					{
						if (gc.fourPlayerMode || gc.coopMode)
						{
							menu.StartCoroutine((IEnumerator)typeof(ScrollingMenu).GetMethod("PersonalMenuDelay").Invoke(menu, new object[0]));
						}
						else if (gc.levelFeelingsScript.DoesNextLevelHaveFeeling(false) && (gc.sessionDataBig.twitchOn || gc.twitchMode) && (gc.sessionDataBig.twitchLevelFeelings || gc.twitchMode) && (gc.sessionData.nextLevelFeeling?.Length == 0 || gc.sessionData.nextLevelFeeling == null) && !gc.challenges.Contains("NoLevelFeelings") && !gc.levelFeelingsScript.CanceledAllLevelFeelings() && gc.serverPlayer && gc.levelFeelingsScript.GetLevelFeeling() != "")
						{
							menu.StartCoroutine((IEnumerator)typeof(ScrollingMenu).GetMethod("ShowMenuDelay").Invoke(menu, new object[2] { "LevelFeelings", Menu.Agent }));
						}
						else
						{
							menu.StartCoroutine(menu.NextLevelDelay());
						}
					}
					else
					{
						foreach (ButtonData buttonData4 in menu.buttonsData)
							buttonData4.isActive = false;
						menu.Invoke("OpenScrollingMenu", 0.1f);
					}
				}
				else if (Menu.Type == UnlocksMenuType.AB_UpgradeTrait)
				{
					if (Menu.Agent.interactionHelper.interactionObjectReal.moneySuccess(GetUpgradeCost()))
					{
						Menu.Agent.usingAugmentationBooth = true;
						Menu.Agent.statusEffects.AddTrait(Unlock.upgrade);
						Debug.Log("UpgradeTrait: " + Name + " - " + Unlock.upgrade);
						PlaySound("AddTrait");
						Menu.Agent.mainGUI.HideScrollingMenuPersonal();
						Menu.Agent.usingAugmentationBooth = false;
					}
					else PlaySound("CantDo");
				}
				else if (Menu.Type == UnlocksMenuType.AB_RemoveTrait)
				{
					if (Menu.Agent.interactionHelper.interactionObjectReal.moneySuccess(GetRemovalCost()))
					{
						Menu.Agent.usingAugmentationBooth = true;
						Menu.Agent.statusEffects.RemoveTrait(Name);
						Debug.Log("RemoveTrait: " + Name);
						Menu.Agent.mainGUI.HideScrollingMenuPersonal();
						Menu.Agent.usingAugmentationBooth = false;
					}
					else PlaySound("CantDo");
				}
				else if (Menu.Type == UnlocksMenuType.AB_SwapTrait)
				{
					ScrollingMenu menu = ((CustomScrollingMenu)Menu).Menu;
					List<Unlock> list = Unlock.isUpgrade
						? gc.sessionDataBig.unlocks.FindAll(u => u.isUpgrade && Unlock.isUpgrade && !Menu.Agent.statusEffects.hasTrait(u.unlockName) && !u.cantSwap && !u.removal && u.specialAbilities.All(ab => Menu.Agent.statusEffects.hasSpecialAbility(ab)))
						: CharacterCreationCost < 0
                            ? gc.sessionDataBig.traitUnlocksCharacterCreation.FindAll(u => u.cost3 == CharacterCreationCost && menu.TraitOK(u) && menu.HasNoCancellations(u) && !u.cantSwap && !u.removal && u.specialAbilities.All(ab => Menu.Agent.statusEffects.hasSpecialAbility(ab)) && u.recommendations.Count == 0)
                            : gc.sessionDataBig.traitUnlocks.FindAll(u => u.cost3 == CharacterCreationCost && menu.TraitOK(u) && menu.HasNoCancellations(u) && !u.cantSwap && !u.removal && u.specialAbilities.All(ab => Menu.Agent.statusEffects.hasSpecialAbility(ab)));
					if (list.Count == 0)
					{
						Menu.Agent.SayDialogue("CantChangeTraitRandomEquivalent");
						PlaySound("CantDo");
					}
					else if (Menu.Agent.interactionHelper.interactionObjectReal.moneySuccess(GetSwapCost()))
					{
						Menu.Agent.usingAugmentationBooth = true;
						Unlock unlock6 = list[UnityEngine.Random.Range(0, list.Count)];
						Menu.Agent.statusEffects.RemoveTrait(Name);
						Menu.Agent.statusEffects.AddTrait(unlock6.unlockName);
						Debug.Log("ChangeTrait: " + Name + " - " + unlock6.unlockName);
						PlaySound("AddTrait");
						Menu.Agent.mainGUI.HideScrollingMenuPersonal();
						Menu.Agent.usingAugmentationBooth = false;
					}
					else PlaySound("CantDo");
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
	}
	public class AbilityUnlock : DisplayedUnlock, IUnlockInCC
	{
		public AbilityUnlock(string name, bool unlockedFromStart = false) : base(name, "Ability", unlockedFromStart) => IsAvailableInCC = true;

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public bool IsAddedToCC
		{
			get => ((CustomCharacterCreation)Menu).CC.abilityChosen == Name;
			set
			{
				bool cur = IsEnabled;
				if (cur && !value) ((CustomCharacterCreation)Menu).CC.abilityChosen = "";
				else if (!cur && value) ((CustomCharacterCreation)Menu).CC.abilityChosen = Name;
			}
		}

		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.abilityUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.abilityUnlocks.Remove(Unlock); Unlock.abilityCount--; }
				else if (cur == false && value) { gc.sessionDataBig.abilityUnlocks.Add(Unlock); Unlock.abilityCount++; }
			}
		}
		public bool IsAvailableInCC
		{
			get => Unlock.onlyInCharacterCreation;
			set => Unlock.onlyInCharacterCreation = value;
		}

		public override void OnPushedButton()
		{
			if (IsUnlocked)
			{
				if (Menu.Type == UnlocksMenuType.CharacterCreation)
				{
					PlaySound("ClickButton");
					AbilityUnlock previous = (AbilityUnlock)Menu.Unlocks.Find(u => u is AbilityUnlock ability && ability.IsAddedToCC);
					IsAddedToCC = !IsAddedToCC;
					UpdateButton();
					previous?.UpdateButton();
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
	}
	public class BigQuestUnlock : DisplayedUnlock, IUnlockInCC
	{
		public BigQuestUnlock(string name, bool unlockedFromStart = false) : base(name, "BigQuest", unlockedFromStart) => IsAvailableInCC = true;

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public bool IsAddedToCC
		{
			get => ((CustomCharacterCreation)Menu).CC.bigQuestChosen == Name;
			set
			{
				bool cur = IsEnabled;
				if (cur && !value) ((CustomCharacterCreation)Menu).CC.bigQuestChosen = "";
				else if (!cur && value) ((CustomCharacterCreation)Menu).CC.bigQuestChosen = Name;
			}
		}

		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.bigQuestUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.bigQuestUnlocks.Remove(Unlock); Unlock.bigQuestCount--; }
				else if (cur == false && value) { gc.sessionDataBig.bigQuestUnlocks.Add(Unlock); Unlock.bigQuestCount++; }
			}
		}
		public bool IsAvailableInCC
		{
			get => Unlock.onlyInCharacterCreation;
			set => Unlock.onlyInCharacterCreation = value;
		}

		public override void OnPushedButton()
		{
			if (IsUnlocked)
			{
				if (Menu.Type == UnlocksMenuType.CharacterCreation)
				{
					PlaySound("ClickButton");
					BigQuestUnlock previous = (BigQuestUnlock)Menu.Unlocks.Find(u => u is BigQuestUnlock bigQuest && bigQuest.IsAddedToCC);
					IsAddedToCC = !IsAddedToCC;
					UpdateButton();
					previous?.UpdateButton();
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
	}
	public class AchievementUnlock : DisplayedUnlock
	{
		public AchievementUnlock(string name, bool unlockedFromStart = false) : base(name, "Achievement", unlockedFromStart) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.achievementUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.achievementUnlocks.Remove(Unlock); Unlock.achievementCount--; }
				else if (cur == false && value) { gc.sessionDataBig.achievementUnlocks.Add(Unlock); Unlock.achievementCount++; }
			}
		}

		public override void OnPushedButton() => UpdateMenu();
	}
	public class FloorUnlock : DisplayedUnlock
	{
		public FloorUnlock(string name, bool unlockedFromStart = false) : base(name, "Floor", unlockedFromStart) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.floorUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.floorUnlocks.Remove(Unlock); Unlock.floorCount--; }
				else if (cur == false && value) { gc.sessionDataBig.floorUnlocks.Add(Unlock); Unlock.floorCount++; }
			}
		}

		public override void OnPushedButton()
		{
			if (IsUnlocked)
			{
				Menu.Agent.mainGUI.HideScrollingMenu();
				gc.mainGUI.ShowCharacterSelect();
				bool quick = gc.challenges.Contains("QuickGame");
				gc.sessionDataBig.elevatorLevel = Name == "Floor5" ? (quick ? 9 : 13)
					: Name == "Floor4" ? (quick ? 7 : 10)
					: Name == "Floor3" ? (quick ? 5 : 7)
					: Name == "Floor2" ? (quick ? 3 : 4)
					: Name == "Floor1" ? 1 : 1;
				if (gc.multiplayerMode)
				{
					if (gc.serverPlayer)
					{
						SendAnnouncementInChat("WantsToGo", Name);
						gc.playerAgent.objectMult.CallRpcForceShowCharacterSelect();
					}
					else gc.playerAgent.objectMult.CallCmdForceShowCharacterSelect(Name);
				}
			}
			else PlaySound("CantDo");
		}
	}
	public class HomeBaseUnlock : UnlockWrapper
	{
		public HomeBaseUnlock(string name, bool unlockedFromStart = false) : base(name, "HomeBase", unlockedFromStart) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.homeBaseUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.homeBaseUnlocks.Remove(Unlock); Unlock.homeBaseCount--; }
				else if (cur == false && value) { gc.sessionDataBig.homeBaseUnlocks.Add(Unlock); Unlock.homeBaseCount++; }
			}
		}
	}
	public class ExtraUnlock : UnlockWrapper
	{
		public ExtraUnlock(string name, bool unlockedFromStart = false) : base(name, "Extra", unlockedFromStart) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.extraUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.extraUnlocks.Remove(Unlock); Unlock.extraCount--; }
				else if (cur == false && value) { gc.sessionDataBig.extraUnlocks.Add(Unlock); Unlock.extraCount++; }
			}
		}
	}
	public class LoadoutUnlock : UnlockWrapper
	{
		public LoadoutUnlock(string name, bool unlockedFromStart = false) : base(name, "Loadout", unlockedFromStart) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.loadoutUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.loadoutUnlocks.Remove(Unlock); Unlock.loadoutCount--; }
				else if (cur == false && value) { gc.sessionDataBig.loadoutUnlocks.Add(Unlock); Unlock.loadoutCount++; }
			}
		}
	}
	public class AgentUnlock : UnlockWrapper
	{
		public AgentUnlock(string name, bool unlockedFromStart = false) : base(name, "Agent", unlockedFromStart) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.agentUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.agentUnlocks.Remove(Unlock); Unlock.agentCount--; }
				else if (cur == false && value) { gc.sessionDataBig.agentUnlocks.Add(Unlock); Unlock.agentCount++; }
			}
		}
	}
	public interface IUnlockInCC
	{
		bool IsAddedToCC { get; set; }
		bool IsAvailableInCC { get; set; }
	}
	public abstract class UnlocksMenu
	{
		protected UnlocksMenu(List<DisplayedUnlock> unlocks) => Unlocks = unlocks;

		public UnlocksMenuType Type { get; protected set; }
		public List<DisplayedUnlock> Unlocks { get; }
		public abstract void UpdateMenu();
		public abstract Agent Agent { get; }
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
	public class CustomLevelEditor : UnlocksMenu
	{
		public CustomLevelEditor(LevelEditor editor, List<DisplayedUnlock> unlocks) : base(unlocks) => Editor = editor;
		public LevelEditor Editor { get; }
		public override Agent Agent => GameController.gameController.playerAgent;

		public override void UpdateMenu()
		{

		}
	}
	public enum UnlocksMenuType
	{
		Unknown,

		MutatorMenu,
		RewardsMenu,
		TraitsMenu,

		RewardConfigs,
		TraitConfigs,
		MutatorConfigs,

		FloorsMenu,
		NewLevelTraits,
		ItemTeleporter,
		Loadouts,
		TwitchRewards,
		TwitchDisasters,

		AB_UpgradeTrait,
		AB_RemoveTrait,
		AB_SwapTrait,

		CharacterSelect,
		Achievements,

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
