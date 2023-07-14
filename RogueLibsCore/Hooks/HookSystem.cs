using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RogueLibsCore
{
    public static class HookSystem
    {
        public static bool OptimizedWithPatcher { get; internal set; }

        private static readonly ConditionalWeakTable<object, IHookController> controllers = new();
        private static readonly Dictionary<Type, ConstructorInfo> constructors = new();

        private static IHookController CreateHookController(object obj)
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IHookController? GetPatched(InvItem instance, bool create)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            IHookController? controller = instance.__RogueLibsHooks as IHookController;
            if (controller is null && create) instance.__RogueLibsHooks = controller = CreateHookController(instance);
            return controller;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IHookController? GetPatched(PlayfieldObject instance, bool create)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            IHookController? controller = instance.__RogueLibsHooks as IHookController;
            if (controller is null && create) instance.__RogueLibsHooks = controller = CreateHookController(instance);
            return controller;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IHookController? GetPatched(StatusEffect instance, bool create)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            IHookController? controller = instance.__RogueLibsHooks as IHookController;
            if (controller is null && create) instance.__RogueLibsHooks = controller = CreateHookController(instance);
            return controller;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IHookController? GetPatched(Trait instance, bool create)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            IHookController? controller = instance.__RogueLibsHooks as IHookController;
            if (controller is null && create) instance.__RogueLibsHooks = controller = CreateHookController(instance);
            return controller;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IHookController GetFromTable(object instance, bool create)
        {
            if (instance is null) throw new ArgumentNullException(nameof(instance));
            if (!controllers.TryGetValue(instance, out IHookController? controller) && create)
                controllers.Add(instance, controller = CreateHookController(instance));
            return controller;
        }

        public static IHookController<InvItem>? GetHookControllerIfExists(this InvItem instance)
            => (IHookController<InvItem>?)(OptimizedWithPatcher ? GetPatched(instance, false) : GetFromTable(instance, false));
        public static IHookController<TObject>? GetHookControllerIfExists<TObject>(this TObject instance) where TObject : PlayfieldObject
            => (IHookController<TObject>?)(OptimizedWithPatcher ? GetPatched(instance, false) : GetFromTable(instance, false));
        public static IHookController<StatusEffect>? GetHookControllerIfExists(this StatusEffect instance)
            => (IHookController<StatusEffect>?)(OptimizedWithPatcher ? GetPatched(instance, false) : GetFromTable(instance, false));
        public static IHookController<Trait>? GetHookControllerIfExists(this Trait instance)
            => (IHookController<Trait>?)(OptimizedWithPatcher ? GetPatched(instance, false) : GetFromTable(instance, false));

        public static IHookController<InvItem> GetHookController(this InvItem instance)
            => (IHookController<InvItem>?)(OptimizedWithPatcher ? GetPatched(instance, true) : GetFromTable(instance, true))!;
        public static IHookController<TObject> GetHookController<TObject>(this TObject instance) where TObject : PlayfieldObject
            => (IHookController<TObject>?)(OptimizedWithPatcher ? GetPatched(instance, true) : GetFromTable(instance, true))!;
        public static IHookController<StatusEffect> GetHookController(this StatusEffect instance)
            => (IHookController<StatusEffect>?)(OptimizedWithPatcher ? GetPatched(instance, true) : GetFromTable(instance, true))!;
        public static IHookController<Trait> GetHookController(this Trait instance)
            => (IHookController<Trait>?)(OptimizedWithPatcher ? GetPatched(instance, true) : GetFromTable(instance, true))!;

        private static bool DestroyPatchedInternal(ref object? field)
        {
            ((IDisposable?)field)?.Dispose();
            return (field = null) is null;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool DestroyPatched(InvItem instance)
            => DestroyPatchedInternal(ref instance.__RogueLibsHooks);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool DestroyPatched(PlayfieldObject instance)
            => DestroyPatchedInternal(ref instance.__RogueLibsHooks);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool DestroyPatched(StatusEffect instance)
            => DestroyPatchedInternal(ref instance.__RogueLibsHooks);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool DestroyPatched(Trait instance)
            => DestroyPatchedInternal(ref instance.__RogueLibsHooks);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool DestroyFromTable(object instance)
        {
            if (controllers.TryGetValue(instance, out IHookController? controller))
            {
                ((IDisposable)controller).Dispose();
                return controllers.Remove(instance);
            }
            return false;
        }

        public static void DestroyHookController(InvItem instance)
            => _ = OptimizedWithPatcher ? DestroyPatched(instance) : DestroyFromTable(instance);
        public static void DestroyHookController(PlayfieldObject instance)
            => _ = OptimizedWithPatcher ? DestroyPatched(instance) : DestroyFromTable(instance);
        public static void DestroyHookController(StatusEffect instance)
            => _ = OptimizedWithPatcher ? DestroyPatched(instance) : DestroyFromTable(instance);
        public static void DestroyHookController(Trait instance)
            => _ = OptimizedWithPatcher ? DestroyPatched(instance) : DestroyFromTable(instance);

    }
}
