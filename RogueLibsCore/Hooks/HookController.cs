using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The default implementation of <see cref="IHookController{T}"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects that the hooks can be attached to.</typeparam>
    public sealed class HookController<T> : IHookController<T>, IDisposable where T : notnull
    {
        /// <inheritdoc/>
        public T Instance { get; }
        object IHookController.Instance => Instance;

        private List<IHook<T>> hooks = new();
        private ReadOnlyCollection<IHook<T>>? hooksReadonly;
        /// <summary>
        ///   <para>Gets a read-only collection of all hooks attached to the current instance.</para>
        /// </summary>
        public ReadOnlyCollection<IHook<T>> Hooks
            => hooksReadonly ??= hooks.AsReadOnly();

        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="HookController{T}"/> class with the specified <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">An object that the hooks will be attached to.</param>
        public HookController(T instance)
            => Instance = instance;

        /// <inheritdoc cref="IHookController.AddHook"/>
        public void AddHook(IHook<T> hook)
        {
            hook.Initialize(Instance);
            hooks.Add(hook);
            HookEvents.RegisterHookEvents(hook);
        }
        /// <inheritdoc cref="IHookController.RemoveHook"/>
        public bool RemoveHook(IHook<T> hook)
        {
            bool res = hooks.Remove(hook);
            if (res) HandleHookRemoval(hook);
            return res;
        }
        /// <inheritdoc/>
        public THook? GetHook<THook>()
            => (THook?)hooks.Find(static hook => hook is THook);
        /// <inheritdoc/>
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
        void IDisposable.Dispose()
        {
            DisposeHooks();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        ///   <para>Finalizes the <see cref="HookController{T}"/> and disposes of all its hooks.</para>
        /// </summary>
        ~HookController() => DisposeHooks();

    }
}
