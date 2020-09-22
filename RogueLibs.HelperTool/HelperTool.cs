using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogueLibsCore.HelperTool
{
	public partial class HelperToolForm : Form
	{
		public HelperToolForm() => InitializeComponent();
		private void HelperTool_Load(object sender, EventArgs e)
		{
			AddTooltips_ItemType();
			AddTooltips_ItemAmount();
			AddTooltips_Categories();
		}
		public void AddTooltips_ItemType()
		{
			ToolTip.SetToolTip(TypeFood, "An item that is considered edible by humans." +
				"\nExamples: Beer, Banana, Whiskey, Bacon Cheeseburger, Fud.");
			ToolTip.SetToolTip(TypeConsumable, "An item that is not a food, but can be consumed." +
				"\nExamples: First Aid Kit, Syringe, Cocktail, Resurrection Shampoo, Rage Poison.");
			ToolTip.SetToolTip(TypeWearable, "An item that can be worn." +
				"\nExamples: Bracelet of Strength, Sunglasses, Bulletproof Vest, Mayor Hat, Gas Mask.");
			ToolTip.SetToolTip(TypeWeaponMelee, "An item that can be used in melee combat." +
				"\nExamples: Sledgehammer, Baseball Bat, Fist, Chloroform Hankie, Plasma Sword.");
			ToolTip.SetToolTip(TypeWeaponProjectile, "An item that can be used in ranged combat." +
				"\nExamples: Freeze Ray, Water Cannon, Shotgun, Rocket Launcher, Oil Container.");
			ToolTip.SetToolTip(TypeWeaponThrown, "An item that can be thrown." +
				"\nExamples: Bear Trap, Banana Peel, Warp Grenade, Shuriken, Paralyzer Trap.");
			ToolTip.SetToolTip(TypeTool, "An item that can be used for something." +
				"\nExamples: Skeleton Key, Blindenizer, Monkey Barrel, Mini Fridge, Walkie-Talkie.");
			ToolTip.SetToolTip(TypeCombine, "An item that can be combined with others." +
				"\nExamples: Melee Durability Spray, Drink Mixer, Ammo Processor, Silencer, Portable Sell-o-matic.");
			ToolTip.SetToolTip(TypeNonItem, "An item that is not an item, lol." +
				"\nExamples: Wreckage, Giblet, Factory Object.");
		}
		public void AddTooltips_ItemAmount()
		{
			ToolTip.SetToolTip(Stackable, "Determines whether an item's amount will be displayed in the inventory.");
			ToolTip.SetToolTip(HasCharges, "Determines whether an item should not be stackable." +
				"\nExamples: Ammo Processor, Food Processor, Cube of Lampey, Remote Control, Bomb Maker.");
			ToolTip.SetToolTip(NoCountText, "Determines whether an item's count should not be shown in the inventory." +
				"\nExamples: Mood Ring, Mayor Hat, Fist, Toss Item, Research Gun.");

			ToolTip.SetToolTip(InitCountBox, "Determines the initial amount of an item.");
			ToolTip.SetToolTip(InitCountLabel, "Determines the initial amount of an item.");
			ToolTip.SetToolTip(RewardCountBox, "Determines the reward amount of an item, given for quests and in loadout.");
			ToolTip.SetToolTip(RewardCountLabel, "Determines the reward amount of an item, given for quests and in loadout.");
			ToolTip.SetToolTip(InitCountAIBox, "Determines the initial amount of an item for NPCs.");
			ToolTip.SetToolTip(InitCountAILabel, "Determines the initial amount of an item for NPCs.");
		}
		public void AddTooltips_Categories()
		{
			ToolTip.SetToolTip(CategoryFood, "Examples: Bacon Cheeseburger, Banana, Mini Fridge, Fud, Ham Sandwich.");
			ToolTip.SetToolTip(CategoryHealth, "Examples: First Aid Kit, Blood Bag.");
			ToolTip.SetToolTip(CategoryDrugs, "Examples: Syringe, Electro Pill, Cocktail, Resurrection Shampoo, Cologne.");
			ToolTip.SetToolTip(CategoryAlcohol, "Examples: Beer, Whiskey.");
			ToolTip.SetToolTip(CategorySex, "Examples: Cod Piece, Condom.");

			ToolTip.SetToolTip(CategoryWeapons, "Examples: Bracelet of Strength, Bulletproof Vest, Chloroform Hankie, Sledgehammer, Banana Peel.");
			ToolTip.SetToolTip(CategoryNonStandardWeapons, "Examples: BFG, Freeze Ray, Rocket Launcher, Shrink Ray, Ghost Gibber.");
			ToolTip.SetToolTip(CategoryNonStandardWeapons2, "Examples: Water Cannon, Leaf Blower, Research Gun, Water Pistol, Tranquilizer Gun.");
			ToolTip.SetToolTip(CategoryNonViolent, "Examples: Water Cannon, Banana Peel, EMP Grenade, Warp Grenade, Taser.");
			ToolTip.SetToolTip(CategoryNotRealWeapons, "Examples: Oil Container, Research Gun.");

			ToolTip.SetToolTip(CategoryMelee, "Examples: Melee Durability Spray, Bracelet of Strength, Kill Profiter, Electro Pill, Critter Upper.");
			ToolTip.SetToolTip(CategoryGuns, "Examples: Ammo Processor, Kill Profiter, Silencer, Bomb Maker, Ammo Stealer.");
			ToolTip.SetToolTip(CategorySocial, "Examples: Memory Mutilator, Necronomicon, Haterator, Cocktail, Friend Phone.");
			ToolTip.SetToolTip(CategoryStealth, "Examples: Blindenizer, Safe Cracking Tool, EMP Grenade, Silencer, Rage Poison.");
			ToolTip.SetToolTip(CategoryMovement, "Examples: Quick Escape Teleporter, Sugar, Antidote.");
			ToolTip.SetToolTip(CategoryDefense, "Examples: Armor Durability Spray, Quick Escape Teleporter, Mini Fridge, Kill Healthenizer, Resurrection Shampoo.");
			ToolTip.SetToolTip(CategoryTrade, "Examples: Free Item Voucher, Cube of Lampey, Portable Sell-o-matic, Hiring Voucher.");
			ToolTip.SetToolTip(CategoryWeird, "Examples: Necronomicon, Mood Ring, Boo-Urn, Voodoo Doll, Magic Lamp.");
			ToolTip.SetToolTip(CategoryTechnology, "Examples: Melee Durability Spray, Blindenizer, Drink Mixer, Monkey Barrel, Translator.");

			ToolTip.SetToolTip(CategoryNonUsableTool, "Examples: Skeleton Key, Safe Cracking Tool, Free Item Voucher, Safe Combination, Window Cutter.");
			ToolTip.SetToolTip(CategoryUsable, "Examples: Blindenizer, Necronomicon, Haterator, Fireworks, Cigarette Lighter.");
			ToolTip.SetToolTip(CategoryPassive, "Examples: Kill Profiter, Quick Escape Teleporter, Mini Fridge, Translator, Four Leaf Clover.");

			ToolTip.SetToolTip(CategoryMeleeAccessory, "Examples: Melee Durability Spray.");
			ToolTip.SetToolTip(CategoryGunAccessory, "Examples: Ammo Processor, Bulletproof Vest, Accuracy Mod, Bomb Maker, Ammo Stealer.");

			ToolTip.SetToolTip(CategorySupplies, "Examples: Safe Cracking Tool, First Aid Kit, Soldier Helmet, Crowbar, Mini Fridge.");
			ToolTip.SetToolTip(CategoryMoney, "Examples: Money.");
			ToolTip.SetToolTip(CategoryNugget, "Examples: Nugget.");
			ToolTip.SetToolTip(CategoryNPCsCantPickUp, "Examples: Freeze Ray, Water Cannon, Taser, Leaf Blower, Tranquilizer Gun.");
		}

		public void GenerateCode()
		{
			StringBuilder sb = new StringBuilder();
			if (AsLambda.Checked)
			{
				sb.AppendLine(AsThis.Text + " =>");
				sb.AppendLine("{");
			}
			List<string> list = new List<string>();

			Append(list, "itemType", "\"" + type + "\"");

			Append(list, "stackable", Stackable.Checked);
			if (HasCharges.Checked) Append(list, "hasCharges", HasCharges.Checked);
			if (NoCountText.Checked) Append(list, "noCountText", NoCountText.Checked);

			Append(list, "initCount", Stackable.Checked ? initCount : 1);
			if (Stackable.Checked && RewardCountBox.BackColor != SystemColors.Info)
				Append(list, "rewardCount", rewardCount);
			if (Stackable.Checked && InitCountAIBox.BackColor != SystemColors.Info)
				Append(list, "initCountAI", initCountAI);
			if (Stackable.Checked && LowCountThresholdBox.BackColor != SystemColors.Info)
				Append(list, "lowCountThreshold", (int)LowCountThresholdBox.Value);

			for (int i = 0; i < list.Count; i++)
			{
				if (AsLambda.Checked) sb.Append(' ', 4);
				sb.AppendLine(list[i]);
			}

			if (AsLambda.Checked) sb.AppendLine("}");
			OutputCode.Text = sb.ToString();
		}

		public void Append(List<string> list, string fieldName, string value)
			=> list.Add(AsThis.Text + "." + fieldName + " = \"" + value + "\";");
		public void Append(List<string> list, string fieldName, bool value)
			=> list.Add(AsThis.Text + "." + fieldName + " = " + (value ? "true" : "false") + ";");
		public void Append(List<string> list, string fieldName, int value)
			=> list.Add(AsThis.Text + "." + fieldName + " = " + value.ToString(CultureInfo.InvariantCulture) + ";");
		public void Append(List<string> list, string fieldName, float value)
			=> list.Add(AsThis.Text + "." + fieldName + " = " + value.ToString(CultureInfo.InvariantCulture) + "f;");

		public string type = "Food";
		public void ChangeTypeTo(string newType)
		{
			int defaultLowCount = newType == "WeaponProjectile" ? Math.Max(initCount / 4, 3)
					: newType == "WeaponMelee" || newType == "Wearable" ? 25
					: newType == "WeaponThrown" ? 5 : 0;
			if (LowCountThresholdBox.BackColor == SystemColors.Info)
				LowCountThresholdBox.Value = defaultLowCount;
			type = newType;
		}
		
		public ItemValueCalculator Calculator;
		private void ItemValueCalculatorButton_Click(object sender, EventArgs e)
		{
			if (Calculator == null)
			{
				Calculator = new ItemValueCalculator() { HelperTool = this };
				Calculator.Show();
				ItemValueCalculatorButton.Text = "Close Item Value Calculator";
			}
			else
			{
				Calculator.Close();
				Calculator.Dispose();
				Calculator = null;
				ItemValueCalculatorButton.Text = "Open Item Value Calculator";
			}
		}

		public int initCount = 1;
		public int rewardCount = 1;
		public int initCountAI = 1;
		public int lowCountThreshold = 1;


		private void Stackable_CheckedChanged(object sender, EventArgs e)
		{
			HasCharges.Enabled = NoCountText.Enabled = InitCountBox.Enabled = RewardCountBox.Enabled = InitCountAIBox.Enabled = LowCountThresholdBox.Enabled = Stackable.Checked;
			if (!Stackable.Checked)
			{
				HasCharges.Checked = false;
				NoCountText.Checked = false;
				InitCountBox.Value = 1;
				RewardCountBox.Value = 1;
				InitCountAIBox.Value = 1;
				LowCountThresholdBox.Value = 0;
			}
		}
		private void HasCharges_CheckedChanged(object sender, EventArgs e)
		{

		}
		private void NoCountText_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void InitCountBox_ValueChanged(object sender, EventArgs e)
		{
			if (!Stackable.Checked) return;
			if (rewardCount == initCount)
				RewardCountBox.Value = InitCountBox.Value;
			if (initCountAI == initCount)
				InitCountAIBox.Value = InitCountBox.Value;

			initCount = (int)InitCountBox.Value;

			RewardCountBox.BackColor = rewardCount == initCount ? SystemColors.Info : SystemColors.Window;
			InitCountAIBox.BackColor = initCountAI == initCount ? SystemColors.Info : SystemColors.Window;
			GenerateCode();
		}
		private void RewardCountBox_ValueChanged(object sender, EventArgs e)
		{
			if (!Stackable.Checked) return;
			rewardCount = (int)RewardCountBox.Value;
			RewardCountBox.BackColor = rewardCount == (int)InitCountBox.Value ? SystemColors.Info : SystemColors.Window;
			GenerateCode();
		}
		private void InitCountAIBox_ValueChanged(object sender, EventArgs e)
		{
			if (!Stackable.Checked) return;
			initCountAI = (int)InitCountAIBox.Value;
			InitCountAIBox.BackColor = initCountAI == (int)InitCountBox.Value ? SystemColors.Info : SystemColors.Window;
			GenerateCode();
		}
		private void LowCountThresholdBox_ValueChanged(object sender, EventArgs e)
		{
			if (!Stackable.Checked) return;
			int defaultLowCountThreshold = type == "WeaponProjectile" ? Math.Max(initCount/*maxAmmo*/ / 4, 3)
				: type == "WeaponMelee" || type == "WeaponThrown" ? 25
				: type == "WeaponThrown" ? 5 : 0;
			GenerateCode();
		}
	}
}
