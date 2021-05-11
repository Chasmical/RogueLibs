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
	///   <para>Big Quest unlock wrapper.</para>
	/// </summary>
	public class BigQuestUnlock : DisplayedUnlock, IUnlockInCC
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="BigQuestUnlock"/> class.</para>
		/// </summary>
		public BigQuestUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="BigQuestUnlock"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id. Must be "&lt;Agent&gt;_BQ".</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		public BigQuestUnlock(string name, bool unlockedFromStart = false) : base(name, "BigQuest", unlockedFromStart) => IsAvailableInCC = true;
		internal BigQuestUnlock(Unlock unlock) : base(unlock) { }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		/// <inheritdoc/>
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

		/// <inheritdoc/>
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
		/// <inheritdoc/>
		public bool IsAvailableInCC
		{
			get => Unlock.onlyInCharacterCreation;
			set => Unlock.onlyInCharacterCreation = value;
		}

		/// <summary>
		///   <para>Gets/sets whether the Big Quest is unlocked ~ its agent is unlocked.</para>
		/// </summary>
		public override bool IsUnlocked { get => Agent.IsUnlocked; set => Agent.IsUnlocked = value; }
		/// <summary>
		///   <para>Gets/sets whether the Big Quest is completed.</para>
		/// </summary>
		public bool IsCompleted { get => Unlock.unlocked; set => Unlock.unlocked = value; }

		private AgentUnlock agent;
		/// <summary>
		///   <para>Agent unlock that the Big Quest unlock belongs to.</para>
		/// </summary>
		public AgentUnlock Agent => agent ?? (agent = RogueLibs.GetUnlock<AgentUnlock>(Name.Substring(0, Name.Length - 3)));

		/// <inheritdoc/>
		public override void SetupUnlock()
		{
			if (Agent.Name == "Cop2" || Agent.Name == "UpperCruster" || Agent.Name == "Guard2")
				IsAvailableInCC = false;
		}

		/// <inheritdoc/>
		public override void UpdateButton()
		{
			if (Menu.Type == UnlocksMenuType.CharacterCreation)
			{
				UpdateButton(IsAddedToCC);
				if (IsUnlocked || Unlock.nowAvailable)
					Text = gc.nameDB.GetName(Agent.Name, "Agent");
			}
		}
		/// <inheritdoc/>
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

		/// <inheritdoc/>
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
		/// <inheritdoc/>
		public override string GetDescription()
		{
			if (IsUnlocked || Unlock.nowAvailable)
			{
				string text = gc.nameDB.GetName("D_" + Name, "Unlock");
				AddCancellationsTo(ref text);
				AddRecommendationsTo(ref text);
				if (!IsUnlocked) AddPrerequisitesTo(ref text);
				return text.Trim('\n');
			}
			else
			{
				string text = "?????";
				AddPrerequisitesTo(ref text);
				return text.Trim('\n');
			}
		}
	}
}
