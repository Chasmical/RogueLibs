using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The collection of hook extensions.</para>
    /// </summary>
    public static class HookExtensions
    {
        private static IHook AddHookShared(IHookController controller, IHook hook)
        {
            if (hook.IsDefault()) throw new ArgumentNullException(nameof(hook));
            controller.AddHook(hook);
            return hook;
        }

        /// <summary>
        ///   <para>Attaches the specified <paramref name="hook"/> to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <param name="hook">The hook to attach to the <paramref name="instance"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="hook"/> is <see langword="null"/>.</exception>
        public static void AddHook(this InvItem instance, IHook<InvItem> hook)
            => AddHookShared(instance.GetHookController(), hook);
        /// <summary>
        ///   <para>Attaches the specified <paramref name="hook"/> to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <param name="hook">The hook to attach to the <paramref name="instance"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="hook"/> is <see langword="null"/>.</exception>
        public static void AddHook(this PlayfieldObject instance, IHook<PlayfieldObject> hook)
            => AddHookShared(instance.GetHookController(), hook);
        /// <summary>
        ///   <para>Attaches the specified <paramref name="hook"/> to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <param name="hook">The hook to attach to the <paramref name="instance"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="hook"/> is <see langword="null"/>.</exception>
        public static void AddHook(this StatusEffect instance, IHook<StatusEffect> hook)
            => AddHookShared(instance.GetHookController(), hook);
        /// <summary>
        ///   <para>Attaches the specified <paramref name="hook"/> to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <param name="hook">The hook to attach to the <paramref name="instance"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="hook"/> is <see langword="null"/>.</exception>
        public static void AddHook(this Trait instance, IHook<Trait> hook)
            => AddHookShared(instance.GetHookController(), hook);

        /// <summary>
        ///   <para>Creates a hook of the specified <typeparamref name="THook"/> type and attaches it to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hook to create and attach to the <paramref name="instance"/>.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The created hook.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook AddHook<THook>(this InvItem instance) where THook : class, IHook<InvItem>, new()
            => (THook)AddHookShared(instance.GetHookController(), new THook());
        /// <summary>
        ///   <para>Creates a hook of the specified <typeparamref name="THook"/> type and attaches it to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hook to create and attach to the <paramref name="instance"/>.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The created hook.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook AddHook<THook>(this PlayfieldObject instance) where THook : class, IHook<PlayfieldObject>, new()
            => (THook)AddHookShared(instance.GetHookController(), new THook());
        /// <summary>
        ///   <para>Creates a hook of the specified <typeparamref name="THook"/> type and attaches it to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hook to create and attach to the <paramref name="instance"/>.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The created hook.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook AddHook<THook>(this StatusEffect instance) where THook : class, IHook<StatusEffect>, new()
            => (THook)AddHookShared(instance.GetHookController(), new THook());
        /// <summary>
        ///   <para>Creates a hook of the specified <typeparamref name="THook"/> type and attaches it to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hook to create and attach to the <paramref name="instance"/>.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The created hook.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook AddHook<THook>(this Trait instance) where THook : class, IHook<Trait>, new()
            => (THook)AddHookShared(instance.GetHookController(), new THook());

        private static bool RemoveHookShared(IHookController? controller, IHook hook)
            => controller is not null && controller.RemoveHook(hook);

        /// <summary>
        ///   <para>Detaches the specified <paramref name="hook"/> from the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <param name="hook">The hook to detach from the <paramref name="instance"/>.</param>
        /// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static bool RemoveHook(this InvItem instance, IHook<InvItem> hook)
            => RemoveHookShared(instance.GetHookControllerIfExists(), hook);
        /// <summary>
        ///   <para>Detaches the specified <paramref name="hook"/> from the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <param name="hook">The hook to detach from the <paramref name="instance"/>.</param>
        /// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static bool RemoveHook(this PlayfieldObject instance, IHook<PlayfieldObject> hook)
            => RemoveHookShared(instance.GetHookControllerIfExists(), hook);
        /// <summary>
        ///   <para>Detaches the specified <paramref name="hook"/> from the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <param name="hook">The hook to detach from the <paramref name="instance"/>.</param>
        /// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static bool RemoveHook(this StatusEffect instance, IHook<StatusEffect> hook)
            => RemoveHookShared(instance.GetHookControllerIfExists(), hook);
        /// <summary>
        ///   <para>Detaches the specified <paramref name="hook"/> from the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <param name="hook">The hook to detach from the <paramref name="instance"/>.</param>
        /// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static bool RemoveHook(this Trait instance, IHook<Trait> hook)
            => RemoveHookShared(instance.GetHookControllerIfExists(), hook);

        private static bool RemoveHookShared<THook>(IHookController? controller) where THook : IHook
        {
            if (controller is null) return false;
            THook? hook = controller.GetHook<THook>();
            return !hook.IsDefault() && controller.RemoveHook(hook);
        }

        /// <summary>
        ///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to detach from the <paramref name="instance"/>.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns><see langword="true"/>, if a hook was successfully detached; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static bool RemoveHook<THook>(this InvItem instance) where THook : IHook<InvItem>
            => RemoveHookShared<THook>(instance.GetHookControllerIfExists());
        /// <summary>
        ///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to detach from the <paramref name="instance"/>.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns><see langword="true"/>, if a hook was successfully detached; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static bool RemoveHook<THook>(this PlayfieldObject instance) where THook : IHook<PlayfieldObject>
            => RemoveHookShared<THook>(instance.GetHookControllerIfExists());
        /// <summary>
        ///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to detach from the <paramref name="instance"/>.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns><see langword="true"/>, if a hook was successfully detached; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static bool RemoveHook<THook>(this StatusEffect instance) where THook : IHook<StatusEffect>
            => RemoveHookShared<THook>(instance.GetHookControllerIfExists());
        /// <summary>
        ///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to detach from the <paramref name="instance"/>.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns><see langword="true"/>, if a hook was successfully detached; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static bool RemoveHook<THook>(this Trait instance) where THook : IHook<Trait>
            => RemoveHookShared<THook>(instance.GetHookControllerIfExists());

        private static THook? GetHookShared<THook>(IHookController? controller)
            => controller is null ? default : controller.GetHook<THook>();

        /// <summary>
        ///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook? GetHook<THook>(this InvItem instance)
            => GetHookShared<THook>(instance.GetHookControllerIfExists());
        /// <summary>
        ///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook? GetHook<THook>(this PlayfieldObject instance)
            => GetHookShared<THook>(instance.GetHookControllerIfExists());
        /// <summary>
        ///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook? GetHook<THook>(this StatusEffect instance)
            => GetHookShared<THook>(instance.GetHookControllerIfExists());
        /// <summary>
        ///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook? GetHook<THook>(this Trait instance)
            => GetHookShared<THook>(instance.GetHookControllerIfExists());

        // TODO: refactor/reimplement these two methods
        /// <summary>
        ///   <para>Returns the <see cref="UnlockWrapper"/> attached to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The attached <see cref="UnlockWrapper"/> hook, if found; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static UnlockWrapper GetHook(this Unlock instance)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            return (UnlockWrapper)instance.__RogueLibsCustom;
        }
        /// <summary>
        ///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook? GetHook<THook>(this Unlock instance) where THook : UnlockWrapper
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            return instance.__RogueLibsCustom as THook ?? null;
        }

        private static THook GetOrAddHookShared<THook>(IHookController controller) where THook : class, IHook, new()
        {
            THook? hook = controller.GetHook<THook>();
            if (hook.IsDefault()) controller.AddHook(hook = new THook());
            return hook;
        }

        /// <summary>
        ///   <para>Returns a hook attached to the current instance, that is assignable to a variable of the <typeparamref name="THook"/> type, or creates one if it doesn't exist.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook GetOrAddHook<THook>(this InvItem instance) where THook : class, IHook<InvItem>, new()
            => GetOrAddHookShared<THook>(instance.GetHookController());
        /// <summary>
        ///   <para>Returns a hook attached to the current instance, that is assignable to a variable of the <typeparamref name="THook"/> type, or creates one if it doesn't exist.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook GetOrAddHook<THook>(this PlayfieldObject instance) where THook : class, IHook<PlayfieldObject>, new()
            => GetOrAddHookShared<THook>(instance.GetHookController());
        /// <summary>
        ///   <para>Returns a hook attached to the current instance, that is assignable to a variable of the <typeparamref name="THook"/> type, or creates one if it doesn't exist.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook GetOrAddHook<THook>(this StatusEffect instance) where THook : class, IHook<StatusEffect>, new()
            => GetOrAddHookShared<THook>(instance.GetHookController());
        /// <summary>
        ///   <para>Returns a hook attached to the current instance, that is assignable to a variable of the <typeparamref name="THook"/> type, or creates one if it doesn't exist.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook GetOrAddHook<THook>(this Trait instance) where THook : class, IHook<Trait>, new()
            => GetOrAddHookShared<THook>(instance.GetHookController());

        /// <summary>
        ///   <para>Determines whether the current instance contains a hook, that is assignable to a variable of the <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns><see langword="true"/>, if the current instance contains a hook, that is assignable to a variable of the <typeparamref name="THook"/> type; otherwise, <see langword="false"/>.</returns>
        public static bool HasHook<THook>(this InvItem instance)
            => !GetHook<THook>(instance).IsDefault();
        /// <summary>
        ///   <para>Determines whether the current instance contains a hook, that is assignable to a variable of the <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns><see langword="true"/>, if the current instance contains a hook, that is assignable to a variable of the <typeparamref name="THook"/> type; otherwise, <see langword="false"/>.</returns>
        public static bool HasHook<THook>(this PlayfieldObject instance)
            => !GetHook<THook>(instance).IsDefault();
        /// <summary>
        ///   <para>Determines whether the current instance contains a hook, that is assignable to a variable of the <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns><see langword="true"/>, if the current instance contains a hook, that is assignable to a variable of the <typeparamref name="THook"/> type; otherwise, <see langword="false"/>.</returns>
        public static bool HasHook<THook>(this StatusEffect instance)
            => !GetHook<THook>(instance).IsDefault();
        /// <summary>
        ///   <para>Determines whether the current instance contains a hook, that is assignable to a variable of the <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns><see langword="true"/>, if the current instance contains a hook, that is assignable to a variable of the <typeparamref name="THook"/> type; otherwise, <see langword="false"/>.</returns>
        public static bool HasHook<THook>(this Trait instance)
            => !GetHook<THook>(instance).IsDefault();

        private static IEnumerable<THook> GetHooksShared<THook>(IHookController? controller)
            => controller?.GetHooks<THook>() ?? Enumerable.Empty<THook>();

        /// <summary>
        ///   <para>Returns an enumerable collection of all hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hooks to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>An enumerable collection of hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static IEnumerable<THook> GetHooks<THook>(this InvItem instance)
            => GetHooksShared<THook>(instance.GetHookControllerIfExists());
        /// <summary>
        ///   <para>Returns an enumerable collection of all hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hooks to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>An enumerable collection of hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static IEnumerable<THook> GetHooks<THook>(this PlayfieldObject instance)
            => GetHooksShared<THook>(instance.GetHookControllerIfExists());
        /// <summary>
        ///   <para>Returns an enumerable collection of all hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hooks to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>An enumerable collection of hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static IEnumerable<THook> GetHooks<THook>(this StatusEffect instance)
            => GetHooksShared<THook>(instance.GetHookControllerIfExists());
        /// <summary>
        ///   <para>Returns an enumerable collection of all hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of the hooks to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>An enumerable collection of hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static IEnumerable<THook> GetHooks<THook>(this Trait instance)
            => GetHooksShared<THook>(instance.GetHookControllerIfExists());

        // TODO: refactor these two methods
        /// <summary>
        ///   <para>Returns the <see cref="StatusEffects"/> instance containing the current <paramref name="statusEffect"/>.</para>
        /// </summary>
        /// <param name="statusEffect">The current instance of <see cref="StatusEffect"/>.</param>
        /// <returns>The <see cref="StatusEffects"/> instance containing the current <paramref name="statusEffect"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="statusEffect"/> is <see langword="null"/>.</exception>
        public static StatusEffects GetStatusEffects(this StatusEffect statusEffect)
        {
            if (statusEffect is null) throw new ArgumentNullException(nameof(statusEffect));
            return (StatusEffects)statusEffect.__RogueLibsContainer;
        }
        /// <summary>
        ///   <para>Returns the <see cref="StatusEffects"/> instance containing the current <paramref name="trait"/>.</para>
        /// </summary>
        /// <param name="trait">The current instance of <see cref="Trait"/>.</param>
        /// <returns>The <see cref="StatusEffects"/> instance containing the current <paramref name="trait"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="trait"/> is <see langword="null"/>.</exception>
        public static StatusEffects GetStatusEffects(this Trait trait)
        {
            if (trait is null) throw new ArgumentNullException(nameof(trait));
            return (StatusEffects)trait.__RogueLibsContainer;
        }

    }
}
