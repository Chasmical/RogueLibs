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
using Light2D.Examples;

namespace RogueLibsCore
{
	internal sealed partial class RogueLibsPlugin
	{
		public void PatchSprites()
		{
			// define non-initialized RogueSprites
			Patcher.Postfix(typeof(GameController), "Awake");

			// set the shared material of all renderers to the one selected in the tk2dSpriteDefinition
			Patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnItemSprite));
			Patcher.Postfix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnItemWeapon));
			Patcher.Postfix(typeof(SpawnerMain), nameof(SpawnerMain.SetLighting2));

			Patcher.Postfix(typeof(ObjectReal), nameof(ObjectReal.RefreshShader));
			Patcher.Postfix(typeof(ObjectSprite), nameof(ObjectSprite.SetObjectHighlight));
			Patcher.Postfix(typeof(ObjectSprite), nameof(ObjectSprite.SetAgentOff));
			Patcher.Postfix(typeof(ObjectSprite), nameof(ObjectSprite.SetAgentHighlight));

			Patcher.Postfix(typeof(InvDatabase), nameof(InvDatabase.ThrowWeapon));
			Patcher.Postfix(typeof(Item), nameof(Item.DestroyMe2));
			Patcher.Postfix(typeof(Item), nameof(Item.FakeStart));
			Patcher.Postfix(typeof(Melee), nameof(Melee.MeleeLateUpdate));

			Patcher.Postfix(typeof(ObjectReal), "Start");
			Patcher.Postfix(typeof(ObjectReal), nameof(ObjectReal.SpawnShadow));

			// Nugget slot image
			Patcher.Postfix(typeof(NuggetSlot), nameof(NuggetSlot.UpdateNuggetText));
		}

		public static void GameController_Awake(GameController __instance)
		{
			RogueSprite.DefinePrepared(__instance.spawnerMain.itemSprites, SpriteScope.Items);
			RogueSprite.DefinePrepared(__instance.spawnerMain.objectSprites, SpriteScope.Objects);
			RogueSprite.DefinePrepared(__instance.spawnerMain.floorSprites, SpriteScope.Floors);
		}

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
					try { newItem.objectSprite.GetComponent<Renderer>().sharedMaterial = mat; }
					catch { Debug.LogError("Couldn't set highlight for item 1: " + newItem); }
					try { newItem.objectSprite.spr.GetComponent<Renderer>().sharedMaterial = mat; }
					catch { Debug.LogError("Couldn't set highlight for item 2: " + newItem); }
					try { newItem.objectSprite.sprH.GetComponent<Renderer>().sharedMaterial = mat; }
					catch { Debug.LogError("Couldn't set highlight for item 3: " + newItem); }
					newItem.objectSprite.transform.Find("Highlight").GetComponent<tk2dSprite>().SetSprite(itemImage.spriteId);
					Debug.LogError("SPAWNN");
				}
				catch
				{
					Debug.LogError("Couldn't set highlight for item 4: " + newItem);
				}
			}
			if (item.invItemName == "Money")
			{
				if (item.invItemCount is 1)
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
		public static void SpawnerMain_SpawnItemWeapon(Item __result)
		{
			try
			{
				tk2dSprite itemImage = __result.tr.GetChild(0).transform.GetChild(0).GetComponent<tk2dSprite>();
				itemImage.GetComponent<Renderer>().sharedMaterial = itemImage.CurrentSprite.material;
			}
			catch { }
		}
		public static void SpawnerMain_SetLighting2(PlayfieldObject myObject)
		{
			if (myObject.CompareTag("ObjectReal"))
			{
				ObjectReal objectReal = (ObjectReal)myObject;
				try { objectReal.spr.GetComponent<Renderer>().sharedMaterial = objectReal.spr.CurrentSprite.material; }
				catch { }
			}
			if (myObject.CompareTag("Item") || myObject.CompareTag("Wreckage"))
			{
				Item item = (Item)myObject;
				try { item.spriteTr.GetComponent<Renderer>().sharedMaterial = item.spr.CurrentSprite.material; }
				catch { }
			}
		}

		public static void ObjectReal_RefreshShader(ObjectReal __instance)
		{
			Material mat = __instance.spr?.CurrentSprite.material;

			Shader shader = GameController.gameController.lightingType == "Full" || GameController.gameController.lightingType == "Med"
				? GameController.gameController.litShader : GameController.gameController.normalShader;
			__instance.objectSprite.meshRenderer.material = mat;
			__instance.objectSprite.meshRenderer.material.shader = shader;
			__instance.objectSprite.objectRenderer.sharedMaterial = mat;
			__instance.objectSprite.objectRenderer.sharedMaterial.shader = shader;
		}
		public static void ObjectSprite_SetObjectHighlight(ObjectSprite __instance)
		{
			if (__instance.sprH.CurrentSprite.__RogueLibsCustom is RogueSprite sprite)
				__instance.objectRendererH.sharedMaterial = sprite.LightUpMaterial;
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
					if (agentSpriteList[i].CurrentSprite.__RogueLibsCustom is RogueSprite sprite)
						__instance.agentHitbox.agentSpriteRendererList[i].sharedMaterial = sprite.Material;
				}
				return;
			}

			List<Renderer> agentSpriteRendererList = __instance.agentHitbox.agentSpriteRendererList;
			for (int j = 0; j < agentSpriteList.Count; j++)
			{
				agentSpriteRendererListH[j].enabled = false;
				if (agentSpriteList[j].CurrentSprite.__RogueLibsCustom is RogueSprite sprite)
					agentSpriteRendererList[j].sharedMaterial = sprite.Material;
			}

			if (__instance.agent.inventory.equippedWeapon == __instance.agent.melee.invItem)
			{
				if (__instance.agent.melee.arm1Sprite.CurrentSprite.__RogueLibsCustom is RogueSprite meleeSpr1)
					__instance.agent.melee.arm1SpriteRenderer.sharedMaterial = meleeSpr1.Material;

				if (__instance.agent.melee.arm2Sprite.CurrentSprite.__RogueLibsCustom is RogueSprite meleeSpr2)
					__instance.agent.melee.arm2SpriteRenderer.sharedMaterial = meleeSpr2.Material;

				if (__instance.agent.melee.spr.CurrentSprite.__RogueLibsCustom is RogueSprite meleeSpr)
					__instance.agent.melee.meleeSpriteRenderer.sharedMaterial = meleeSpr.Material;
			}
			else if (__instance.agent.inventory.equippedWeapon == __instance.agent.gun.visibleGun)
			{
				if (__instance.agent.gun.arm1Sprite.CurrentSprite.__RogueLibsCustom is RogueSprite gunSpr1)
					__instance.agent.gun.arm1SpriteRenderer.sharedMaterial = gunSpr1.Material;

				if (__instance.agent.gun.arm2Sprite.CurrentSprite.__RogueLibsCustom is RogueSprite gunSpr2)
					__instance.agent.gun.arm2SpriteRenderer.sharedMaterial = gunSpr2.Material;

				if (__instance.agent.gun.gunSprite.CurrentSprite.__RogueLibsCustom is RogueSprite gunSpr)
					__instance.agent.gun.gunSpriteRenderer.sharedMaterial = gunSpr.Material;
			}
		}
		public static void ObjectSprite_SetAgentHighlight(ObjectSprite __instance, int i)
		{
			Renderer renderer = __instance.agentHitbox.agentSpriteRendererListH[i];
			if (__instance.agentHitbox.agentSpriteListH[i].CurrentSprite.__RogueLibsCustom is RogueSprite sprite)
				renderer.sharedMaterial = sprite.LightUpMaterial;
		}

		public static void InvDatabase_ThrowWeapon(InvDatabase __instance)
		{
			if (__instance.agent?.agentHitboxScript?.heldItem2?.CurrentSprite?.__RogueLibsCustom is RogueSprite sprite)
				__instance.agent.agentHitboxScript.heldItem2Renderer.sharedMaterial = sprite.Material;
		}
		public static void Item_DestroyMe2(Item __instance)
		{
			if (__instance.itemImage?.CurrentSprite?.__RogueLibsCustom is RogueSprite sprite)
				__instance.itemImageTransform.GetComponent<Renderer>().sharedMaterial = sprite.Material;
		}
		public static void Item_FakeStart(Item __instance)
		{
			if (__instance.itemImageReal?.CurrentSprite?.__RogueLibsCustom is RogueSprite sprite)
				__instance.itemImageReal.GetComponent<Renderer>().sharedMaterial = sprite.Material;
		}
		public static void Melee_MeleeLateUpdate(Melee __instance)
		{
			AgentHitbox hb = __instance.agent.agentHitboxScript;

			hb.heldItem2H.SetSprite(hb.heldItem2.spriteId);
			if (hb.heldItem2.CurrentSprite.__RogueLibsCustom is RogueSprite sprite)
			{
				hb.heldItem2Renderer.sharedMaterial = sprite.Material;
				hb.heldItem2H.GetComponent<Renderer>().sharedMaterial = sprite.Material;
			}

			hb.heldItemH.SetSprite(hb.heldItem.spriteId);
			if (hb.heldItem.CurrentSprite.__RogueLibsCustom is RogueSprite sprite2)
			{
				hb.heldItemRenderer.sharedMaterial = sprite2.Material;
				hb.heldItemH.GetComponent<Renderer>().sharedMaterial = sprite2.Material;
			}
		}

		public static void ObjectReal_Start(ObjectReal __instance)
		{
			if (__instance.spr != null)
				__instance.ChangeSprite(__instance.spr.CurrentSprite.name);
			__instance.objectSprite?.RefreshRenderer();
			try
			{
				__instance.RefreshShader();
				__instance.StartCoroutine(__instance.SpawnShadow());
			}
			catch { }
		}
		public static void ObjectReal_SpawnShadow(ObjectReal __instance, ref IEnumerator __result)
			=> __result = SpawnShadowHelper(__instance, __result);
		private static IEnumerator SpawnShadowHelper(ObjectReal __instance, IEnumerator enumerator)
		{
			while (enumerator.MoveNext())
				yield return enumerator.Current;

			if (__instance.objectShadow != null)
			{
				__instance.objectShadow.SetSprite(__instance.spr.CurrentSprite.name);
				Material mat = __instance.objectShadow.CurrentSprite.material;
				__instance.objectShadow.GetComponent<Renderer>().sharedMaterial = mat;
				foreach (Renderer renderer in __instance.objectShadow.GetComponents<Renderer>())
					renderer.sharedMaterial = mat;
				foreach (Renderer renderer in __instance.objectShadow.GetComponentsInChildren<Renderer>(true))
					renderer.sharedMaterial = mat;
			}
			if (__instance.objectShadowCustom != null)
			{
				__instance.objectShadowCustom.SetSprite(__instance.spr.CurrentSprite.name);
				Material mat = __instance.objectShadowCustom.CurrentSprite.material;
				__instance.objectShadowCustom.GetComponent<Renderer>().sharedMaterial = mat;
				foreach (Renderer renderer in __instance.objectShadowCustom.GetComponents<Renderer>())
					renderer.sharedMaterial = mat;
				foreach (Renderer renderer in __instance.objectShadowCustom.GetComponentsInChildren<Renderer>(true))
					renderer.sharedMaterial = mat;
			}
		}

		public static void NuggetSlot_UpdateNuggetText(Image ___itemImage)
			=> ___itemImage.sprite = GameController.gameController.gameResources.itemDic
				.TryGetValue("Nugget", out Sprite sprite) ? sprite : null;
	}
}
