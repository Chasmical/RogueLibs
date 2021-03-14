using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Default information about a <see cref="CustomItem"/>, specified in the type's attributes.</para>
	/// </summary>
	public sealed class CustomItemInfo
	{
		/// <summary>
		///   <para>Gets the item's name/id.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Gets the item's categories.</para>
		/// </summary>
		public ReadOnlyCollection<string> Categories { get; }
		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreDefaultChecksAttribute"/> was applied to <see cref="IItemUsable.UseItem"/>.</para>
		/// </summary>
		public bool IgnoreDefaultChecks_UseItem { get; }
		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreDefaultChecksAttribute"/> was applied to <see cref="IItemCombinable.CombineFilter(InvItem)"/>.</para>
		/// </summary>
		public bool IgnoreDefaultChecks_CombineFilter { get; }
		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreDefaultChecksAttribute"/> was applied to <see cref="IItemCombinable.CombineItems(InvItem)"/>.</para>
		/// </summary>
		public bool IgnoreDefaultChecks_CombineItems { get; }
		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreDefaultChecksAttribute"/> was applied to <see cref="IItemTargetable.TargetFilter(PlayfieldObject)"/>.</para>
		/// </summary>
		public bool IgnoreDefaultChecks_TargetFilter { get; }
		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreDefaultChecksAttribute"/> was applied to <see cref="IItemTargetable.TargetObject(PlayfieldObject)"/>.</para>
		/// </summary>
		public bool IgnoreDefaultChecks_TargetObject { get; }

		private static readonly Dictionary<Type, CustomItemInfo> infos = new Dictionary<Type, CustomItemInfo>();
		/// <summary>
		///   <para>Gets a <see cref="CustomItemInfo"/> for the specified <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="type"><see cref="CustomItem"/> type.</param>
		/// <returns><see cref="CustomItemInfo"/> containing the default information about the specified custom item <paramref name="type"/>.</returns>
		public static CustomItemInfo Get(Type type) => infos.TryGetValue(type, out CustomItemInfo info) ? info : (infos[type] = new CustomItemInfo(type));
		/// <summary>
		///   <para>Gets a <see cref="CustomItemInfo"/> for the specified <typeparamref name="TItem"/>.</para>
		/// </summary>
		/// <typeparam name="TItem"><see cref="CustomItem"/> type.</typeparam>
		/// <returns><see cref="CustomItemInfo"/> containing the default information about the specified custom item <typeparamref name="TItem"/>.</returns>
		public static CustomItemInfo Get<TItem>() where TItem : CustomItem => Get(typeof(TItem));

		private CustomItemInfo(Type type)
		{
			if (!typeof(CustomItem).IsAssignableFrom(type)) throw new ArgumentException("The specified type is not a CustomItem!", nameof(type));
			Name = type.GetCustomAttribute<ItemNameAttribute>()?.Name ?? type.Name;
			Categories = new ReadOnlyCollection<string>(type.GetCustomAttributes<ItemCategoriesAttribute>().SelectMany(c => c.Categories).ToArray());

			if (typeof(IItemUsable).IsAssignableFrom(type))
			{
				IgnoreDefaultChecks_UseItem = type.GetMethod(nameof(IItemUsable.UseItem)).GetCustomAttribute<IgnoreDefaultChecksAttribute>() != null;
			}
			if (typeof(IItemCombinable).IsAssignableFrom(type))
			{
				IgnoreDefaultChecks_CombineFilter = type.GetMethod(nameof(IItemCombinable.CombineFilter)).GetCustomAttribute<IgnoreDefaultChecksAttribute>() != null;
				IgnoreDefaultChecks_CombineItems = type.GetMethod(nameof(IItemCombinable.CombineItems)).GetCustomAttribute<IgnoreDefaultChecksAttribute>() != null;
			}
			if (typeof(IItemTargetable).IsAssignableFrom(type))
			{
				IgnoreDefaultChecks_TargetFilter = type.GetMethod(nameof(IItemTargetable.TargetFilter)).GetCustomAttribute<IgnoreDefaultChecksAttribute>() != null;
				IgnoreDefaultChecks_TargetObject = type.GetMethod(nameof(IItemTargetable.TargetObject)).GetCustomAttribute<IgnoreDefaultChecksAttribute>() != null;
			}
		}
	}
	/// <summary>
	///   <para>Ignores the default checks. Read the methods' description for more info.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class IgnoreDefaultChecksAttribute : Attribute { }
	/// <summary>
	///   <para>Specifies the custom item's name/id. If not used, uses the type's name, without a namespace.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class ItemNameAttribute : Attribute
	{
		/// <summary>
		///   <para>Name/id of the custom item.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="ItemNameAttribute"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Name/id of the custom item.</param>
		public ItemNameAttribute(string name) => Name = name;
	}
	/// <summary>
	///   <para>Specifies the custom item's categories.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class ItemCategoriesAttribute : Attribute
	{
		/// <summary>
		///   <para>Categories of the custom item.</para>
		/// </summary>
		public ReadOnlyCollection<string> Categories { get; }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="ItemCategoriesAttribute"/> with the specified <paramref name="categories"/>.</para>
		/// </summary>
		/// <param name="categories">Categories of the custom item.</param>
		public ItemCategoriesAttribute(params string[] categories) => Categories = new ReadOnlyCollection<string>(categories);
	}
}
