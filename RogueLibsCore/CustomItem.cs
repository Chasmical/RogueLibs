using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
	public abstract class CustomItem : IHook<InvItem>
	{
		public InvItem Item { get; private set; }
		InvItem IHook<InvItem>.Instance { get => Item; set => Item = value; }
		object IHook.Instance { get => Item; set => Item = (InvItem)value; }

		public InvDatabase Inventory => Item.database;
		public Agent Owner => Item.agent;
		public int Count
		{
			get => Item.invItemCount;
			set
			{
				int delta = value - Count;
				if (delta < 0) Inventory.SubtractFromItemCount(Item, -delta);
				else Item.invItemCount += delta;
			}
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public static GameController gc => GameController.gameController;

		public CustomItemInfo ItemInfo { get; internal set; }

		void IHook.Initialize()
		{
			Item.Categories.AddRange(ItemInfo.Categories);
			SetupDetails();
			if (Item.itemIcon == null) Item.LoadItemSprite(ItemInfo.Name);
		}
		public abstract void SetupDetails();
	}
	public interface IItemUsable
	{
		void UseItem();
	}
	public interface IItemCombinable
	{
		bool CombineFilter(InvItem other);
		void CombineItems(InvItem other);
		CustomTooltip CombineTooltip(InvItem other);
	}
	public interface IItemTargetable
	{
		bool TargetFilter(PlayfieldObject target);
		void TargetObject(PlayfieldObject target);
		CustomTooltip TargetTooltip(PlayfieldObject target);
	}
	public struct CustomTooltip
	{
		public CustomTooltip(string text)
		{
			Text = text;
			Color = null;
		}
		public CustomTooltip(string text, Color color)
		{
			Text = text;
			Color = color;
		}

		public string Text { get; }
		public Color? Color { get; }

		public static implicit operator CustomTooltip(string text) => new CustomTooltip(text);
	}
}
