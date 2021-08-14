using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BepInEx;
using HarmonyLib;

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

			Patcher.AnyErrors();
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
	}
}
