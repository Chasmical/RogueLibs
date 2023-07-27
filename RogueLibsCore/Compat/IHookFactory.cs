using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a hook factory, that creates hooks attachable to instances of type <typeparamref name="T"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects that the created hooks can be attached to.</typeparam>
    [Obsolete("IHookFactory<T> interface was deprecated in RogueLibs v4.0.0. Use the non-generic IHookFactory interface instead.")]
    public interface IHookFactory<in T> : IHookFactory where T : notnull { }
}
