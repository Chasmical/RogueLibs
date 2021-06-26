using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace RogueLibsCore
{
	public sealed class ItemInfo
	{
		public string Name { get; }
		public ReadOnlyCollection<string> Categories { get; } = RogueUtilities.Empty;

		private static readonly Dictionary<Type, ItemInfo> infos = new Dictionary<Type, ItemInfo>();
		public static ItemInfo Get(Type type)
		{
			if (!infos.TryGetValue(type, out ItemInfo info))
				infos.Add(type, info = new ItemInfo(type));
			return info;
		}
		public static ItemInfo Get<TItem>() where TItem : CustomItem => Get(typeof(TItem));

		private ItemInfo(Type type)
		{
			if (!typeof(CustomItem).IsAssignableFrom(type))
				throw new ArgumentException($"{nameof(type)} does not inherit from {nameof(CustomItem)}!", nameof(type));

			Name = type.GetCustomAttribute<ItemNameAttribute>()?.Name ?? type.Name;
			Categories = new ReadOnlyCollection<string>(type.GetCustomAttributes<ItemCategoriesAttribute>().SelectMany(c => c.Categories).ToArray());
		}
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class ItemNameAttribute : Attribute
	{
		public string Name { get; }
		public ItemNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
	}
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class ItemCategoriesAttribute : Attribute
	{
		public ReadOnlyCollection<string> Categories { get; }
		public ItemCategoriesAttribute(params string[] categories)
		{
			if (categories is null) throw new ArgumentNullException(nameof(categories));
			Categories = new ReadOnlyCollection<string>(Array.FindAll(categories, c => !(c is null)));
		}
	}
}
