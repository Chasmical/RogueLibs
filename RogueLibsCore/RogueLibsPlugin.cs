using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using BepInEx;
using RogueLibsCore.Properties;

namespace RogueLibsCore
{
    [BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.CompiledVersion)]
    [BepInIncompatibility(@"abbysssal.streetsofrogue.ectd")]
    [BepInIncompatibility(@"abbysssal.streetsofrogue.roguelibs")]
    internal sealed partial class RogueLibsPlugin : BaseUnityPlugin
    {
        public RoguePatcher Patcher = null!; // initialized in Awake()

        private static int awoken;

        private void Awake()
        {
            if (Interlocked.Exchange(ref awoken, 1) == 1)
            {
                Logger.LogError("RogueLibs multi-instancing is not supported!");
                return;
            }

#if DEBUG
            Logger.LogWarning($"Running RogueLibs v{RogueLibs.CompiledSemanticVersion}. (DEBUG CONFIGURATION)");
#else
            Logger.LogInfo($"Running RogueLibs v{RogueLibs.CompiledSemanticVersion}.");
#endif

            CheckPatcherInstallation();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            RogueFramework.Plugin = this;
            RogueFramework.Logger = Logger;

            Patcher = new RoguePatcher(this);
#if DEBUG
            Patcher.EnableStopwatch = true;
#endif
            PatchAbilities();
            PatchCharacterCreation();
            PatchItems();
            PatchMisc();
            PatchMainGUI();
            PatchScrollingMenu();
            PatchSprites();
            PatchTraitsAndStatusEffects();
            PatchUnlocks();
            PatchDisasters();
            PatchAgents();
            PatchInteractions();
            PatchAgentInteractions();
#if DEBUG
            Patcher.SortResults();
            Patcher.LogResults();
#endif
            sw.Stop();
            Logger.LogDebug($"RogueLibs took {sw.ElapsedMilliseconds,5:#####} ms to initialize.");
        }

        private void CheckPatcherInstallation()
        {
            try
            {
                [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
                static void TryUsingPatchedFields() => _ = new InvItem().__RogueLibsHooks;

                TryUsingPatchedFields();
                Logger.LogInfo("RogueLibsPatcher successfully detected.");
                HookSystem.OptimizedWithPatcher = true;
            }
            catch (MissingFieldException)
            {
                Logger.LogWarning("RogueLibsPatcher could not be detected. Attempting to install it...");
                HookSystem.OptimizedWithPatcher = false;
                InstallPatcher();
            }
        }
        private void InstallPatcher()
        {
            try
            {
                byte[] patcherBytes = Resources.RogueLibsPatcher;
                string patcherPath = Path.Combine(Paths.PatcherPluginPath, "RogueLibsPatcher.dll");
                Logger.LogMessage($"\"{patcherPath}\"");
                File.WriteAllBytes(patcherPath, patcherBytes);
                Logger.LogMessage("RogueLibsPatcher installed successfully!");
                Logger.LogMessage("Hook system optimizations will be applied after a restart.");
            }
            catch (Exception e)
            {
                Logger.LogError("RogueLibsPatcher could not be installed!");
                Logger.LogError(e);
            }
        }

        private void OnDestroy()
            => awoken = 0;
    }
}
