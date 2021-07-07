using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	public class MutatorUnlock : DisplayedUnlock
	{
		public MutatorUnlock() : this(null, false) { }
		public MutatorUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
		public MutatorUnlock(string name) : this(name, false) { }
		public MutatorUnlock(string name, bool unlockedFromStart) : base(name, "Challenge", unlockedFromStart) { }
		internal MutatorUnlock(Unlock unlock) : base(unlock) { }

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
					if (IsEnabled = !IsEnabled)
						foreach (DisplayedUnlock du in GetCancellations())
							du.IsEnabled = false;
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
				gc.unlocks.DoUnlockForced(Name, Type);
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
				string text = !Name.Contains("NoD_")
					? gc.nameDB.GetName("D_" + Name, Unlock.unlockDescriptionType)
					: gc.nameDB.GetName("NoDisasterDescription", "Unlock");
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
