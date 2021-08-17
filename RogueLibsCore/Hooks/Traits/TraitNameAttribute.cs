using System;

namespace RogueLibsCore
{
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
