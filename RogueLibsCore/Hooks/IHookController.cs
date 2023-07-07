namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a collection of hooks, attached to a single object.</para>
    /// </summary>
    public interface IHookController
    {
        /// <summary>
        ///   <para>Gets the object that the hooks are attached to.</para>
        /// </summary>
        object Instance { get; }

        /// <summary>
        ///   <para>Attaches the specified <paramref name="hook"/> to the current instance.</para>
        /// </summary>
        /// <param name="hook">The hook to attach to the current instance.</param>
        void AddHook(IHook hook);
        /// <summary>
        ///   <para>Detaches the specified <paramref name="hook"/> from the current instance.</para>
        /// </summary>
        /// <param name="hook">The hook to detach from the current instance.</param>
        /// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
        bool RemoveHook(IHook hook);

        /// <summary>
        ///   <para>Gets a hook from the collection that is assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hook to search for.</typeparam>
        /// <returns>A hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="null"/>.</returns>
        THook? GetHook<THook>();
        /// <summary>
        ///   <para>Returns an enumerable collection of all hooks in the collection that are assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hooks to search for.</typeparam>
        /// <returns>An enumerable collection of hooks that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
        THook[] GetHooks<THook>();
    }
    /// <summary>
    ///   <para>Represents a collection of hooks, attached to a single instance of type <typeparamref name="T"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects, that the hooks can be attached to.</typeparam>
    public interface IHookController<out T> : IHookController where T : notnull
    {
        /// <summary>
        ///   <para>Gets the instance of type <typeparamref name="T"/> that the hooks are attached to.</para>
        /// </summary>
        new T Instance { get; }
    }
}
