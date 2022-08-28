namespace RogueLibsCore
{
    public abstract class CustomWeaponProjectile : CustomItem, ICustomItemSetupHelper
    {
        void ICustomItemSetupHelper.BeforeSetup()
        {
            Item.itemType = ItemTypes.WeaponProjectile;
            Item.weaponCode = weaponType.WeaponProjectile;
            Item.isWeapon = true;
            Item.gunKnockback = RogueFramework.SpecialInt;
            Item.maxAmmo = RogueFramework.SpecialInt;
        }
        void ICustomItemSetupHelper.AfterSetup()
        {
            if (Item.gunKnockback is RogueFramework.SpecialInt)
            {
                Item.gunKnockback = 0;
                RogueFramework.LogWarning($"Custom item {GetType()} doesn't set the Item.gunKnockback field!");
            }
            if (Item.maxAmmo is RogueFramework.SpecialInt)
                Item.maxAmmo = Item.initCount;
        }

    }
}
