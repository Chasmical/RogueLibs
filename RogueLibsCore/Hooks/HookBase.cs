namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a hook base. Implements the interfaces, leaving only one abstract method to implement.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects that the hook can be attached to.</typeparam>
    public abstract class HookBase<T> : IHook<T>
    {
        /// <summary>
        ///   <para>Initializes the hook.</para>
        /// </summary>
        protected abstract void Initialize();
        void IHook.Initialize() => Initialize();

        /// <summary>
        ///   <para>Gets or sets the instance that the hook is attached to.</para>
        /// </summary>
        protected T Instance { get; set; }
        T IHook<T>.Instance { get => Instance; set => Instance = (T)value; }
        object IHook.Instance { get => Instance; set => Instance = (T)value; }
    }
}
