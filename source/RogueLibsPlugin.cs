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
			patcher.Postfix(typeof(ScrollingMenu), "SortUnlocks"); // insert CustomMutators in the menu
			patcher.Prefix(typeof(ScrollingMenu), "PushedButton"); // disable conflicting mutators and triggering CustomMutator events








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

		public void Validate(CustomUnlock customUnlock)
		{
			Unlock newUnlock = null;
			SessionDataBig big = GameController.gameController.sessionDataBig;
			if (customUnlock is CustomMutator mutator)
			{
				Unlock generalUnlock = big.unlocks.Find(u => u.unlockName == mutator.Id && u.unlockType == "Challenge");
				Unlock challengeUnlock = big.challengeUnlocks.Find(u => u.unlockName == mutator.Id && u.unlockType == "Challenge");

				newUnlock = generalUnlock ?? challengeUnlock ?? new Unlock(mutator.Id, "Challenge", mutator.IsUnlocked);

				if (generalUnlock == null) big.unlocks.Add(newUnlock);

				if (mutator.Available && challengeUnlock == null) big.challengeUnlocks.Add(newUnlock);
				else if (!mutator.Available && challengeUnlock != null) big.challengeUnlocks.Remove(challengeUnlock);
				Unlock.challengeCount = big.challengeUnlocks.Count;
			}
			else if (customUnlock is CustomItem item)
			{
				Unlock generalUnlock = big.unlocks.Find(u => u.unlockName == item.Id && u.unlockType == "Item");
				Unlock availableUnlock = big.itemUnlocks.Find(u => u.unlockName == item.Id && u.unlockType == "Item");
				Unlock availableCCUnlock = big.itemUnlocks.Find(u => u.unlockName == item.Id && u.unlockType == "Item");
				Unlock availableITUnlock = big.itemUnlocks.Find(u => u.unlockName == item.Id && u.unlockType == "Item");

				newUnlock = generalUnlock ?? availableUnlock ?? availableCCUnlock ?? availableITUnlock ?? new Unlock(item.Id, "Item", item.IsUnlocked);

				if (generalUnlock == null) big.unlocks.Add(newUnlock);

				if (item.Available && availableUnlock == null) big.itemUnlocks.Add(newUnlock);
				else if (!item.Available && availableUnlock != null) big.itemUnlocks.Remove(availableUnlock);
				Unlock.itemCount = big.itemUnlocks.Count;

				if (item.AvailableInCharacterCreation && availableCCUnlock == null) big.itemUnlocksCharacterCreation.Add(newUnlock);
				else if (!item.AvailableInCharacterCreation && availableCCUnlock != null) big.itemUnlocksCharacterCreation.Remove(availableCCUnlock);
				Unlock.itemCountCharacterCreation = big.itemUnlocksCharacterCreation.Count;

				if (item.AvailableInItemTeleporter && availableITUnlock == null) big.freeItemUnlocks.Add(newUnlock);
				else if (!item.AvailableInItemTeleporter && availableITUnlock != null) big.freeItemUnlocks.Remove(availableITUnlock);
				Unlock.itemCountFree = big.freeItemUnlocks.Count;

				newUnlock.freeItem = item.AvailableInItemTeleporter;
				newUnlock.onlyInCharacterCreation = item.AvailableInCharacterCreation && !item.Available;
				newUnlock.unavailable = !item.Available;
			}
			else if (customUnlock is CustomAbility ability)
			{
				Unlock generalUnlock = big.unlocks.Find(u => u.unlockName == ability.Id && u.unlockType == "Ability");
				Unlock abilityUnlock = big.abilityUnlocks.Find(u => u.unlockName == ability.Id && u.unlockType == "Ability");

				newUnlock = generalUnlock ?? abilityUnlock ?? new Unlock(ability.Id, "Ability", ability.IsUnlocked);

				if (generalUnlock == null) big.unlocks.Add(newUnlock);

				if (ability.Available && abilityUnlock == null) big.abilityUnlocks.Add(newUnlock);
				else if (!ability.Available && abilityUnlock != null) big.abilityUnlocks.Remove(abilityUnlock);
				Unlock.abilityCount = big.abilityUnlocks.Count;
			}
			if (newUnlock != null)
			{
				newUnlock.unlocked = customUnlock.IsUnlocked;
				newUnlock.cost = customUnlock.UnlockCost;
				newUnlock.cancellations = customUnlock.Conflicting;
			}


		}

		protected static void Unlocks_LoadInitialUnlocks(Unlocks __instance)
		{
			foreach (CustomMutator mutator in RogueLibs.CustomMutators)
			{
				Unlock unlock = __instance.AddUnlock(new Unlock(mutator.Id, "Challenge", mutator.IsUnlocked, mutator.UnlockCost, 0, 0));
				GameController.gameController.sessionDataBig.unlocks.Add(unlock);
				GameController.gameController.sessionDataBig.challengeUnlocks.Add(unlock);
				Unlock.challengeCount++;
			}
			foreach (CustomItem item in RogueLibs.CustomItems)
			{
				Unlock unlock = __instance.AddUnlock(new Unlock(item.Id, "Item", item.IsUnlocked, item.UnlockCost, 0, 0));
				GameController.gameController.sessionDataBig.unlocks.Add(unlock);
				if (item.Available)
				{
					GameController.gameController.sessionDataBig.itemUnlocks.Add(unlock);
					Unlock.itemCount++;
				}
				if (item.AvailableInCharacterCreation)
				{
					GameController.gameController.sessionDataBig.itemUnlocksCharacterCreation.Add(unlock);
					Unlock.itemCountCharacterCreation++;
				}
				if (item.AvailableInItemTeleporter)
				{
					GameController.gameController.sessionDataBig.freeItemUnlocks.Add(unlock);
					Unlock.itemCountFree++;
				}
				
			}
			foreach (CustomAbility ability in RogueLibs.CustomAbilities)
			{
				Unlock unlock = __instance.AddUnlock(new Unlock(ability.Id, "Ability", ability.IsUnlocked, ability.UnlockCost, 0, 0));
				GameController.gameController.sessionDataBig.unlocks.Add(unlock);
				GameController.gameController.sessionDataBig.abilityUnlocks.Add(unlock);
				Unlock.abilityCount++;
			}
		}
		protected static void ScrollingMenu_SortUnlocks(ScrollingMenu __instance, string unlockType, List<Unlock> ___listUnlocks)
		{
			List<Unlock> addToBeginning = new List<Unlock>();
			List<Unlock> mixWithOriginal = new List<Unlock>();
			List<Unlock> addToEnd = new List<Unlock>();

			List<Unlock> extracted = new List<Unlock>();
			foreach (Unlock unlock in ___listUnlocks)
			{ // filter the custom ones
				if (unlock.unlockType == "Challenge" && RogueLibs.CustomMutators.Exists(m => m.Id == unlock.unlockName))
					extracted.Add(unlock);
				else if (unlock.unlockType == "Item" && RogueLibs.CustomItems.Exists(i => i.Id == unlock.unlockName))
					extracted.Add(unlock);
				else if (unlock.unlockType == "Ability" && RogueLibs.CustomAbilities.Exists(a => a.Id == unlock.unlockName))
					extracted.Add(unlock);
			}

			foreach (Unlock unlock in extracted)
				___listUnlocks.Remove(unlock);

			if (unlockType == "Challenge")
			{
				RogueLibs.CustomMutators.Sort();

				foreach (Unlock unlock in extracted)
				{
					CustomMutator mutator = RogueLibs.GetCustomMutator(unlock.unlockName);
					if (!mutator.ShowInMenu) continue;

					if (mutator.SortingOrder < 0) addToBeginning.Add(unlock);
					else if (mutator.SortingOrder == 0) mixWithOriginal.Add(unlock);
					else addToEnd.Add(unlock);
				}
			}
			else if (unlockType == "Item")
			{
				RogueLibs.CustomItems.Sort();
			}

			addToBeginning.Sort();
			addToEnd.Sort();

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
					return false;
				}
				else if (custom != null)
				{ // not unlocked and is a custom mutator
					if (custom.UnlockCost != -1)
					{ // can be purchased
						if (custom.UnlockCost <= __instance.gc.sessionDataBig.nuggets)
						{ // the player can afford the purchase
							__instance.gc.unlocks.SubtractNuggets(custom.UnlockCost);
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
							return false;
						}
					}
					else
					{ // can't be purchased
						__instance.gc.audioHandler.Play(__instance.agent, "CantDo");
						return false;
					}
				}













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
