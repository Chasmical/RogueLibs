using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Default information about a <see cref="CustomTrait"/>, specified in the type's attributes.</para>
	/// </summary>
	public sealed class TraitInfo
	{
		/// <summary>
		///   <para>Gets the trait's name/id.</para>
		/// </summary>
		public string Name { get; }

		private static readonly Dictionary<Type, TraitInfo> infos = new Dictionary<Type, TraitInfo>();
		/// <summary>
		///   <para>Gets a <see cref="TraitInfo"/> for the specified <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="type"><see cref="CustomTrait"/> type.</param>
		/// <returns><see cref="TraitInfo"/> containing the default information about the specified custom trait <paramref name="type"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomTrait"/>.</exception>
		public static TraitInfo Get(Type type) => infos.TryGetValue(type, out TraitInfo info) ? info : (infos[type] = new TraitInfo(type));
		/// <summary>
		///   <para>Gets a <see cref="TraitInfo"/> for the specified <typeparamref name="TTrait"/>.</para>
		/// </summary>
		/// <typeparam name="TTrait"><see cref="CustomTrait"/> type.</typeparam>
		/// <returns><see cref="TraitInfo"/> containing the default information about the specified custom trait <typeparamref name="TTrait"/>.</returns>
		public static TraitInfo Get<TTrait>() where TTrait : CustomTrait => Get(typeof(TTrait));

		private TraitInfo(Type type)
		{
			if (!typeof(CustomTrait).IsAssignableFrom(type)) throw new ArgumentException($"The specified type is not a {nameof(CustomTrait)}!", nameof(type));
			TraitNameAttribute attr = type.GetCustomAttribute<TraitNameAttribute>();

			Name = attr?.Name ?? type.Name;
		}
	}
	/// <summary>
	///   <para>Specifies the custom trait's name and other parameters. If not used, the type's name and default values are used instead.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class TraitNameAttribute : Attribute
	{
		/// <summary>
		///   <para>Name/id of the trait.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="TraitNameAttribute"/>.</para>
		/// </summary>
		public TraitNameAttribute() { }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="TraitNameAttribute"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Name/id of the custom trait.</param>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		public TraitNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
	}
}
