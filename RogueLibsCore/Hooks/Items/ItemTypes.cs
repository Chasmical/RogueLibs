namespace RogueLibsCore
{
	/// <summary>
	///   <para>The collection of item types used in the game. Use it to avoid typos.</para>
	/// </summary>
	public static class ItemTypes
	{
		/// <summary>
		///   <para>Specifies that the item is a food or a drink and can be consumed.
		///   <br/>Examples: Fud, Beer, Ham Sandwich, Whiskey, Banana.</para>
		/// </summary>
		public const string Food = "Food";
		/// <summary>
		///   <para>Specifies that the item can be consumed, but is not considered a food item.
		///   <br/>Examples: First Aid Kit, Syringe, Cocktail, Cigarettes, Cologne.</para>
		/// </summary>
		public const string Consumable = "Consumable";
		/// <summary>
		///   <para>Specifies that the item can be worn.
		///   <br/>Examples: Bracelet of Strength, Bulletproof Vest, Soldier Helmet, Mood Ring, Mayor Badge.</para>
		/// </summary>
		public const string Wearable = "Wearable";
		/// <summary>
		///   <para>Specifies that the item is a melee weapon.
		///   <br/>Examples: Chloroform Hankie, Sledgehammer, Fist, Knife, Wrench.</para>
		/// </summary>
		public const string WeaponMelee = "WeaponMelee";
		/// <summary>
		///   <para>Specifies that the item is a projectile/ranged weapon.
		///   <br/>Examples: Freeze Ray, Laser Gun, Pistol, Oil Container, Fire Extinguisher.</para>
		/// </summary>
		public const string WeaponProjectile = "WeaponProjectile";
		/// <summary>
		///   <para>Specifies that the item is a thrown weapon.
		///   <br/>Examples: Land Mine, Grenade, Toss, Molotov Cocktail, Shuriken.</para>
		/// </summary>
		public const string WeaponThrown = "WeaponThrown";
		/// <summary>
		///   <para>Specifies that the item is something useful, that does not fall under any other type.
		///   <br/>Examples: Safe Cracking Tool, Necronomicon, Hypnotizer II, Kill Profiter, Cube of Lampey.</para>
		/// </summary>
		public const string Tool = "Tool";
		/// <summary>
		///   <para>Specifies that the item can be combined with other items.
		///   <br/>Examples: Food Processor, Armor Durability Doubler, Accuracy Mod, Identify Wand, Portable Sell-O-Matic.</para>
		/// </summary>
		public const string Combine = "Combine";
	}
}
