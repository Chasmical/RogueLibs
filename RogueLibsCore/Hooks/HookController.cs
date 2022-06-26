using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The default implementation of <see cref="IHookController{T}"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects that the hooks can be attached to.</typeparam>
    public sealed class HookController<T> : IHookController<T>, IDisposable
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="HookController{T}"/> class with the specified <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">An object that the hooks will be attached to.</param>
        public HookController(T instance) => Instance = instance;
        /// <inheritdoc/>
        public T Instance { get; }
        object IHookController.Instance => Instance!;

        private readonly List<IHook<T>> hooks = new List<IHook<T>>();

        /// <inheritdoc/>
        public void AddHook(IHook<T> hook)
        {
            if (hook is null) throw new ArgumentNullException(nameof(hook));
            hook.Instance = Instance;
            hooks.Add(hook);
            HandleHookAddition(hook);
            hook.Initialize();
        }
        /// <summary>
        ///   <para>Creates a hook of the specified <typeparamref name="THook"/> type using its default constructor and attaches it to the current instance.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hook to create and attach to the current instance.</typeparam>
        /// <returns>The created hook of the specified <typeparamref name="THook"/> type.</returns>
        public THook AddHook<THook>()
            where THook : IHook<T>, new()
        {
            THook hook = new THook { Instance = Instance };
            hooks.Add(hook);
            HandleHookAddition(hook);
            hook.Initialize();
            return hook;
        }
        void IHookController.AddHook(IHook hook)
        {
            if (hook is null) throw new ArgumentNullException(nameof(hook));
            if (hook is IHook<T> iHook) AddHook(iHook);
            else throw new ArgumentException("Invalid type!", nameof(hook));
        }

        private static void HandleHookAddition(IHook hook)
        {
            if (hook is IDoUpdate) RogueLibsPlugin.updateList.Add(hook);
            if (hook is IDoFixedUpdate) RogueLibsPlugin.fixedUpdateList.Add(hook);
        }
        private static void HandleHookRemoval(IHook hook)
        {
            if (hook is IDoUpdate)
            {
                if (RogueLibsPlugin.updatingHooks)
                    RogueLibsPlugin.removeFromUpdateList.Add(hook);
                else RogueLibsPlugin.updateList.Remove(hook);
            }
            if (hook is IDoFixedUpdate)
            {
                if (RogueLibsPlugin.fixedUpdatingHooks)
                    RogueLibsPlugin.removeFromFixedUpdateList.Add(hook);
                else RogueLibsPlugin.fixedUpdateList.Remove(hook);
            }
        }

        /// <inheritdoc/>
        public bool RemoveHook(IHook<T> hook)
        {
            if (hooks.Remove(hook))
            {
                HandleHookRemoval(hook);
                return true;
            }
            return false;
        }
        /// <summary>
        ///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current instance.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hook to detach from the current instance.</typeparam>
        /// <returns><see langword="true"/>, if a hook of the specified <typeparamref name="THook"/> type was successfully detached; otherwise, <see langword="false"/>.</returns>
        public bool RemoveHook<THook>()
        {
            int index = hooks.FindIndex(static h => h is THook);
            if (index is -1) return false;
            IHook hook = hooks[index];
            hooks.RemoveAt(index);
            HandleHookRemoval(hook);
            return true;
        }
        bool IHookController.RemoveHook(IHook hook)
        {
            int index = hooks.FindIndex(h => h == hook);
            if (index is -1) return false;
            hooks.RemoveAt(index);
            HandleHookRemoval(hook);
            return true;
        }

        /// <inheritdoc/>
        public THook? GetHook<THook>() => (THook?)hooks.Find(static h => h is THook);
        /// <inheritdoc/>
        public THook[] GetHooks<THook>()
        {
            List<THook> found = new List<THook>();
            for (int i = 0, count = hooks.Count; i < count; i++)
            {
                IHook<T> hook = hooks[i];
                if (hook is THook tHook) found.Add(tHook);
            }
            return found.ToArray();
        }
        /// <summary>
        ///   <para>Gets all hooks attached to the current instance.</para>
        /// </summary>
        /// <returns>A collection of hooks attached to the current instance.</returns>
        public IEnumerable<IHook<T>> GetHooks() => hooks.ToArray();

        public void Dispose()
        {
            try
            {
                for (int i = 0, count = hooks.Count; i < count; i++)
                {
                    IHook<T> hook = hooks[i];
                    HandleHookRemoval(hook);
                    (hook as IDisposable)?.Dispose();
                }
            }
            finally
            {
                hooks.Clear();
            }
        }

    }
}
