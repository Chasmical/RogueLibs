namespace RogueLibsCore
{
    public interface IHook
    {
        object Instance { get; }
        void Initialize(object instance);
    }
    public interface IHook<out T> : IHook where T : notnull
    {
        new T Instance { get; }
    }
}
