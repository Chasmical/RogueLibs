namespace RogueLibsCore
{
    public abstract class CustomWeaponMelee : CustomItem, ICustomItemSetupHelper
    {
        void ICustomItemSetupHelper.BeforeSetup()
        {
            Item.itemType = ItemTypes.WeaponMelee;
            Item.weaponCode = weaponType.WeaponMelee;
            Item.isWeapon = true;
            Item.meleeDamage = RogueFramework.SpecialInt;
            Item.initCount = 100;
        }
        void ICustomItemSetupHelper.AfterSetup()
        {
            if (Item.meleeDamage is RogueFramework.SpecialInt)
            {
                Item.meleeDamage = 0;
                RogueFramework.LogWarning($"Custom item {GetType()} doesn't set the Item.meleeDamage field!");
            }
        }

        public Melee? Melee => Owner?.melee;

        public abstract MeleeAttackInfo? StartAttack();
        public abstract void EndAttack();

        public virtual void PreHit(MeleePreHitArgs e) { }
        public virtual void Hit(MeleeHitArgs e) { }

        // public virtual int Deplete(PlayfieldObject obj, float damage);
        // IItemEquippable
        // public virtual void OnEquipped();
        // public virtual void OnUnequipped();

    }
}
