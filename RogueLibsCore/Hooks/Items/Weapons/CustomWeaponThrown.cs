namespace RogueLibsCore
{
    public abstract class CustomWeaponThrown : CustomItem, ICustomItemSetupHelper
    {
        void ICustomItemSetupHelper.BeforeSetup()
        {
            Item.itemType = ItemTypes.WeaponThrown;
            Item.weaponCode = weaponType.WeaponThrown;
            Item.isWeapon = true;
            Item.throwDamage = RogueFramework.SpecialInt;
            Item.throwDistance = RogueFramework.SpecialInt;
        }
        void ICustomItemSetupHelper.AfterSetup()
        {
            if (Item.throwDamage is RogueFramework.SpecialInt)
            {
                Item.throwDamage = 0;
                RogueFramework.LogWarning($"Custom item {GetType()} doesn't set the Item.throwDamage field!");
            }
            if (Item.throwDistance is RogueFramework.SpecialInt)
            {
                Item.throwDistance = 0;
                RogueFramework.LogWarning($"Custom item {GetType()} doesn't set the Item.throwDistance field!");
            }
        }
    }
}
