using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	public abstract class DisplayedUnlock : UnlockWrapper, IComparable<DisplayedUnlock>
	{
		protected DisplayedUnlock(string name, string type, bool unlockedFromStart) : base(name, type, unlockedFromStart) { }
		internal DisplayedUnlock(Unlock unlock) : base(unlock) { }

		public UnlocksMenu Menu { get; internal set; }
		public ButtonData ButtonData { get; internal set; }
		public UnlockButtonState State { get => ButtonData.GetState(); set => ButtonData.SetState(value); }
		public string Text { get => ButtonData.buttonText; set => ButtonData.buttonText = value; }

		public int SortingOrder { get; set; }
		public int SortingIndex { get; set; }
		public bool IgnoreStateSorting { get; set; }
		public virtual int CompareTo(DisplayedUnlock other)
		{
			int res = SortingOrder.CompareTo(other.SortingOrder);
			if (res != 0) return res;
			if (!IgnoreStateSorting)
			{
				res = GetStateNum().CompareTo(other.GetStateNum());
				if (res != 0) return res;
			}
			res = SortingIndex.CompareTo(other.SortingIndex);
			return res != 0 ? res : Unlock.CompareTo(other.Unlock);
		}
		private int GetStateNum()
		{
			if (IsUnlocked) return 0;
			else if (Unlock.nowAvailable && UnlockCost != 0) return 1;
			else if (Unlock.nowAvailable) return 2;
			else return 3;
		}

		public virtual void UpdateButton() => UpdateButton(IsEnabled, UnlockButtonState.Selected, UnlockButtonState.Normal);
		protected void UpdateButton(bool isEnabledOrSelected) => UpdateButton(isEnabledOrSelected, UnlockButtonState.Selected, UnlockButtonState.Normal);
		protected void UpdateButton(bool isEnabledOrSelected, UnlockButtonState selected, UnlockButtonState normal)
		{
			Text = GetFancyName();
			State = IsUnlocked ? isEnabledOrSelected ? selected : normal
				: Unlock.nowAvailable && UnlockCost > -1 ? UnlockButtonState.Purchasable
				: UnlockButtonState.Locked;
		}

		public abstract void OnPushedButton();

		public virtual string GetFancyName()
		{
			string name = GetName();
			if (Menu.Type == UnlocksMenuType.NewLevelTraits)
			{
				if (Unlock.specialAbilities.Count > 0 || Unlock.leadingTraits.Count > 0)
					name = $"<color=yellow>{name}</color>";
				if (Unlock.isUpgrade)
					name = $"<color=lime>{name}</color>";
				if (Name == "EnduranceTrait" || Name == "Strength" || Name == "Accuracy" || Name == "Speed")
					name = $"<color=cyan>{name}</color>";
				if ((gc.twitchMode || gc.sessionDataBig.twitchOn) && (gc.sessionDataBig.twitchTraits || gc.twitchMode))
				{
					int num = Menu.Unlocks.IndexOf(this);
					int votes = Menu.Agent.isPlayer is 2 ? gc.twitchFunctions.voteCount[num + 5]
						: Menu.Agent.isPlayer is 3 ? gc.twitchFunctions.voteCount[num + 10]
                        : Menu.Agent.isPlayer is 4 ? gc.twitchFunctions.voteCount[num + 15]
						: gc.twitchFunctions.voteCount[num];
					name = $"{name} <color=yellow>#{num + 1 + (Menu.Agent.isPlayer - 1) * 5}</color> <color=cyan>({votes})</color>";
				}
			}
			else if (Menu.Type == UnlocksMenuType.TwitchRewards)
			{
				if (gc.twitchMode || gc.sessionDataBig.twitchOn && gc.sessionDataBig.twitchRewards)
				{
					int num = Menu.Unlocks.IndexOf(this);
					name = $"{name} <color=yellow>#{num + 1}</color> <color=cyan>({gc.twitchFunctions.voteCount[num]})</color>";
				}
			}
			else if (Menu.Type == UnlocksMenuType.TwitchDisasters)
			{
				if (gc.twitchMode || gc.sessionDataBig.twitchOn && gc.sessionDataBig.twitchRewards)
				{
					int num = Menu.Unlocks.IndexOf(this);
					name = $"{name} <color=yellow>#{num + 1}</color> <color=cyan>({gc.twitchFunctions.voteCount[num]})</color>";
				}
			}
			else
			{
				if (Menu.Type == UnlocksMenuType.CharacterCreation)
				{
					if (CharacterCreationCost != 0)
						name += $" | <color={(CharacterCreationCost < 0 ? "lime" : "orange")}>{CharacterCreationCost}</color>";
				}
				if (Unlock.nowAvailable && UnlockCost > -1)
				{
					name += $" - ${UnlockCost}";
				}
			}
			return name;
		}

		protected void PlaySound(string clipName) => Menu.PlaySound(clipName);
		protected void SendAnnouncementInChat(string msg1, string msg2 = null, string msg3 = null)
		{
			if (gc.serverPlayer && gc.multiplayerMode)
				Menu.Agent.objectMult.SendChatAnnouncement(msg1, msg2 ?? string.Empty, msg3 ?? string.Empty);
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
		public IEnumerable<DisplayedUnlock> GetCancellations()
		{
			foreach (DisplayedUnlock unlock in Menu.Unlocks)
				if (unlock.Unlock.cancellations.Contains(Name) || Unlock.cancellations.Contains(unlock.Name))
					yield return unlock;
		}
	}
}
