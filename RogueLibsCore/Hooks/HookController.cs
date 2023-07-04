using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
    internal sealed class HookController<T> : IHookController<T>, IDisposable where T : notnull
    {
        public T Instance { get; }
        object IHookController.Instance => Instance;

        private List<IHook<T>> hooks = new();
        private ReadOnlyCollection<IHook<T>>? hooksReadonly;
        public ReadOnlyCollection<IHook<T>> Hooks
            => hooksReadonly ??= hooks.AsReadOnly();

        public HookController(T instance)
            => Instance = instance;

        public void AddHook(IHook<T> hook)
        {
            hook.Initialize(Instance);
            hooks.Add(hook);
            HookEvents.RegisterHookEvents(hook);
        }
        public bool RemoveHook(IHook<T> hook)
        {
            bool res = hooks.Remove(hook);
            if (res) HandleHookRemoval(hook);
            return res;
        }
        public THook? GetHook<THook>()
            => (THook?)hooks.Find(static hook => hook is THook);
        public THook[] GetHooks<THook>()
        {
            List<THook> results = new();
            foreach (IHook<T> hook in hooks)
                if (hook is THook hookT)
                    results.Add(hookT);
            return results.ToArray();
        }

        void IHookController.AddHook(IHook hook)
            => AddHook((IHook<T>)hook);
        bool IHookController.RemoveHook(IHook hook)
            => hook is IHook<T> hookT && RemoveHook(hookT);

        private static void HandleHookRemoval(IHook hook)
        {
            HookEvents.UnRegisterHookEvents(hook);
            (hook as IDisposable)?.Dispose();
        }

        private void DisposeHooks()
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (hooks is null) return;

            for (int i = 0, count = hooks.Count; i < count; i++)
                HandleHookRemoval(hooks[i]);
            hooks = null!;
            hooksReadonly = null!;
        }
        public void Dispose()
        {
            DisposeHooks();
            GC.SuppressFinalize(this);
        }
        ~HookController() => DisposeHooks();

    }
}
