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
		/// <summary>
		///   <para>Applies the patches to <see cref="Unlocks"/>.</para>
		/// </summary>
		public void PatchUnlocks()
		{
			// synchronize some fields
			Patcher.Postfix(typeof(Unlocks), nameof(Unlocks.AddUnlock), new Type[] { typeof(string), typeof(string), typeof(bool), typeof(int), typeof(int), typeof(int), typeof(Unlock) });

			Patcher.Prefix(typeof(Unlocks), nameof(Unlocks.LoadInitialUnlocks), nameof(Unlocks_LoadInitialUnlocks_Prefix));
			// replace the entire foreach loop in the end
			Patcher.Transpiler(typeof(Unlocks), nameof(Unlocks.LoadInitialUnlocks));

			RogueLibs.CreateCustomName("UnlockFor", "Unlock", new CustomNameInfo
			{
				English = "Unlock for",
				Russian = "Разблокировать за"
			});
		}

		/// <summary>
		///   <para><b>Postfix-patch.</b> Synchronizes some of the fields.</para>
		/// </summary>
		/// <param name="createdUnlock">Unlock created with up-to-date information.</param>
		/// <param name="__result">Unlock loaded with potentially outdated information.</param>
		public static void Unlocks_AddUnlock(Unlock createdUnlock, Unlock __result)
		{
			if (createdUnlock != null)
			{
				__result.unavailable = createdUnlock.unavailable;
				__result.onlyInCharacterCreation = createdUnlock.onlyInCharacterCreation;
				__result.freeItem = createdUnlock.freeItem;
			}
		}

		public static void Unlocks_LoadInitialUnlocks_Prefix(bool ___loadedInitialUnlocks)
		{
			if (___loadedInitialUnlocks) return;
			RogueLibsInternals.Unlocks.Clear();
			foreach (UnlockWrapper wrapper in RogueLibsInternals.CustomUnlocks)
			{
				RogueLibsInternals.Unlocks.Add(wrapper);
				AddUnlockFull(wrapper);
			}
		}
		/// <summary>
		///   <para><b>Transpiler-patch.</b> Replaces the entire foreach loop in the end with <see cref="LoadUnlockWrappersAndCategorize"/> method call.</para>
		/// </summary>
		/// <param name="codeEnumerable">Original method's code.</param>
		/// <returns>Modified code, with the foreach loop in the end replaced with the <see cref="LoadUnlockWrappersAndCategorize"/> method call.</returns>
		public static IEnumerable<CodeInstruction> Unlocks_LoadInitialUnlocks(IEnumerable<CodeInstruction> codeEnumerable)
			=> codeEnumerable.ReplaceRegion(
				new Func<CodeInstruction, bool>[]
				{
					i => i.opcode == OpCodes.Callvirt && i.Calls(typeof(List<Unlock>).GetMethod("GetEnumerator"))
				},
				new Func<CodeInstruction, bool>[]
				{
					i => i.opcode == OpCodes.Endfinally
				},
				new CodeInstruction[]
				{
					new CodeInstruction(OpCodes.Pop),
					new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(LoadUnlockWrappersAndCategorize)))
				}
			);
		/// <summary>
		///   <para>Initializes and sets up the unlock wrappers, both original and custom.</para>
		/// </summary>
		public static void LoadUnlockWrappersAndCategorize()
		{
			GameController gc = GameController.gameController;
			SessionDataBig sdb = gc.sessionDataBig;

			sdb.unlocks.AddRange(RogueLibsInternals.Unlocks.Select(w => w.Unlock));
			foreach (Unlock unlock in sdb.unlocks.ToList())
			{
				// wrapping original unlocks
				if (gc.unlocks.GetSpecialUnlockInfo(unlock.unlockName, unlock) != "") unlock.cost = -2;
				UnlockWrapper wrapper = RogueLibsInternals.Unlocks.Find(u => u.Name == unlock.unlockName && u.Type == unlock.unlockType);
				if (wrapper != null)
					AddUnlockFull(wrapper);
				else
				{
					if (unlock.unlockType == "Challenge")
					{
						unlock.unavailable = false;
						wrapper = new MutatorUnlock(unlock);
					}
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
						RogueLibsInternals.Logger.LogError("Unknown unlock type!\n" +
							$"unlockName: {unlock.unlockName}\n" +
							$"unlockType: {unlock.unlockType}\n" +
							$"unlocked:   {unlock.unlocked}");
						sdb.unlocks.Remove(unlock);
						continue;
					}
					if (wrapper is IUnlockInCC inCC && !inCC.IsAvailableInCC) inCC.IsAvailableInCC = wrapper.IsAvailable;
					RogueLibsInternals.Unlocks.Add(wrapper);
					AddUnlockFull(wrapper, true);
				}
			}
		}
		/// <summary>
		///   <para>Integrates the specified unlock <paramref name="wrapper"/> into the game.</para>
		/// </summary>
		/// <param name="wrapper">Unlock's wrapper.</param>
		/// <param name="alreadyLoaded">Determines whether the unlock was already loaded from a save file.</param>
		public static void AddUnlockFull(UnlockWrapper wrapper, bool alreadyLoaded = false)
		{
			// integrating custom unlocks
			Unlock result = alreadyLoaded ? wrapper.Unlock : GameController.gameController.unlocks.AddUnlock(wrapper.Unlock);
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
