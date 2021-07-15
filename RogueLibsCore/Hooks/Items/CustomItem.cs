using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom item.</para>
	/// </summary>
	public abstract class CustomItem : HookBase<InvItem>
	{
		/// <summary>
		///   <para>Gets the current <see cref="InvItem"/> instance.</para>
		/// </summary>
		public InvItem Item => Instance;
		/// <summary>
		///   <para>Gets the item's inventory.</para>
		/// </summary>
		public InvDatabase Inventory => Item.database;
		/// <summary>
		///   <para>Gets the item's owner.</para>
		/// </summary>
		public Agent Owner => Item.agent;
		/// <summary>
		///   <para>Gets or sets the item's current count.</para>
		/// </summary>
		public int Count
		{
			get => Item.invItemCount;
			set
			{
				int delta = value - Count;
				if (delta < 0 && Inventory != null)
					Inventory.SubtractFromItemCount(Item, -delta);
				else Item.invItemCount += delta;
			}
		}

		/// <summary>
		///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
		public static GameController gc => GameController.gameController;

		/// <summary>
		///   <para>Gets the custom item's metadata.</para>
		/// </summary>
		public ItemInfo ItemInfo { get; internal set; }

		/// <inheritdoc/>
		protected override sealed void Initialize()
		{
			Item.Categories.AddRange(ItemInfo.Categories);
			SetupDetails();
			if (Item.itemIcon is null) Item.LoadItemSprite(ItemInfo.Name);
		}
		/// <summary>
		///   <para>The method that is called when the item's details are set up.</para>
		/// </summary>
		public abstract void SetupDetails();
		/// <summary>
		///   <para>Returns the custom item's count text.</para>
		/// </summary>
		/// <returns>The custom count string, if overriden; otherwise, <see langword="null"/>.</returns>
		public virtual CustomTooltip GetCountString()
		{
			if (Item.noCountText) return default;

			if (Item.rechargeAmount > 0)
			{
				if (Count == Item.rechargeAmount)
					return new CustomTooltip(Item.rechargeAmount - 1, Color.red);
				else if (Item.invItemCount != 1)
					return new CustomTooltip(Count - 1, Color.red);
				else return default;
			}

			if (Item.stackable || Item.stackableContents || Item.isArmor || Item.isArmorHead
				|| Item.itemType == ItemTypes.WeaponProjectile || Item.itemType == ItemTypes.WeaponMelee)
				return new CustomTooltip(Count, Color.white);

			return default;
		}
	}
	/// <summary>
	///   <para>Indicates that a custom item is usable.</para>
	/// </summary>
	public interface IItemUsable
	{
		/// <summary>
		///   <para>Uses the item. The return value indicates whether the usage succeeded or failed.</para>
		/// </summary>
		/// <returns><see langword="true"/>, if the current item was successfully used; otherwise, <see langword="false"/>.</returns>
		bool UseItem();
	}
	/// <summary>
	///   <para>Indicates that a custom item is combinable.</para>
	/// </summary>
	public interface IItemCombinable
	{
		/// <summary>
		///   <para>Determines whether to highlight the <paramref name="other"/> item in the inventory when combining the current item.</para>
		/// </summary>
		/// <param name="other">The other item.</param>
		/// <returns><see langword="true"/>, if the current item can be combined with the <paramref name="other"/> item; otherwise, <see langword="false"/>.</returns>
		bool CombineFilter(InvItem other);
		/// <summary>
		///   <para>Combines the current item with the <paramref name="other"/> item. The return value indicates whether the combining succeeded or failed.</para>
		/// </summary>
		/// <param name="other">The other item.</param>
		/// <returns><see langword="true"/>, if the current item was successfully combined with the <paramref name="other"/> item; otherwise, <see langword="false"/>.</returns>
		bool CombineItems(InvItem other);
		/// <summary>
		///   <para>Determines the cursor text when hovering over the <paramref name="other"/> item.</para>
		/// </summary>
		/// <param name="other">The other item.</param>
		/// <returns>The cursor text to display, or <see langword="null"/> to display the default cursor text.</returns>
		CustomTooltip CombineCursorText(InvItem other);
		/// <summary>
		///   <para>Determines the combine tooltip in the <paramref name="other"/> item's slot.</para>
		/// </summary>
		/// <param name="other">The other item.</param>
		/// <returns>The combine tooltip to display, or <see langword="null"/> to not display anything.</returns>
		CustomTooltip CombineTooltip(InvItem other);
	}
	/// <summary>
	///   <para>Indicates that a custom item is targetable.</para>
	/// </summary>
	public interface IItemTargetable
	{
		/// <summary>
		///   <para>Determines whether to highlight the <paramref name="target"/> object when targeting the current item.</para>
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <returns><see langword="true"/>, if the current item can be targeted at the <paramref name="target"/> object; otherwise, <see langword="false"/>.</returns>
		bool TargetFilter(PlayfieldObject target);
		/// <summary>
		///   <para>Uses the current item on the <paramref name="target"/> object. The return value indicates whether the usage succeeded or failed.</para>
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <returns><see langword="true"/>, if the item was successfully used on the <paramref name="target"/> object; otherwise, <see langword="false"/>.</returns>
		bool TargetObject(PlayfieldObject target);
		/// <summary>
		///   <para>Determines the cursor text when hovering over the <paramref name="target"/> object.</para>
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <returns>The cursor text to display, or <see langword="null"/> to display the default cursor text.</returns>
		CustomTooltip TargetCursorText(PlayfieldObject target);
	}
	/// <summary>
	///   <para>Indicates that a custom item is targetable anywhere.</para>
	/// </summary>
	public interface IItemTargetableAnywhere
	{
		/// <summary>
		///   <para>Determines whether to highlight the cursor when hovering over the specified <paramref name="position"/> and combining the current item.</para>
		/// </summary>
		/// <param name="position">The target position.</param>
		/// <returns><see langword="true"/>, if the current item can be targeted at the specified <paramref name="position"/>; otherwise, <see langword="false"/>.</returns>
		bool TargetFilter(Vector2 position);
		/// <summary>
		///   <para>Uses the current item on the specified <paramref name="position"/>. The return value indicates whether the usage succeeded or failed.</para>
		/// </summary>
		/// <param name="position">The target position.</param>
		/// <returns><see langword="true"/>, if the item was successfully used on the specified <paramref name="position"/>; otherwise, <see langword="false"/>.</returns>
		bool TargetPosition(Vector2 position);
		/// <summary>
		///   <para>Determines the cursor text when hovering over the specified <paramref name="position"/>.</para>
		/// </summary>
		/// <param name="position">The target position.</param>
		/// <returns>The cursor text to display, or <see langword="null"/> to display the default cursor text.</returns>
		CustomTooltip TargetCursorText(Vector2 position);
	}
	/// <summary>
	///   <para>Represents a custom tooltip.</para>
	/// </summary>
	public struct CustomTooltip
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="text"/>.</para>
		/// </summary>
		/// <param name="text">The tooltip's text.</param>
		public CustomTooltip(string text)
		{
			Text = text;
			Color = null;
		}
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">An object representing the tooltip's text.</param>
		public CustomTooltip(object obj)
		{
			Text = obj?.ToString();
			Color = null;
		}
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="text"/> and <paramref name="color"/>.</para>
		/// </summary>
		/// <param name="text">The tooltip's text.</param>
		/// <param name="color">The tooltip's text color.</param>
		public CustomTooltip(string text, Color color)
		{
			Text = text;
			Color = color;
		}
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="obj"/> and <paramref name="color"/>.</para>
		/// </summary>
		/// <param name="obj">An object representing the tooltip's text.</param>
		/// <param name="color">The tooltip's text color.</param>
		public CustomTooltip(object obj, Color color)
		{
			Text = obj?.ToString();
			Color = color;
		}
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The tooltip's localizable string.</param>
		public CustomTooltip(IName name)
		{
			Text = name.GetCurrentOrDefault();
			Color = null;
		}

		/// <summary>
		///   <para>Gets the tooltip's text.</para>
		/// </summary>
		public string Text { get; }
		/// <summary>
		///   <para>Gets the tooltip's text color.</para>
		/// </summary>
		public Color? Color { get; }

		/// <summary>
		///   <para>Implicitly converts a <see cref="string"/> into a <see cref="CustomTooltip"/>.</para>
		/// </summary>
		/// <param name="text">The tooltip's text.</param>
		public static implicit operator CustomTooltip(string text) => new CustomTooltip(text);
		/// <summary>
		///   <para>Implicitly converts an <see cref="int"/> into a <see cref="CustomTooltip"/>.</para>
		/// </summary>
		/// <param name="number">The tooltip's text.</param>
		public static implicit operator CustomTooltip(int number) => new CustomTooltip(number.ToString());
		/// <summary>
		///   <para>Implicitly converts a <see cref="float"/> into a <see cref="CustomTooltip"/>.</para>
		/// </summary>
		/// <param name="number">The tooltip's text.</param>
		public static implicit operator CustomTooltip(float number) => new CustomTooltip(number.ToString());
		/// <summary>
		///   <para>Implicitly converts a <see cref="CustomName"/> into a <see cref="CustomTooltip"/>.</para>
		/// </summary>
		/// <param name="name">The tooltip's localizable string.</param>
		public static implicit operator CustomTooltip(CustomName name) => new CustomTooltip(name);
		/// <summary>
		///   <para>Implicitly converts a <see cref="CustomNameInfo"/> into a <see cref="CustomTooltip"/>.</para>
		/// </summary>
		/// <param name="nameInfo">The tooltip's localizable string.</param>
		public static implicit operator CustomTooltip(CustomNameInfo nameInfo) => new CustomTooltip(nameInfo);
	}
	/// <summary>
	///   <para>Represents a factory of <see cref="CustomItem"/> hooks.</para>
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
		///   <para>Adds the specified <typeparamref name="TItem"/> type to the factory.</para>
		/// </summary>
		/// <typeparam name="TItem">The <see cref="CustomItem"/> type to add.</typeparam>
		/// <returns>The added item's metadata.</returns>
		public ItemInfo AddItem<TItem>() where TItem : CustomItem, new()
		{
			ItemInfo info = ItemInfo.Get<TItem>();
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Created custom item {typeof(TItem)} ({info.Name}).");
			itemsDict.Add(info.Name, new ItemEntry { Initializer = () => new TItem(), ItemInfo = info });
			return info;
		}

		private struct ItemEntry
		{
			public Func<IHook<InvItem>> Initializer;
			public ItemInfo ItemInfo;
		}
	}
}
