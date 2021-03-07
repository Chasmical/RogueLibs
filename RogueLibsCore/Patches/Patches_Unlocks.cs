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
	public partial class RogueLibsPlugin
	{
		public void PatchUnlocks()
		{
			// synchronize some fields
			Patcher.Postfix(typeof(Unlocks), nameof(Unlocks.AddUnlock), new Type[] { typeof(string), typeof(string), typeof(bool), typeof(int), typeof(int), typeof(int), typeof(Unlock) });

			// replace the entire foreach loop in the end
			Patcher.Transpiler(typeof(Unlocks), nameof(Unlocks.LoadInitialUnlocks));
		}

		public static void Unlocks_AddUnlock(Unlock createdUnlock, Unlock __result)
		{
			if (createdUnlock != null)
			{
				__result.unavailable = createdUnlock.unavailable;
				__result.onlyInCharacterCreation = createdUnlock.onlyInCharacterCreation;
				__result.freeItem = createdUnlock.freeItem;
			}
		}

		public static IEnumerable<CodeInstruction> Unlocks_LoadInitialUnlocks(IEnumerable<CodeInstruction> codeEnumerable)
		{
			List<CodeInstruction> code = new List<CodeInstruction>(codeEnumerable);
			int getEnumerator = code.FindIndex(i => i.opcode == OpCodes.Callvirt && i.Calls(typeof(List<Unlock>).GetMethod("GetEnumerator")));
			int endFinally = code.FindIndex(getEnumerator, i => i.opcode == OpCodes.Endfinally);

			code.RemoveRange(getEnumerator + 1, endFinally - getEnumerator);
			code.InsertRange(getEnumerator + 1, new CodeInstruction[]
			{
				new CodeInstruction(OpCodes.Pop),
				new CodeInstruction(OpCodes.Call, loadUnlockWrappersMethod)
			});
			return code;
		}
		private static readonly MethodInfo loadUnlockWrappersMethod = SymbolExtensions.GetMethodInfo(() => LoadUnlockWrappersAndCategorize());
		public static void LoadUnlockWrappersAndCategorize()
		{
			GameController gc = GameController.gameController;
			SessionDataBig sdb = gc.sessionDataBig;

			sdb.unlocks.AddRange(RogueLibs.Unlocks.Select(w => w.Unlock));
			foreach (Unlock unlock in new List<Unlock>(sdb.unlocks))
			{
				// wrapping original unlocks
				if (gc.unlocks.GetSpecialUnlockInfo(unlock.unlockName, unlock) != "") unlock.cost = -2;
				UnlockWrapper wrapper = RogueLibs.Unlocks.Find(u => u.Name == unlock.unlockName && u.Type == unlock.unlockType);
				if (wrapper == null)
				{
					if (unlock.unlockType == "Challenge") wrapper = new MutatorUnlock(unlock);
					else if (unlock.unlockType == "Item")
					{
						if (!unlock.unavailable && !unlock.onlyInCharacterCreation && !unlock.freeItem)
							unlock.onlyInCharacterCreation = unlock.freeItem = true;
						wrapper = new ItemUnlock(unlock);
					}
					else if (unlock.unlockType == "Trait")
					{
						unlock.onlyInCharacterCreation = !unlock.unavailable;
						wrapper = new TraitUnlock(unlock);
					}
					else if (unlock.unlockType == "Ability")
					{
						unlock.onlyInCharacterCreation = !unlock.unavailable;
						wrapper = new AbilityUnlock(unlock);
					}
					else if (unlock.unlockType == "Achievement") wrapper = new AchievementUnlock(unlock);
					else if (unlock.unlockType == "Floor") wrapper = new FloorUnlock(unlock);
					else if (unlock.unlockType == "BigQuest") wrapper = new BigQuestUnlock(unlock);
					else if (unlock.unlockType == "HomeBase") wrapper = new HomeBaseUnlock(unlock);
					else if (unlock.unlockType == "Extra") wrapper = new ExtraUnlock(unlock);
					else if (unlock.unlockType == "Agent") wrapper = new AgentUnlock(unlock);
					else if (unlock.unlockType == "Loadout") wrapper = new LoadoutUnlock(unlock);
					else
					{
						RogueLibs.Logger.LogError("Unknown unlock type!\n" +
							$"unlockName: {unlock.unlockName}\n" +
							$"unlockType: {unlock.unlockType}\n" +
							$"unlocked:   {unlock.unlocked}");
						sdb.unlocks.Remove(unlock);
						continue;
					}
					if (wrapper is IUnlockInCC inCC && !inCC.IsAvailableInCC) inCC.IsAvailableInCC = wrapper.IsAvailable;
					RogueLibs.Unlocks.Add(wrapper);
					AddCustomUnlockFull(wrapper, true);
				}
				else AddCustomUnlockFull(wrapper);
			}
		}
		public static void AddCustomUnlockFull(UnlockWrapper wrapper, bool alreadySetup = false)
		{
			// integrating custom unlocks
			Unlock result = alreadySetup ? wrapper.Unlock : GameController.gameController.unlocks.AddUnlock(wrapper.Unlock);
			if (wrapper.Unlock != result)
			{
				List<Unlock> list = GameController.gameController.sessionDataBig.unlocks;
				list.Remove(result);
				list.Add(wrapper.Unlock);
				wrapper.IsUnlocked = result.unlocked;
			}
			wrapper.IsAvailable = wrapper.IsAvailable;
			if (wrapper is IUnlockInCC inCC) inCC.IsAvailableInCC = inCC.IsAvailableInCC;
			if (wrapper is ItemUnlock item) item.IsAvailableInItemTeleporter = item.IsAvailableInItemTeleporter;
			// make sure that the Unlocks are in their appropriate lists
			wrapper.SetupUnlock();
		}
	}
}
