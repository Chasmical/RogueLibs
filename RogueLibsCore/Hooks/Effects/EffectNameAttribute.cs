using System;

namespace RogueLibsCore
{
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
}
