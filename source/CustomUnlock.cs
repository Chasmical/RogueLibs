using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RogueLibsCore
{
	public abstract class CustomUnlock : IComparable<CustomUnlock>
	{
		internal CustomUnlock(string id, CustomName name, CustomName description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		public string Id { get; }
		public abstract string Type { get; }

		public bool OverrideOriginal { get; set; }

		public CustomName Name { get; }
		public CustomName Description { get; }

		public int SortingOrder { get; set; } = -1;
		public int SortingIndex { get; set; } = 0;

		int IComparable<CustomUnlock>.CompareTo(CustomUnlock other)
		{
			int res = SortingOrder.CompareTo(other.SortingOrder);
			return res != 0 ? res : SortingIndex.CompareTo(other.SortingIndex);
		}

		private bool unlockedSave = false;
		public bool UnlockedSave
		{
			get => unlockedSave;
			set
			{
				unlockedSave = value;
				Unlock generalUnlock = GameController.gameController.sessionDataBig.unlocks.Find(u => u.unlockName == Id && u.unlockType == Type);
				if (generalUnlock == null)
					RogueLibs.PluginInstance.Validate(this);
				else
					generalUnlock.unlocked = IsUnlocked;
			}
		}
		private bool unlockedInitially = true;
		public bool UnlockedInitially
		{
			get => unlockedInitially;
			set
			{
				unlockedInitially = value;
				Unlock generalUnlock = GameController.gameController.sessionDataBig.unlocks.Find(u => u.unlockName == Id && u.unlockType == Type);
				if (generalUnlock == null)
					RogueLibs.PluginInstance.Validate(this);
				else
					generalUnlock.unlocked = IsUnlocked;
			}
		}
		public bool IsUnlocked => UnlockedInitially || UnlockedSave;

		private int unlockCost = 0;
		public int UnlockCost
		{
			get => unlockCost;
			set
			{
				Unlock generalUnlock = GameController.gameController.sessionDataBig.unlocks.Find(u => u.unlockName == Id && u.unlockType == Type);
				if (generalUnlock == null)
					RogueLibs.PluginInstance.Validate(this);
				else
					generalUnlock.cost = unlockCost = value;
			}
		}

		public bool Available { get; set; } = true;
		public bool AvailableInCharacterCreation { get; set; } = true;

		public Action<ButtonData, Unlock> CustomSetupHandler;
		public Action<ScrollingMenu, ButtonHelper> CustomPressHandler;

		public bool ShowInMenu { get; set; } = true;

		public List<string> Conflicting { get; set; } = new List<string>();

		private Sprite sprite;
		public Sprite Sprite
		{
			get => sprite;
			set
			{
				GameResources gr = GameController.gameController.gameResources;

				int index = gr.itemList.IndexOf(sprite);
				if (index != -1) gr.itemList[index] = sprite = value;
				else gr.itemList.Add(sprite = value);

				if (gr.itemDic.ContainsKey(Id)) gr.itemDic[Id] = value;
				else gr.itemDic.Add(Id, value);
			}
		}
	}
}
