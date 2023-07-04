namespace RogueLibsCore
{
    public abstract class HookBase<T> : IHook<T> where T : notnull
    {
        private T? _instance;
        object IHook.Instance => _instance!;
        public T Instance => _instance!;

        void IHook.Initialize(object instance)
        {
            _instance = (T)instance;
            Initialize();
        }

        protected virtual void Initialize() { }

    }
}
