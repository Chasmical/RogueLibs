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
		public void PatchMisc()
		{
			// get and set the current game language as a LanguageCode
			Patcher.Postfix(typeof(NameDB), nameof(NameDB.RealAwake));
			// CustomNames
			Patcher.Postfix(typeof(NameDB), nameof(NameDB.GetName));

			// IDoUpdate.Update()
			Patcher.Postfix(typeof(Updater), "Update");
			// IDoFixedUpdate.FixedUpdate()
			Patcher.Postfix(typeof(Updater), nameof(Updater.FixedUpdate));
		}

		public static void NameDB_RealAwake(NameDB __instance)
		{
			if (!CustomName.Languages.TryGetValue(__instance.language, out LanguageCode code))
				code = LanguageCode.English;

			LanguageService.NameDB = __instance;
			LanguageService.Current = code;
		}
		public static void NameDB_GetName(string myName, string type, ref string __result)
		{
			string orig = __result;
			if (__result.StartsWith("E_")) __result = null;

			foreach (INameProvider provider in RogueFramework.NameProviders)
				provider.GetName(myName, type, ref __result);

			if (__result is null) __result = orig;
		}

		public static void Updater_Update()
		{
			List<Agent> agents = GameController.gameController.agentList;
			for (int i = 0; i < agents.Count; i++)
			{
				Agent agent = agents[i];
				foreach (IDoUpdate obj in agents[i].GetHooks<IDoUpdate>())
					try { obj.Update(); }
					catch (Exception e)
					{
						RogueFramework.Logger.LogError($"Error updating {obj} in {agent.agentName}");
						RogueFramework.Logger.LogError(e);
					}

				for (int j = 0; j < agent.inventory.InvItemList.Count; j++)
				{
					InvItem item = agent.inventory.InvItemList[j];
					foreach (IDoUpdate obj in item.GetHooks<IDoUpdate>())
						try { obj.Update(); }
						catch (Exception e)
						{
							RogueFramework.Logger.LogError($"Error updating {obj} in {item.invItemName} ({agent.agentName})");
							RogueFramework.Logger.LogError(e);
						}
				}

				for (int j = 0; j < agent.statusEffects.StatusEffectList.Count; j++)
				{
					StatusEffect effect = agent.statusEffects.StatusEffectList[j];
					foreach (IDoUpdate obj in effect.GetHooks<IDoUpdate>())
						try { obj.Update(); }
						catch (Exception e)
						{
							RogueFramework.Logger.LogError($"Error updating {obj} in {effect.statusEffectName} ({agent.agentName})");
							RogueFramework.Logger.LogError(e);
						}
				}

				for (int j = 0; j < agent.statusEffects.TraitList.Count; j++)
				{
					Trait trait = agent.statusEffects.TraitList[j];
					foreach (IDoUpdate obj in trait.GetHooks<IDoUpdate>())
						try { obj.Update(); }
						catch (Exception e)
						{
							RogueFramework.Logger.LogError($"Error updating {obj} in {trait.traitName} ({agent.agentName})");
							RogueFramework.Logger.LogError(e);
						}
				}
			}

			List<Item> items = GameController.gameController.itemList;
			for (int i = 0; i < items.Count; i++)
			{
				foreach (IDoUpdate obj in items[i].invItem.GetHooks<IDoUpdate>())
					try { obj.Update(); }
					catch (Exception e)
					{
						RogueFramework.Logger.LogError($"Error updating {obj} in {items[i]}");
						RogueFramework.Logger.LogError(e);
					}
			}

			List<ObjectReal> objects = GameController.gameController.objectRealListUpdate;
			for (int i = 0; i < objects.Count; i++)
			{
				foreach (IDoUpdate obj in objects[i].GetHooks<IDoUpdate>())
					try { obj.Update(); }
					catch (Exception e)
					{
						RogueFramework.Logger.LogError($"Error updating {obj} in {objects[i].objectName}");
						RogueFramework.Logger.LogError(e);
					}
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
					catch (Exception e)
					{
						RogueFramework.Logger.LogError($"Error updating {obj} in {agent.agentName}");
						RogueFramework.Logger.LogError(e);
					}

				for (int j = 0; j < agent.inventory.InvItemList.Count; j++)
				{
					InvItem item = agent.inventory.InvItemList[j];
					foreach (IDoFixedUpdate obj in item.GetHooks<IDoFixedUpdate>())
						try { obj.FixedUpdate(); }
						catch (Exception e)
						{
							RogueFramework.Logger.LogError($"Error updating {obj} in {item.invItemName} ({agent.agentName})");
							RogueFramework.Logger.LogError(e);
						}
				}

				for (int j = 0; j < agent.statusEffects.StatusEffectList.Count; j++)
				{
					StatusEffect effect = agent.statusEffects.StatusEffectList[j];
					foreach (IDoFixedUpdate obj in effect.GetHooks<IDoFixedUpdate>())
						try { obj.FixedUpdate(); }
						catch (Exception e)
						{
							RogueFramework.Logger.LogError($"Error updating {obj} in {effect.statusEffectName} ({agent.agentName})");
							RogueFramework.Logger.LogError(e);
						}
				}

				for (int j = 0; j < agent.statusEffects.TraitList.Count; j++)
				{
					Trait trait = agent.statusEffects.TraitList[j];
					foreach (IDoFixedUpdate obj in trait.GetHooks<IDoFixedUpdate>())
						try { obj.FixedUpdate(); }
						catch (Exception e)
						{
							RogueFramework.Logger.LogError($"Error updating {obj} in {trait.traitName} ({agent.agentName})");
							RogueFramework.Logger.LogError(e);
						}
				}
			}

			List<Item> items = GameController.gameController.itemList;
			for (int i = 0; i < items.Count; i++)
			{
				foreach (IDoFixedUpdate obj in items[i].invItem.GetHooks<IDoFixedUpdate>())
					try { obj.FixedUpdate(); }
					catch (Exception e)
					{
						RogueFramework.Logger.LogError($"Error updating {obj} in {items[i]}");
						RogueFramework.Logger.LogError(e);
					}
			}

			List<ObjectReal> objects = GameController.gameController.objectRealListUpdate;
			for (int i = 0; i < objects.Count; i++)
			{
				foreach (IDoFixedUpdate obj in objects[i].GetHooks<IDoFixedUpdate>())
					try { obj.FixedUpdate(); }
					catch (Exception e)
					{
						RogueFramework.Logger.LogError($"Error updating {obj} in {objects[i].objectName}");
						RogueFramework.Logger.LogError(e);
					}
			}
		}
	}
}
