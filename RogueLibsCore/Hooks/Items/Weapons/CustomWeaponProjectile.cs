namespace RogueLibsCore
{
    public abstract class CustomWeaponProjectile : CustomItem, ICustomItemSetupHelper
    {
        void ICustomItemSetupHelper.BeforeSetup()
        {
            Item.itemType = ItemTypes.WeaponProjectile;
            Item.weaponCode = weaponType.WeaponProjectile;
            Item.isWeapon = true;
            Item.gunKnockback = -1;
        }
        void ICustomItemSetupHelper.AfterSetup()
        {
            if (Item.gunKnockback is -1)
            {
                Item.gunKnockback = 0;
                RogueFramework.LogWarning($"Custom item {GetType()} doesn't set the Item.gunKnockback field!");
            }
        }

    }
}
