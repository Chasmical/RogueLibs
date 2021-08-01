namespace RogueLibsCore.Test
{
	[ItemCategories(RogueCategories.Usable, RogueCategories.Social)]
	public class JokeBook : CustomItem, IItemUsable
	{
		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomItem<JokeBook>()
				.WithName(new CustomNameInfo("Joke Book"))
				.WithDescription(new CustomNameInfo("Always wanted to be a Comedian? Now you can! (kind of)"))
				.WithSprite(Properties.Resources.JokeBook)
				.WithUnlock(new ItemUnlock
				{
					UnlockCost = 10,
					LoadoutCost = 5,
					CharacterCreationCost = 3,
					Prerequisites = { VanillaAgents.Comedian + "_BQ" },
				});
		}

		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.itemValue = 15;
			Item.initCount = 10;
			Item.rewardCount = 10;
			Item.stackable = true;
			Item.hasCharges = true;
			Item.goesInToolbar = true;
		}
		public bool UseItem()
		{
			if (Owner.statusEffects.makingJoke) return false;

			string prev = Owner.specialAbility;
			Owner.specialAbility = VanillaAbilities.Joke;
			Owner.statusEffects.PressedSpecialAbility();
			Owner.specialAbility = prev;

			Count--;
			return true;
		}
	}
}
