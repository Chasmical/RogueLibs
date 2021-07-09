using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
	public abstract class CustomItem : HookBase<InvItem>
	{
		public InvItem Item => Instance;
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

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
		public static GameController gc => GameController.gameController;

		public ItemInfo ItemInfo { get; internal set; }

		protected override sealed void Initialize()
		{
			Item.Categories.AddRange(ItemInfo.Categories);
			SetupDetails();
			if (Item.itemIcon is null) Item.LoadItemSprite(ItemInfo.Name);
		}
		public abstract void SetupDetails();
		public virtual string GetCountString() => null;
	}
	public interface IItemUsable
	{
		bool UseItem();
	}
	public interface IItemCombinable
	{
		bool CombineFilter(InvItem other);
		bool CombineItems(InvItem other);
		CustomTooltip CombineCursorText(InvItem other);
		CustomTooltip CombineTooltip(InvItem other);
	}
	public interface IItemTargetable
	{
		bool TargetFilter(PlayfieldObject target);
		bool TargetObject(PlayfieldObject target);
		CustomTooltip TargetCursorText(PlayfieldObject target);
	}
	public interface IItemTargetableAnywhere
	{
		bool TargetFilter(Vector3 position);
		bool TargetPosition(Vector3 position);
		CustomTooltip TargetCursorText(Vector3 position);
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
		public CustomTooltip(IName name)
		{
			Text = name[LanguageService.Current] ?? name[LanguageService.FallBack];
			Color = null;
		}

		public string Text { get; }
		public Color? Color { get; }

		public static implicit operator CustomTooltip(string text) => new CustomTooltip(text);
		public static implicit operator CustomTooltip(int number) => new CustomTooltip(number.ToString());
		public static implicit operator CustomTooltip(float number) => new CustomTooltip(number.ToString());
		public static implicit operator CustomTooltip(CustomName name) => new CustomTooltip(name);
		public static implicit operator CustomTooltip(CustomNameInfo nameInfo) => new CustomTooltip(nameInfo);
	}
	public sealed class CustomItemFactory : HookFactoryBase<InvItem>
	{
		private readonly Dictionary<string, ItemEntry> itemsDict = new Dictionary<string, ItemEntry>();
		public override bool TryCreate(InvItem instance, out IHook<InvItem> hook)
		{
			if (instance != null && itemsDict.TryGetValue(instance.invItemName, out ItemEntry entry))
			{
				hook = entry.Initializer();
				if (hook is CustomItem custom)
					custom.ItemInfo = entry.ItemInfo;
				hook.Instance = instance;
				return true;
			}
			hook = null;
			return false;
		}
		public ItemInfo AddItem<T>() where T : CustomItem, new()
		{
			ItemInfo info = ItemInfo.Get<T>();
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Created custom item {typeof(T)} ({info.Name}).");
			itemsDict.Add(info.Name, new ItemEntry { Initializer = () => new T(), ItemInfo = info });
			return info;
		}

		private struct ItemEntry
		{
			public Func<IHook<InvItem>> Initializer;
			public ItemInfo ItemInfo;
		}
	}
}
