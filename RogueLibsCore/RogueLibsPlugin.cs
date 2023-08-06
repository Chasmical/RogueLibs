using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using BepInEx;

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
            HookSystem.DeterminePatcherOptimizations();

            if (HookSystem.PatcherGeneration == HookSystem.LatestPatcherGeneration)
                Logger.LogInfo($"RogueLibsPatcher successfully detected. (gen. {HookSystem.PatcherGeneration})");
            else
                InstallOrUpgradePatcher();

            DeleteOutdatedPatchers();
        }
        private void InstallOrUpgradePatcher()
        {
            bool upgrading = HookSystem.PatcherGeneration > 0;
            Logger.LogWarning(upgrading
                                  ? $"RogueLibsPatcher is outdated (gen. {HookSystem.PatcherGeneration}). Attempting to upgrade it..."
                                  : "RogueLibsPatcher could not be detected. Attempting to install it...");
            try
            {
                byte[] patcherBytes = Properties.Resources.RogueLibsPatcher;
                string patcherPath = Path.Combine(Paths.PatcherPluginPath, $"RogueLibsPatcher.Gen{HookSystem.LatestPatcherGeneration}.dll");
                Logger.LogMessage($"\"{patcherPath}\"");
                File.WriteAllBytes(patcherPath, patcherBytes);
                Logger.LogMessage($"RogueLibsPatcher {(upgrading ? "upgraded" : "installed")} successfully! (gen. {HookSystem.LatestPatcherGeneration})");
                Logger.LogMessage("Hook system optimizations will be applied after a restart.");
            }
            catch (Exception e)
            {
                Logger.LogError($"RogueLibsPatcher could not be {(upgrading ? "upgraded" : "installed")}!");
                Logger.LogError(e);
            }
        }
        private void DeleteOutdatedPatchers()
        {
            // Only works when the game is launched as administrator
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                [MethodImpl(MethodImplOptions.NoInlining)]
                static void DeletePatcherOnReboot(string fileName)
                {
                    string path = Path.Combine(Paths.PatcherPluginPath, fileName);
                    if (File.Exists(path)) WindowsNativeMethods.MoveFileEx(path, null, MoveFileFlags.DelayUntilReboot);
                }

                try
                {
                    DeletePatcherOnReboot("RogueLibsPatcher.dll");
                    for (int i = 1; i < HookSystem.LatestPatcherGeneration; i++)
                        DeletePatcherOnReboot($"RogueLibsPatcher.Gen{i}.dll");
                }
                catch (Exception e)
                {
                    Logger.LogError(e);
                }
            }
        }

        private void OnDestroy()
            => awoken = 0;
    }
}
