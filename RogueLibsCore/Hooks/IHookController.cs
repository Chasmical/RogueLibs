namespace RogueLibsCore
{
    public interface IHookController
    {
        object Instance { get; }
        void AddHook(IHook hook);
        bool RemoveHook(IHook hook);
        THook? GetHook<THook>();
        THook[] GetHooks<THook>();
    }
    public interface IHookController<out T> : IHookController where T : notnull
    {
        new T Instance { get; }
    }
}
