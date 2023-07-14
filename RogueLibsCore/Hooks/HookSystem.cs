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

        public static IHookController<InvItem>? GetHookControllerIfExists(this InvItem obj)
            => (IHookController<InvItem>?)(OptimizedWithPatcher ? Ref(obj) : Lookup(obj));
        public static IHookController<Trait>? GetHookControllerIfExists(this Trait obj)
            => (IHookController<Trait>?)(OptimizedWithPatcher ? Ref(obj) : Lookup(obj));
        public static IHookController<StatusEffect>? GetHookControllerIfExists(this StatusEffect obj)
            => (IHookController<StatusEffect>?)(OptimizedWithPatcher ? Ref(obj) : Lookup(obj));
        public static IHookController<TObject>? GetHookControllerIfExists<TObject>(this TObject obj) where TObject : PlayfieldObject
            => (IHookController<TObject>?)(OptimizedWithPatcher ? Ref(obj) : Lookup(obj));

        private static object AttachController(InvItem obj, IHookController controller)
            => OptimizedWithPatcher ? Ref(obj) = controller : Associate(obj, controller);
        private static object AttachController(Trait obj, IHookController controller)
            => OptimizedWithPatcher ? Ref(obj) = controller : Associate(obj, controller);
        private static object AttachController(StatusEffect obj, IHookController controller)
            => OptimizedWithPatcher ? Ref(obj) = controller : Associate(obj, controller);
        private static object AttachController(PlayfieldObject obj, IHookController controller)
            => OptimizedWithPatcher ? Ref(obj) = controller : Associate(obj, controller);

        public static IHookController<InvItem> GetHookController(this InvItem obj)
            => obj.GetHookControllerIfExists() ?? (IHookController<InvItem>)AttachController(obj, CreateController(obj));
        public static IHookController<Trait> GetHookController(this Trait obj)
            => obj.GetHookControllerIfExists() ?? (IHookController<Trait>)AttachController(obj, CreateController(obj));
        public static IHookController<StatusEffect> GetHookController(this StatusEffect obj)
            => obj.GetHookControllerIfExists() ?? (IHookController<StatusEffect>)AttachController(obj, CreateController(obj));
        public static IHookController<TObject> GetHookController<TObject>(this TObject obj) where TObject : PlayfieldObject
            => obj.GetHookControllerIfExists() ?? (IHookController<TObject>)AttachController(obj, CreateController(obj));

    }
}
