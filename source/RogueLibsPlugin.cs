using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLibsCore
{
#pragma warning disable CS1591
	[BepInPlugin(RogueLibs.pluginGuid, RogueLibs.pluginName, RogueLibs.pluginVersion)]
	public class RogueLibsPlugin : BaseUnityPlugin
	{
		protected static ManualLogSource MyLogger;

		protected void Awake()
		{
			RogueLibs.PluginInstance = this;
			RogueLibs.Logger = MyLogger = Logger;

			RoguePatcher patcher = new RoguePatcher(this, GetType());

			patcher.Postfix(typeof(NameDB), "GetName"); // CustomNames

			patcher.Postfix(typeof(Unlocks), "LoadInitialUnlocks");
			patcher.Postfix(typeof(ScrollingMenu), "SortUnlocks");
			patcher.Prefix(typeof(ScrollingMenu), "PushedButton");








		}

		protected static string[] languages = new string[8] { "english", "schinese", "german", "spanish", "brazilian", "russian", "french", "koreana" };
		protected static void NameDB_GetName(NameDB __instance, string myName, string type, ref string __result)
		{
			if (!__result.StartsWith("E_")) return;
			foreach (CustomName name in RogueLibs.CustomNames)
				if (name.Id == myName && name.Type == type)
				{
					int index = Array.IndexOf(languages, __instance.language);
					if (index < 0) index++;
					__result = name.Translations[index] ?? name.English;
					return;
				}
		}

		internal void EnsureOne(List<Unlock> list, Unlock unlock, bool add)
		{
			list.RemoveAll(u => u.unlockName == unlock.unlockName);

			if (add) list.Add(unlock);
			else list.Remove(unlock);
		}
		internal void Setup(CustomUnlock customUnlock)
		{
			SessionDataBig big = GameController.gameController.sessionDataBig;
			GameResources gr = GameController.gameController.gameResources;

			customUnlock.unlock = big.unlocks.Find(u => u.unlockName == customUnlock.Id && u.unlockType == customUnlock.Type);
			if (customUnlock.unlock == null)
			{
				Unlock newUnlock = new Unlock(customUnlock.Id, customUnlock.Type, customUnlock.Unlocked, customUnlock.UnlockCost ?? 0);
				customUnlock.unlock = GameController.gameController.unlocks.AddUnlock(newUnlock);
				EnsureOne(big.unlocks, customUnlock.unlock, true);
			}

			if (customUnlock is CustomMutator mutator)
			{
				EnsureOne(big.challengeUnlocks, mutator.unlock, mutator.Available);
			}
			else if (customUnlock is CustomItem item)
			{
				EnsureOne(big.itemUnlocks, item.unlock, item.Available);
				EnsureOne(big.itemUnlocksCharacterCreation, item.unlock, item.AvailableInCharacterCreation);
				EnsureOne(big.freeItemUnlocks, item.unlock, item.AvailableInItemTeleporter);
			}
			else if (customUnlock is CustomAbility ability)
			{
				EnsureOne(big.abilityUnlocks, ability.unlock, ability.Available);
			}

			if (customUnlock.Sprite != null)
			{
				if (gr.itemDic.ContainsKey(customUnlock.Id))
					gr.itemDic[customUnlock.Id] = customUnlock.Sprite;
				else gr.itemDic.Add(customUnlock.Id, customUnlock.Sprite);

				if (!gr.itemList.Contains(customUnlock.Sprite))
					gr.itemList.Add(customUnlock.Sprite);
			}
		}

		protected static bool loadedInitialUnlocks = false;
		protected static void Unlocks_LoadInitialUnlocks(Unlocks __instance, ref bool ___doResetCertainAbilities)
		{
			bool prev = ___doResetCertainAbilities;
			___doResetCertainAbilities = false;

			if (loadedInitialUnlocks) return;
			loadedInitialUnlocks = true;

			foreach (CustomUnlock unlock in RogueLibs.EnumerateCustomUnlocks())
				RogueLibs.PluginInstance.Setup(unlock);

			___doResetCertainAbilities = prev;
		}
		protected static void ScrollingMenu_SortUnlocks(ScrollingMenu __instance, string unlockType, List<Unlock> ___listUnlocks)
		{
			List<Unlock> extracted = new List<Unlock>();
			if (unlockType == "Challenge")
			{
				foreach (Unlock unlock in ___listUnlocks)
					if (RogueLibs.CustomMutators.Exists(m => m.Id == unlock.unlockName))
						extracted.Add(unlock);
			}
			else if (unlockType == "Item")
			{
				foreach (Unlock unlock in ___listUnlocks)
					if (RogueLibs.CustomItems.Exists(i => i.Id == unlock.unlockName))
						extracted.Add(unlock);
			}

			foreach (Unlock unlock in extracted)
				___listUnlocks.Remove(unlock);
			__instance.numButtons -= extracted.Count;

			List<Unlock> addToBeginning = new List<Unlock>();
			List<Unlock> mixWithOriginal = new List<Unlock>();
			List<Unlock> addToEnd = new List<Unlock>();

			if (unlockType == "Challenge")
			{
				RogueLibs.CustomMutators.Sort();

				foreach (Unlock unlock in extracted)
				{
					CustomMutator mutator = RogueLibs.GetCustomMutator(unlock.unlockName);
					if (!mutator.Available) continue;

					if (mutator.SortingOrder < 0) addToBeginning.Add(unlock);
					else if (mutator.SortingOrder == 0) mixWithOriginal.Add(unlock);
					else addToEnd.Add(unlock);
				}
			}
			else if (unlockType == "Item")
			{
				RogueLibs.CustomItems.Sort();

				foreach (Unlock unlock in extracted)
				{
					CustomItem item = RogueLibs.GetCustomItem(unlock.unlockName);
					if (!item.Available) continue;

					if (item.SortingOrder < 0) addToBeginning.Add(unlock);
					else if (item.SortingOrder == 0) mixWithOriginal.Add(unlock);
					else addToEnd.Add(unlock);
				}
			}

			___listUnlocks.AddRange(mixWithOriginal);
			___listUnlocks.Sort(1, ___listUnlocks.Count - 1, null);
			___listUnlocks.InsertRange(1, addToBeginning);
			___listUnlocks.AddRange(addToEnd);

			__instance.numButtons += addToBeginning.Count + mixWithOriginal.Count + addToEnd.Count;
		}
		protected static bool ScrollingMenu_PushedButton(ScrollingMenu __instance, ButtonHelper myButton, List<Unlock> ___listUnlocks)
		{
			Unlock u = myButton.scrollingButtonUnlock;
			ButtonData data = __instance.buttonsData[myButton.scrollingButtonNum];

			if (__instance.menuType == "Challenges")
			{
				if (!__instance.gc.serverPlayer)
				{
					__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
					return false;
				}

				CustomMutator custom = RogueLibs.GetCustomMutator(myButton.scrollingButtonType);

				if (u.unlocked)
				{ // if unlocked, then handle ClearAll OR toggle on/off

					if (myButton.scrollingButtonType == "ClearAll")
					{ // handling ClearAll button
						__instance.gc.challenges.Clear();
						__instance.gc.originalChallenges.Clear();
						foreach (ButtonData buttonData in __instance.buttonsData)
							if (buttonData.scrollingHighlighted)
							{
								buttonData.scrollingHighlighted = false;
								buttonData.highlightedSprite = __instance.solidObjectButton;
								if (buttonData.scrollingButtonUnlock.unlockName == "SuperSpecialCharacters")
									__instance.gc.mainGUI.characterSelectScript.RefreshSuperSpecials();
							}
						if (__instance.gc.multiplayerMode)
							__instance.agent.objectMult.SendChatAnnouncement("ClearedAllChallenges", string.Empty, string.Empty);
					}
					else
					{ // normal handling
						myButton.scrollingHighlighted = data.scrollingHighlighted = true;
						SpriteState spriteState = default;
						spriteState.highlightedSprite = myButton.scrollingHighlighted ? myButton.solidObjectButtonSelected : myButton.solidObjectButton;
						myButton.button.spriteState = spriteState;
						data.highlightedSprite = myButton.scrollingHighlighted ? __instance.solidObjectButtonSelected : __instance.solidObjectButton;

						if (myButton.scrollingHighlighted)
						{ // was toggled on
							__instance.gc.challenges.Add(myButton.scrollingButtonType);
							__instance.gc.originalChallenges.Add(myButton.scrollingButtonType);
						}
						else
						{ // was toggled off
							__instance.gc.challenges.Remove(myButton.scrollingButtonType);
							__instance.gc.originalChallenges.Remove(myButton.scrollingButtonType);
						}
						if (myButton.scrollingButtonType == "SuperSpecialCharacters")
							__instance.gc.mainGUI.characterSelectScript.RefreshSuperSpecials();
						if (__instance.gc.multiplayerMode)
							__instance.agent.objectMult.SendChatAnnouncement((myButton.scrollingHighlighted ? "Added" : "Removed") + "Challenge", myButton.scrollingButtonType, string.Empty);
					}

					__instance.gc.sessionDataBig.challenges = __instance.gc.challenges;
					__instance.gc.sessionDataBig.originalChallenges = __instance.gc.originalChallenges;
					__instance.gc.audioHandler.Play(__instance.gc.playerAgent, "ClickButton");
					__instance.gc.SetDailyRunText();
					__instance.UpdateOtherVisibleMenus(__instance.menuType);
				}
				else if (custom != null)
				{ // not unlocked and is a custom mutator
					if (custom.UnlockCost != null)
					{ // can be purchased
						if (custom.UnlockCost <= __instance.gc.sessionDataBig.nuggets)
						{ // the player can afford the purchase
							__instance.gc.unlocks.SubtractNuggets(custom.UnlockCost.Value);
							__instance.gc.unlocks.DoUnlock(custom.Id, "Challenge");
							__instance.gc.audioHandler.Play(__instance.agent, "BuyUnlock");

							for (int i = 0; i < __instance.numButtons; i++)
								__instance.SetupChallenges(__instance.buttonsData[i], ___listUnlocks[i]);

							__instance.gc.SetDailyRunText();
							__instance.UpdateOtherVisibleMenus(__instance.menuType);
						}
						else
						{ // the player can not afford the purchase
							__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
						}
					}
					else
					{ // can't be purchased
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
					}
				}












				return false;
			}
			else if (__instance.menuType == "Items")
			{











				return false;
			}






			return true;
		}












	}
#pragma warning restore CS1591
}
