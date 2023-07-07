namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a hook base. Implements <see cref="IHook{T}"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects that the hook can be attached to.</typeparam>
    public abstract class HookBase<T> : IHook<T> where T : notnull
    {
        private T? _instance;
        object IHook.Instance => _instance!;
        /// <inheritdoc/>
        public T Instance => _instance!;

        void IHook.Initialize(object instance)
        {
            _instance = (T)instance;
            Initialize();
        }

        /// <summary>
        ///   <para>Initializes the hook.</para>
        /// </summary>
        protected virtual void Initialize() { }

    }
}
