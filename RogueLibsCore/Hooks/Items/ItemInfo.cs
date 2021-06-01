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
	public sealed class ItemInfo
	{
		/// <summary>
		///   <para>Gets the item's name/id.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Gets the item's categories.</para>
		/// </summary>
		public ReadOnlyCollection<string> Categories { get; } = RogueUtilities.Empty;

		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreChecksAttribute"/> was applied to <see cref="IItemUsable.UseItem"/>.</para>
		/// </summary>
		public ReadOnlyCollection<string> IgnoreChecks_UseItem { get; } = RogueUtilities.Empty;

		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreChecksAttribute"/> was applied to <see cref="IItemCombinable.CombineFilter(InvItem)"/>.</para>
		/// </summary>
		public ReadOnlyCollection<string> IgnoreChecks_CombineFilter { get; } = RogueUtilities.Empty;
		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreChecksAttribute"/> was applied to <see cref="IItemCombinable.CombineItems(InvItem)"/>.</para>
		/// </summary>
		public ReadOnlyCollection<string> IgnoreChecks_CombineItems { get; } = RogueUtilities.Empty;
		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreChecksAttribute"/> was applied to <see cref="IItemCombinable.CombineTooltip(InvItem)"/>.</para>
		/// </summary>
		public ReadOnlyCollection<string> IgnoreChecks_CombineTooltip { get; } = RogueUtilities.Empty;

		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreChecksAttribute"/> was applied to <see cref="IItemTargetable.TargetFilter(PlayfieldObject)"/>.</para>
		/// </summary>
		public ReadOnlyCollection<string> IgnoreChecks_TargetFilter { get; } = RogueUtilities.Empty;
		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreChecksAttribute"/> was applied to <see cref="IItemTargetable.TargetObject(PlayfieldObject)"/>.</para>
		/// </summary>
		public ReadOnlyCollection<string> IgnoreChecks_TargetObject { get; } = RogueUtilities.Empty;
		/// <summary>
		///   <para>Determines whether an <see cref="IgnoreChecksAttribute"/> was applied to <see cref="IItemTargetable.TargetTooltip(PlayfieldObject)"/>.</para>
		/// </summary>
		public ReadOnlyCollection<string> IgnoreChecks_TargetTooltip { get; } = RogueUtilities.Empty;

		private static readonly Dictionary<Type, ItemInfo> infos = new Dictionary<Type, ItemInfo>();
		/// <summary>
		///   <para>Gets a <see cref="ItemInfo"/> for the specified <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="type"><see cref="CustomItem"/> type.</param>
		/// <returns><see cref="ItemInfo"/> containing the default information about the specified custom item <paramref name="type"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomItem"/>.</exception>
		public static ItemInfo Get(Type type)
		{
			if (!infos.TryGetValue(type, out ItemInfo info))
				infos.Add(type, info = new ItemInfo(type));
			return info;
		}
		/// <summary>
		///   <para>Gets a <see cref="ItemInfo"/> for the specified <typeparamref name="TItem"/>.</para>
		/// </summary>
		/// <typeparam name="TItem"><see cref="CustomItem"/> type.</typeparam>
		/// <returns><see cref="ItemInfo"/> containing the default information about the specified custom item <typeparamref name="TItem"/>.</returns>
		public static ItemInfo Get<TItem>() where TItem : CustomItem => Get(typeof(TItem));

		private ItemInfo(Type type)
		{
			if (!typeof(CustomItem).IsAssignableFrom(type))
				throw new ArgumentException($"The specified type does not inherit from {nameof(CustomItem)}!", nameof(type));
			Name = type.GetCustomAttribute<ItemNameAttribute>()?.Name ?? type.Name;
			Categories = new ReadOnlyCollection<string>(type.GetCustomAttributes<ItemCategoriesAttribute>().SelectMany(c => c.Categories).ToArray());

			if (typeof(IItemUsable).IsAssignableFrom(type))
			{
				IEnumerable<string> checks = type.GetInterfaceMethod(typeof(IItemUsable), nameof(IItemUsable.UseItem))
					.GetCustomAttributes<IgnoreChecksAttribute>().SelectMany(a => a.IgnoredChecks);
				IgnoreChecks_UseItem = checks.Any() ? new ReadOnlyCollection<string>(checks.ToArray()) : RogueUtilities.Empty;
			}
			if (typeof(IItemCombinable).IsAssignableFrom(type))
			{
				IEnumerable<string> checks = type.GetInterfaceMethod(typeof(IItemCombinable), nameof(IItemCombinable.CombineFilter))
					.GetCustomAttributes<IgnoreChecksAttribute>().SelectMany(a => a.IgnoredChecks);
				IgnoreChecks_CombineFilter = checks.Any() ? new ReadOnlyCollection<string>(checks.ToArray()) : RogueUtilities.Empty;

				checks = type.GetInterfaceMethod(typeof(IItemCombinable), nameof(IItemCombinable.CombineItems))
					.GetCustomAttributes<IgnoreChecksAttribute>().SelectMany(a => a.IgnoredChecks);
				IgnoreChecks_CombineItems = checks.Any() ? new ReadOnlyCollection<string>(checks.ToArray()) : RogueUtilities.Empty;

				checks = type.GetInterfaceMethod(typeof(IItemCombinable), nameof(IItemCombinable.CombineTooltip))
					.GetCustomAttributes<IgnoreChecksAttribute>().SelectMany(a => a.IgnoredChecks);
				IgnoreChecks_CombineTooltip = checks.Any() ? new ReadOnlyCollection<string>(checks.ToArray()) : RogueUtilities.Empty;
			}
			if (typeof(IItemTargetable).IsAssignableFrom(type))
			{
				IEnumerable<string> checks = type.GetInterfaceMethod(typeof(IItemTargetable), nameof(IItemTargetable.TargetFilter))
					.GetCustomAttributes<IgnoreChecksAttribute>().SelectMany(a => a.IgnoredChecks);
				IgnoreChecks_TargetFilter = checks.Any() ? new ReadOnlyCollection<string>(checks.ToArray()) : RogueUtilities.Empty;

				checks = type.GetInterfaceMethod(typeof(IItemTargetable), nameof(IItemTargetable.TargetObject))
					.GetCustomAttributes<IgnoreChecksAttribute>().SelectMany(a => a.IgnoredChecks);
				IgnoreChecks_TargetObject = checks.Any() ? new ReadOnlyCollection<string>(checks.ToArray()) : RogueUtilities.Empty;

				checks = type.GetInterfaceMethod(typeof(IItemTargetable), nameof(IItemTargetable.TargetTooltip))
					.GetCustomAttributes<IgnoreChecksAttribute>().SelectMany(a => a.IgnoredChecks);
				IgnoreChecks_TargetTooltip = checks.Any() ? new ReadOnlyCollection<string>(checks.ToArray()) : RogueUtilities.Empty;
			}
		}
	}
	/// <summary>
	///   <para>Ignores the specified checks.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class IgnoreChecksAttribute : Attribute
	{
		public ReadOnlyCollection<string> IgnoredChecks { get; }
		public IgnoreChecksAttribute(params string[] checks)
		{
			if (checks is null) throw new ArgumentNullException(nameof(checks));
			IgnoredChecks = new ReadOnlyCollection<string>(Array.FindAll(checks, c => !(c is null)));
		}
	}
	/// <summary>
	///   <para>Specifies the custom item's name/id. If not used, the type's name is used instead.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
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
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		public ItemNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
	}
	/// <summary>
	///   <para>Specifies the custom item's categories.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
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
		/// <exception cref="ArgumentNullException"><paramref name="categories"/> is <see langword="null"/>.</exception>
		public ItemCategoriesAttribute(params string[] categories)
		{
			if (categories is null) throw new ArgumentNullException(nameof(categories));
			Categories = new ReadOnlyCollection<string>(Array.FindAll(categories, c => !(c is null)));
		}
	}
}
