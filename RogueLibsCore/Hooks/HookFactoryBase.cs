namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a hook factory base. Implements the interfaces, leaving only one abstract method to implement.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects that the created hooks can be attached to.</typeparam>
    public abstract class HookFactoryBase<T> : IHookFactory<T>
    {
        /// <inheritdoc/>
        public abstract bool TryCreate(T instance, out IHook<T> hook);
        bool IHookFactory.TryCreate(object instance, out IHook hook)
        {
            bool res = TryCreate((T)instance, out IHook<T> hookT);
            hook = hookT;
            return res;
        }
    }
}
