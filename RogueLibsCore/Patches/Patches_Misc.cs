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
            // IDoFixedUpdate.FixedUpdate
            Patcher.Postfix(typeof(Updater), nameof(Updater.FixedUpdate));
            // IDoLateUpdate.LateUpdate
            Patcher.Postfix(typeof(Updater), "LateUpdate");

            // load prepared AudioClips
            Patcher.Prefix(typeof(AudioHandler), nameof(AudioHandler.SetupDics), nameof(AudioHandler_SetupDics_Prefix));
            Patcher.Postfix(typeof(AudioHandler), nameof(AudioHandler.SetupDics));

            // remove 99 nuggets max limit
            Patcher.Prefix(typeof(Unlocks), nameof(Unlocks.AddNuggets));

            Patcher.Postfix(typeof(MainGUI), "Awake");
            Patcher.Postfix(typeof(GameController), nameof(GameController.SetVersionText));

            // clear hooks on PlayfieldObject.RecycleAwake()
            Patcher.Postfix(typeof(PlayfieldObject), nameof(PlayfieldObject.RecycleAwake));

            Patcher.AnyErrors();

            RogueLibs.CreateVersionText("RogueLibsVersion", "RL v" + RogueLibs.CompiledSemanticVersion);
        }

        private static bool firstRun = true;
        public static void NameDB_RealAwake(NameDB __instance)
        {
            if (!LanguageService.Languages.TryGetValue(__instance.language, out LanguageCode code))
                code = LanguageCode.English;
            if (RogueFramework.IsDebugEnabled(DebugFlags.Names))
                RogueFramework.LogDebug($"Current language: {LanguageService.GetLanguageName(code)} ({(int)code})");

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

        internal static bool updatingHooks;
        internal static bool fixedUpdatingHooks;
        internal static bool lateUpdatingHooks;
        internal static readonly List<WeakReference<IHook>> doUpdateHooks = new List<WeakReference<IHook>>();
        internal static readonly List<WeakReference<IHook>> doFixedUpdateHooks = new List<WeakReference<IHook>>();
        internal static readonly List<WeakReference<IHook>> doLateUpdateHooks = new List<WeakReference<IHook>>();
        internal static readonly List<WeakReference<IHook>> removeDoUpdateHooks = new List<WeakReference<IHook>>();
        internal static readonly List<WeakReference<IHook>> removeDoFixedUpdateHooks = new List<WeakReference<IHook>>();
        internal static readonly List<WeakReference<IHook>> removeDoLateUpdateHooks = new List<WeakReference<IHook>>();

        public static void Updater_Update()
        {
            GameController gc = GameController.gameController;
            if (gc.levelTransitioning || gc.offlineGameStarting) return;
            try
            {
                updatingHooks = true;
                for (int i = 0, count = doUpdateHooks.Count; i < count; i++)
                {
                    WeakReference<IHook> hookRef = doUpdateHooks[i];
                    if (!hookRef.TryGetTarget(out IHook? hook))
                        removeDoUpdateHooks.Add(hookRef);
                    else ((IDoUpdate)hook).Update();
                }
            }
            finally
            {
                updatingHooks = false;
                if (removeDoUpdateHooks.Count > 0)
                {
                    doUpdateHooks.RemoveAll(removeDoUpdateHooks.Contains);
                    removeDoUpdateHooks.Clear();
                }
            }
        }
        public static void Updater_FixedUpdate()
        {
            if (GameController.gameController.levelTransitioning) return;
            try
            {
                fixedUpdatingHooks = true;
                for (int i = 0, count = doFixedUpdateHooks.Count; i < count; i++)
                {
                    WeakReference<IHook> hookRef = doFixedUpdateHooks[i];
                    if (!hookRef.TryGetTarget(out IHook? hook))
                        removeDoFixedUpdateHooks.Add(hookRef);
                    // ReSharper disable once SuspiciousTypeConversion.Global
                    else ((IDoFixedUpdate)hook).FixedUpdate();
                }
            }
            finally
            {
                fixedUpdatingHooks = false;
                if (removeDoFixedUpdateHooks.Count > 0)
                {
                    doFixedUpdateHooks.RemoveAll(removeDoFixedUpdateHooks.Contains);
                    removeDoFixedUpdateHooks.Clear();
                }
            }
        }
        public static void Updater_LateUpdate()
        {
            GameController gc = GameController.gameController;
            if (gc.levelTransitioning || gc.offlineGameStarting) return;
            try
            {
                lateUpdatingHooks = true;
                for (int i = 0, count = doLateUpdateHooks.Count; i < count; i++)
                {
                    WeakReference<IHook> hookRef = doLateUpdateHooks[i];
                    if (!hookRef.TryGetTarget(out IHook? hook))
                        removeDoLateUpdateHooks.Add(hookRef);
                    // ReSharper disable once SuspiciousTypeConversion.Global
                    else ((IDoLateUpdate)hook).LateUpdate();
                }
            }
            finally
            {
                lateUpdatingHooks = false;
                if (removeDoLateUpdateHooks.Count > 0)
                {
                    doLateUpdateHooks.RemoveAll(removeDoLateUpdateHooks.Contains);
                    removeDoLateUpdateHooks.Clear();
                }
            }
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

        internal static bool versionLinesReady;
        internal static readonly List<VersionText> versionLines = new List<VersionText>();
        private static Vector3 versionTextOffset;
        internal static Text AttachVersionText(GameObject versionObj, string id, string? text)
        {
            GameObject? myObject = versionObj.transform.Find(id)?.gameObject;
            if (myObject != null) return myObject.GetComponent<Text>();

            myObject = new GameObject(id);
            myObject.transform.SetParent(versionObj.transform);

            Text txt = myObject.AddComponent<Text>();
            txt.text = text;
            txt.font = versionObj.GetComponent<Text>().font;
            txt.fontSize = 40;
            txt.horizontalOverflow = HorizontalWrapMode.Overflow;

            RectTransform rect = myObject.GetComponent<RectTransform>();
            rect.anchorMin = rect.anchorMax = Vector2.zero;
            rect.position = versionTextOffset;
            versionTextOffset += new Vector3(0f, 20f, 0f);
            rect.localScale = Vector3.one;
            rect.pivot = Vector2.zero;

            return txt;
        }
        public static void MainGUI_Awake()
        {
            versionLinesReady = true;
            versionTextOffset = new Vector3(5f, -10f, 0f);
            GameObject versionObj = GameObject.Find("VersionText2");
            foreach (VersionText versionText in versionLines)
            {
                GameObject? alreadyAttached = versionObj.transform.Find(versionText.Id)?.gameObject;
                if (alreadyAttached != null) return;
                versionText.AssignText(AttachVersionText(versionObj, versionText.Id, versionText.Text));
            }
        }
        public static void GameController_SetVersionText(GameController __instance)
        {
            Text version = __instance.versionText2;
            if (!version.text.StartsWith("SoR ", StringComparison.OrdinalIgnoreCase))
                version.text = "SoR " + version.text;
        }

        public static void PlayfieldObject_RecycleAwake(PlayfieldObject __instance)
        {
            (__instance.__RogueLibsHooks as IDisposable)?.Dispose();
            __instance.__RogueLibsHooks = null;

            GetOrCreateModel(__instance);

            bool debug = RogueFramework.IsDebugEnabled(DebugFlags.Effects);
            foreach (IHookFactory<PlayfieldObject> factory in RogueFramework.ObjectFactories)
                if (factory.TryCreate(__instance, out IHook<PlayfieldObject>? hook))
                {
                    if (debug) RogueFramework.LogDebug($"Initializing object hook {hook} ({__instance.objectName}.");
                    __instance.AddHook(hook);
                }
        }
    }
}
