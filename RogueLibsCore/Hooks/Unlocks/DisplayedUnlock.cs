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
					int votes = Menu.Agent.isPlayer == 2 ? gc.twitchFunctions.voteCount[num + 5]
						: Menu.Agent.isPlayer == 3 ? gc.twitchFunctions.voteCount[num + 10]
                        : Menu.Agent.isPlayer == 4 ? gc.twitchFunctions.voteCount[num + 15]
						: gc.twitchFunctions.voteCount[num];
					Text = $"{Text} <color=yellow>#{num + 1 + (Menu.Agent.isPlayer - 1) * 5}</color> <color=cyan>({votes})</color>";
				}
			}
			else if (Menu.Type == UnlocksMenuType.TwitchRewards)
			{
				if (gc.twitchMode || gc.sessionDataBig.twitchOn && gc.sessionDataBig.twitchRewards)
				{
					int num = Menu.Unlocks.IndexOf(this);
					Text = $"{Text} <color=yellow>#{num + 1}</color> <color=cyan>({gc.twitchFunctions.voteCount[num]})</color>";
				}
			}
			else if (Menu.Type == UnlocksMenuType.TwitchDisasters)
			{
				if (gc.twitchMode || gc.sessionDataBig.twitchOn && gc.sessionDataBig.twitchRewards)
				{
					int num = Menu.Unlocks.IndexOf(this);
					Text = $"{Text} <color=yellow>#{num + 1}</color> <color=cyan>({gc.twitchFunctions.voteCount[num]})</color>";
				}
			}
			return name;
		}

		/// <summary>
		///   <para>Plays a clip with the specified <paramref name="clipName"/> to the player.</para>
		/// </summary>
		/// <param name="clipName"><see cref="AudioClip"/>'s name/id.</param>
		protected void PlaySound(string clipName) => gc.audioHandler.Play(Menu.Agent, clipName);
		/// <summary>
		///   <para>Sends an announcement in chat with the specified <paramref name="msg1"/>, <paramref name="msg2"/> and <paramref name="msg3"/>.</para>
		/// </summary>
		/// <param name="msg1">Message 1.</param>
		/// <param name="msg2">Message 2.</param>
		/// <param name="msg3">Message 3.</param>
		protected void SendAnnouncementInChat(string msg1, string msg2 = null, string msg3 = null)
		{
			if (gc.serverPlayer && gc.multiplayerMode)
				Menu.Agent.objectMult.SendChatAnnouncement(msg1, msg2 ?? string.Empty, msg3 ?? string.Empty);
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
