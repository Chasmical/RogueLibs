using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RogueLibsCore
{
    public static class HookSystem
    {
        public static bool OptimizedWithPatcher { get; internal set; }

        private static readonly ConditionalWeakTable<object, object> controllers = new();
        private static readonly ConditionalWeakTable<object, object> extraLookup = new();
        private static readonly Dictionary<Type, ConstructorInfo> constructors = new();

        private static IHookController CreateController(object obj)
        {
            Type objType = obj.GetType();
            if (!constructors.TryGetValue(objType, out ConstructorInfo? ctor))
            {
                Type controllerType = typeof(HookController<>).MakeGenericType(objType);
                ctor = controllerType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[1] { objType }, null)!;
                constructors.Add(objType, ctor);
            }
            return (IHookController)ctor.Invoke(new object[1] { obj });
        }

        [MethodImpl(MethodImplOptions.NoInlining)] private static ref object? Ref(InvItem obj) => ref obj.__RogueLibsHooks;
        [MethodImpl(MethodImplOptions.NoInlining)] private static ref object? Ref(PlayfieldObject obj) => ref obj.__RogueLibsHooks;
        [MethodImpl(MethodImplOptions.NoInlining)] private static ref object? Ref(StatusEffect obj) => ref obj.__RogueLibsHooks;
        [MethodImpl(MethodImplOptions.NoInlining)] private static ref object? Ref(Trait obj) => ref obj.__RogueLibsHooks;

        private static object? Lookup(object obj)
            => controllers.TryGetValue(obj, out object? value) ? value : null;
        private static object Associate(object obj, object controller)
        {
            controllers.Add(obj, controller);
            return controller;
        }

        public static IHookController<InvItem>? GetHookControllerIfExists(this InvItem instance)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            return (IHookController<InvItem>?)(OptimizedWithPatcher ? Ref(instance) : Lookup(instance));
        }
        public static IHookController<Trait>? GetHookControllerIfExists(this Trait instance)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            return (IHookController<Trait>?)(OptimizedWithPatcher ? Ref(instance) : Lookup(instance));
        }
        public static IHookController<StatusEffect>? GetHookControllerIfExists(this StatusEffect instance)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            return (IHookController<StatusEffect>?)(OptimizedWithPatcher ? Ref(instance) : Lookup(instance));
        }
        public static IHookController<TObject>? GetHookControllerIfExists<TObject>(this TObject instance) where TObject : PlayfieldObject
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            return (IHookController<TObject>?)(OptimizedWithPatcher ? Ref(instance) : Lookup(instance));
        }

        private static object AttachController(InvItem obj, IHookController controller)
            => OptimizedWithPatcher ? Ref(obj) = controller : Associate(obj, controller);
        private static object AttachController(Trait obj, IHookController controller)
            => OptimizedWithPatcher ? Ref(obj) = controller : Associate(obj, controller);
        private static object AttachController(StatusEffect obj, IHookController controller)
            => OptimizedWithPatcher ? Ref(obj) = controller : Associate(obj, controller);
        private static object AttachController(PlayfieldObject obj, IHookController controller)
            => OptimizedWithPatcher ? Ref(obj) = controller : Associate(obj, controller);

        public static IHookController<InvItem> GetHookController(this InvItem instance)
            => instance.GetHookControllerIfExists() ?? (IHookController<InvItem>)AttachController(instance, CreateController(instance));
        public static IHookController<Trait> GetHookController(this Trait instance)
            => instance.GetHookControllerIfExists() ?? (IHookController<Trait>)AttachController(instance, CreateController(instance));
        public static IHookController<StatusEffect> GetHookController(this StatusEffect instance)
            => instance.GetHookControllerIfExists() ?? (IHookController<StatusEffect>)AttachController(instance, CreateController(instance));
        public static IHookController<TObject> GetHookController<TObject>(this TObject instance) where TObject : PlayfieldObject
            => instance.GetHookControllerIfExists() ?? (IHookController<TObject>)AttachController(instance, CreateController(instance));

        private static bool RemoveController(ref object? field)
        {
            (field as IDisposable)?.Dispose();
            return (field = null) is null;
        }
        private static bool RemoveController(object obj)
        {
            if (controllers.TryGetValue(obj, out object? controller))
            {
                (controller as IDisposable)?.Dispose();
                return controllers.Remove(obj);
            }
            return false;
        }

        public static void DestroyHookController(InvItem instance)
            => _ = OptimizedWithPatcher ? RemoveController(ref Ref(instance)) : RemoveController(instance);
        public static void DestroyHookController(Trait instance)
            => _ = OptimizedWithPatcher ? RemoveController(ref Ref(instance)) : RemoveController(instance);
        public static void DestroyHookController(StatusEffect instance)
            => _ = OptimizedWithPatcher ? RemoveController(ref Ref(instance)) : RemoveController(instance);
        public static void DestroyHookController(PlayfieldObject instance)
            => _ = OptimizedWithPatcher ? RemoveController(ref Ref(instance)) : RemoveController(instance);



        [MethodImpl(MethodImplOptions.NoInlining)] private static ref object? RefExtra(Trait obj) => ref obj.__RogueLibsContainer;
        [MethodImpl(MethodImplOptions.NoInlining)] private static ref object? RefExtra(StatusEffect obj) => ref obj.__RogueLibsContainer;
        [MethodImpl(MethodImplOptions.NoInlining)] private static ref object? RefExtra(Unlock obj) => ref obj.__RogueLibsCustom;
        [MethodImpl(MethodImplOptions.NoInlining)] private static ref object? RefExtra(ButtonData obj) => ref obj.__RogueLibsCustom;
        [MethodImpl(MethodImplOptions.NoInlining)] private static ref object? RefExtra(tk2dSpriteDefinition obj) => ref obj.__RogueLibsCustom;

        private static object? LookupExtra(object obj)
            => extraLookup.TryGetValue(obj, out object? value) ? value : null;
        private static object AssociateExtra(object obj, object extra)
        {
            extraLookup.Add(obj, extra);
            return extra;
        }

        public static void SetStatusEffects(Trait instance, StatusEffects parent)
            => _ = OptimizedWithPatcher ? RefExtra(instance) = parent : AssociateExtra(instance, parent);
        public static void SetStatusEffects(StatusEffect instance, StatusEffects parent)
            => _ = OptimizedWithPatcher ? RefExtra(instance) = parent : AssociateExtra(instance, parent);

        /// <summary>
        ///   <para>Returns the <see cref="StatusEffects"/> instance containing the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The current instance of <see cref="Trait"/>.</param>
        /// <returns>The <see cref="StatusEffects"/> instance containing the current <paramref name="instance"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static StatusEffects? GetStatusEffects(this Trait instance)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            return (StatusEffects?)(OptimizedWithPatcher ? RefExtra(instance) : LookupExtra(instance));
        }
        /// <summary>
        ///   <para>Returns the <see cref="StatusEffects"/> instance containing the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The current instance of <see cref="StatusEffect"/>.</param>
        /// <returns>The <see cref="StatusEffects"/> instance containing the current <paramref name="instance"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static StatusEffects? GetStatusEffects(this StatusEffect instance)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            return (StatusEffects?)(OptimizedWithPatcher ? RefExtra(instance) : LookupExtra(instance));
        }

        public static void SetHook(Unlock instance, UnlockWrapper wrapper)
            => _ = OptimizedWithPatcher ? RefExtra(instance) = wrapper : AssociateExtra(instance, wrapper);
        public static void SetHook(ButtonData instance, UnlockWrapper wrapper)
            => _ = OptimizedWithPatcher ? RefExtra(instance) = wrapper : AssociateExtra(instance, wrapper);

        /// <summary>
        ///   <para>Returns the <see cref="UnlockWrapper"/> attached to the current <paramref name="instance"/>.</para>
        /// </summary>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The attached <see cref="UnlockWrapper"/> hook, if found; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static UnlockWrapper? GetHook(this Unlock instance)
            => (UnlockWrapper?)(OptimizedWithPatcher ? RefExtra(instance) : LookupExtra(instance));
        /// <summary>
        ///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
        /// </summary>
        /// <typeparam name="THook">The type of a hook to search for.</typeparam>
        /// <param name="instance">The instance of a hookable type.</param>
        /// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
        public static THook? GetHook<THook>(this Unlock instance) where THook : UnlockWrapper
            => instance.GetHook() as THook;
        public static UnlockWrapper? GetHook(this ButtonData instance)
            => (UnlockWrapper?)(OptimizedWithPatcher ? RefExtra(instance) : LookupExtra(instance));

        public static void SetHook(tk2dSpriteDefinition instance, RogueSprite wrapper)
            => _ = OptimizedWithPatcher ? RefExtra(instance) = wrapper : AssociateExtra(instance, wrapper);
        public static void RemoveHook(tk2dSpriteDefinition instance)
            => _ = OptimizedWithPatcher ? RefExtra(instance) = null : extraLookup.Remove(instance);

        public static RogueSprite? GetHook(this tk2dSpriteDefinition instance)
            => (RogueSprite?)(OptimizedWithPatcher ? RefExtra(instance) : LookupExtra(instance));

    }
}
