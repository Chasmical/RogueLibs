﻿using System;
using System.Diagnostics;
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

            Logger.LogInfo($"Running RogueLibs v{RogueLibs.CompiledSemanticVersion}.");

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

                // TODO: attempt to install RogueLibsPatcher.dll automatically (try-catch)
            }

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

        private void OnDestroy()
            => awoken = 0;
    }
}
