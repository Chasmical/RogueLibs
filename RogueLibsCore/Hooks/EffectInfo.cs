using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	public sealed class EffectInfo
	{
		public string Name { get; }
		public EffectLimitations Limitations { get; }
		public bool RemoveOnDeath => (Limitations & EffectLimitations.RemoveOnDeath) != 0;
		public bool RemoveOnKnockOut => (Limitations & EffectLimitations.RemoveOnKnockOut) != 0;
		public bool RemoveOnNextLevel => (Limitations & EffectLimitations.RemoveOnNextLevel) != 0;

		private static readonly Dictionary<Type, EffectInfo> infos = new Dictionary<Type, EffectInfo>();
		public static EffectInfo Get(Type type) => infos.TryGetValue(type, out EffectInfo info) ? info : (infos[type] = new EffectInfo(type));
		public static EffectInfo Get<TEffect>() where TEffect : CustomEffect => Get(typeof(TEffect));

		private EffectInfo(Type type)
		{
			if (!typeof(CustomEffect).IsAssignableFrom(type))
				throw new ArgumentException($"The specified {nameof(type)} is not a {nameof(CustomEffect)}!", nameof(type));
			EffectNameAttribute attr = type.GetCustomAttribute<EffectNameAttribute>();
			Name = attr?.Name ?? type.Name;
		}
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class EffectNameAttribute : Attribute
	{
		public string Name { get; }
		public EffectNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class EffectParametersAttribute : Attribute
	{
		public EffectLimitations Limitations { get; }
		public EffectParametersAttribute(EffectLimitations limitations = EffectLimitations.RemoveOnDeath) => Limitations = limitations;
	}
	[Flags]
	public enum EffectLimitations
	{
		None = 0,

		RemoveOnDeath     = 1 << 0,
		RemoveOnKnockOut  = 1 << 1,
		RemoveOnNextLevel = 1 << 2,

		Default = RemoveOnDeath
	}
}
