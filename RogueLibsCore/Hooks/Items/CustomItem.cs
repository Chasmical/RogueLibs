using System;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a custom item.</para>
    /// </summary>
    public abstract class CustomItem : HookBase<InvItem>
    {
        /// <summary>
        ///   <para>Gets the current <see cref="InvItem"/> instance.</para>
        /// </summary>
        public InvItem Item => Instance;
        /// <summary>
        ///   <para>Gets the item's owner.</para>
        /// </summary>
        public Agent? Owner => Item.agent;
        /// <summary>
        ///   <para>Gets the item's inventory.</para>
        /// </summary>
        public InvDatabase? Inventory => Item.database;

        /// <summary>
        ///   <para>Gets or sets the item's current count.</para>
        /// </summary>
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

        /// <summary>
        ///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
        // ReSharper disable once InconsistentNaming
        public static GameController gc => GameController.gameController;

        /// <summary>
        ///   <para>Gets the custom item's metadata.</para>
        /// </summary>
        public CustomItemMetadata Metadata { get; internal set; } = null!; // initialized immediately in CustomItemFactory

        /// <inheritdoc/>
        protected sealed override void Initialize()
        {
            Item.stackable = true;
            Item.Categories.AddRange(Metadata.Categories);
            if (this is IItemCombinable)
                Item.itemType = ItemTypes.Combine;

            Item.hierarchy2 = float.NaN;
            Item.maxAmmo = RogueFramework.SpecialInt;
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
                RogueFramework.LogError(e, "SetupDetails", this, Owner);
            }

            if (Item.itemType is null)
            {
                RogueFramework.LogWarning($"Custom item {GetType()} doesn't set the Item.itemType field!");
                Item.itemType = ItemTypes.Tool;
            }
            if (Item.itemIcon is null) Item.LoadItemSprite(Metadata.Name);

            if (float.IsNaN(Item.hierarchy2))
                Item.hierarchy2 = Item.hierarchy;
            if (Item.maxAmmo is RogueFramework.SpecialInt)
                Item.maxAmmo = Item.initCount;
            if (Item.rewardCount is RogueFramework.SpecialInt)
                Item.rewardCount = Item.initCount;
            if (Item.lowCountThreshold is RogueFramework.SpecialInt)
            {
                //if (this is CustomWeaponProjectile)
                //    Item.lowCountThreshold = Math.Max(Item.maxAmmo / 4, 3);
                //else if (this is CustomWeaponMelee)
                //    Item.lowCountThreshold = 25;
                //else if (this is CustomWeaponThrown)
                //    Item.lowCountThreshold = 5;
                if (Item.isArmor || Item.isArmorHead)
                    Item.lowCountThreshold = 25;
                else
                    Item.lowCountThreshold = 0;
            }

            helper?.AfterSetup();
        }

        /// <summary>
        ///   <para>The method that is called when the item's details are set up.</para>
        /// </summary>
        public abstract void SetupDetails();

        /// <summary>
        ///   <para>Returns the custom item's count text.</para>
        /// </summary>
        /// <returns>The custom count string, if overriden; otherwise, <see langword="null"/>.</returns>
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

        /// <summary>
        ///   <para>Returns the custom item's sprite name. Can be dynamically changed, for example, based on the item's count.</para>
        /// </summary>
        /// <returns>The name of the sprite for the custom item to use.</returns>
        public virtual string GetSprite() => Metadata.Name;

    }
}
