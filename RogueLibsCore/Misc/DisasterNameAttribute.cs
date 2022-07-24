using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Specifies a different name for the custom disaster to use.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DisasterNameAttribute : Attribute
    {
        /// <summary>
        ///   <para>Gets the custom disaster's name.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="DisasterNameAttribute"/> class with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The custom disaster's name.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
        public DisasterNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
