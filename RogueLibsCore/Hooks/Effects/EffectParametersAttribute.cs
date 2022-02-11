using System;

namespace RogueLibsCore
{
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
}
