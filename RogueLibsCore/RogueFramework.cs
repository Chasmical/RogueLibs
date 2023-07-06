using System;
using System.Runtime.CompilerServices;
using BepInEx.Logging;

namespace RogueLibsCore
{
    public static class RogueFramework
    {
        // initialized in RogueLibsPlugin.Awake()
        public static RogueLibsPlugin Plugin { get; internal set; } = null!;
        public static ManualLogSource Logger { get; internal set; } = null!;

        public static bool Debug
        {
            [MethodImpl(MethodImplOptions.NoInlining)] get =>
#if DEBUG
                true;
#else
                false;
#endif
        }

        internal const int SpecialInt = -488755541;

        public static void LogDebug(string message)
        {
            Logger.LogDebug(message);
        }
        public static void LogDebug(Type sourceType, string message)
        {
            Logger.LogDebug($"[{sourceType.FullName}] {message}");
        }

        public static void LogWarning(string message)
        {
            Logger.LogWarning(message);
        }
        public static void LogWarning(Type sourceType, string message)
        {
            Logger.LogWarning($"[{sourceType.FullName}] {message}");
        }

        public static void LogError(string message, Exception exception)
        {
            Logger.LogError(message);
            Logger.LogError(exception);
        }
        public static void LogError(Type sourceType, string message, Exception exception)
        {
            Logger.LogError($"[{sourceType.FullName}] {message}");
            Logger.LogError(exception);
        }

    }
}
