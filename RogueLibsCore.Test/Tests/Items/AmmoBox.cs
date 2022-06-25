using UnityEngine;

namespace RogueLibsCore.Test
{
    [ItemCategories(RogueCategories.Technology, RogueCategories.GunAccessory, RogueCategories.Guns)]
    public class AmmoBox : CustomItem, IItemCombinable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomItem<AmmoBox>()
                .WithName(new CustomNameInfo("Ammo Box"))
                .WithDescription(new CustomNameInfo("Combine with any refillable weapon to refill it. Limited ammo."))
                .WithSprite(Properties.Resources.AmmoBox)
                .WithUnlock(new ItemUnlock
                {
                    UnlockCost = 10,
                    LoadoutCost = 5,
                    CharacterCreationCost = 3,
                    Prerequisites = { VanillaItems.KillAmmunizer },
                });
        }

        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Combine;
            Item.itemValue = 4;
            Item.initCount = 100;
            Item.rewardCount = 200;
            Item.hasCharges = true;
            Item.stackable = true;
        }
        public bool CombineFilter(InvItem other) => other.itemType == ItemTypes.WeaponProjectile && !other.noRefills;
        public bool CombineItems(InvItem other)
        {
            if (!CombineFilter(other))
            {
                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);
                return false;
            }
            if (other.invItemCount >= other.maxAmmo)
            {
                Owner.SayDialogue("AmmoDispenserFull");
                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);
                return false;
            }

            int amountToRefill = other.maxAmmo - other.invItemCount;
            float singleCost = (float)other.itemValue / other.maxAmmo;
            if (Owner.oma.superSpecialAbility && Owner.agentName is VanillaAgents.Soldier or VanillaAgents.Doctor)
                singleCost = 0f;

            int affordableAmount = (int)Mathf.Ceil(Count / singleCost);
            int willBeBought = Mathf.Min(affordableAmount, amountToRefill);
            int willBeReduced = (int)Mathf.Min(Count, willBeBought * singleCost);

            Count -= willBeReduced;
            other.invItemCount += willBeBought;
            Owner.SayDialogue("AmmoDispenserFilled");
            gc.audioHandler.Play(Owner, VanillaAudio.BuyItem);
            return true;
        }

        public CustomTooltip CombineTooltip(InvItem other)
        {
            if (!CombineFilter(other)) return default;

            int amountToRefill = other.maxAmmo - other.invItemCount;
            if (amountToRefill == 0) return default;

            float singleCost = (float)other.itemValue / other.maxAmmo;
            if (Owner.oma.superSpecialAbility && Owner.agentName is VanillaAgents.Soldier or VanillaAgents.Doctor)
                singleCost = 0f;
            int cost = (int)Mathf.Floor(amountToRefill * singleCost);
            int canAfford = (int)Mathf.Ceil(Count / singleCost);

            return "+" + Mathf.Min(amountToRefill, canAfford) + " (" + Mathf.Min(cost, Count) + ")";
        }

        public CustomTooltip CombineCursorText(InvItem other) => gc.nameDB.GetName("RefillGun", NameTypes.Interface);
        // it's one of the vanilla dialogues, so there's no need to define it in the mod
    }
}
