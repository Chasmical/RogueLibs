using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	public class BigQuestUnlock : DisplayedUnlock, IUnlockInCC
	{
		public BigQuestUnlock(string name, bool unlockedFromStart = false) : base(name, "BigQuest", unlockedFromStart) => IsAvailableInCC = true;
		internal BigQuestUnlock(Unlock unlock) : base(unlock) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public bool IsAddedToCC
		{
			get => ((CustomCharacterCreation)Menu).CC.bigQuestChosen == Agent.Name;
			set
			{
				bool cur = IsAddedToCC;
				if (cur && !value) ((CustomCharacterCreation)Menu).CC.bigQuestChosen = "";
				else if (!cur && value) ((CustomCharacterCreation)Menu).CC.bigQuestChosen = Agent.Name;
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

		public override bool IsUnlocked { get => Agent.IsUnlocked; set => Agent.IsUnlocked = value; }
		public bool IsCompleted { get => Unlock.unlocked; set => Unlock.unlocked = value; }

		private AgentUnlock agent;
		public AgentUnlock Agent => agent ?? (agent = RogueLibs.GetUnlock<AgentUnlock>(Name.Substring(0, Name.Length - 3)));

		public override void SetupUnlock()
		{
			if (Agent.Name == "Cop2" || Agent.Name == "UpperCruster" || Agent.Name == "Guard2")
				IsAvailableInCC = false;
		}
		public override string GetName()
		{
			if (IsUnlocked || Unlock.nowAvailable)
			{
				string name = gc.nameDB.GetName(Name, "Unlock");
				if (Agent.Name == "Gangbanger" || Agent.Name == "GangbangerB")
					name += $" ({gc.nameDB.GetName(Agent.Name + "_N", "Agent")})";
				return name;
			}
			else return "?????";
		}
		public override string GetDescription()
		{
			if (IsUnlocked || Unlock.nowAvailable)
			{
				string text = gc.nameDB.GetName("D_" + Name, "Unlock");
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
		public override void UpdateButton()
		{
			if (Menu.Type == UnlocksMenuType.CharacterCreation)
			{
				if (IsUnlocked)
				{
					State = IsAddedToCC ? UnlockButtonState.Selected : UnlockButtonState.Normal;
					Text = gc.nameDB.GetName(Agent.Name, "Agent");
				}
				else if (Unlock.nowAvailable && UnlockCost > -1)
				{
					State = UnlockButtonState.Purchasable;
					Text = gc.nameDB.GetName(Agent.Name, "Agent");
				}
				else
				{
					State = UnlockButtonState.Locked;
					Text = "?????";
				}
			}
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
}
