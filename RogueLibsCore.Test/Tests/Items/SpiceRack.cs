using UnityEngine;

namespace RogueLibsCore.Test
{
    [ItemCategories(RogueCategories.Food, RogueCategories.Health)]
    public class SpiceRack : CustomItem, IItemCombinable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomItem<SpiceRack>()
                .WithName(new CustomNameInfo("Spice Rack"))
                .WithDescription(new CustomNameInfo("Combine with any food item to increase its healing properties."))
                .WithSprite(Properties.Resources.SpiceRack)
                .WithUnlock(new ItemUnlock
                {
                    UnlockCost = 10,
                    LoadoutCost = 3,
                    CharacterCreationCost = 2,
                    Prerequisites = { VanillaItems.FoodProcessor },
                });

            SeasonCursorText = RogueLibs.CreateCustomName("SeasonItem", NameTypes.Interface, new CustomNameInfo("Season"));
        }
        private static CustomName SeasonCursorText = null!;

        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Combine;
            Item.itemValue = 4;
            Item.initCount = 10;
            Item.rewardCount = 15;
            Item.stackable = true;
            Item.hasCharges = true;
        }
        public bool CombineFilter(InvItem other)
        {
            if (other.itemType != ItemTypes.Food || other.healthChange is 0
                || !other.Categories.Contains(RogueCategories.Food)) return false;

            SpicedHook? hook = other.GetHook<SpicedHook>();
            return hook is null || hook.Spiciness < 3;
        }
        public bool CombineItems(InvItem other)
        {
            if (!CombineFilter(other)) return false;

            SpicedHook hook = other.GetHook<SpicedHook>() ?? other.AddHook<SpicedHook>();
            hook.IncreaseSpiciness();

            Count--;
            gc.audioHandler.Play(Owner, VanillaAudio.CombineItem);
            return true;
        }
        public CustomTooltip CombineCursorText(InvItem other) => SeasonCursorText;
        public CustomTooltip CombineTooltip(InvItem other)
        {
            if (!CombineFilter(other)) return default;

            SpicedHook? hook = other.GetHook<SpicedHook>();
            int bonus = hook is null ? (int)Mathf.Ceil(other.healthChange / 4f) : hook.HealthBonus;
            return new CustomTooltip($"+{bonus}", Color.green);
        }

        private class SpicedHook : HookBase<InvItem>
        {
            protected override void Initialize()
                => HealthBonus = (int)Mathf.Ceil(Instance.healthChange / 4f);

            public int HealthBonus { get; private set; }
            public int Spiciness { get; private set; }

            public void IncreaseSpiciness()
            {
                if (Spiciness is 3) return;

                Spiciness++;
                Instance.healthChange += HealthBonus;
            }
        }
    }
}
