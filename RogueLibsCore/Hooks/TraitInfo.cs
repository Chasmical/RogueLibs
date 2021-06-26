using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace RogueLibsCore
{
	public sealed class TraitInfo
	{
		public string Name { get; }

		private static readonly Dictionary<Type, TraitInfo> infos = new Dictionary<Type, TraitInfo>();
		public static TraitInfo Get(Type type) => infos.TryGetValue(type, out TraitInfo info) ? info : (infos[type] = new TraitInfo(type));
		public static TraitInfo Get<TTrait>() where TTrait : CustomTrait => Get(typeof(TTrait));

		private TraitInfo(Type type)
		{
			if (!typeof(CustomTrait).IsAssignableFrom(type)) throw new ArgumentException($"The specified type is not a {nameof(CustomTrait)}!", nameof(type));
			TraitNameAttribute attr = type.GetCustomAttribute<TraitNameAttribute>();

			Name = attr?.Name ?? type.Name;
		}
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class TraitNameAttribute : Attribute
	{
		public string Name { get; }
		public TraitNameAttribute() { }
		public TraitNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
	}
}
