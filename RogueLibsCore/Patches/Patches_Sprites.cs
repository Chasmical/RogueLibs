using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchSprites()
        {
            // define non-initialized RogueSprites
            Patcher.Postfix(typeof(tk2dEditorSpriteDataUnloader), nameof(tk2dEditorSpriteDataUnloader.Register));

            // set the shared material of all renderers to the one selected in the tk2dSpriteDefinition
            Patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnItemSprite));
            Patcher.Postfix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnItemWeapon));
            Patcher.Postfix(typeof(SpawnerMain), nameof(SpawnerMain.SetLighting2));

            Patcher.Postfix(typeof(ObjectReal), nameof(ObjectReal.RefreshShader));
            Patcher.Postfix(typeof(ObjectSprite), nameof(ObjectSprite.SetObjectHighlight));
            Patcher.Postfix(typeof(ObjectSprite), nameof(ObjectSprite.SetAgentOff));
            Patcher.Postfix(typeof(ObjectSprite), nameof(ObjectSprite.SetAgentHighlight));

            Patcher.Postfix(typeof(InvDatabase), nameof(InvDatabase.ThrowWeapon));
            Patcher.Prefix(typeof(InvDatabase), nameof(InvDatabase.DropItemAmount),
                           new Type[4] { typeof(InvItem), typeof(int), typeof(bool), typeof(Vector2) });
            Patcher.Postfix(typeof(Item), nameof(Item.DestroyMe2));
            Patcher.Postfix(typeof(Item), nameof(Item.FakeStart));
            Patcher.Postfix(typeof(Melee), nameof(Melee.MeleeLateUpdate));

            Patcher.Postfix(typeof(ObjectReal), "Start");
            Patcher.Postfix(typeof(ObjectReal), nameof(ObjectReal.SpawnShadow));

            // Nugget slot image
            Patcher.Postfix(typeof(NuggetSlot), nameof(NuggetSlot.UpdateNuggetText));
        }

        // ReSharper disable once IdentifierTypo
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        public static void tk2dEditorSpriteDataUnloader_Register(tk2dSpriteCollectionData data)
        {
            // RogueSprite.Dump(data);
            switch (data.name)
            {
                case "Items": RogueFramework.ItemSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Items); break;
                case "ObjectReals": RogueFramework.ObjectSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Objects); break;
                case "FloorTiles1": RogueFramework.FloorSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Floors); break;
                case "Bullets": RogueFramework.BulletSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Bullets); break;
                case "Hair": RogueFramework.HairSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Hair); break;
                case "FacialHair": RogueFramework.FacialHairSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.FacialHair); break;
                case "HeadPieces": RogueFramework.HeadPieceSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.HeadPieces); break;
                case "Agents": RogueFramework.AgentSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Agents); break;
                case "Bodies": RogueFramework.BodySprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Bodies); break;
                case "Wreckage": RogueFramework.WreckageSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Wreckage); break;
                case "Interface": RogueFramework.InterfaceSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Interface); break;
                case "Decals": RogueFramework.DecalSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Decals); break;
                case "WallTops": RogueFramework.WallTopSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.WallTops); break;
                case "WallTiles1": RogueFramework.WallSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Walls); break;
                case "Spawners": RogueFramework.SpawnerSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Spawners); break;
                case "Shadows": RogueFramework.ShadowSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.Shadows); break;
                case "ShadowTiles": RogueFramework.TileShadowSprites = data; RogueSprite.DefinePrepared(data, SpriteScope.TileShadows); break;
                default: RogueFramework.LogError($"Registered an unknown sprite collection '{data.name}'."); break;
            }
        }

        public static bool SpawnerMain_SpawnItemSprite(SpawnerMain __instance, InvItem item, tk2dSprite itemImage, Item newItem)
        {
            CustomItem? custom = item.GetHook<CustomItem>();
            if (custom is not null)
            {
                string spriteName = custom.GetSprite();
                item.LoadItemSprite(spriteName);
                itemImage.SetSprite(spriteName);
            }

            try { itemImage.SetSprite(__instance.gc.spawnerMain.itemSprites, item.spriteName); } catch { /* ??? */ }
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
                    Debug.LogError(@"SPAWNN");
                }
                catch
                {
                    Debug.LogError("Couldn't set highlight for item 4: " + newItem);
                }
            }
            if (item.invItemName == VanillaItems.Money)
            {
                if (item.invItemCount == 1)
                {
                    itemImage.SetSprite(itemImage.GetSpriteIdByName("MoneyA"));
                    item.shadowOffset = 6;
                }
                else if (item.invItemCount is > 1 and <= 5)
                {
                    itemImage.SetSprite(itemImage.GetSpriteIdByName("MoneyB"));
                    item.shadowOffset = 4;
                }
                else if (item.invItemCount is > 5 and < 10)
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
            catch { /* ??? */ }
        }
        public static void SpawnerMain_SetLighting2(PlayfieldObject myObject)
        {
            if (myObject.CompareTag("ObjectReal"))
            {
                ObjectReal objectReal = (ObjectReal)myObject;
                try { objectReal.spr.GetComponent<Renderer>().sharedMaterial = objectReal.spr.CurrentSprite.material; }
                catch { /* ??? */ }
            }
            if (myObject.CompareTag("Item") || myObject.CompareTag("Wreckage"))
            {
                Item item = (Item)myObject;
                try { item.spriteTr.GetComponent<Renderer>().sharedMaterial = item.spr.CurrentSprite.material; }
                catch { /* ??? */ }
            }
        }

        public static void ObjectReal_RefreshShader(ObjectReal __instance)
        {
            Material? mat = __instance.spr?.CurrentSprite.material;
            if (mat is null) return;

            Shader shader = GameController.gameController.lightingType is "Full" or "Med"
                ? GameController.gameController.litShader : GameController.gameController.normalShader;
            __instance.objectSprite.meshRenderer.material = mat;
            __instance.objectSprite.meshRenderer.material.shader = shader;
            __instance.objectSprite.objectRenderer.sharedMaterial = mat;
            __instance.objectSprite.objectRenderer.sharedMaterial.shader = shader;
        }
        public static void ObjectSprite_SetObjectHighlight(ObjectSprite __instance)
        {
            RogueSprite? sprite = __instance.sprH.CurrentSprite.GetHook();
            if (sprite is not null) __instance.objectRendererH.sharedMaterial = sprite.LightUpMaterial;
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
                    RogueSprite? sprite = agentSpriteList[i].CurrentSprite.GetHook();
                    if (sprite is not null) __instance.agentHitbox.agentSpriteRendererList[i].sharedMaterial = sprite.Material;
                }
                return;
            }

            List<Renderer> agentSpriteRendererList = __instance.agentHitbox.agentSpriteRendererList;
            for (int j = 0; j < agentSpriteList.Count; j++)
            {
                agentSpriteRendererListH[j].enabled = false;
                RogueSprite? sprite = agentSpriteList[j].CurrentSprite.GetHook();
                if (sprite is not null) agentSpriteRendererList[j].sharedMaterial = sprite.Material;
            }

            if (__instance.agent.inventory.equippedWeapon == __instance.agent.melee.invItem)
            {
                RogueSprite? meleeSpr1 = __instance.agent.melee.arm1Sprite.CurrentSprite.GetHook();
                if (meleeSpr1 is not null) __instance.agent.melee.arm1SpriteRenderer.sharedMaterial = meleeSpr1.Material;

                RogueSprite? meleeSpr2 = __instance.agent.melee.arm2Sprite.CurrentSprite.GetHook();
                if (meleeSpr2 is not null) __instance.agent.melee.arm2SpriteRenderer.sharedMaterial = meleeSpr2.Material;

                RogueSprite? meleeSpr = __instance.agent.melee.spr.CurrentSprite.GetHook();
                if (meleeSpr is not null) __instance.agent.melee.meleeSpriteRenderer.sharedMaterial = meleeSpr.Material;
            }
            else if (__instance.agent.inventory.equippedWeapon == __instance.agent.gun.visibleGun)
            {
                RogueSprite? gunSpr1 = __instance.agent.gun.arm1Sprite.CurrentSprite.GetHook();
                if (gunSpr1 is not null) __instance.agent.gun.arm1SpriteRenderer.sharedMaterial = gunSpr1.Material;

                RogueSprite? gunSpr2 = __instance.agent.gun.arm2Sprite.CurrentSprite.GetHook();
                if (gunSpr2 is not null) __instance.agent.gun.arm2SpriteRenderer.sharedMaterial = gunSpr2.Material;

                RogueSprite? gunSpr = __instance.agent.gun.gunSprite.CurrentSprite.GetHook();
                if (gunSpr is not null) __instance.agent.gun.gunSpriteRenderer.sharedMaterial = gunSpr.Material;
            }
        }
        public static void ObjectSprite_SetAgentHighlight(ObjectSprite __instance, int i)
        {
            Renderer renderer = __instance.agentHitbox.agentSpriteRendererListH[i];
            RogueSprite? sprite = __instance.agentHitbox.agentSpriteListH[i].CurrentSprite.GetHook();
            if (sprite is not null) renderer.sharedMaterial = sprite.LightUpMaterial;
        }

        public static void InvDatabase_ThrowWeapon(InvDatabase __instance)
        {
            RogueSprite? sprite = __instance.agent?.agentHitboxScript?.heldItem2?.CurrentSprite?.GetHook();
            if (sprite is not null) __instance.agent.agentHitboxScript.heldItem2Renderer.sharedMaterial = sprite.Material;
        }
        public static bool InvDatabase_DropItemAmount(InvDatabase __instance, InvItem item, int amount, bool actionsAfterDrop,
                                                      Vector2 teleportingItemLocation, out Item __result)
        {
            GameController gc = GameController.gameController;
            Item? dropped = null;
            if (gc.serverPlayer)
            {
                Vector2 vector = __instance.tr.position;
                if (teleportingItemLocation != Vector2.zero) vector = teleportingItemLocation;
                Vector3 itemPos = new Vector3(vector.x + UnityEngine.Random.Range(0f, 0.08f),
                                              vector.y + UnityEngine.Random.Range(0f, 0.08f), __instance.tr.position.z);

                InvItem invItem = new InvItem
                {
                    invItemName = item.invItemName,
                    invItemCount = amount,
                    contents = item.contents,
                    itemType = item.itemType,
                    isWeapon = item.isWeapon,
                    autoSortToolbarSlot = -1,
                };
                invItem.SetupDetails(true);

                dropped = gc.spawnerMain.SpawnItem(itemPos, invItem, actionsAfterDrop, __instance.GetComponent<Agent>());
                if (!actionsAfterDrop) dropped.SetCantPickUp(false);
            }
            else __instance.agent.objectMult.DropItem(item, amount, actionsAfterDrop, teleportingItemLocation);

            __instance.SubtractFromItemCount(item, amount);
            if (gc.serverPlayer && dropped?.owner is not null && dropped.owner.isPlayer > 0 && dropped.owner.localPlayer)
                dropped.owner.mainGUI.invInterface.justPressedAttackOnInterface = true;
            if (gc.serverPlayer && teleportingItemLocation == Vector2.zero)
                gc.audioHandler.Play(__instance.agent, "DropItem");
            __result = dropped!;
            return false;
        }
        public static void Item_DestroyMe2(Item __instance)
        {
            RogueSprite? sprite = __instance.itemImage?.CurrentSprite?.GetHook();
            if (sprite is not null) __instance.itemImageTransform.GetComponent<Renderer>().sharedMaterial = sprite.Material;
        }
        public static void Item_FakeStart(Item __instance)
        {
            RogueSprite? sprite = __instance.itemImageReal?.CurrentSprite?.GetHook();
            if (sprite is not null) __instance.itemImageReal.GetComponent<Renderer>().sharedMaterial = sprite.Material;
        }
        public static void Melee_MeleeLateUpdate(Melee __instance)
        {
            AgentHitbox hb = __instance.agent.agentHitboxScript;

            hb.heldItem2H.SetSprite(hb.heldItem2.spriteId);
            RogueSprite? sprite = hb.heldItem2.CurrentSprite.GetHook();
            if (sprite is not null)
            {
                hb.heldItem2Renderer.sharedMaterial = sprite.Material;
                hb.heldItem2H.GetComponent<Renderer>().sharedMaterial = sprite.Material;
            }

            hb.heldItemH.SetSprite(hb.heldItem.spriteId);
            RogueSprite? sprite2 = hb.heldItem.CurrentSprite.GetHook();
            if (sprite2 is not null)
            {
                hb.heldItemRenderer.sharedMaterial = sprite2.Material;
                hb.heldItemH.GetComponent<Renderer>().sharedMaterial = sprite2.Material;
            }
        }

        public static void ObjectReal_Start(ObjectReal __instance)
        {
            try
            {
                if (__instance.spr is not null)
                    __instance.ChangeSprite(__instance.spr.CurrentSprite.name);
                __instance.objectSprite?.RefreshRenderer();
                __instance.RefreshShader();
                __instance.StartCoroutine(__instance.SpawnShadow());
            }
            catch { /* ??? */ }
        }
        public static void ObjectReal_SpawnShadow(ObjectReal __instance, ref IEnumerator __result)
            => __result = SpawnShadowHelper(__instance, __result);
        private static IEnumerator SpawnShadowHelper(ObjectReal __instance, IEnumerator enumerator)
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;

            if (__instance.objectShadow is not null)
            {
                __instance.objectShadow.SetSprite(__instance.spr.CurrentSprite.name);
                Material mat = __instance.objectShadow.CurrentSprite.material;
                __instance.objectShadow.GetComponent<Renderer>().sharedMaterial = mat;
                foreach (Renderer renderer in __instance.objectShadow.GetComponents<Renderer>())
                    renderer.sharedMaterial = mat;
                foreach (Renderer renderer in __instance.objectShadow.GetComponentsInChildren<Renderer>(true))
                    renderer.sharedMaterial = mat;
            }
            if (__instance.objectShadowCustom is not null)
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
                .TryGetValue(VanillaItems.Nugget, out Sprite sprite) ? sprite : null;
    }
}
