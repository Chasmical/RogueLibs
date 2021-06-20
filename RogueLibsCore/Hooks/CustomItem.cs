using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a base class for all custom items.</para>
	/// </summary>
	public abstract class CustomItem : HookBase<InvItem>
	{
		/// <summary>
		///   <para>Gets the associated <see cref="InvItem"/> object.</para>
		/// </summary>
		public InvItem Item => Instance;

		/// <summary>
		///   <para>Gets the inventory, containing the item.</para>
		/// </summary>
		public InvDatabase Inventory => Item.database;
		/// <summary>
		///   <para>Gets the item's owner.</para>
		/// </summary>
		public Agent Owner => Item.agent;
		/// <summary>
		///   <para>Gets/sets the amount of the item. Automatically destroys it, if there's 0 or less of it.</para>
		/// </summary>
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

		/// <summary>
		///   <para>Gets the game's <see cref="GameController"/> that controls the game.</para>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public static GameController gc => GameController.gameController;

		/// <summary>
		///   <para>Gets the default information about the item, defined in the type's attributes.</para>
		/// </summary>
		public ItemInfo ItemInfo { get; internal set; }

		/// <inheritdoc/>
		protected override sealed void Initialize()
		{
			Item.Categories.AddRange(ItemInfo.Categories);
			SetupDetails();
			if (Item.itemIcon == null) Item.LoadItemSprite(ItemInfo.Name);
		}
		/// <summary>
		///   <para>Method that is called once, when creating a new item. Set up your item's fields and properties here.</para>
		/// </summary>
		public abstract void SetupDetails();
		/// <summary>
		///   <para>Plays the item usage animation.</para>
		/// </summary>
		public void UseItemAnim() => new ItemFunctions().UseItemAnim(Item, Owner);
	}
	/// <summary>
	///   <para>Specifies that this <see cref="CustomItem"/> can be used/consumed.</para>
	/// </summary>
	public interface IItemUsable
	{
		/// <summary>
		///   <para>Determines what will happen when the player uses/consumes this item.</para>
		/// </summary>
		void UseItem();
	}
	/// <summary>
	///   <para>Specifies that this <see cref="CustomItem"/> can be combined with other items.<br/><b>The item must be of "Combine" type!</b></para>
	/// </summary>
	public interface IItemCombinable
	{
		/// <summary>
		///   <para>Determines what items this item can be combined with.</para>
		/// </summary>
		/// <param name="other">Other item.</param>
		/// <returns><see langword="true"/>, if this item can be combined with the specified <paramref name="other"/> item; otherwise, <see langword="false"/>.</returns>
		bool CombineFilter(InvItem other);
		/// <summary>
		///   <para>Determines what will happen when the player combines this item with the specified <paramref name="other"/> item.</para>
		/// </summary>
		/// <param name="other">Other item.</param>
		void CombineItems(InvItem other);
		/// <summary>
		///   <para>Determines the short tooltip text, that will be displayed in the top-left corner of the inventory slot of the specified <paramref name="other"/> item.</para>
		/// </summary>
		/// <param name="other">Other item.</param>
		/// <returns>Text and color of the tooltip to display.</returns>
		CustomTooltip CombineTooltip(InvItem other);
	}
	/// <summary>
	///   <para>Specifies that this <see cref="CustomItem"/> can be used on objects.</para>
	/// </summary>
	public interface IItemTargetable
	{
		/// <summary>
		///   <para>Determines what objects this item can be used on.</para>
		/// </summary>
		/// <param name="target">Target object.</param>
		/// <returns><see langword="true"/>, if this item can be used on the specified <paramref name="target"/> object; otherwise, <see langword="false"/>.</returns>
		bool TargetFilter(PlayfieldObject target);
		/// <summary>
		///   <para>Determines what will happen when the player uses this item on the specified <paramref name="target"/> object.</para>
		/// </summary>
		/// <param name="target">Target object.</param>
		void TargetObject(PlayfieldObject target);
		/// <summary>
		///   <para>Determines the tooltip text, that will be displayed near the cursor, when hovering over the specified <paramref name="target"/> object.</para>
		/// </summary>
		/// <param name="target">Target object.</param>
		/// <returns>Text and color of the tooltip to display.</returns>
		CustomTooltip TargetTooltip(PlayfieldObject target);
	}
	public interface IItemCustomCount
	{
		CustomTooltip GetCount();
	}
	/// <summary>
	///   <para>Value type, containing information about a custom tooltip - its text and color.</para>
	/// </summary>
	public struct CustomTooltip
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomTooltip"/> with the specified <paramref name="text"/>.</para>
		/// </summary>
		/// <param name="text">Tooltip text.</param>
		public CustomTooltip(string text)
		{
			Text = text;
			Color = null;
		}
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomTooltip"/> with the specified <paramref name="text"/> and <paramref name="color"/>.</para>
		/// </summary>
		/// <param name="text">Tooltip text.</param>
		/// <param name="color">Tooltip color.</param>
		public CustomTooltip(string text, Color color)
		{
			Text = text;
			Color = color;
		}

		/// <summary>
		///   <para>Tooltip's text.</para>
		/// </summary>
		public string Text { get; }
		/// <summary>
		///   <para>Tooltip's color.</para>
		/// </summary>
		public Color? Color { get; }

		/// <summary>
		///   <para>Converts a <see cref="string"/> into a <see cref="CustomTooltip"/>.</para>
		/// </summary>
		/// <param name="text">Tooltip text.</param>
		public static implicit operator CustomTooltip(string text) => new CustomTooltip(text);
		/// <summary>
		///   <para>Converts an <see cref="int"/> into a <see cref="CustomTooltip"/>.</para>
		/// </summary>
		/// <param name="number">Tooltip text.</param>
		public static implicit operator CustomTooltip(int number) => new CustomTooltip(number.ToString());
		/// <summary>
		///   <para>Converts a <see cref="float"/> into a <see cref="CustomTooltip"/>.</para>
		/// </summary>
		/// <param name="number">Tooltip text.</param>
		public static implicit operator CustomTooltip(float number) => new CustomTooltip(number.ToString());
	}
	/// <summary>
	///   <para>Represents a specialized <see cref="IHookFactory{T}"/> for <see cref="CustomItem"/> types.</para>
	/// </summary>
	public sealed class CustomItemFactory : HookFactoryBase<InvItem>
	{
		private readonly Dictionary<string, ItemEntry> itemsDict = new Dictionary<string, ItemEntry>();
		/// <inheritdoc/>
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
		/// <summary>
		///   <para>Adds the specified <typeparamref name="T"/> item type to the factory.</para>
		/// </summary>
		/// <typeparam name="T">Custom item's type.</typeparam>
		public ItemInfo AddItem<T>() where T : CustomItem, new()
		{
			ItemInfo info = ItemInfo.Get<T>();
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
