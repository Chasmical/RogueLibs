// ReSharper disable CommentTypo
namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The collection of item and trait categories used in the game. Use it to avoid typos.</para>
    /// </summary>
    public static class RogueCategories
    {
        /// <summary>
        ///   <para>The category for items, that are related to food. The category for agents specifies that the agent can defense yourself.
        ///   <br/>Examples: Fud, Ham Sandwich, Bacon Cheeseburger, Banana, Mini Fridge.</para>
        /// </summary>
        public const string Food = "Food";
        /// <summary>
        ///   <para>The category for items, that are in some way related to drugs, or ingestable/inhalable non-drugs.
        ///   <br/>Examples: Syringe, Cocktail, Electro Pill, Rage Poison, Resurrection Shampoo, Antidote, Cologne.</para>
        /// </summary>
        public const string Drugs = "Drugs";
        /// <summary>
        ///   <para>The category for items, that are, or in some way related to, alcohol.
        ///   <br/>Examples: Beer, Whiskey.</para>
        /// </summary>
        public const string Alcohol = "Alcohol";
        /// <summary>
        ///   <para>The category for items, that are in some way related to health.
        ///   <br/>Examples: First Aid Kit, Blood Bag.</para>
        /// </summary>
        public const string Health = "Health";
        /// <summary>
        ///   <para>The category for items, that are in some way related to sex. Yeah, Matt added that for some reason.
        ///   <br/>Examples: Codpiece, Condom.</para>
        /// </summary>
        public const string Sex = "Sex";

        /// <summary>
        ///   <para>The category for items, that are in some way related to the technological/scientific progress.
        ///   <br/>Examples: Ammo Processor, Melee Durability Spray, Blindenizer, Drink Mixer, Monkey Barrel.
        ///   <br/>Also, for some reason, includes the Shapeshifter's Possession Stone.</para>
        /// </summary>
        public const string Technology = "Technology";
        /// <summary>
        ///   <para>The category for items, that are not usable <b>directly</b>, but usable in certain situations or on certain objects.
        ///   <br/>Examples: Lockpick, Window Cutter, Free Item Voucher, Door Detonator, Slave Helmet Remover.</para>
        /// </summary>
        public const string NonUsableTool = "NonUsableTool";
        /// <summary>
        ///   <para>The category for items, that work passively.
        ///   <br/>Examples: Money, Nugget, Quick Escape Teleporter, Translator, Cube of Lampey.</para>
        /// </summary>
        public const string Passive = "Passive";
        /// <summary>
        ///   <para>The category for items, that are usable <b>directly</b>.
        ///   <br/>Examples: Necronomicon, Fireworks, Walkie-Talkie, Cigarette Lighter, Cardboard Box.
        ///   <br/>Also includes Slave Helmet Remover for some reason.</para>
        /// </summary>
        public const string Usable = "Usable";
        /// <summary>
        ///   <para>The category for items, that are in some way related to magic, religion or occult.
        ///   <br/>Examples: Necronomicon, Mood Ring, Magic Lamp, Boo-Urn, Voodoo Doll.</para>
        /// </summary>
        public const string Weird = "Weird";

        /// <summary>
        ///   <para>The category for items, that are in some way related to weapons, weapon mods or armor.
        ///   <br/>Examples: Bear Trap, Crowbar, Rate of Fire Mod, Shotgun, Bracelet of Strength, Sticky Glove.</para>
        /// </summary>
        public const string Weapons = "Weapons";
        /// <summary>
        ///   <para>The category for items, that are considered to be "unusual" weapons, but capable of doing harm.
        ///   <br/>Examples: Rocket Launcher, Freeze Ray, Flamethrower, Shrink Ray, Ghost Gibber.</para>
        /// </summary>
        public const string NonStandardWeapons = "NonStandardWeapons";
        /// <summary>
        ///   <para>The category for items, that are considered to be "unusual" weapons, but usually harmless.
        ///   <br/>Examples: Water Cannon, Research Gun, Water Pistol, Fire Extinguisher, Tranquilizer Gun.</para>
        /// </summary>
        public const string NonStandardWeapons2 = "NonStandardWeapons2";
        /// <summary>
        ///   <para>The category for items, that can be considered non-violent weapons.
        ///   <br/>Examples: Water Cannon, Banana Peel, EMP Grenade, Research Gun, Paralyzer Trap.
        ///   <br/>For some reason, includes Wrestler's Toss ability.</para>
        /// </summary>
        public const string NonViolent = "NonViolent";
        /// <summary>
        ///   <para>The category for items, that are not usually used to inflict harm (well, at least directly).
        ///   <br/>Examples: Oil Container, Research Gun.</para>
        /// </summary>
        public const string NotRealWeapons = "NotRealWeapons";

        /// <summary>
        ///   <para>The category for items, that affect or are affected by melee weapons in some way.
        ///   <br/>Examples: Melee Durability Spray.</para>
        /// </summary>
        public const string MeleeAccessory = "MeleeAccessory";
        /// <summary>
        ///   <para>The category for items, that affect or are affected by guns in some way.
        ///   <br/>Examples: Ammo Processor, Bulletproof Vest, Ammo Capacity Mod, Bomb Maker, Kill Ammunizer.</para>
        /// </summary>
        public const string GunAccessory = "GunAccessory";

        /// <summary>
        ///   <para>The category for... uh... everything, that can be found at the construction site? or a warehouse?.. Idk.
        ///   <br/>Examples: Safe Cracking Tool, First Aid Kit, Soldier Helmet, Augmentation Canister, Gas Mask, Hard Hat, Saw, Crowbar, Mini Fridge, Jackhammer, Lockpick, Blowtorch, Power Drill, Blood Bag, Cardboard Box, Cigarette Lighter, Chainsaw, Safe Buster, Matches, Rag, Shovel, Rope, Grappling Hook, Window Cutter, Wrench, Slave Helmet.</para>
        /// </summary>
        public const string Supplies = "Supplies";
        /// <summary>
        ///   <para>The category for items, that NPCs shouldn't be able to pick up and use against the player.
        ///   <br/>Examples: Freeze Ray, Laser Gun, Leaf Blower, Water Pistol, Tranquilizer Gun.</para>
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string NPCsCantPickUp = "NPCsCantPickUp";
        /// <summary>
        ///   <para>The category for different types of nuggets.
        ///   <br/>Examples: Chicken Nugget, Gold Nugget, Nougat, Nugget Hop, NuGet.</para>
        /// </summary>
        public const string Nugget = "Nugget";
        /// <summary>
        ///   <para>The category for different types of currency.
        ///   <br/>Examples: Chicken Nugget, Bottle Cap, United States Dollar, Bell, Simoleon.</para>
        /// </summary>
        public const string Money = "Money";

        /// <summary>
        ///   <para>The category for everything, that is in some way related to melee weapons.
        ///   <br/>Examples (items): Melee Durability Doubler, Bracelet of Strength, Kill Profiter, Electro Pill, Critter Upper.
        ///   <br/>Examples (traits): Harmless, Tank-Like, Increased Crit Chance, No In-Fighting, Wall Walloper.
        ///   <br/>Examples (agents): Businessman, Doctor, Firefighter, GangbangerB, Gorilla, Mafia.</para>
        /// </summary>
        public const string Melee = "Melee";
        /// <summary>
        ///   <para>The category for everything, that is in some way related to guns, ammo and sometimes explosives.
        ///   <br/>Examples (items): Ammo Processor, Kill Profiter, Ammo Capacity Mod, Ammo Stealer, Bomb Maker.
        ///   <br/>Examples (traits): Big Bullets, Blaster Survivor, Ammo Scavenger, No In-Fighting, Burning Bullets.
        ///   <br/>Examples (agents): Werewolf, Bartender, Businessman, MechPilot, Shopkeeper.</para>
        /// </summary>
        public const string Guns = "Guns";
        /// <summary>
        ///   <para>The category for everything, that is in some way related to social interaction.
        ///   <br/>Examples (items): Necronomicon, Haterator, Drink Mixer, Cocktail, Slave Helmet Remover, Body Swapper.
        ///   <br/>Examples (traits): Class Solidarity, Clumsiness Forgiven, Low-Cost Jobs, Disturbing Facial Expressions, Share the Health.
        ///   <br/>Examples (agents): Mafia, RobotPlayer, Scientist, Shopkeeper, Slavemaster, Soldier.</para>
        /// </summary>
        public const string Social = "Social";
        /// <summary>
        ///   <para>The category for everything, that is in some way related to stealth.
        ///   <br/>Examples (items): Safe Buster, Haterator, EMP Grenade, Boombox, Silencer.
        ///   <br/>Examples (traits): Backstabber, Blends In Nicely, Secret Vandalizer, Intrusion Artist, Honor Among Thieves.
        ///   <br/>Examples (agents): Alien, Athlete, Cannibal, Courier, Hacker, Thief.</para>
        /// </summary>
        public const string Stealth = "Stealth";
        /// <summary>
        ///   <para>The category for everything, that is in some way related to movement.
        ///   <br/>Examples (items): Quick Escape Teleporter, Sugar, Antidote.
        ///   <br/>Examples (traits): Skinny Nerdlinger, Kneecapper, Roller Skates, Slippery Target, Bulky.
        ///   <br/>Examples (agents): Vampire, Worker, Wrestler, Zombie, Athlete, Bouncer.</para>
        /// </summary>
        public const string Movement = "Movement";
        /// <summary>
        ///   <para>The category for everything, that is in some way related to defense.
        ///   <br/>Examples (items): Armor Durability Doubler, Quick Escape Teleporter, Mini Fridge, Kill Healthenizer, Resurrection Shampoo.
        ///   <br/>Examples (traits): I'm Outtie, Un-Crits, Fireproof Skin, Medical Professional, Disturbing Facial Expressions.
        ///   <br/>Examples (agents): Alien, Athlete, Bouncer, Comedian, Cop.</para>
        /// </summary>
        public const string Defense = "Defense";
        /// <summary>
        ///   <para>The category for everything, that is in some way related to trading.
        ///   <br/>Examples (items): Free Item Voucher, Cube of Lampey, Portable Sell-O-Matic, Hiring Voucher.
        ///   <br/>Examples (traits): Drug-a-lug, Shrewd Negotiator, Moocher, Shop Drops, Banana Lover.
        ///   <br/>Examples (agents): Werewolf, Bartender, Businessman, MechPilot, Shopkeeper.</para>
        /// </summary>
        public const string Trade = "Trade";

        /// <summary>
        ///   <para>Info (traits):The category for traits, that are non-beneficial to the agent that has these traits.
        ///   <br/>Examples (traits): Corruption Costs, Bodyguard, No Teleports, Fair Game, Sausage Fingers.</para>
        /// </summary>
        public const string Negative = "Negative";
    }
}
