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
        ///   <para>Gets the item's inventory.</para>
        /// </summary>
        public InvDatabase? Inventory => Item.database;
        /// <summary>
        ///   <para>Gets the item's owner.</para>
        /// </summary>
        public Agent? Owner => Item.agent;
        /// <summary>
        ///   <para>Gets or sets the item's current count.</para>
        /// </summary>
        public int Count
        {
            get => Item.invItemCount;
            set
            {
                int delta = value - Count;
                if (delta < 0 && Inventory != null)
                    Inventory.SubtractFromItemCount(Item, -delta);
                else Item.invItemCount += delta;
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
        public ItemInfo ItemInfo { get; internal set; } = null!; // initialized immediately in CustomItemFactory

        /// <inheritdoc/>
        protected sealed override void Initialize()
        {
            Item.Categories.AddRange(ItemInfo.Categories);
            SetupDetails();
            if (Item.itemIcon is null) Item.LoadItemSprite(ItemInfo.Name);
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
        public virtual string GetSprite() => ItemInfo.Name;

    }
}
