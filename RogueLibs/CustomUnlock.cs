using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game unlock.</para>
	/// </summary>
	public abstract class CustomUnlock : IComparable<CustomUnlock>
	{
		internal CustomUnlock(string id, CustomName name, CustomName description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		internal Unlock unlock;

		/// <summary>
		///   <para>Identifier of this <see cref="CustomUnlock"/>.</para>
		/// </summary>
		public string Id { get; }
		/// <summary>
		///   <para>Type of this <see cref="CustomUnlock"/>.</para>
		/// </summary>
		public abstract string Type { get; }

		/// <summary>
		///   <para>Localizable name of this <see cref="CustomUnlock"/>.</para>
		/// </summary>
		public CustomName Name { get; }
		/// <summary>
		///   <para>Localizable description of this <see cref="CustomUnlock"/>.</para>
		/// </summary>
		public CustomName Description { get; }

		/// <summary>
		///   <para>Determines the position of this <see cref="CustomUnlock"/> in lists. (Default: -1)</para>
		///   <para>&lt;0 - the <see cref="CustomUnlock"/> will be placed before all original unlocks;<br/>=0 - the <see cref="CustomUnlock"/> will be placed with original unlocks;<br/>&gt;0 - the <see cref="CustomUnlock"/> will be placed after all original unlocks.</para>
		/// </summary>
		public int SortingOrder { get; set; } = -1;
		/// <summary>
		///   <para>Determines the position of this <see cref="CustomUnlock"/> in lists, if its SortingOrder equals to another's SortingOrder. (Default: 0)</para>
		/// </summary>
		public int SortingIndex { get; set; } = 0;

		/// <summary>
		///   <para>Compares this <see cref="CustomUnlock"/> with <paramref name="another"/>.</para>
		/// </summary>
		public int CompareTo(CustomUnlock another)
		{
			int res = SortingOrder.CompareTo(another.SortingOrder);
			return res != 0 ? res : SortingIndex.CompareTo(another.SortingIndex);
		}

		private bool unlocked = false;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomUnlock"/> is unlocked. Use <see cref="DoUnlock(bool)"/> for unlocking.</para>
		/// </summary>
		public bool Unlocked
		{
			get => unlock != null ? (unlocked = unlock.unlocked) : unlocked;
			set
			{
				if (unlock != null) unlock.unlocked = value;
				unlocked = value;
			}
		}

		private int? unlockCost = null;
		/// <summary>
		///   <para>Determines the unlock cost of this <see cref="CustomUnlock"/>, in nuggets. Set to <see langword="null"/> to make it non-purchasable. (Default: <see langword="null"/>)</para>
		/// </summary>
		public int? UnlockCost
		{
			get => unlockCost;
			set
			{
				if (unlock != null) unlock.cost = value ?? 0;
				unlockCost = value;
			}
		}

		/// <summary>
		///   <para>Determines whether this <see cref="CustomUnlock"/> will be available in standard unlock lists.</para>
		/// </summary>
		public abstract bool Available { get; set; }

		private List<string> categories = new List<string>();
		/// <summary>
		///   <para>Determines the categories of this <see cref="CustomUnlock"/>. Barely used in the game.</para>
		/// </summary>
		public List<string> Categories
		{
			get => unlock != null ? (categories = unlock.categories) : categories;
			set
			{
				if (unlock != null)
					unlock.categories = value;
				categories = value;
			}
		}

		private List<string> conflicting = new List<string>();
		/// <summary>
		///   <para>Determines the conflicting unlocks (also known as cancellations) of this <see cref="CustomUnlock"/>.</para>
		///   <para>Don't edit the list yourself! Use methods: <see cref="AddConflicting(string[])"/> and <see cref="RemoveConflicting(string[])"/>.</para>
		/// </summary>
		public List<string> Conflicting
		{
			get => unlock != null ? (conflicting = unlock.cancellations) : conflicting;
			set
			{
				if (unlock != null)
					unlock.cancellations = value;
				conflicting = value;
			}
		}

		/// <summary>
		///   <para>Adds the specified <paramref name="customUnlocks"/> to the conflicting list.</para>
		/// </summary>
		public void AddConflicting(params CustomUnlock[] customUnlocks)
		{
			foreach (CustomUnlock u in customUnlocks)
			{
				if (u.Id == Id) continue;
				if (!Conflicting.Contains(u.Id))
					Conflicting.Add(u.Id);
				if (!u.Conflicting.Contains(Id))
					u.Conflicting.Add(Id);
			}
		}
		/// <summary>
		///   <para>Removes the specified <paramref name="customUnlocks"/> from the conflicting list.</para>
		/// </summary>
		public void RemoveConflicting(params CustomUnlock[] customUnlocks)
		{
			foreach (CustomUnlock u in customUnlocks)
			{
				Conflicting.Remove(u.Id);
				u.Conflicting.Remove(Id);
			}
		}

		/// <summary>
		///   <para>Adds the specified <paramref name="unlockIds"/> to the conflicting list.</para>
		/// </summary>
		public void AddConflicting(params string[] unlockIds)
		{
			bool flag = unlock != null;
			foreach (string id in unlockIds)
			{
				if (id == Id) continue;
				if (!Conflicting.Contains(id))
					Conflicting.Add(id);
				if (unlock != null)
					foreach (Unlock u in GameController.gameController.sessionDataBig.unlocks)
						if (u.unlockName == id && !u.cancellations.Contains(Id))
							u.cancellations.Add(Id);
			}
		}
		/// <summary>
		///   <para>Removes the specified <paramref name="unlockIds"/> from the conflicting list.</para>
		/// </summary>
		public void RemoveConflicting(params string[] unlockIds)
		{
			foreach (string id in unlockIds)
			{
				Conflicting.Remove(id);
				if (unlock != null)
					foreach (Unlock u in GameController.gameController.sessionDataBig.unlocks)
						if (u.unlockName == id)
							u.cancellations.Remove(Id);
			}
		}

		private List<string> prerequisites = new List<string>();
		/// <summary>
		///   <para>Determines the prerequisite unlocks for this <see cref="CustomUnlock"/>. Without all of them, the <see cref="CustomUnlock"/> will be unavailable.</para>
		/// </summary>
		public List<string> Prerequisites
		{
			get => unlock != null ? (prerequisites = unlock.prerequisites) : prerequisites;
			set
			{
				if (unlock != null)
					unlock.prerequisites = value;
				prerequisites = value;
			}
		}

		private List<string> recommendations = new List<string>();
		/// <summary>
		///   <para>Determines the recommended unlocks for this <see cref="CustomUnlock"/>. They are displayed in the Character Creation menu.</para>
		/// </summary>
		public List<string> Recommendations
		{
			get => unlock != null ? (recommendations = unlock.recommendations) : recommendations;
			set
			{
				if (unlock != null)
					unlock.recommendations = value;
				recommendations = value;
			}
		}

		/// <summary>
		///   <para>Determines the special unlock information. See <see cref="Unlocks.GetSpecialUnlockInfo(string, Unlock)"/> for more info.</para>
		/// </summary>
		public Func<Unlock, string> GetSpecialUnlockInfo { get; set; }

		private Sprite sprite;
		/// <summary>
		///   <para>Determines the <see cref="UnityEngine.Sprite"/> that will be used for this <see cref="CustomUnlock"/>.</para>
		/// </summary>
		public Sprite Sprite
		{
			get => sprite;
			set
			{
				GameResources gr = GameController.gameController?.gameResources;
				if (gr != null)
				{
					if (value != null)
					{
						if (gr.itemDic.ContainsKey(Id))
							gr.itemDic[Id] = value;
						else gr.itemDic.Add(Id, value);

						int index = gr.itemList.IndexOf(sprite);
						if (index != -1) gr.itemList[index] = value;
						else gr.itemList.Add(value);
					}
					else
					{
						gr.itemDic.Remove(Id);
						gr.itemList.Remove(sprite);
					}
				}
				sprite = value;
			}
		}

		/// <summary>
		///   <para>Event that is invoked when this unlock is unlocked using <see cref="Unlocks.DoUnlock(string, string)"/>.</para>
		/// </summary>
		public event Action OnUnlocked;

		internal void InvokeOnUnlockedEvent() => OnUnlocked?.Invoke();

		/// <summary>
		///   <para>Unlocks this <see cref="CustomUnlock"/> using <see cref="Unlocks.DoUnlock(string, string)"/> and updates all menus.</para>
		/// </summary>
		/// <param name="playSound">Determines whether the "BuyUnlock" sound effect should be played.</param>
		public void DoUnlock(bool playSound = true)
		{
			GameController gc = GameController.gameController;
			if (playSound) gc?.audioHandler?.PlayMust(gc?.playerAgent, "BuyUnlock");
			if (unlock == null)
			{
				unlocked = true;
				return;
			}
			gc.unlocks.DoUnlock(Id, Type);

			ScrollingMenu sm = gc.mainGUI.scrollingMenuScript;
			CharacterCreation cc = gc.mainGUI.characterCreationScript;

			if (sm != null && sm.gameObject.activeSelf)
				if (Type == "Challenge")
				{
					List<Unlock> listUnlocks = (List<Unlock>)AccessTools.Field(typeof(ScrollingMenu), "listUnlocks").GetValue(sm);
					for (int i = 0; i < sm.numButtons; i++)
						sm.SetupChallenges(sm.buttonsData[i], listUnlocks[i]);

					sm.gc.SetDailyRunText();
					sm.UpdateOtherVisibleMenus(sm.menuType);
					try { sm.scrollerController.myScroller.RefreshActiveCellViews(); } catch { }
				}
				else if (Type == "Item")
				{
					List<Unlock> listUnlocks = (List<Unlock>)AccessTools.Field(typeof(ScrollingMenu), "listUnlocks").GetValue(sm);

					if (sm.menuType == "Items")
					{
						for (int i = 0; i < sm.numButtons; i++)
							sm.SetupItemUnlocks(sm.buttonsData[i], listUnlocks[i]);
						sm.UpdateActiveCount();
					}
					else if (sm.menuType == "FreeItems")
					{
						for (int i = 0; i < sm.numButtons; i++)
							sm.SetupFreeItems(sm.buttonsData[i], listUnlocks[i]);
					}

					sm.UpdateOtherVisibleMenus(sm.menuType);
					try { sm.scrollerController.myScroller.RefreshActiveCellViews(); } catch { }
				}
				else if (Type == "Trait")
				{
					List<Unlock> listUnlocks = (List<Unlock>)AccessTools.Field(typeof(ScrollingMenu), "listUnlocks").GetValue(sm);
					for (int i = 0; i < sm.numButtons; i++)
						sm.SetupTraitUnlocks(sm.buttonsData[i], listUnlocks[i]);

					sm.UpdateActiveCount();
					sm.UpdateOtherVisibleMenus(sm.menuType);
					try { sm.scrollerController.myScroller.RefreshActiveCellViews(); } catch { }
				}

			if (cc != null && cc.gameObject.activeSelf)
				if (Type == "Item")
				{
					for (int i = 0; i < cc.numButtonsItems; i++)
						cc.SetupItems(cc.buttonsDataItems[i], cc.listUnlocksItems[i]);
					cc.scrollerControllerItems.myScroller.RefreshActiveCellViews();
				}
				else if (Type == "Ability")
				{
					for (int i = 0; i < cc.numButtonsAbilities; i++)
						cc.SetupAbilities(cc.buttonsDataAbilities[i], cc.listUnlocksAbilities[i]);
					cc.scrollerControllerItems.myScroller.RefreshActiveCellViews();
				}
				else if (Type == "Trait")
				{
					for (int i = 0; i < cc.numButtonsTraits; i++)
						cc.SetupTraits(cc.buttonsDataTraits[i], cc.listUnlocksTraits[i]);
					cc.scrollerControllerItems.myScroller.RefreshActiveCellViews();
				}
		}

	}
}
