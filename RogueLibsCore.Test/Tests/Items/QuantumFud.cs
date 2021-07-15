using UnityEngine;

namespace RogueLibsCore.Test
{
	[ItemCategories(RogueCategories.Food, RogueCategories.Technology)]
	public class QuantumFud : CustomItem, IItemUsable, IDoUpdate
	{
		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomItem<QuantumFud>()
				.WithName(new CustomNameInfo("Quantum Fud"))
				.WithDescription(new CustomNameInfo("A very complicated piece of quantum technology. When you eat it, its quantum equivalent clone is consumed, while the original thing remains intact."))
				.WithSprite(Properties.Resources.QuantumFud)
				.WithUnlock(new ItemUnlock
				{
					UnlockCost = 10,
					CharacterCreationCost = 10,
					LoadoutCost = 10,
				   Prerequisites = { "FoodProcessor" },
				});
		}

		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Food;
			Item.itemValue = 180;
			Item.healthChange = 1;
			Item.cantBeCloned = true;
			Item.goesInToolbar = true;
		}

		public float Cooldown { get; set; }
		public void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime, 0f);

		public bool UseItem()
		{
			if (Cooldown != 0f) return false;

			int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);
			Owner.statusEffects.ChangeHealth(heal);

			if (Owner.HasTrait("HealthItemsGiveFollowersExtraHealth")
				|| Owner.HasTrait("HealthItemsGiveFollowersExtraHealth2"))
				new ItemFunctions().GiveFollowersHealth(Owner, heal);

			gc.audioHandler.Play(Owner, "UseFood");
			Cooldown = 0.5f;
			return true;
		}
	}
}
