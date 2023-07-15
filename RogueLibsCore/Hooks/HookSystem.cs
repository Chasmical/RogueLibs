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

    }
}
