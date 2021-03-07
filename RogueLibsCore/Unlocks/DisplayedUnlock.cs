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
				if (Menu.Type == UnlocksMenuType.CharacterCreation && CharacterCreationCost != 0)
					Text += $" | <color={(CharacterCreationCost < 0 ? "lime" : "orange")}>{CharacterCreationCost}</color>";
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
}
