namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a hook.</para>
    /// </summary>
    public interface IHook
    {
        /// <summary>
        ///   <para>Gets the instance that the hook is attached to.</para>
        /// </summary>
        object Instance { get; }
        /// <summary>
        ///   <para>Initializes the hook on the specified <paramref name="instance"/>.</para>
        /// </summary>
        void Initialize(object instance);
    }
    /// <summary>
    ///   <para>Represents a hook, attachable to instances of type <typeparamref name="T"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects that the hook can be attached to.</typeparam>
    public interface IHook<out T> : IHook where T : notnull
    {
        /// <summary>
        ///   <para>Gets the instance that the hook is attached to.</para>
        /// </summary>
        new T Instance { get; }
    }
}
