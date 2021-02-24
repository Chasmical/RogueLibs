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
	[BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.Version)]
	public class RogueLibsPlugin : BaseUnityPlugin
	{
		public void Awake()
		{
			RogueLibs.Plugin = this;
			RogueLibs.Logger = Logger;

			RoguePatcher patcher = new RoguePatcher(this);

			// get and set the current game language as a LanguageCode
			patcher.Postfix(typeof(NameDB), nameof(NameDB.RealAwake));
			// CustomNames
			patcher.Postfix(typeof(NameDB), nameof(NameDB.GetName));

			RogueLibs.AddCustomName("UnlockFor", "Unlock", new CustomNameInfo
			{
				[LanguageCode.English] = "Unlock for",
				[LanguageCode.Russian] = "Открыть за"
			});

			// IDoUpdate.Update()
			patcher.Postfix(typeof(Updater), "Update");
			// IDoFixedUpdate.FixedUpdate()
			patcher.Postfix(typeof(Updater), nameof(Updater.FixedUpdate));

			// define RogueSprites in the RogueSprite.addOnGCAwakeList
			patcher.Postfix(typeof(GameController), "Awake");

			// set the shared material of all renderers to the one selected in the tk2dSpriteDefinition
			patcher.Postfix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnItemSprite));
			patcher.Postfix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnItemWeapon));

			// create and initialize item hooks
			patcher.Postfix(typeof(InvItem), nameof(InvItem.SetupDetails));

			// CustomItem, IItemUsable patch / partial override
			patcher.Prefix(typeof(ItemFunctions), nameof(ItemFunctions.UseItem));
			patcher.Postfix(typeof(ItemFunctions), nameof(ItemFunctions.UseItem), nameof(ItemFunctions_UseItem_Postfix));

			// CustomItem, IItemCombinable and IItemTargetable / complete override
			patcher.Prefix(typeof(InvItem), nameof(InvItem.CombineItems));
			patcher.Prefix(typeof(InvItem), nameof(InvItem.TargetObject));

			// CustomItem, IItemTargetable.TargetTooltip(.) patches
			patcher.Postfix(typeof(InvInterface), nameof(InvInterface.ShowTarget), new Type[] { typeof(InvItem) });
			patcher.Postfix(typeof(InvInterface), nameof(InvInterface.ShowCursorText),
				new Type[] { typeof(string), typeof(string), typeof(PlayfieldObject), typeof(int) });
			patcher.Postfix(typeof(InvInterface), nameof(InvInterface.HideCursorText));

			// CustomItem, IItemCombinable.CombineTooltip(.) patch
			patcher.Postfix(typeof(InvSlot), nameof(InvSlot.SetColor));

			patcher.Transpiler(typeof(Unlocks), nameof(Unlocks.LoadInitialUnlocks));

			//patcher.Transpiler(typeof(ScrollingMenu), nameof(ScrollingMenu.OpenScrollingMenu), nameof(ScrollingMenu_OpenScrollingMenu_Transpiler));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.OpenScrollingMenu), nameof(ScrollingMenu_OpenScrollingMenu_Prefix));
			patcher.Postfix(typeof(ScrollingMenu), nameof(ScrollingMenu.OpenScrollingMenu));

			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupChallenges));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupChangeTraitsRandom));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupFreeItems));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupItemUnlocks));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupLoadouts));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupRemoveTraits));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupTraitUnlocks));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SetupUpgradeTraits));

			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.SortUnlocks));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.PushedButton));
			patcher.Prefix(typeof(ScrollingMenu), nameof(ScrollingMenu.ShowDetails));
		}

		public static void NameDB_RealAwake(NameDB __instance)
			=> currentLanguageCode = CustomName.Languages.TryGetValue(__instance.language, out LanguageCode code) ? code : LanguageCode.English;
		public static void NameDB_GetName(string myName, string type, ref string __result)
		{
			if (__result.StartsWith("E_") && RogueLibs.CustomNames.TryGetValue(type, out List<CustomName> list))
			{
				CustomName custom = list.Find(n => n.Name == myName);
				if (custom != null) __result = custom[currentLanguageCode] ?? custom.English;
			}
		}
		private static LanguageCode currentLanguageCode;

		public static void Updater_Update()
		{
			List<Agent> agents = GameController.gameController.agentList;
			for (int i = 0; i < agents.Count; i++)
			{
				Agent agent = agents[i];
				foreach (IDoUpdate obj in agents[i].GetHooks<IDoUpdate>())
					try { obj.Update(); }
					catch { Debug.LogError($"Error updating {obj} in {agent.agentName}"); }

				for (int j = 0; j < agent.inventory.InvItemList.Count; j++)
				{
					InvItem item = agent.inventory.InvItemList[j];
					foreach (IDoUpdate obj in item.GetHooks<IDoUpdate>())
						try { obj.Update(); }
						catch { Debug.LogError($"Error updating {obj} in {item.invItemName} ({agent.agentName})"); }
				}

				for (int j = 0; j < agent.statusEffects.StatusEffectList.Count; j++)
				{
					StatusEffect effect = agent.statusEffects.StatusEffectList[j];
					foreach (IDoUpdate obj in effect.GetHooks<IDoUpdate>())
						try { obj.Update(); }
						catch { Debug.LogError($"Error updating {obj} in {effect.statusEffectName} ({agent.agentName})"); }
				}

				for (int j = 0; j < agent.statusEffects.TraitList.Count; j++)
				{
					Trait trait = agent.statusEffects.TraitList[j];
					foreach (IDoUpdate obj in trait.GetHooks<IDoUpdate>())
						try { obj.Update(); }
						catch { Debug.LogError($"Error updating {obj} in {trait.traitName} ({agent.agentName})"); }
				}
			}

			List<Item> items = GameController.gameController.itemList;
			for (int i = 0; i < items.Count; i++)
			{
				foreach (IDoUpdate obj in items[i].invItem.GetHooks<IDoUpdate>())
					try { obj.Update(); }
					catch { Debug.LogError($"Error updating {obj} in {items[i]}"); }
			}

			List<ObjectReal> objects = GameController.gameController.objectRealListUpdate;
			for (int i = 0; i < objects.Count; i++)
			{
				foreach (IDoUpdate obj in objects[i].GetHooks<IDoUpdate>())
					try { obj.Update(); }
					catch { Debug.LogError($"Error updating {obj} in {objects[i].objectName}"); }
			}
		}
		public static void Updater_FixedUpdate()
		{
			List<Agent> agents = GameController.gameController.agentList;
			for (int i = 0; i < agents.Count; i++)
			{
				Agent agent = agents[i];
				foreach (IDoFixedUpdate obj in agents[i].GetHooks<IDoFixedUpdate>())
					try { obj.FixedUpdate(); }
					catch { Debug.LogError($"Error updating {obj} in {agent.agentName}"); }

				for (int j = 0; j < agent.inventory.InvItemList.Count; j++)
				{
					InvItem item = agent.inventory.InvItemList[j];
					foreach (IDoFixedUpdate obj in item.GetHooks<IDoFixedUpdate>())
						try { obj.FixedUpdate(); }
						catch { Debug.LogError($"Error updating {obj} in {item.invItemName} ({agent.agentName})"); }
				}

				for (int j = 0; j < agent.statusEffects.StatusEffectList.Count; j++)
				{
					StatusEffect effect = agent.statusEffects.StatusEffectList[j];
					foreach (IDoFixedUpdate obj in effect.GetHooks<IDoFixedUpdate>())
						try { obj.FixedUpdate(); }
						catch { Debug.LogError($"Error updating {obj} in {effect.statusEffectName} ({agent.agentName})"); }
				}

				for (int j = 0; j < agent.statusEffects.TraitList.Count; j++)
				{
					Trait trait = agent.statusEffects.TraitList[j];
					foreach (IDoFixedUpdate obj in trait.GetHooks<IDoFixedUpdate>())
						try { obj.FixedUpdate(); }
						catch { Debug.LogError($"Error updating {obj} in {trait.traitName} ({agent.agentName})"); }
				}
			}

			List<Item> items = GameController.gameController.itemList;
			for (int i = 0; i < items.Count; i++)
			{
				foreach (IDoFixedUpdate obj in items[i].invItem.GetHooks<IDoFixedUpdate>())
					try { obj.FixedUpdate(); }
					catch { Debug.LogError($"Error updating {obj} in {items[i]}"); }
			}

			List<ObjectReal> objects = GameController.gameController.objectRealListUpdate;
			for (int i = 0; i < objects.Count; i++)
			{
				foreach (IDoFixedUpdate obj in objects[i].GetHooks<IDoFixedUpdate>())
					try { obj.FixedUpdate(); }
					catch { Debug.LogError($"Error updating {obj} in {objects[i].objectName}"); }
			}
		}

		public static void GameController_Awake(GameController __instance)
		{
			tk2dSpriteCollectionData coll = __instance.spawnerMain.itemSprites;
			List<RogueSprite> list = RogueSprite.addOnGCAwakeList[(int)SpriteScope.Items];
			for (int i = 0; i < list.Count; i++)
			{
				RogueSprite sprite = list[i];
				sprite.willBeAddedOnGCAwake = false;
				sprite.DefineToCollection(coll);
			}
			RogueSprite.addOnGCAwakeList[(int)SpriteScope.Items] = null;

			coll = __instance.spawnerMain.objectSprites;
			list = RogueSprite.addOnGCAwakeList[(int)SpriteScope.Objects];
			for (int i = 0; i < list.Count; i++)
			{
				RogueSprite sprite = list[i];
				sprite.willBeAddedOnGCAwake = false;
				sprite.DefineToCollection(coll);
			}
			RogueSprite.addOnGCAwakeList[(int)SpriteScope.Objects] = null;
		}

		public static void SpawnerMain_SpawnItemSprite(tk2dSprite itemImage, Item newItem)
		{
			Material mat = itemImage.CurrentSprite.material;
			foreach (Renderer r in itemImage.GetComponents<Renderer>())
				r.sharedMaterial = mat;
			foreach (Renderer r in newItem.GetComponents<Renderer>())
				r.sharedMaterial = mat;

			newItem.objectSprite.objectRenderer.sharedMaterial = mat;
			newItem.objectSprite.itemOff = mat;
			newItem.objectSprite.objectRendererH.sharedMaterial = mat;
			newItem.objectSprite.itemLightUp = mat;
		}
		public static void SpawnerMain_SpawnItemWeapon(Item __result)
		{
			tk2dSprite itemImage = __result.tr.GetChild(0).transform.GetChild(0).GetComponent<tk2dSprite>();
			itemImage.GetComponent<Renderer>().sharedMaterial = itemImage.CurrentSprite.material;
		}

		public static void InvItem_SetupDetails(InvItem __instance)
		{
			foreach (IHookFactory<InvItem> factory in RogueLibs.InvItemFactories)
				if (factory.CanCreate(__instance))
				{
					IHook<InvItem> hook = factory.CreateHook(__instance);
					__instance.AddHook(hook);
					hook.Initialize();
				}
		}

		public static bool ItemFunctions_UseItem(InvItem item, Agent agent)
		{
			CustomItem custom = item.GetHook<CustomItem>();
			if (custom is IItemTargetable targetable)
			{
				item.invInterface.ShowOrHideTarget(item);
				return false;
			}

			if (custom?.ItemInfo.IgnoreDefaultChecks_UseItem != true)
			{ // ignore default checks OR original item
				if (agent.ghost)
				{
					agent.gc.audioHandler.Play(agent, "CantDo");
					return false;
				}
				else if (agent.statusEffects.hasTrait("CantInteract") && item.itemType != "Food")
				{
					agent.SayDialogue("CantInteract");
					agent.gc.audioHandler.Play(agent, "CantDo");
					return false;
				}
			}
			if (agent.localPlayer)
			{
				if (!agent.inventory.HasItem(item.invItemName) && agent.inventory.equippedSpecialAbility?.invItemName != item.invItemName)
					return false;
				else if ((item.Categories.Contains("Usable") || item.itemType == "Consumable") && !item.used)
				{
					item.used = true;
					if (agent.isPlayer > 0) agent.gc.sessionData.endStats[agent.isPlayer].itemsUsed++;
				}
			}

			if (InventoryEvents.onItemUseCheck.Raise(new OnItemUsedArgs(item, agent)))
			{
				if (!(custom is IItemUsable usable))
					return true;

				if (item.agent == agent) usable.UseItem();
				else
				{
					Agent prev = item.agent;
					item.agent = agent;
					usable.UseItem();
					item.agent = prev;
				}
			}
			return false;
		}
		public static void ItemFunctions_UseItem_Postfix(InvItem item, Agent agent)
		{
			if (!(item.GetHook<CustomItem>() is IItemTargetable))
			{
				OnItemUsedArgs args = new OnItemUsedArgs(item, agent);
				InventoryEvents.Global.onItemUsed.Raise(args);
				item.database.GetEvents().onItemUsed.Raise(args);
			}
		}
		public static bool InvItem_CombineItems(InvItem __instance, InvItem otherItem, int slotNum, Agent myAgent, string combineType, ref bool __result)
		{
			CustomItem custom = __instance.GetHook<CustomItem>();

			if (custom?.ItemInfo.IgnoreDefaultChecks_CombineFilter != true)
			{
				if (__instance.invItemName == otherItem.invItemName && __instance.stackable)
				{
					if (__instance.invItemName == "Syringe" && __instance.contents[0] != otherItem.contents[0])
					{
						__result = false;
						return false;
					}
					if (combineType == "Combine")
					{
						if (myAgent.controllerType != "Keyboard")
						{
							myAgent.gc.audioHandler.Play(myAgent, "BeginCombine");
						}
						otherItem.agent.mainGUI.invInterface.PutDraggedItemBack();
					}
					__result = true;
					return false;
				}
			}

			bool firstCheck;
			if (custom is IItemCombinable combinable)
			{
				if (__instance.agent == myAgent) firstCheck = combinable.CombineFilter(otherItem);
				else
				{
					Agent prev = __instance.agent;
					__instance.agent = myAgent;
					firstCheck = combinable.CombineFilter(otherItem);
					__instance.agent = prev;
				}
			}
			else firstCheck = __instance.itemFunctions.CombineItems(__instance, myAgent, otherItem, slotNum, string.Empty);

			__result = firstCheck && InventoryEvents.onItemsCombineCheck.Raise(new OnItemsCombinedArgs(__instance, otherItem, myAgent));

			if (__result && combineType == "Combine")
			{
				if (custom is IItemCombinable combinable2)
				{
					if (__instance.agent == myAgent) combinable2.CombineItems(otherItem);
					else
					{
						Agent prev = __instance.agent;
						__instance.agent = myAgent;
						combinable2.CombineItems(otherItem);
						__instance.agent = prev;
					}
				}
				else __instance.itemFunctions.CombineItems(__instance, myAgent, otherItem, slotNum, "Combine");

				if (custom?.ItemInfo.IgnoreDefaultChecks_CombineItems != true
					&& (__instance.invItemCount < 1 || !__instance.database.InvItemList.Contains(__instance)))
				{
					myAgent.mainGUI.invInterface.HideDraggedItem();
					myAgent.mainGUI.invInterface.HideTarget();
				}

				OnItemsCombinedArgs args = new OnItemsCombinedArgs(__instance, otherItem, myAgent);
				InventoryEvents.Global.onItemsCombined.Raise(args);
				__instance.database.GetEvents().onItemsCombined.Raise(args);
			}
			return false;
		}
		public static bool InvItem_TargetObject(InvItem __instance, PlayfieldObject otherObject, string combineType, ref bool __result)
		{
			CustomItem custom = __instance.GetHook<CustomItem>();

			if (custom?.ItemInfo.IgnoreDefaultChecks_TargetFilter != true)
			{
				if (Vector2.Distance(__instance.agent.curPosition, otherObject.curPosition) > 15f || otherObject.playfieldObjectType == "Agent" && (otherObject.playfieldObjectAgent.butlerBot || otherObject.playfieldObjectAgent.mechEmpty))
				{
					__result = false;
					return false;
				}
			}

			bool firstCheck = custom is IItemTargetable combinable
				? combinable.TargetFilter(otherObject)
				: __instance.itemFunctions.TargetObject(__instance, __instance.agent, otherObject, string.Empty);

			__result = firstCheck && InventoryEvents.onItemTargetCheck.Raise(new OnItemTargetedArgs(__instance, otherObject));

			if (__result && combineType == "Combine")
			{
				if (custom is IItemTargetable combinable2) combinable2.TargetObject(otherObject);
				else __instance.itemFunctions.TargetObject(__instance, __instance.agent, otherObject, "Combine");

				if (custom?.ItemInfo.IgnoreDefaultChecks_TargetObject != true
					&& (__instance.invItemCount < 1 || !__instance.database.InvItemList.Contains(__instance)))
				{
					__instance.agent.mainGUI.invInterface.HideDraggedItem();
					__instance.agent.mainGUI.invInterface.HideTarget();
				}

				OnItemTargetedArgs args = new OnItemTargetedArgs(__instance, otherObject);
				InventoryEvents.Global.onItemTargeted.Raise(args);
				__instance.database.GetEvents().onItemTargeted.Raise(args);
			}
			return false;
		}
		private static Color? targetTextColor;
		public static void InvInterface_ShowTarget(InvInterface __instance, InvItem item)
		{
			if (item.itemType != "Combine")
			{
				if (targetTextColor == null) targetTextColor = __instance.cursorTextString3.color;
				CustomItem custom = item.GetHook<CustomItem>();
				if (custom is IItemTargetable targetable)
				{
					CustomTooltip tooltip = targetable.TargetTooltip(item.agent.target.playfieldObject);
					__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
					__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;
				}
			}
		}
		public static void InvInterface_ShowCursorText(InvInterface __instance, PlayfieldObject myPlayfieldObject)
		{
			CustomItem custom = __instance.mainGUI.targetItem?.GetHook<CustomItem>();
			if (custom is IItemTargetable targetable)
			{
				CustomTooltip tooltip = targetable.TargetTooltip(myPlayfieldObject);
				__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
				__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;
			}
		}
		public static void InvInterface_HideCursorText(InvInterface __instance)
		{
			CustomItem custom = __instance.mainGUI.targetItem?.GetHook<CustomItem>();
			if (custom is IItemTargetable targetable)
			{
				CustomTooltip tooltip = targetable.TargetTooltip(null);
				__instance.cursorTextString3.text = tooltip.Text ?? string.Empty;
				__instance.cursorTextString3.color = tooltip.Color ?? targetTextColor.Value;
			}
		}
		private static Color? combineTextColor;
		public static void InvSlot_SetColor(InvSlot __instance, Text ___itemText)
		{
			InvItem combiner = __instance.mainGUI.targetItem ?? __instance.database.invInterface.draggedInvItem;
			if (combiner == null) return;
			InvItem combinee = __instance.curItemList[__instance.slotNumber];

			CustomItem custom = combiner.GetHook<CustomItem>();
			if (!(custom is IItemCombinable combinable)) return;

			if (__instance.slotType == "Player" || __instance.slotType == "Toolbar" || __instance.slotType == "Chest" || __instance.slotType == "NPCChest")
			{
				if (combinee.invItemName != null && combiner.itemType == "Combine")
				{
					if (combiner.CombineItems(combinee, __instance.slotNumber, string.Empty, __instance.agent) && __instance.slotType != "NPCChest")
					{
						__instance.myImage.color = new Color32(0, __instance.br, __instance.br, __instance.standardAlpha);
						__instance.itemImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
						__instance.myImage.sprite = __instance.invBoxCanUse;

						if (__instance.slotType != "NPCChest" && __instance.slotType != "Chest")
						{
							if (combineTextColor == null) combineTextColor = __instance.toolbarNumText.color;
							CustomTooltip tooltip = combinable.CombineTooltip(combinee);
							__instance.toolbarNumTextGo.SetActive(true);
							__instance.toolbarNumText.text = tooltip.Text ?? string.Empty;
							__instance.toolbarNumText.color = tooltip.Color ?? combineTextColor.Value;
						}
					}
					else if ((__instance.slotType != "Toolbar" || __instance.mainGUI.openedInventory) && __instance.slotType != "NPCChest")
					{
						__instance.myImage.color = new Color32(__instance.br, 0, __instance.br, __instance.standardAlpha);
						__instance.itemImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, __instance.fadedItemAlpha);
						__instance.myImage.sprite = __instance.invBoxNormal;
						___itemText.color = __instance.whiteTransparent;
						__instance.toolbarNumTextGo.SetActive(false);
					}
				}
				else if (__instance.slotType != "NPCChest" && (combinee.invItemName != null || combiner.itemType != "Combine"))
				{
					__instance.myImage.color = __instance.overSlot
						? (Color)new Color32(0, __instance.br, __instance.br, __instance.standardAlpha)
						: (Color)new Color32(__instance.br, __instance.br, __instance.br, __instance.standardAlpha);

					__instance.itemImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					__instance.myImage.sprite = __instance.invBoxNormal;
					if (__instance.slotType == "Toolbar")
						__instance.toolbarNumTextGo.SetActive(false);
				}
				if (__instance.mainGUI.curSelected == __instance.mySelectable && __instance.agent.controllerType != "Keyboard")
					__instance.invInterface.OnSelectionBox(__instance.slotType, __instance.tr.position);
			}
		}

		public static IEnumerable<CodeInstruction> Unlocks_LoadInitialUnlocks(IEnumerable<CodeInstruction> codeEnumerable)
		{ // remove the entire foreach loop in the end
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
					if (unlock.unlockType == "Challenge") wrapper = new MutatorUnlock(unlock.unlockName);
					else if (unlock.unlockType == "Item") wrapper = new ItemUnlock(unlock.unlockName);
					else if (unlock.unlockType == "Trait") wrapper = new TraitUnlock(unlock.unlockName);
					else if (unlock.unlockType == "Ability") wrapper = new AbilityUnlock(unlock.unlockName);
					else if (unlock.unlockType == "Achievement") wrapper = new AchievementUnlock(unlock.unlockName);
					else if (unlock.unlockType == "Floor") wrapper = new FloorUnlock(unlock.unlockName);
					else if (unlock.unlockType == "BigQuest") wrapper = new BigQuestUnlock(unlock.unlockName);
					else if (unlock.unlockType == "HomeBase") wrapper = new HomeBaseUnlock(unlock.unlockName);
					else if (unlock.unlockType == "Extra") wrapper = new ExtraUnlock(unlock.unlockName);
					else if (unlock.unlockType == "Agent") wrapper = new AgentUnlock(unlock.unlockName);
					else if (unlock.unlockType == "Loadout") wrapper = new LoadoutUnlock(unlock.unlockName);
					wrapper.Unlock = unlock;
					unlock.__RogueLibsCustom = wrapper;
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

		public static void ScrollingMenu_OpenScrollingMenu_Prefix(ScrollingMenu __instance, out float __state)
		{
			float x = 1f - __instance.scrollBar.value;
			__state = x * (__instance.numButtons - __instance.numButtonsOnScreen + 1f);
			RogueLibs.Logger.LogError($"{__state}={x} * {__instance.numButtons - __instance.numButtonsOnScreen + 1f}");
		}
		public static void ScrollingMenu_OpenScrollingMenu(ScrollingMenu __instance, ref float __state, List<Unlock> ___listUnlocks)
		{
			__instance.numButtons = ___listUnlocks.Count;
			float x = __state / (__instance.numButtons - __instance.numButtonsOnScreen + 1f);
			RogueLibs.Logger.LogError($"{x}={__state} / {__instance.numButtons - __instance.numButtonsOnScreen + 1f}");
			__instance.StartCoroutine(EnsureScrollbarValue(__instance, 1f - x));
			if (__instance.menuType == "Challenges" || __instance.menuType == "FreeItems")
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
			}
			else if (__instance.menuType == "Traits" || __instance.menuType == "Floors")
			{
				foreach (ButtonData buttonData in __instance.buttonsData)
				{
					SetupUnlocks(buttonData, buttonData.scrollingButtonUnlock);
				}
			}
		}
		private static IEnumerator EnsureScrollbarValue(ScrollingMenu menu, float value)
		{
			menu.scrollBar.value = value;
			yield return null;
			menu.scrollBar.value = value;
			yield return null;
			menu.scrollBar.value = value;
			yield return null;
			menu.scrollBar.value = value;
		}

		public static bool ScrollingMenu_SetupChallenges(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupChangeTraitsRandom(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupFreeItems(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupItemUnlocks(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupLoadouts(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupRemoveTraits(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupTraitUnlocks(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);
		public static bool ScrollingMenu_SetupUpgradeTraits(ButtonData myButtonData, Unlock myUnlock) => SetupUnlocks(myButtonData, myUnlock);

		public static bool SetupUnlocks(ButtonData myButtonData, Unlock myUnlock)
		{
			DisplayedUnlock du = (DisplayedUnlock)(myButtonData.__RogueLibsCustom = myUnlock.__RogueLibsCustom);
			du.ButtonData = myButtonData;

			myButtonData.scrollingButtonUnlock = myUnlock;
			myButtonData.scrollingButtonType = myUnlock.unlockName;
			myButtonData.interactable = true;
			myButtonData.buttonText = du.GetName();

			du.UpdateUnlock();
			du.UpdateButton();
			return false;
		}

		public static readonly DisplayedUnlock clearAllMutators = new ClearAllMutatorsUnlock();
		public static readonly DisplayedUnlock clearAllItems = new ClearAllItemsUnlock();
		public static readonly DisplayedUnlock clearAllTraits = new ClearAllTraitsUnlock();

		public static bool ScrollingMenu_SortUnlocks(ScrollingMenu __instance, List<Unlock> myUnlockList, string unlockType, List<Unlock> ___listUnlocks)
		{
			CustomScrollingMenu menu = new CustomScrollingMenu(__instance, myUnlockList.Select(u => u.__RogueLibsCustom).OfType<DisplayedUnlock>().ToList());
			___listUnlocks.Clear();
			___listUnlocks.AddRange(menu.Unlocks.Select(du => du.Unlock));

			foreach (DisplayedUnlock du in menu.Unlocks)
				du.Menu = menu;

			if (unlockType == "Challenge")
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
				clearAllMutators.Menu = menu;
				___listUnlocks.Insert(0, clearAllMutators.Unlock);
			}
			else if (unlockType == "Item")
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
				clearAllItems.Menu = menu;
				___listUnlocks.Insert(0, clearAllItems.Unlock);
			}
			else if (unlockType == "Trait")
			{
				__instance.nuggetSlot.gameObject.SetActive(true);
				clearAllTraits.Menu = menu;
				___listUnlocks.Insert(0, clearAllTraits.Unlock);
			}
			else if (unlockType == "Ability" || unlockType == "BigQuest")
			{
				___listUnlocks.RemoveAll(u => u.__RogueLibsCustom is IUnlockInCC inCC && !inCC.IsAvailableInCC);
			}

			__instance.numButtons = ___listUnlocks.Count;
			return false;
		}
		public static bool ScrollingMenu_PushedButton(ScrollingMenu __instance, ButtonHelper myButton)
		{
			ButtonData buttonData = __instance.buttonsData[myButton.scrollingButtonNum];
			DisplayedUnlock du = (DisplayedUnlock)buttonData.__RogueLibsCustom;
			if (__instance.menuType == "Challenges")
			{
				du?.OnPushedButton();
				return false;
			}
			return true;
		}
		public static bool ScrollingMenu_ShowDetails(ScrollingMenu __instance, ButtonHelper myButton)
		{
			if (__instance.agent != null && myButton.scrollingButtonUnlock?.unlockType == "Trait" && __instance.agent.addedEndLevelTrait || !string.IsNullOrEmpty(myButton.scrollingButtonLevelFeeling) || !string.IsNullOrEmpty(myButton.scrollingButtonConfigName) || !string.IsNullOrEmpty(myButton.scrollingButtonAgentName))
				return true;
			DisplayedUnlock du = (DisplayedUnlock)myButton.scrollingButtonUnlock.__RogueLibsCustom;

			__instance.detailsTitle.text = du.GetName();
			__instance.detailsText.text = du.GetDescription();
			__instance.detailsImage.sprite = du.GetImage();

			return false;
		}
	}
}
