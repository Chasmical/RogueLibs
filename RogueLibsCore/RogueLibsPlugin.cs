﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using BepInEx;
using System.Threading;
using UnityEngine;

namespace RogueLibsCore
{
    [BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.CompiledVersion)]
    [BepInIncompatibility(@"abbysssal.streetsofrogue.ectd")]
    [BepInIncompatibility(@"abbysssal.streetsofrogue.roguelibs")]
    internal sealed partial class RogueLibsPlugin : BaseUnityPlugin
    {
        public RoguePatcher Patcher = null!; // initialized in Awake()
        public static RogueLibsPlugin Instance = null!;

        private static int awoken;
        public void Awake()
        {
            if (Interlocked.Exchange(ref awoken, 1) == 1)
            {
                Logger.LogError("A second instance of RogueLibs was awakened, so it was terminated immediately.");
                return;
            }

            string invalidPatcherPath = Path.Combine(Paths.PluginPath, "RogueLibsPatcher.dll");
            if (File.Exists(invalidPatcherPath))
            {
                Logger.LogWarning("Moved RogueLibsPatcher.dll from \\BepInEx\\plugins to \\BepInEx\\patchers.");
                File.Move(invalidPatcherPath, Path.Combine(Paths.PatcherPluginPath, "RogueLibsPatcher.dll"));

                string[] cmdArgs = Environment.GetCommandLineArgs();
                // string fileName = cmdArgs[0];
                StringBuilder args = new StringBuilder();
                for (int i = 1; i < cmdArgs.Length; i++)
                    args.Append(' ').Append('\"').Append(cmdArgs[i].Replace("\"", "\\\"")).Append('\"');

                Directory.Delete(Application.temporaryCachePath, true);

                // Process.Start(fileName, args.ToString());

                Application.Quit(0);
                Logger.LogError("\n===================================================" +
                                "\n‖‖‖    RogueLibsPatcher was installed in the    ‖‖‖" +
                                "\n‖‖‖ wrong directory! Restart the game manually. ‖‖‖" +
                                "\n===================================================");
                Thread.Sleep(3000);
                Process.GetCurrentProcess().Kill();
                return;
            }

            try
            {
                [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
                // ReSharper disable once UnusedLocalFunctionReturnValue
                static int Use(object? obj) => obj?.GetHashCode() ?? 0;

                PlayfieldObject test = new PlayfieldObject();
                Use(test.__RogueLibsHooks);
                test.__RogueLibsHooks = new object();
                Use(test.__RogueLibsHooks);
            }
            catch (Exception)
            {
                Application.Quit(0);
                Logger.LogError("\n==========================================" +
                                "\n‖‖‖ RogueLibsPatcher is not installed! ‖‖‖" +
                                "\n‖‖‖  Install it and restart the game.  ‖‖‖" +
                                "\n==========================================");
                Thread.Sleep(3000);
                Process.GetCurrentProcess().Kill();
                return;
            }

            Logger.LogInfo($"Running RogueLibs v{RogueLibs.CompiledSemanticVersion}.");
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Instance = this;
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
            Logger.LogDebug($"RogueLibs took {sw.ElapsedMilliseconds,5:#####} ms to load.");
        }
    }
}
