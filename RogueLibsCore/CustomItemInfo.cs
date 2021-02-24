using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace RogueLibsCore
{
	public sealed class CustomItemInfo
	{
		public string Name { get; }
		public ReadOnlyCollection<string> Categories { get; }
		public bool IgnoreDefaultChecks_UseItem { get; }
		public bool IgnoreDefaultChecks_CombineFilter { get; }
		public bool IgnoreDefaultChecks_CombineItems { get; }
		public bool IgnoreDefaultChecks_TargetFilter { get; }
		public bool IgnoreDefaultChecks_TargetObject { get; }

		private static readonly Dictionary<Type, CustomItemInfo> infos = new Dictionary<Type, CustomItemInfo>();
		public static CustomItemInfo Get(Type type) => infos.TryGetValue(type, out CustomItemInfo info) ? info : (infos[type] = new CustomItemInfo(type));
		public static CustomItemInfo Get<T>() => Get(typeof(T));

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
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class IgnoreDefaultChecksAttribute : Attribute { }
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class ItemNameAttribute : Attribute
	{
		public string Name { get; }
		public ItemNameAttribute(string name) => Name = name;
	}
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class ItemCategoriesAttribute : Attribute
	{
		public ReadOnlyCollection<string> Categories { get; }
		public ItemCategoriesAttribute(params string[] categories) => Categories = new ReadOnlyCollection<string>(categories);
	}
}
