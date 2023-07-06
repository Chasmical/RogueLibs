using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
    public abstract class CustomItem : HookBase<InvItem>
    {
        public InvItem Item => Instance;
        public Agent? Owner => Item.agent;
        public InvDatabase? Inventory => Item.database;

        public int Count
        {
            get => Item.invItemCount;
            set
            {
                int delta = value - Item.invItemCount;
                if (delta < 0 && Inventory is not null)
                    Inventory.SubtractFromItemCount(Item, -delta);
                else
                    Item.invItemCount += delta;
            }
        }

        protected sealed override void Initialize()
        {
            Item.stackable = true;
            Item.Categories.AddRange(Metadata.Categories);
            if (this is IItemCombinable)
                Item.itemType = ItemTypes.Combine;
            Item.rewardCount = RogueFramework.SpecialInt;
            Item.lowCountThreshold = RogueFramework.SpecialInt;

            ICustomItemSetupHelper? helper = this as ICustomItemSetupHelper;
            helper?.BeforeSetup();

            try
            {
                SetupDetails();
            }
            catch (Exception e)
            {
                RogueFramework.LogError(GetType(), "SetupDetails() raised an exception!", e);
            }

            if (Item.itemType is null)
            {
                RogueFramework.LogWarning(GetType(), "SetupDetails() didn't initialize Item.itemType!");
                Item.itemType = "Tool";
            }
            if (Item.itemIcon is null) Item.LoadItemSprite(Metadata.Name);
            if (Item.rewardCount is RogueFramework.SpecialInt)
                Item.rewardCount = Item.initCount;
            if (Item.lowCountThreshold is RogueFramework.SpecialInt)
            {
                //else if (this is CustomWeaponProjectile)
                //    Item.lowCountThreshold = Math.Max(Item.maxAmmo / 4, 3);
                //else if (this is CustomWeaponMelee)
                //    Item.lowCountThreshold = 25;
                //else if (this is CustomWeaponThrown)
                //    Item.lowCountThreshold = 5;
                if (Item.isArmor || Item.isArmorHead)
                    Item.lowCountThreshold = 25;
            }

            helper?.AfterSetup();
        }

        public abstract void SetupDetails();

        public virtual CustomTooltip GetCountString()
        {
            if (Item.noCountText) return default;

            if (Item.rechargeAmount > 0)
            {
                if (Count == Item.rechargeAmount)
                    return new CustomTooltip(Item.rechargeAmount - 1, Color.red);
                if (Item.invItemCount != 1)
                    return new CustomTooltip(Count - 1, Color.red);
                return default;
            }

            if (Item.stackable || Item.stackableContents || Item.isArmor || Item.isArmorHead
             || Item.itemType is ItemTypes.WeaponProjectile or ItemTypes.WeaponMelee)
                return new CustomTooltip(Count, Color.white);

            return default;
        }

        public virtual string GetSprite() => Metadata.Name;

    }
}
