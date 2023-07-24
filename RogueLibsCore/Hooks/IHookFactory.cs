namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a hook factory.</para>
    /// </summary>
    public interface IHookFactory
    {
        /// <summary>
        ///   <para>Tries to create a hook for the specified <paramref name="instance"/>, and returns it.</para>
        /// </summary>
        /// <param name="instance">The object to create a hook for.</param>
        /// <returns>The created hook, if one was successfully created; otherwise, <see langword="null"/>.</returns>
        IHook? TryCreateHook(object instance);
    }
}
