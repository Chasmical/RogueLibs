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
	///   <para>Base unlock wrapper class, that can be displayed in the menus.</para>
	/// </summary>
	public abstract class DisplayedUnlock : UnlockWrapper, IComparable<DisplayedUnlock>
	{
		/// <summary>
		///   <para>Initializes a new instance of the current type with the specified <paramref name="name"/> and <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id.</param>
		/// <param name="type">Unlock's type.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		protected DisplayedUnlock(string name, string type, bool unlockedFromStart) : base(name, type, unlockedFromStart) { }
		internal DisplayedUnlock(Unlock unlock) : base(unlock) { }

		/// <summary>
		///   <para>Gets the <see cref="UnlocksMenu"/> that the unlock is displayed in.</para>
		/// </summary>
		public UnlocksMenu Menu { get; internal set; }
		/// <summary>
		///   <para>Gets the <see cref="global::ButtonData"/> associated with the unlock.</para>
		/// </summary>
		public ButtonData ButtonData { get; internal set; }
		/// <summary>
		///   <para>Gets/sets the button's state.</para>
		/// </summary>
		public UnlockButtonState State { get => ButtonData.GetState(); set => ButtonData.SetState(value); }
		/// <summary>
		///   <para>Gets/sets the button's text.</para>
		/// </summary>
		public string Text { get => ButtonData.buttonText; set => ButtonData.buttonText = value; }

		/// <summary>
		///   <para>Get/sets the unlock's sorting order in the menus.</para>
		/// </summary>
		public int SortingOrder { get; set; }
		/// <summary>
		///   <para>Get/sets the unlock's sorting index in the menus.</para>
		/// </summary>
		public int SortingIndex { get; set; }
		/// <summary>
		///   <para>Get/sets whether the unlock's state (unlocked, purchasable, unavailable, locked) will affect the unlock's position in the menus.</para>
		/// </summary>
		public bool IgnoreStateSorting { get; set; }
		/// <summary>
		///   <para>Compares the current unlock with the <paramref name="other"/> unlock and returns an integer, indicating their position relative to each other.</para>
		/// </summary>
		/// <param name="other">Other <see cref="DisplayedUnlock"/>.</param>
		/// <returns>Integer, indicating the current unlock's position relative to the specified <paramref name="other"/> unlock.</returns>
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

		/// <summary>
		///   <para>Updates the button's state.</para>
		/// </summary>
		public virtual void UpdateButton() => UpdateButton(IsEnabled, UnlockButtonState.Selected, UnlockButtonState.Normal);
		/// <summary>
		///   <para>Helper method for updating the button's state, using the default <see cref="UnlockButtonState.Selected"/> and <see cref="UnlockButtonState.Normal"/> states.</para>
		/// </summary>
		/// <param name="isEnabledOrSelected">Determines whether the unlock is considered enabled or selected.</param>
		protected void UpdateButton(bool isEnabledOrSelected) => UpdateButton(isEnabledOrSelected, UnlockButtonState.Selected, UnlockButtonState.Normal);
		/// <summary>
		///   <para>Helper method for updating the button's state, using the specified <paramref name="selected"/> and <paramref name="normal"/> states.</para>
		/// </summary>
		/// <param name="isEnabledOrSelected">Determines whether the unlock is considered enabled or selected.</param>
		/// <param name="selected">Enabled/selected state.</param>
		/// <param name="normal">Disabled/not selected state.</param>
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

		/// <summary>
		///   <para>Determines what will happen when you push the unlock's button.</para>
		/// </summary>
		public abstract void OnPushedButton();
		/// <summary>
		///   <para>Gets the unlock's display name.</para>
		/// </summary>
		/// <returns>Unlock's display name, if it's unlocked or purchasable; otherwise, "?????".</returns>
		public virtual string GetName() => IsUnlocked || Unlock.nowAvailable ? gc.nameDB.GetName(Name, Unlock.unlockNameType) : "?????";
		/// <summary>
		///   <para>Gets the unlock's display description, including the cancellations, recommendations and prerequisites.</para>
		/// </summary>
		/// <returns>Unlock's display description, if it's unlocked or purchasable; otherwise, "?????". Includes the cancellations and recommendations, if it's unlocked or purchasable. Includes the prerequisites and the unlock cost, if it's purchasable or locked.</returns>
		public virtual string GetDescription()
		{
			if (IsUnlocked || Unlock.nowAvailable)
			{
				string text = gc.nameDB.GetName(Name, Unlock.unlockDescriptionType);
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
		/// <summary>
		///   <para>Gets the unlock's display image.</para>
		/// </summary>
		/// <returns>Unlock's sprite/image, if it's unlocked or purchasable; otherwise, <see langword="null"/>.</returns>
		public virtual Sprite GetImage() => (IsUnlocked || Unlock.nowAvailable) && RogueLibsInternals.ExtraSprites.TryGetValue(Name, out Sprite image) ? image : null;

		/// <summary>
		///   <para>Adds the unlock's cancellations to the <paramref name="description"/>.</para>
		/// </summary>
		/// <param name="description">Unlock's description.</param>
		protected void AddCancellationsTo(ref string description)
		{
			if (Unlock.cancellations.Count > 0)
			{
				description += $"\n\n<color=orange>{gc.nameDB.GetName("Cancels", "Interface")}:</color>\n" +
					string.Join(", ", Unlock.cancellations.ConvertAll(unlockName =>
					{
						DisplayedUnlock unlock = (DisplayedUnlock)gc.sessionDataBig.unlocks.Find(u => u.unlockName == unlockName)?.__RogueLibsCustom;
						return unlock?.GetName();
					}));
			}
		}
		/// <summary>
		///   <para>Adds the unlock's recommendations to the <paramref name="description"/>.</para>
		/// </summary>
		/// <param name="description">Unlock's description.</param>
		protected void AddRecommendationsTo(ref string description)
		{
			if (Unlock.recommendations.Count > 0)
			{
				description += $"\n\n<color=cyan>{gc.nameDB.GetName("Recommends", "Interface")}:</color>\n" +
					string.Join(", ", Unlock.recommendations.ConvertAll(unlockName =>
					{
						DisplayedUnlock unlock = (DisplayedUnlock)gc.sessionDataBig.unlocks.Find(u => u.unlockName == unlockName)?.__RogueLibsCustom;
						return unlock?.GetName();
					}));
			}
		}
		/// <summary>
		///   <para>Adds the unlock's prerequisites, special unlock conditions and/or unlock cost to the <paramref name="description"/>.</para>
		/// </summary>
		/// <param name="description">Unlock's description.</param>
		protected void AddPrerequisitesTo(ref string description)
		{
			if (Unlock.prerequisites.Count > 0 || UnlockCost != 0)
			{
				string add = $"\n\n<color=cyan>{gc.nameDB.GetName("Prerequisites", "Unlock")}:</color>\n" +
					string.Join(", ", Unlock.prerequisites.ConvertAll(unlockName =>
					{
						DisplayedUnlock unlock = (DisplayedUnlock)gc.sessionDataBig.unlocks.Find(u => u.unlockName == unlockName).__RogueLibsCustom;
						string name = unlock.GetName();
						if (unlock.IsUnlocked) name = $"<color=#80808080>{name}</color>";
						return name;
					}));
				if (UnlockCost == -2) add += "\n\n" + gc.unlocks.GetSpecialUnlockInfo(Name, Unlock);
				description += add;
			}
			if (Unlock.cost == -2)
			{
				description += $"\n<color=cyan>{gc.nameDB.GetName("Prerequisites", "Unlock")}:</color>\n" +
					gc.unlocks.GetSpecialUnlockInfo(Name, Unlock) + "\n";
			}
			else if (Unlock.cost > 0)
			{
				description += $"\n<color=cyan>{gc.nameDB.GetName("UnlockFor", "Unlock")} ${Unlock.cost}</color>\n";
			}
		}

		/// <summary>
		///   <para>Plays a clip with the specified <paramref name="clipName"/> to the player.</para>
		/// </summary>
		/// <param name="clipName"><see cref="AudioClip"/>'s name/id.</param>
		public void PlaySound(string clipName) => gc.audioHandler.Play(Menu.Agent, clipName);
		/// <summary>
		///   <para>Sends an announcement in chat with the specified <paramref name="msg1"/>, <paramref name="msg2"/> and <paramref name="msg3"/>.</para>
		/// </summary>
		/// <param name="msg1">Message 1.</param>
		/// <param name="msg2">Message 2.</param>
		/// <param name="msg3">Message 3.</param>
		public void SendAnnouncementInChat(string msg1, string msg2 = "", string msg3 = "")
		{
			if (gc.serverPlayer && gc.multiplayerMode)
				Menu.Agent.objectMult.SendChatAnnouncement(msg1, msg2, msg3);
		}

		/// <summary>
		///   <para>Updates the unlock's menu.</para>
		/// </summary>
		public void UpdateMenu() => Menu.UpdateMenu();
		/// <summary>
		///   <para>Updates all unlocks' buttons.</para>
		/// </summary>
		public void UpdateAllUnlocks()
		{
			foreach (DisplayedUnlock unlock in Menu.Unlocks)
			{
				unlock.UpdateUnlock();
				unlock.UpdateButton();
			}
		}
		/// <summary>
		///   <para>Gets all unlocks, that are cancelled by the current unlock.</para>
		/// </summary>
		public IEnumerable<DisplayedUnlock> GetCancellations()
		{
			foreach (DisplayedUnlock unlock in Menu.Unlocks)
				if (unlock.Unlock.cancellations.Contains(Name) || Unlock.cancellations.Contains(unlock.Name))
					yield return unlock;
		}
	}
}
