using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents the <see cref="CustomEffect"/> type metadata.</para>
	/// </summary>
	public sealed class EffectInfo
	{
		/// <summary>
		///   <para>Gets the custom effect's name.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Gets the custom effect's limitations flags.</para>
		/// </summary>
		public EffectLimitations Limitations { get; }
		/// <summary>
		///   <para>Determines whether the status effect is removed on death.</para>
		/// </summary>
		public bool RemoveOnDeath { get; }
		/// <summary>
		///   <para>Determines whether the status effect is removed on knockout.</para>
		/// </summary>
		public bool RemoveOnKnockOut { get; }
		/// <summary>
		///   <para>Determines whether the status effect is removed between levels.</para>
		/// </summary>
		public bool RemoveOnNextLevel { get; }

		private static readonly Dictionary<Type, EffectInfo> infos = new Dictionary<Type, EffectInfo>();
		/// <summary>
		///   <para>Gets the specified <see cref="CustomEffect"/> <paramref name="type"/>'s metadata.</para>
		/// </summary>
		/// <param name="type">The <see cref="CustomEffect"/> type to get the metadata for.</param>
		/// <returns>The specified <paramref name="type"/>'s metadata.</returns>
		/// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomEffect"/>.</exception>
		public static EffectInfo Get(Type type) => infos.TryGetValue(type, out EffectInfo info) ? info : (infos[type] = new EffectInfo(type));
		/// <summary>
		///   <para>Gets the specified <typeparamref name="TEffect"/>'s metadata.</para>
		/// </summary>
		/// <typeparam name="TEffect">The <see cref="CustomEffect"/> type get the metadata for.</typeparam>
		/// <returns>The specified <typeparamref name="TEffect"/>'s metadata.</returns>
		public static EffectInfo Get<TEffect>() where TEffect : CustomEffect => Get(typeof(TEffect));

		private EffectInfo(Type type)
		{
			if (!typeof(CustomEffect).IsAssignableFrom(type))
				throw new ArgumentException($"The specified {nameof(type)} is not a {nameof(CustomEffect)}.", nameof(type));

			EffectNameAttribute attr = type.GetCustomAttributes<EffectNameAttribute>().FirstOrDefault();
			Name = attr?.Name ?? type.FullName;

			EffectParametersAttribute parsAttr = type.GetCustomAttributes<EffectParametersAttribute>().FirstOrDefault();
			if (parsAttr is null)
				RogueFramework.LogWarning($"Type {type} does not have a {nameof(EffectParametersAttribute)}!");

			Limitations = parsAttr?.Limitations ?? EffectLimitations.RemoveOnDeath;
			RemoveOnDeath = (Limitations & EffectLimitations.RemoveOnDeath) != 0;
			RemoveOnKnockOut = (Limitations & EffectLimitations.RemoveOnKnockOut) != 0;
			RemoveOnNextLevel = (Limitations & EffectLimitations.RemoveOnNextLevel) != 0;
		}
	}
	/// <summary>
	///   <para>Specifies a different name for the custom item to use.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class EffectNameAttribute : Attribute
	{
		/// <summary>
		///   <para>Gets the custom effect's name.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="EffectNameAttribute"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The custom effect's name.</param>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		public EffectNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
	}
	/// <summary>
	///   <para>Specifies custom effect's parameters.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class EffectParametersAttribute : Attribute
	{
		/// <summary>
		///   <para>Gets the custom effect's limitations.</para>
		/// </summary>
		public EffectLimitations Limitations { get; }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="EffectParametersAttribute"/> class with the specified <paramref name="limitations"/>.</para>
		/// </summary>
		/// <param name="limitations"></param>
		public EffectParametersAttribute(EffectLimitations limitations = EffectLimitations.RemoveOnDeath) => Limitations = limitations;
	}
	/// <summary>
	///   <para>Represents a custom effect's limitations.</para>
	/// </summary>
	[Flags]
	public enum EffectLimitations
	{
		/// <summary>
		///   <para>No limitations.</para>
		/// </summary>
		None = 0,

		/// <summary>
		///   <para>The effect will be removed on death.</para>
		/// </summary>
		RemoveOnDeath     = 1 << 0,
		/// <summary>
		///   <para>The effect will be removed on knockout.</para>
		/// </summary>
		RemoveOnKnockOut  = 1 << 1,
		/// <summary>
		///   <para>The effect will be removed on the next level.</para>
		/// </summary>
		RemoveOnNextLevel = 1 << 2,
	}
}
