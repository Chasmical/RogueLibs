﻿using UnityEngine;

namespace RogueLibsCore.Test
{
    [ItemCategories(RogueCategories.Technology, RogueCategories.Usable, RogueCategories.Stealth)]
    public class WildBypasser : CustomItem, IItemUsable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomItem<WildBypasser>()
                .WithName(new CustomNameInfo("Wild Bypasser"))
                .WithDescription(new CustomNameInfo("Warps you in the direction you're facing. Teleports through any amount of walls."))
                .WithSprite(Properties.Resources.WildBypasser)
                .WithUnlock(new ItemUnlock
                {
                    UnlockCost = 10,
                    LoadoutCost = 7,
                    CharacterCreationCost = 3,
                    Prerequisites = { VanillaItems.WallBypasser },
                });
        }

        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Tool;
            Item.itemValue = 60;
            Item.initCount = 2;
            Item.rewardCount = 3;
            Item.stackable = true;
            Item.goesInToolbar = true;
        }
        public bool UseItem()
        {
            Vector3 position = Owner!.agentHelperTr.localPosition = Vector3.zero;
            TileData tileData;
            int limit = 0;
            do
            {
                position.x += 0.64f;
                Owner.agentHelperTr.localPosition = position;
                tileData = gc.tileInfo.GetTileData(Owner.agentHelperTr.position);

            } while ((gc.tileInfo.IsOverlapping(Owner.agentHelperTr.position, "Anything")
                || tileData.wallMaterial != wallMaterialType.None) && limit++ < 250);

            if (limit > 250)
            {
                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);
                return false;
            }

            Owner.SpawnParticleEffect("Spawn", Owner.tr.position);
            Owner.Teleport(Owner.agentHelperTr.position, false, true);
            Owner.rb.velocity = Vector2.zero;

            if (!(Owner.HasTrait(VanillaTraits.IntrusionArtist)
                    && gc.percentChance(Owner.DetermineLuck(80, "ThiefToolsMayNotSubtract", true)))
                && !(Owner.HasTrait(VanillaTraits.IntrusionArtist2)
                    && gc.percentChance(Owner.DetermineLuck(40, "ThiefToolsMayNotSubtract", true))))
                Count--;

            Owner.SpawnParticleEffect("Spawn", Owner.tr.position, false);
            gc.audioHandler.Play(Owner, VanillaAudio.Spawn);
            return true;
        }
    }
}
