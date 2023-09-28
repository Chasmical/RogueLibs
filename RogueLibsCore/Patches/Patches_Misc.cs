using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchMisc()
        {
            // initialize LanguageService
            Patcher.Postfix(typeof(NameDB), nameof(NameDB.RealAwake));
            // CustomNames
            Patcher.Prefix(typeof(NameDB), nameof(NameDB.GetName));

            // IDoUpdate.Update
            Patcher.Postfix(typeof(Updater), "Update");
            // IDoLateUpdate.LateUpdate
            Patcher.Postfix(typeof(Updater), "LateUpdate");
            // IDoFixedUpdate.FixedUpdate
            Patcher.Postfix(typeof(Updater), "FixedUpdate");

            // load prepared AudioClips
            Patcher.Prefix(typeof(AudioHandler), nameof(AudioHandler.SetupDics), nameof(AudioHandler_SetupDics_Prefix));
            Patcher.Postfix(typeof(AudioHandler), nameof(AudioHandler.SetupDics));

            // remove 99 nuggets max limit
            Patcher.Prefix(typeof(Unlocks), nameof(Unlocks.AddNuggets));

            Patcher.Postfix(typeof(GameController), nameof(GameController.SetVersionText));

            // clear hooks on PlayfieldObject.RecycleAwake()
            Patcher.Postfix(typeof(PlayfieldObject), nameof(PlayfieldObject.RecycleAwake));
            // custom Discord links
            Patcher.Prefix(typeof(MenuGUI), nameof(MenuGUI.PressedDiscordButton));

            Patcher.AnyErrors();

            RogueLibs.CreateCustomName("DiscordButton", NameTypes.Interface, new CustomNameInfo
            {
                English = "Discord",
                Russian = @"Оф. Русский Discord",
            });
            DiscordLinkInfo = new CustomNameInfo
            {
                English = "https://discord.gg/ucsAHt62eB",
                Russian = "https://discord.gg/neDvsmk",
            };
        }
        private static CustomNameInfo DiscordLinkInfo;

        private static bool firstRun = true;
        public static void NameDB_RealAwake(NameDB __instance)
        {
            if (!LanguageService.Languages.TryGetValue(__instance.language, out LanguageCode code))
                code = LanguageCode.English;

            LanguageService.NameDB = __instance;
            if (firstRun)
            {
                LanguageService.current = code;
                firstRun = false;
                Localization.Init();
            }
            else
            {
                LanguageService.Current = code;
            }
        }
        public static bool NameDB_GetName(string? myName, string type, out string? __result)
        {
            string? res = Localization.GetName(myName, type);
            if (res?.StartsWith("E_") == true) res = null;

            foreach (INameProvider provider in RogueFramework.NameProviders)
                provider.GetName(myName, type, ref res);

            __result = res;
            return __result is null;
        }

        public static void Updater_Update()
        {
            GameController gc = GameController.gameController;
            if (gc.levelTransitioning || gc.offlineGameStarting) return;
            HookEvents.updateDispatcher.DispatchEvent(static h => h.Update());
        }
        public static void Updater_LateUpdate()
        {
            GameController gc = GameController.gameController;
            if (gc.levelTransitioning || gc.offlineGameStarting) return;
            HookEvents.lateUpdateDispatcher.DispatchEvent(static h => h.LateUpdate());
        }
        public static void Updater_FixedUpdate()
        {
            if (GameController.gameController.levelTransitioning) return;
            HookEvents.fixedUpdateDispatcher.DispatchEvent(static h => h.FixedUpdate());
        }

        // ReSharper disable once IdentifierTypo
        public static void AudioHandler_SetupDics_Prefix(AudioHandler __instance, out bool __state)
            => __state = __instance.loadedDics;
        internal static readonly List<AudioClip> preparedClips = new List<AudioClip>();
        // ReSharper disable once IdentifierTypo
        public static void AudioHandler_SetupDics(AudioHandler __instance, ref bool __state)
        {
            if (__state) return;
            foreach (AudioClip clip in preparedClips)
            {
                __instance.audioClipRealList.Add(clip);
                __instance.audioClipList.Add(clip.name);
                __instance.audioClipDic.Add(clip.name, clip);
            }
        }

        public static bool Unlocks_AddNuggets(int numNuggets)
        {
            GameController.gameController.sessionDataBig.nuggets += numNuggets;
            GameController.gameController.unlocks.SaveUnlockData(true);
            return false;
        }

        public static void GameController_SetVersionText(GameController __instance)
        {
            Text version = __instance.versionText2;
            if (!version.text.StartsWith("SoR ", StringComparison.OrdinalIgnoreCase))
                version.text = $"SoR {version.text}, RL v{RogueLibs.CompiledSemanticVersion}";
        }

        public static void PlayfieldObject_RecycleAwake(PlayfieldObject __instance)
        {
            HookSystem.DestroyHookController(__instance);

            GetOrCreateModel(__instance);

            IHookController controller = __instance.GetHookController();
            foreach (IHookFactory factory in RogueFramework.ObjectFactories)
            {
                IHook? hook = factory.TryCreateHook(__instance);
                if (hook is not null) controller.AddHook(hook);
            }
        }

        public static bool MenuGUI_PressedDiscordButton()
        {
            GameController gc = GameController.gameController;
            LanguageCode cur = LanguageService.Current;
            if (Application.systemLanguage == SystemLanguage.Russian)
                cur = LanguageCode.Russian;
            Application.OpenURL(DiscordLinkInfo[cur] ?? DiscordLinkInfo.English);
            return false;
        }

    }
}
