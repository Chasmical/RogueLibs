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

		public ReadOnlyCollection<string> IgnoredChecks { get; } = RogueUtilities.Empty;
		public bool IgnoresCheck(string name) => IgnoredChecks.Contains(name);

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

			ItemNameAttribute nameAttr = type.GetCustomAttributes<ItemNameAttribute>().FirstOrDefault();
			Name = nameAttr?.Name ?? type.Name;

			string[] categories = type.GetCustomAttributes<ItemCategoriesAttribute>().SelectMany(c => c.Categories).Distinct().ToArray();
			Categories = new ReadOnlyCollection<string>(categories);

			IEnumerable<string> typeIgnores = type.GetCustomAttributes<IgnoreChecksAttribute>().SelectMany(a => a.IgnoredChecks);

			List<MethodInfo> methods = new List<MethodInfo>();
			if (typeof(IItemUsable).IsAssignableFrom(type))
			{
				methods.Add(type.GetInterfaceMethod(typeof(IItemUsable),
					nameof(IItemUsable.UseItem)));
			}
			if (typeof(IItemCombinable).IsAssignableFrom(type))
			{
				methods.AddRange(type.GetInterfaceMethods(typeof(IItemCombinable),
					nameof(IItemCombinable.CombineFilter),
					nameof(IItemCombinable.CombineItems),
					nameof(IItemCombinable.CombineTooltip),
					nameof(IItemCombinable.CombineCursorText)));
			}
			if (typeof(IItemTargetable).IsAssignableFrom(type))
			{
				methods.AddRange(type.GetInterfaceMethods(typeof(IItemTargetable),
					nameof(IItemTargetable.TargetFilter),
					nameof(IItemTargetable.TargetObject),
					nameof(IItemTargetable.TargetCursorText)));
			}
			if (typeof(IItemTargetableAnywhere).IsAssignableFrom(type))
			{
				methods.AddRange(type.GetInterfaceMethods(typeof(IItemTargetableAnywhere),
					nameof(IItemTargetableAnywhere.TargetFilter),
					nameof(IItemTargetableAnywhere.TargetPosition),
					nameof(IItemTargetableAnywhere.TargetCursorText)));
			}
			IEnumerable<string> methodIgnores = methods.SelectMany(m => m.GetCustomAttributes<IgnoreChecksAttribute>()
				.SelectMany(a => a.IgnoredChecks));

			string[] ignoredChecks = typeIgnores.Concat(methodIgnores).Distinct().ToArray();
			if (ignoredChecks.Length > 0)
				IgnoredChecks = new ReadOnlyCollection<string>(ignoredChecks);
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
			Categories = new ReadOnlyCollection<string>(Array.FindAll(categories, c => c != null));
		}
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class IgnoreChecksAttribute : Attribute
	{
		public ReadOnlyCollection<string> IgnoredChecks { get; }
		public IgnoreChecksAttribute(params string[] ignoreChecks)
		{
			if (ignoreChecks is null) throw new ArgumentNullException(nameof(ignoreChecks));
			IgnoredChecks = new ReadOnlyCollection<string>(Array.FindAll(ignoreChecks, c => c != null));
		}
	}
}
