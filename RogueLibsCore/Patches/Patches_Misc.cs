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
		///   <para>Applies the patches to <see cref="NameDB"/> and <see cref="Updater"/>.</para>
		/// </summary>
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

		/// <summary>
		///   <para><b>Postfix-patch.</b> Saves the current language as a <see cref="LanguageCode"/> value.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="NameDB"/>.</param>
		public static void NameDB_RealAwake(NameDB __instance)
			=> currentLanguageCode = CustomName.Languages.TryGetValue(__instance.language, out LanguageCode code) ? code : LanguageCode.English;
		/// <summary>
		///   <para><b>Postfix-patch.</b> Makes the original method return the appropriate <see cref="ICustomName"/>'s translation, if the original returned a string starting with <c>"E_"</c>.</para>
		/// </summary>
		/// <param name="myName">Custom name's name/id.</param>
		/// <param name="type">Custom name's type.</param>
		/// <param name="__result">Return value of the method.</param>
		public static void NameDB_GetName(string myName, string type, ref string __result)
		{
			if (__result.StartsWith("E_") && RogueLibsInternals.CustomNames.TryGetValue(type, out Dictionary<string, ICustomName> category)
				&& category.TryGetValue(myName, out ICustomName customName))
				__result = customName[currentLanguageCode] ?? customName[LanguageCode.English];
		}
		private static LanguageCode currentLanguageCode;

		/// <summary>
		///   <para><b>Postfix-patch.</b> Invokes <see cref="IDoUpdate.Update"/> of all custom hooks, attached to the game's agents, the items in their inventory, their traits and status effects, the dropped items and the placed objects.</para>
		/// </summary>
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
						RogueLibsInternals.Logger.LogError($"Error updating {obj} in {agent.agentName}");
						RogueLibsInternals.Logger.LogError(e);
					}

				for (int j = 0; j < agent.inventory.InvItemList.Count; j++)
				{
					InvItem item = agent.inventory.InvItemList[j];
					foreach (IDoUpdate obj in item.GetHooks<IDoUpdate>())
						try { obj.Update(); }
						catch (Exception e)
						{
							RogueLibsInternals.Logger.LogError($"Error updating {obj} in {item.invItemName} ({agent.agentName})");
							RogueLibsInternals.Logger.LogError(e);
						}
				}

				for (int j = 0; j < agent.statusEffects.StatusEffectList.Count; j++)
				{
					StatusEffect effect = agent.statusEffects.StatusEffectList[j];
					foreach (IDoUpdate obj in effect.GetHooks<IDoUpdate>())
						try { obj.Update(); }
						catch (Exception e)
						{
							RogueLibsInternals.Logger.LogError($"Error updating {obj} in {effect.statusEffectName} ({agent.agentName})");
							RogueLibsInternals.Logger.LogError(e);
						}
				}

				for (int j = 0; j < agent.statusEffects.TraitList.Count; j++)
				{
					Trait trait = agent.statusEffects.TraitList[j];
					foreach (IDoUpdate obj in trait.GetHooks<IDoUpdate>())
						try { obj.Update(); }
						catch (Exception e)
						{
							RogueLibsInternals.Logger.LogError($"Error updating {obj} in {trait.traitName} ({agent.agentName})");
							RogueLibsInternals.Logger.LogError(e);
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
						RogueLibsInternals.Logger.LogError($"Error updating {obj} in {items[i]}");
						RogueLibsInternals.Logger.LogError(e);
					}
			}

			List<ObjectReal> objects = GameController.gameController.objectRealListUpdate;
			for (int i = 0; i < objects.Count; i++)
			{
				foreach (IDoUpdate obj in objects[i].GetHooks<IDoUpdate>())
					try { obj.Update(); }
					catch (Exception e)
					{
						RogueLibsInternals.Logger.LogError($"Error updating {obj} in {objects[i].objectName}");
						RogueLibsInternals.Logger.LogError(e);
					}
			}
		}
		/// <summary>
		///   <para><b>Postfix-patch.</b> Invokes <see cref="IDoFixedUpdate.FixedUpdate"/> of all custom hooks, attached to the game's agents, the items in their inventory, their traits and status effects, the dropped items and the placed objects.</para>
		/// </summary>
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
						RogueLibsInternals.Logger.LogError($"Error updating {obj} in {agent.agentName}");
						RogueLibsInternals.Logger.LogError(e);
					}

				for (int j = 0; j < agent.inventory.InvItemList.Count; j++)
				{
					InvItem item = agent.inventory.InvItemList[j];
					foreach (IDoFixedUpdate obj in item.GetHooks<IDoFixedUpdate>())
						try { obj.FixedUpdate(); }
						catch (Exception e)
						{
							RogueLibsInternals.Logger.LogError($"Error updating {obj} in {item.invItemName} ({agent.agentName})");
							RogueLibsInternals.Logger.LogError(e);
						}
				}

				for (int j = 0; j < agent.statusEffects.StatusEffectList.Count; j++)
				{
					StatusEffect effect = agent.statusEffects.StatusEffectList[j];
					foreach (IDoFixedUpdate obj in effect.GetHooks<IDoFixedUpdate>())
						try { obj.FixedUpdate(); }
						catch (Exception e)
						{
							RogueLibsInternals.Logger.LogError($"Error updating {obj} in {effect.statusEffectName} ({agent.agentName})");
							RogueLibsInternals.Logger.LogError(e);
						}
				}

				for (int j = 0; j < agent.statusEffects.TraitList.Count; j++)
				{
					Trait trait = agent.statusEffects.TraitList[j];
					foreach (IDoFixedUpdate obj in trait.GetHooks<IDoFixedUpdate>())
						try { obj.FixedUpdate(); }
						catch (Exception e)
						{
							RogueLibsInternals.Logger.LogError($"Error updating {obj} in {trait.traitName} ({agent.agentName})");
							RogueLibsInternals.Logger.LogError(e);
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
						RogueLibsInternals.Logger.LogError($"Error updating {obj} in {items[i]}");
						RogueLibsInternals.Logger.LogError(e);
					}
			}

			List<ObjectReal> objects = GameController.gameController.objectRealListUpdate;
			for (int i = 0; i < objects.Count; i++)
			{
				foreach (IDoFixedUpdate obj in objects[i].GetHooks<IDoFixedUpdate>())
					try { obj.FixedUpdate(); }
					catch (Exception e)
					{
						RogueLibsInternals.Logger.LogError($"Error updating {obj} in {objects[i].objectName}");
						RogueLibsInternals.Logger.LogError(e);
					}
			}
		}
	}
}
