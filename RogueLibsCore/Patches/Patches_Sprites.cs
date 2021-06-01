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
		///   <para>Applies the patches to <see cref="SpawnerMain"/> and stuff to set up the custom sprites.</para>
		/// </summary>
		public void PatchSprites()
		{
			// define RogueSprites in the RogueSprite.addOnGCAwakeList
			Patcher.Postfix(typeof(GameController), "Awake");

			// set the shared material of all renderers to the one selected in the tk2dSpriteDefinition
			Patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnItemSprite));
			Patcher.Postfix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnItemWeapon));
			Patcher.Postfix(typeof(SpawnerMain), nameof(SpawnerMain.SetLighting2));
			Patcher.Postfix(typeof(ObjectSprite), nameof(ObjectSprite.SetObjectHighlight));
			Patcher.Postfix(typeof(ObjectSprite), nameof(ObjectSprite.SetAgentOff));
			Patcher.Postfix(typeof(Melee), nameof(Melee.MeleeLateUpdate), nameof(Melee_MeleeLateUpdate_Prefix));
			Patcher.Postfix(typeof(Melee), nameof(Melee.MeleeLateUpdate));
		}

		/// <summary>
		///   <para><b>Postfix-patch.</b> Defines the custom sprites from <see cref="RogueSprite.prepared"/>.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="GameController"/>.</param>
		public static void GameController_Awake(GameController __instance)
		{
			RogueSprite.DefinePrepared(__instance.spawnerMain.itemSprites, SpriteScope.Items);
			RogueSprite.DefinePrepared(__instance.spawnerMain.objectSprites, SpriteScope.Objects);
			RogueSprite.DefinePrepared(__instance.spawnerMain.floorSprites, SpriteScope.Floors);
		}

		/// <summary>
		///   <para><b>Prefix-patch (complete override).</b> Sets the dropped item's sprite and sets its materials and shaders.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="SpawnerMain"/>.</param>
		/// <param name="item">Dropped item as an <see cref="InvItem"/>.</param>
		/// <param name="itemImage"><see cref="tk2dSprite"/> with the item's sprite.</param>
		/// <param name="newItem">Dropped item as an <see cref="Item"/>.</param>
		/// <returns><see langword="false"/>. Completely overrides the original method.</returns>
		public static bool SpawnerMain_SpawnItemSprite(SpawnerMain __instance, InvItem item, tk2dSprite itemImage, Item newItem)
		{
			try { itemImage.SetSprite(__instance.gc.spawnerMain.itemSprites, item.spriteName); } catch { }
			Material mat = itemImage.CurrentSprite.material;

			itemImage.GetComponent<Renderer>().sharedMaterial = mat;
			try
			{
				if (!__instance.gc.serverPlayer)
				{
					__instance.itemLightUp = Instantiate(mat);
					__instance.itemLightUp.shader = __instance.gc.lightUpShader;
				}
				newItem.objectSprite.sprH.GetComponent<Renderer>().sharedMaterial = mat;
				newItem.objectSprite.sprH.SetSprite(itemImage.spriteId);
			}
			catch
			{
				try
				{
					newItem.objectSprite.transform.Find("Highlight").GetComponent<tk2dSprite>().SetSprite(itemImage.spriteId);
					try { newItem.objectSprite.GetComponent<Renderer>().sharedMaterial = mat; }
					catch { Debug.LogError("Couldn't set highlight for item 1: " + newItem); }
					try { newItem.objectSprite.spr.GetComponent<Renderer>().sharedMaterial = mat; }
					catch { Debug.LogError("Couldn't set highlight for item 2: " + newItem); }
					try { newItem.objectSprite.sprH.GetComponent<Renderer>().sharedMaterial = mat; }
					catch { Debug.LogError("Couldn't set highlight for item 3: " + newItem); }
					Debug.LogError("SPAWNN");
				}
				catch
				{
					Debug.LogError("Couldn't set highlight for item 4: " + newItem);
				}
			}
			if (item.invItemName == "Money")
			{
				if (item.invItemCount == 1)
				{
					itemImage.SetSprite(itemImage.GetSpriteIdByName("MoneyA"));
					item.shadowOffset = 6;
				}
				else if (item.invItemCount > 1 && item.invItemCount <= 5)
				{
					itemImage.SetSprite(itemImage.GetSpriteIdByName("MoneyB"));
					item.shadowOffset = 4;
				}
				else if (item.invItemCount > 5 && item.invItemCount < 10)
				{
					itemImage.SetSprite(itemImage.GetSpriteIdByName("MoneyC"));
					item.shadowOffset = 4;
				}
				else item.shadowOffset = 3;
			}

			return false;
		}
		/// <summary>
		///   <para><b>Postfix-patch.</b> Sets the renderer's material.</para>
		/// </summary>
		/// <param name="__result">Created item.</param>
		public static void SpawnerMain_SpawnItemWeapon(Item __result)
		{
			tk2dSprite itemImage = __result.tr.GetChild(0).transform.GetChild(0).GetComponent<tk2dSprite>();
			itemImage.GetComponent<Renderer>().sharedMaterial = itemImage.CurrentSprite.material;
		}
		/// <summary>
		///   <para><b>Postfix-patch.</b> Sets the renderer's material.</para>
		/// </summary>
		/// <param name="myObject">Object with a renderer with an incorrect material.</param>
		public static void SpawnerMain_SetLighting2(PlayfieldObject myObject)
		{
			if (myObject.CompareTag("Item") || myObject.CompareTag("Wreckage"))
			{
				Item item = (Item)myObject;
				item.spriteTr.GetComponent<Renderer>().sharedMaterial = item.spriteRealTr.GetComponent<tk2dSprite>().CurrentSprite.material;
			}
		}
		public static void ObjectSprite_SetObjectHighlight(ObjectSprite __instance)
		{
			RogueSprite sprite = (RogueSprite)__instance.sprH.CurrentSprite.__RogueLibsCustom;
			if (sprite != null) __instance.objectRendererH.sharedMaterial = sprite.LightUpMaterial;
		}
		public static void ObjectSprite_SetAgentOff(ObjectSprite __instance)
		{
			List<Renderer> agentSpriteRendererListH = __instance.agentHitbox.agentSpriteRendererListH;
			List<tk2dSprite> agentSpriteList = __instance.agentHitbox.agentSpriteList;
			if (!__instance.agentColorDirty && __instance.gc.loadCompleteReally && __instance.didSetRendererOffInitial)
			{
				for (int i = 0; i < agentSpriteRendererListH.Count; i++)
				{
					agentSpriteRendererListH[i].enabled = false;
					RogueSprite sprite = (RogueSprite)agentSpriteList[i].CurrentSprite.__RogueLibsCustom;
					if (sprite != null) __instance.agentHitbox.agentSpriteRendererList[i].sharedMaterial = sprite.Material;
				}
				return;
			}

			List<Renderer> agentSpriteRendererList = __instance.agentHitbox.agentSpriteRendererList;
			for (int j = 0; j < agentSpriteList.Count; j++)
			{
				agentSpriteRendererListH[j].enabled = false;
				RogueSprite sprite = (RogueSprite)agentSpriteList[j].CurrentSprite.__RogueLibsCustom;
				if (sprite != null) agentSpriteRendererList[j].sharedMaterial = sprite.Material;
			}

			RogueSprite meleeSpr1 = (RogueSprite)__instance.agent.melee.spr.CurrentSprite.__RogueLibsCustom;
			if (meleeSpr1 != null) __instance.agent.melee.arm1SpriteRenderer.sharedMaterial = meleeSpr1.Material;

			RogueSprite meleeSpr2 = (RogueSprite)__instance.agent.melee.spr.CurrentSprite.__RogueLibsCustom;
			if (meleeSpr2 != null) __instance.agent.melee.arm2SpriteRenderer.sharedMaterial = meleeSpr2.Material;

			RogueSprite meleeSpr = (RogueSprite)__instance.agent.melee.spr.CurrentSprite.__RogueLibsCustom;
			if (meleeSpr != null) __instance.agent.melee.meleeSpriteRenderer.sharedMaterial = meleeSpr.Material;

			RogueSprite gunSpr1 = (RogueSprite)__instance.agent.melee.spr.CurrentSprite.__RogueLibsCustom;
			if (gunSpr1 != null) __instance.agent.gun.arm1SpriteRenderer.sharedMaterial = gunSpr1.Material;

			RogueSprite gunSpr2 = (RogueSprite)__instance.agent.melee.spr.CurrentSprite.__RogueLibsCustom;
			if (gunSpr2 != null) __instance.agent.gun.arm2SpriteRenderer.sharedMaterial = gunSpr2.Material;

			RogueSprite gunSpr = (RogueSprite)__instance.agent.melee.spr.CurrentSprite.__RogueLibsCustom;
			if (gunSpr != null) __instance.agent.gun.gunSpriteRenderer.sharedMaterial = gunSpr.Material;
		}
		public static void Melee_MeleeLateUpdate_Prefix(Melee __instance, ref bool __state)
			=> __state = ((__instance.agent.brain.active && (__instance.agent.inCombat || __instance.agent.inFleeCombat || __instance.agent.onCamera)) || !__instance.gc.loadCompleteReally) && (__instance.agent.inventory.equippedWeapon != __instance.agent.inventory.fist || __instance.refreshWeapon);
		public static void Melee_MeleeLateUpdate(Melee __instance, ref bool __state)
		{
			if (!__state) return;

			AgentHitbox hb = __instance.agent.agentHitboxScript;
			RogueSprite sprite = (RogueSprite)hb.heldItem2.CurrentSprite.__RogueLibsCustom;
			if (sprite != null) hb.heldItem2Renderer.sharedMaterial = sprite.Material;
		}
	}
}
