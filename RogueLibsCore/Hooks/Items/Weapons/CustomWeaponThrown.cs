namespace RogueLibsCore
{
    public abstract class CustomWeaponThrown : CustomItem, ICustomItemSetupHelper
    {
        void ICustomItemSetupHelper.BeforeSetup()
        {
            Item.itemType = ItemTypes.WeaponThrown;
            Item.weaponCode = weaponType.WeaponThrown;
            Item.isWeapon = true;
            Item.throwDamage = -1;
            Item.throwDistance = -1;
        }
        void ICustomItemSetupHelper.AfterSetup()
        {
            if (Item.throwDamage is -1)
            {
                Item.throwDamage = 0;
                RogueFramework.LogWarning($"Custom item {GetType()} doesn't set the Item.throwDamage field!");
            }
            if (Item.throwDistance is -1)
            {
                Item.throwDistance = 0;
                RogueFramework.LogWarning($"Custom item {GetType()} doesn't set the Item.throwDistance field!");
            }
        }
    }
}
