using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents the <see cref="CustomTrait"/> type metadata.</para>
	/// </summary>
	public sealed class TraitInfo
	{
		/// <summary>
		///   <para>Gets the custom trait's name.</para>
		/// </summary>
		public string Name { get; }

		private static readonly Dictionary<Type, TraitInfo> infos = new Dictionary<Type, TraitInfo>();
		/// <summary>
		///   <para>Gets the specified <see cref="CustomTrait"/> <paramref name="type"/>'s metadata.</para>
		/// </summary>
		/// <param name="type">The <see cref="CustomTrait"/> type to get the metadata for.</param>
		/// <returns>The specified <paramref name="type"/>'s metadata.</returns>
		/// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomTrait"/>.</exception>
		public static TraitInfo Get(Type type) => infos.TryGetValue(type, out TraitInfo info) ? info : (infos[type] = new TraitInfo(type));
		/// <summary>
		///   <para>Gets the specified <typeparamref name="TTrait"/>'s metadata.</para>
		/// </summary>
		/// <typeparam name="TTrait">The <see cref="CustomTrait"/> type get the metadata for.</typeparam>
		/// <returns>The specified <typeparamref name="TTrait"/>'s metadata.</returns>
		public static TraitInfo Get<TTrait>() where TTrait : CustomTrait => Get(typeof(TTrait));

		private TraitInfo(Type type)
		{
			if (!typeof(CustomTrait).IsAssignableFrom(type))
				throw new ArgumentException($"The specified type is not a {nameof(CustomTrait)}!", nameof(type));

			TraitNameAttribute nameAttr = type.GetCustomAttributes<TraitNameAttribute>().FirstOrDefault();
			Name = nameAttr?.Name ?? type.Name;
		}
	}
	/// <summary>
	///   <para>Specifies a different name for the custom trait to use.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class TraitNameAttribute : Attribute
	{
		/// <summary>
		///   <para>Gets the custom trait's name.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="TraitNameAttribute"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The custom trait's name.</param>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		public TraitNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
	}
}
