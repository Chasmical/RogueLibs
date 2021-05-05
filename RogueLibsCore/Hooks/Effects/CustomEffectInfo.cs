using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Default information about a <see cref="CustomEffect"/>, specified in the type's attributes.</para>
	/// </summary>
	public sealed class CustomEffectInfo
	{
		/// <summary>
		///   <para>Gets the status effect's name/id.</para>
		/// </summary>
		public string Name { get; }

		private static readonly Dictionary<Type, CustomEffectInfo> infos = new Dictionary<Type, CustomEffectInfo>();
		/// <summary>
		///   <para>Gets a <see cref="CustomEffectInfo"/> for the specified <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="type"><see cref="CustomEffect"/> type.</param>
		/// <returns><see cref="CustomEffectInfo"/> containing the default information about the specified custom effect <paramref name="type"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomEffect"/>.</exception>
		public static CustomEffectInfo Get(Type type) => infos.TryGetValue(type, out CustomEffectInfo info) ? info : (infos[type] = new CustomEffectInfo(type));
		/// <summary>
		///   <para>Gets a <see cref="CustomEffectInfo"/> for the specified <typeparamref name="TEffect"/>.</para>
		/// </summary>
		/// <typeparam name="TEffect"><see cref="CustomEffect"/> type.</typeparam>
		/// <returns><see cref="CustomEffectInfo"/> containing the default information about the specified custom effect <typeparamref name="TEffect"/>.</returns>
		public static CustomEffectInfo Get<TEffect>() where TEffect : CustomEffect => Get(typeof(TEffect));

		private CustomEffectInfo(Type type)
		{
			if (!typeof(CustomEffect).IsAssignableFrom(type)) throw new ArgumentException($"The specified type is not a {nameof(CustomEffect)}!", nameof(type));
			EffectNameAttribute attr = type.GetCustomAttribute<EffectNameAttribute>();

			Name = attr?.Name ?? type.Name;
		}
	}
	/// <summary>
	///   <para>Specifies the custom status effect's name and other parameters. If not used, the type's name and default values are used instead.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class EffectNameAttribute : Attribute
	{
		/// <summary>
		///   <para>Name/id of the status effect.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="EffectNameAttribute"/>.</para>
		/// </summary>
		public EffectNameAttribute() { }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="EffectNameAttribute"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Name/id of the custom effect.</param>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		public EffectNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
	}
}
