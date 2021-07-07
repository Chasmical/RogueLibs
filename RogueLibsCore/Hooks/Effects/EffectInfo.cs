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
		public bool RemoveOnDeath { get; }
		public bool RemoveOnKnockOut { get; }
		public bool RemoveOnNextLevel { get; }

		private static readonly Dictionary<Type, EffectInfo> infos = new Dictionary<Type, EffectInfo>();
		public static EffectInfo Get(Type type) => infos.TryGetValue(type, out EffectInfo info) ? info : (infos[type] = new EffectInfo(type));
		public static EffectInfo Get<TEffect>() where TEffect : CustomEffect => Get(typeof(TEffect));

		private EffectInfo(Type type)
		{
			if (!typeof(CustomEffect).IsAssignableFrom(type))
				throw new ArgumentException($"The specified {nameof(type)} is not a {nameof(CustomEffect)}!", nameof(type));

			EffectNameAttribute attr = type.GetCustomAttributes<EffectNameAttribute>().FirstOrDefault();
			Name = attr?.Name ?? type.Name;

			EffectParametersAttribute parsAttr = type.GetCustomAttributes<EffectParametersAttribute>().FirstOrDefault();
			Limitations = parsAttr?.Limitations ?? EffectLimitations.Default;
			RemoveOnDeath = (Limitations & EffectLimitations.RemoveOnDeath) != 0;
			RemoveOnKnockOut = (Limitations & EffectLimitations.RemoveOnKnockOut) != 0;
			RemoveOnNextLevel = (Limitations & EffectLimitations.RemoveOnNextLevel) != 0;
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
		public EffectParametersAttribute(EffectLimitations limitations = EffectLimitations.Default) => Limitations = limitations;
	}
	[Flags]
	public enum EffectLimitations
	{
		None = 0,

		RemoveOnDeath     = 1 << 0,
		RemoveOnKnockOut  = 1 << 1,
		RemoveOnNextLevel = 1 << 2,

		Default = RemoveOnDeath,
	}
}
