using System;
using System.Linq;
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

            // load prepared AudioClips
            Patcher.Prefix(typeof(AudioHandler), nameof(AudioHandler.SetupDics), nameof(AudioHandler_SetupDics_Prefix));
            Patcher.Postfix(typeof(AudioHandler), nameof(AudioHandler.SetupDics));

            // remove 99 nuggets max limit
            Patcher.Prefix(typeof(Unlocks), nameof(Unlocks.AddNuggets));

            Patcher.Postfix(typeof(MainGUI), "Awake");
            Patcher.Postfix(typeof(GameController), nameof(GameController.SetVersionText));

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
        public static bool NameDB_GetName(string myName, string type, ref string __result)
        {
            string orig = Localization.GetName(myName, type);
            __result = orig;
            if (__result?.StartsWith("E_") == true) __result = null;

            foreach (INameProvider provider in RogueFramework.NameProviders)
                provider.GetName(myName, type, ref __result);

            if (__result is null) __result = orig;
            return __result is null;
        }

        public static void Updater_Update()
        {
            foreach (Agent agent in GameController.gameController.agentList.ToList())
            {
                foreach (IDoUpdate obj in agent.GetHooks<IDoUpdate>())
                    try { obj.Update(); }
                    catch (Exception e) { RogueFramework.LogError(e, "IDoUpdate.Update", obj); }

                InvItem specialAbility = agent.inventory.equippedSpecialAbility;
                if (specialAbility != null)
                    foreach (IDoUpdate obj in specialAbility.GetHooks<IDoUpdate>())
                        try { obj.Update(); }
                        catch (Exception e) { RogueFramework.LogError(e, "IDoUpdate.Update", obj, agent); }

                foreach (InvItem item in agent.inventory.InvItemList.ToList())
                        if (item != specialAbility)
                        foreach (IDoUpdate obj in item.GetHooks<IDoUpdate>())
                            try { obj.Update(); }
                            catch (Exception e) { RogueFramework.LogError(e, "IDoUpdate.Update", obj, agent); }

                foreach (StatusEffect effect in agent.statusEffects.StatusEffectList.ToList())
                    foreach (IDoUpdate obj in effect.GetHooks<IDoUpdate>())
                        try { obj.Update(); }
                        catch (Exception e) { RogueFramework.LogError(e, "IDoUpdate.Update", obj, agent); }

                foreach (Trait trait in agent.statusEffects.TraitList.ToList())
                    foreach (IDoUpdate obj in trait.GetHooks<IDoUpdate>())
                        try { obj.Update(); }
                        catch (Exception e) { RogueFramework.LogError(e, "IDoUpdate.Update", obj, agent); }
            }

            foreach (ObjectReal objectReal in GameController.gameController.objectRealListUpdate.ToList())
            {
                foreach (IDoUpdate obj in objectReal.GetHooks<IDoUpdate>())
                    try { obj.Update(); }
                    catch (Exception e) { RogueFramework.LogError(e, "IDoUpdate.Update", obj); }

                if (objectReal.objectInvDatabase != null)
                    foreach (InvItem item in objectReal.objectInvDatabase.InvItemList)
                        foreach (IDoUpdate obj in item.GetHooks<IDoUpdate>())
                            try { obj.Update(); }
                            catch (Exception e) { RogueFramework.LogError(e, "IDoUpdate.Update", obj, objectReal); }
            }

            foreach (Item item in GameController.gameController.itemList.ToList())
                foreach (IDoUpdate obj in item.invItem.GetHooks<IDoUpdate>())
                    try { obj.Update(); }
                    catch (Exception e) { RogueFramework.LogError(e, "IDoUpdate.Update", obj, item); }
        }
        public static void Updater_FixedUpdate()
        {
            foreach (Agent agent in GameController.gameController.agentList.ToList())
            {
                foreach (IDoFixedUpdate obj in agent.GetHooks<IDoFixedUpdate>())
                    try { obj.FixedUpdate(); }
                    catch (Exception e) { RogueFramework.LogError(e, "IDoFixedUpdate.FixedUpdate", obj); }

                InvItem specialAbility = agent.inventory.equippedSpecialAbility;
                if (specialAbility != null)
                    foreach (IDoFixedUpdate obj in specialAbility.GetHooks<IDoFixedUpdate>())
                        try { obj.FixedUpdate(); }
                        catch (Exception e) { RogueFramework.LogError(e, "IDoFixedUpdate.FixedUpdate", obj, agent); }

                foreach (InvItem item in agent.inventory.InvItemList.ToList())
                    if (item != specialAbility)
                        foreach (IDoFixedUpdate obj in item.GetHooks<IDoFixedUpdate>())
                            try { obj.FixedUpdate(); }
                            catch (Exception e) { RogueFramework.LogError(e, "IDoFixedUpdate.FixedUpdate", obj, agent); }

                foreach (StatusEffect effect in agent.statusEffects.StatusEffectList.ToList())
                    foreach (IDoFixedUpdate obj in effect.GetHooks<IDoFixedUpdate>())
                        try { obj.FixedUpdate(); }
                        catch (Exception e) { RogueFramework.LogError(e, "IDoFixedUpdate.FixedUpdate", obj, agent); }

                foreach (Trait trait in agent.statusEffects.TraitList.ToList())
                    foreach (IDoFixedUpdate obj in trait.GetHooks<IDoFixedUpdate>())
                        try { obj.FixedUpdate(); }
                        catch (Exception e) { RogueFramework.LogError(e, "IDoFixedUpdate.FixedUpdate", obj, agent); }
            }

            foreach (ObjectReal objectReal in GameController.gameController.objectRealListUpdate.ToList())
            {
                foreach (IDoFixedUpdate obj in objectReal.GetHooks<IDoFixedUpdate>())
                    try { obj.FixedUpdate(); }
                    catch (Exception e) { RogueFramework.LogError(e, "IDoFixedUpdate.FixedUpdate", obj); }

                if (objectReal.objectInvDatabase != null)
                    foreach (InvItem item in objectReal.objectInvDatabase.InvItemList)
                        foreach (IDoFixedUpdate obj in item.GetHooks<IDoFixedUpdate>())
                            try { obj.FixedUpdate(); }
                            catch (Exception e) { RogueFramework.LogError(e, "IDoFixedUpdate.FixedUpdate", obj, objectReal); }
            }

            foreach (Item item in GameController.gameController.itemList.ToList())
                foreach (IDoFixedUpdate obj in item.invItem.GetHooks<IDoFixedUpdate>())
                    try { obj.FixedUpdate(); }
                    catch (Exception e) { RogueFramework.LogError(e, "IDoFixedUpdate.FixedUpdate", obj, item); }
        }

        public static void AudioHandler_SetupDics_Prefix(AudioHandler __instance, ref bool __state)
            => __state = __instance.loadedDics;
        internal static List<AudioClip> preparedClips = new List<AudioClip>();
        public static void AudioHandler_SetupDics(AudioHandler __instance, ref bool __state)
        {
            if (__state) return;
            foreach (AudioClip clip in preparedClips)
            {
                __instance.audioClipRealList.Add(clip);
                __instance.audioClipList.Add(clip.name);
                __instance.audioClipDic.Add(clip.name, clip);
            }
            preparedClips = null;
        }

        public static bool Unlocks_AddNuggets(int numNuggets)
        {
            GameController.gameController.sessionDataBig.nuggets += numNuggets;
            GameController.gameController.unlocks.SaveUnlockData(true);
            return false;
        }

        internal static bool versionLinesReady;
        internal static readonly List<VersionText> versionLines = new List<VersionText>();
        private static Vector3 versionTextOffset = new Vector3(5f, -10f, 0f);
        internal static Text AttachVersionText(GameObject versionObj, string id, string text)
        {
            GameObject myObject = versionObj.transform.Find(id)?.gameObject;
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
        public static void MainGUI_Awake(MainGUI __instance)
        {
            versionLinesReady = true;
            GameObject versionObj = GameObject.Find("VersionText2");
            foreach (VersionText versionText in versionLines)
            {
                GameObject alreadyAttached = versionObj.transform.Find(versionText.Id)?.gameObject;
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
    }
    public class VersionText
    {
        internal VersionText(string id) => Id = id;
        internal VersionText(string id, string text) : this(id) => preparedText = text;
        public string Id { get; }
        private Text textComponent;
        private string preparedText;
        public string Text
        {
            get => textComponent != null ? textComponent.text : preparedText ?? string.Empty;
            set
            {
                if (textComponent != null) textComponent.text = value ?? string.Empty;
                else preparedText = value ?? string.Empty;
            }
        }
        internal void AssignText(Text text)
        {
            textComponent = text;
            text.text = preparedText ?? string.Empty;
        }
    }
}
