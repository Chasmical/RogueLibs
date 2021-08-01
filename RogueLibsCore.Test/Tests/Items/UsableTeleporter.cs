using UnityEngine;

namespace RogueLibsCore.Test
{
    [ItemCategories(RogueCategories.Usable, RogueCategories.Technology, RogueCategories.Stealth)]
    public class UsableTeleporter : CustomItem, IItemTargetableAnywhere
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomItem<UsableTeleporter>()
                .WithName(new CustomNameInfo("Usable Teleporter"))
                .WithDescription(new CustomNameInfo("Teleports you somewhere. Has limited uses."))
                .WithSprite(Properties.Resources.UsableTeleporter)
                .WithUnlock(new ItemUnlock
                {
                    UnlockCost = 10,
                    LoadoutCost = 9,
                    CharacterCreationCost = 5,
                    Prerequisites = { "QuickEscapeTeleporter", nameof(WildBypasser) },
                });

            RogueLibs.CreateCustomName("TeleportHere", "Interface", new CustomNameInfo("Teleport here"));
        }

        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Tool;
            Item.itemValue = 80;
            Item.initCount = 2;
            Item.rewardCount = 3;
            Item.stackable = true;
            Item.goesInToolbar = true;
        }
        public bool TargetFilter(Vector2 position)
        {
            TileData tileData = gc.tileInfo.GetTileData(position);
            return !gc.tileInfo.IsOverlapping(position, "Anything") && tileData.wallMaterial == wallMaterialType.None;
        }
        public bool TargetPosition(Vector2 position)
        {
            if (!TargetFilter(position)) return false;

            Owner.SpawnParticleEffect("Spawn", Owner.tr.position);
            Owner.Teleport(position, false, true);
            Owner.rb.velocity = Vector2.zero;
            Owner.SpawnParticleEffect("Spawn", Owner.tr.position, false);
            gc.audioHandler.Play(Owner, "Spawn");

            Count--;
            return true;
        }
        public CustomTooltip TargetCursorText(Vector2 position) => gc.nameDB.GetName("TeleportHere", "Interface");
    }
}
