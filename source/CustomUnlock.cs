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

		internal Unlock unlock;

		public string Id { get; }
		public abstract string Type { get; }

		public CustomName Name { get; }
		public CustomName Description { get; }

		public int SortingOrder { get; set; } = -1;
		public int SortingIndex { get; set; } = 0;

		public int CompareTo(CustomUnlock other)
		{
			int res = SortingOrder.CompareTo(other.SortingOrder);
			return res != 0 ? res : SortingIndex.CompareTo(other.SortingIndex);
		}

		private bool unlocked = false;
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
		public int? UnlockCost
		{
			get => unlockCost;
			set
			{
				if (unlock != null) unlock.cost = value ?? 0;
				unlockCost = value;
			}
		}

		public abstract bool Available { get; set; }

		private List<string> categories = new List<string>();
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

		private List<string> prerequisites = new List<string>();
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

		private List<string> specialAbilities = new List<string>();
		public List<string> SpecialAbilities
		{
			get => unlock != null ? (specialAbilities = unlock.specialAbilities) : specialAbilities;
			set
			{
				if (unlock != null)
					unlock.specialAbilities = value;
				specialAbilities = value;
			}
		}

		private Sprite sprite;
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
	}
}
