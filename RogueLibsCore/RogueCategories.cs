using System;
using System.Linq;
using System.Collections.Generic;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Collection of categories, used in the original game. Use it to avoid typos in the category names/ids.</para>
	/// </summary>
	public static class RogueCategories
	{
		/// <summary>
		///   <para>Category for everything, that is related to food.
		///   <br/>Examples: Fud, Ham Sandwich, Bacon Cheeseburger, Banana, Mini Fridge.</para>
		/// </summary>
		public const string Food = "Food";
		/// <summary>
		///   <para>Category for everything, that is in some way related to drugs, or ingestable/inhalable non-drugs.
		///   <br/>Examples: Syringe, Cocktail, Electro Pill, Rage Poison, Resurrection Shampoo, Antidote, Cologne.</para>
		/// </summary>
		public const string Drugs = "Drugs";
		/// <summary>
		///   <para>Category for everything, that is in some way related to alcohol.
		///   <br/>Examples: Beer, Whiskey.</para>
		/// </summary>
		public const string Alcohol = "Alcohol";
		/// <summary>
		///   <para>Category for everything, that is in some way related to health.
		///   <br/>Examples: First Aid Kit, Blood Bag.</para>
		/// </summary>
		public const string Health = "Health";
		/// <summary>
		///   <para>Category for everything, that is in some way related to sex. Yeah, Matt added that for some reason.
		///   <br/>Examples: Codpiece, Condom.</para>
		/// </summary>
		public const string Sex = "Sex";

		/// <summary>
		///   <para>Category for everything, that is in some way related to technology, electronics or the techical/scientific progress altogether. Also, for some reason, includes the Shapeshifter's Possession stone.
		///   <br/>Examples: Ammo Processor, Melee Durability Spray, Blindenizer, Drink Mixer, Monkey Barrel.</para>
		/// </summary>
		public const string Technology = "Technology";
		/// <summary>
		///   <para>Category for everything, that is in some way related to tools, that aren't usable <b>directly</b>.
		///   <br/>Examples: Lockpick, Window Cutter, Free Item Voucher, Door Detonator, Slave Helmet Remover.</para>
		/// </summary>
		public const string NonUsableTool = "NonUsableTool";
		/// <summary>
		///   <para>Category for everything, that works passively.
		///   <br/>Examples: Money, Nugget, Quick Escape Teleporter, Translator, Cube of Lampey.</para>
		/// </summary>
		public const string Passive = "Passive";
		/// <summary>
		///   <para>Category for everything, that is usable <b>directly</b>. Also includes Slave Helmet Remover for some reason.
		///   <br/>Examples: Necronomicon, Fireworks, Walkie-Talkie, Cigarette Lighter, Cardboard Box.</para>
		/// </summary>
		public const string Usable = "Usable";

		/// <summary>
		///   <para>Category for everything, that is in some way related to weapons, weapon mods or armor.
		///   <br/>Examples: Bear Trap, Crowbar, Rate of Fire Mod, Shotgun, Bracelet of Strength, Sticky Glove.</para>
		/// </summary>
		public const string Weapons = "Weapons";
		/// <summary>
		///   <para>Category for everything, that is considered to be an "unusual" weapon, but capable of doing harm.
		///   <br/>Examples: Rocket Launcher, Freeze Ray, Flamethrower, Shrink Ray, Ghost Gibber.</para>
		/// </summary>
		public const string NonStandardWeapons = "NonStandardWeapons";
		/// <summary>
		///   <para>Category for everything, that is considered to be an "unusual" weapon, but pretty harmless.
		///   <br/>Examples: Water Cannon, Research Gun, Water Pistol, Fire Extinguisher, Tranquilizer Gun.</para>
		/// </summary>
		public const string NonStandardWeapons2 = "NonStandardWeapons2";
		/// <summary>
		///   <para>Category for everything, that can be considered a non-violent weapon. For some reason, includes Wrestler's Toss ability.
		///   <br/>Examples: Water Cannon, Banana Peel, EMP Grenade, Research Gun, Paralyzer Trap.</para>
		/// </summary>
		public const string NonViolent = "NonViolent";
		/// <summary>
		///   <para>Category for everything, that is not usually used to inflict harm (well, at least directly).
		///   <br/>Examples: Oil Container, Research Gun.</para>
		/// </summary>
		public const string NotRealWeapons = "NotRealWeapons";

		/// <summary>
		///   <para>Category for everything, that affects or is affected by melee weapons in some way.
		///   <br/>Examples: Melee Durability Spray.</para>
		/// </summary>
		public const string MeleeAccessory = "MeleeAccessory";
		/// <summary>
		///   <para>Category for everything, that affects or is affected by guns in some way.
		///   <br/>Examples: Ammo Processor, Bulletproof Vest, Ammo Capacity Mod, Bomb Maker, Kill Ammunizer.</para>
		/// </summary>
		public const string GunAccessory = "GunAccessory";

		/// <summary>
		///   <para>Category for... uh... everything, that can be found at the construction site?.. But then what about Augmentation Canister? And Slave Helmet? I have absolutely no idea.
		///   <br/>Examples: Safe Cracking Tool, First Aid Kit, Soldier Helmet, Augmentation Canister, Gas Mask, Hard Hat, Saw, Crowbar, Mini Fridge, Jackhammer, Lockpick, Blowtorch, Power Drill, Blood Bag, Cardboard Box, Cigarette Lighter, Chainsaw, Safe Buster, Matches, Rag, Shovel, Rope, Grappling Hook, Window Cutter, Wrench, Slave Helmet.</para>
		/// </summary>
		public const string Supplies = "Supplies";
		/// <summary>
		///   <para>Category for everything, that NPCs shouldn't be able to pick up and use against the player.
		///   <br/>Examples: Freeze Ray, Laser Gun, Leaf Blower, Water Pistol, Tranquilizer Gun.</para>
		/// </summary>
		public const string NPCsCantPickUp = "NPCsCantPickUp";
		/// <summary>
		///   <para>Category for different types of nuggets.
		///   <br/>Examples: Chicken Nugget, Gold Nugget, Nougat, Nugget Hop, NuGet.</para>
		/// </summary>
		public const string Nugget = "Nugget";
		/// <summary>
		///   <para>Category for different types of currency.
		///   <br/>Examples: Chicken Nugget, Bottle Cap, United States Dollar, Bell, Simoleon.</para>
		/// </summary>
		public const string Money = "Money";

		/// <summary>
		///   <para>Category for everything, that is in some way related to melee weapons.
		///   <br/>Examples: Melee Durability Doubler, Bracelet of Strength, Kill Profiter, Electro Pill, Critter Upper.</para>
		/// </summary>
		public const string Melee = "Melee";
		/// <summary>
		///   <para>Category for everything, that is in some way related to guns, ammo and sometimes explosives.
		///   <br/>Examples: Ammo Processor, Kill Profiter, Ammo Capacity Mod, Ammo Stealer, Bomb Maker.</para>
		/// </summary>
		public const string Guns = "Guns";
		/// <summary>
		///   <para>Category for everything, that is in some way related to social interaction.
		///   <br/>Examples: Necronomicon, Haterator, Drink Mixer, Cocktail, Slave Helmet Remover, Body Swapper.</para>
		/// </summary>
		public const string Social = "Social";
		/// <summary>
		///   <para>Category for everything, that is in some way related to stealth.
		///   <br/>Examples: Safe Buster, Haterator, EMP Grenade, Boombox, Silencer.</para>
		/// </summary>
		public const string Stealth = "Stealth";
		/// <summary>
		///   <para>Category for everything, that is in some way related to movement.
		///   <br/>Examples: Quick Escape Teleporter, Sugar, Antidote.</para>
		/// </summary>
		public const string Movement = "Movement";
		/// <summary>
		///   <para>Category for everything, that is in some way related to defense.
		///   <br/>Examples: Armor Durability Doubler, Quick Escape Teleporter, Mini Fridge, Kill Healthenizer, Resurrection Shampoo.</para>
		/// </summary>
		public const string Defense = "Defense";
		/// <summary>
		///   <para>Category for everything, that is in some way related to trading.
		///   <br/>Examples: Free Item Voucher, Cube of Lampey, Portable Sell-O-Matic, Hiring Voucher.</para>
		/// </summary>
		public const string Trade = "Trade";
		/// <summary>
		///   <para>Category for everything, that is in some way related to magic, religion and occult.
		///   <br/>Examples: Necronomicon, Mood Ring, Magic Lamp, Boo-Urn, Voodoo Doll.</para>
		/// </summary>
		public const string Weird = "Weird";
	}
	/// <summary>
	///   <para>Collection of item types, used in the original game. Use it to avoid typos in the type names/ids.</para>
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
