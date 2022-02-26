using System;
using System.Reflection;
using JetBrains.Annotations;

namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        private static RoguePatcher patcher = null!;

        internal static void PatchAll()
        {
            patcher = RogueFramework.Plugin.Patcher;
            patcher.Postfix(typeof(PlayfieldObject), "Awake");

            object[] empty = new object[0];
            foreach (MethodInfo method in typeof(VanillaInteractions).GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                if (method.GetCustomAttribute<IncludeAttribute>() is not null)
                    method.Invoke(null, empty);
            }
        }

        [Include]
        private static void Debug()
        {
            RogueInteractions.CreateProvider(static h =>
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.EnableHints))
                    h.AddButton("InteractionsPatched", static m => m.StopInteraction());
            });
            RogueLibs.CreateCustomName("InteractionsPatched", NameTypes.Interface, new CustomNameInfo
            {
                English = "I am patched!",
                Russian = @"Я пропатчен!",
            });
        }

        private static readonly Type[] Params1 = { typeof(string) };
        private static readonly Type[] Params2 = { typeof(string), typeof(int) };
        public static void Patch<T>(Type[] parameterTypes) where T : PlayfieldObject
        {
            patcher.Prefix(typeof(T), nameof(PlayfieldObject.DetermineButtons), nameof(RogueLibsPlugin.DetermineButtonsHook));
            patcher.Prefix(typeof(T), nameof(PlayfieldObject.PressedButton), nameof(RogueLibsPlugin.PressedButtonHook), parameterTypes);
        }
        public static void PatchInteract<T>() where T : PlayfieldObject
        {
            patcher.Prefix(typeof(T), nameof(PlayfieldObject.Interact), nameof(RogueLibsPlugin.InteractHook));
        }
        public static void PatchInteractFar<T>() where T : PlayfieldObject
        {
            patcher.Prefix(typeof(T), nameof(PlayfieldObject.InteractFar), nameof(RogueLibsPlugin.InteractFarHook));
        }
        public static void MakeInteractable<T>() where T : PlayfieldObject
        {
            patcher.Postfix(typeof(T), "Awake", nameof(RogueLibsPlugin.AwakeInteractableHook));
            patcher.Postfix(typeof(T), nameof(PlayfieldObject.RecycleAwake), nameof(RogueLibsPlugin.RecycleAwakeInteractableHook));
        }

        [AttributeUsage(AttributeTargets.Method), MeansImplicitUse]
        internal class IncludeAttribute : Attribute { }

    }
}
