namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a hook.</para>
    /// </summary>
    public interface IHook
    {
        /// <summary>
        ///   <para>Initializes the hook.</para>
        /// </summary>
        void Initialize();
        /// <summary>
        ///   <para>Gets or sets the instance that the hook is attached to.</para>
        /// </summary>
        object Instance { get; set; }
    }
    /// <summary>
    ///   <para>Represents a hook, attachable to instances of type <typeparamref name="T"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects that the hook can be attached to.</typeparam>
    public interface IHook<T> : IHook
    {
        /// <summary>
        ///   <para>Gets or sets the instance that the hook is attached to.</para>
        /// </summary>
        new T Instance { get; set; }
    }
}
