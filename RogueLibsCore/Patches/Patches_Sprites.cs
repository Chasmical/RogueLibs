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
		}

		/// <summary>
		///   <para><b>Postfix-patch.</b> Defines the custom sprites from <see cref="RogueSprite.addOnGCAwakeDict"/>.</para>
		/// </summary>
		/// <param name="__instance">Instance of <see cref="GameController"/>.</param>
		public static void GameController_Awake(GameController __instance)
		{
			tk2dSpriteCollectionData coll = __instance.spawnerMain.itemSprites;
			List<RogueSprite> list = RogueSprite.addOnGCAwakeDict[SpriteScope.Items];
			for (int i = 0; i < list.Count; i++)
			{
				RogueSprite sprite = list[i];
				sprite.willBeAddedOnGCAwake = false;
				sprite.DefineToCollection(coll);
			}
			RogueSprite.addOnGCAwakeDict.Remove(SpriteScope.Items);

			coll = __instance.spawnerMain.objectSprites;
			list = RogueSprite.addOnGCAwakeDict[SpriteScope.Objects];
			for (int i = 0; i < list.Count; i++)
			{
				RogueSprite sprite = list[i];
				sprite.willBeAddedOnGCAwake = false;
				sprite.DefineToCollection(coll);
			}
			RogueSprite.addOnGCAwakeDict.Remove(SpriteScope.Objects);

			coll = __instance.spawnerMain.floorSprites;
			list = RogueSprite.addOnGCAwakeDict[SpriteScope.Floors];
			for (int i = 0; i < list.Count; i++)
			{
				RogueSprite sprite = list[i];
				sprite.willBeAddedOnGCAwake = false;
				sprite.DefineToCollection(coll);
			}
			RogueSprite.addOnGCAwakeDict.Remove(SpriteScope.Floors);
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
	}
}
