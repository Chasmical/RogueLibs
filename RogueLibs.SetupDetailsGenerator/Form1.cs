using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogueLibsCore.SetupDetailsGenerator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			GenerateCode();

			ToolTip.SetToolTip(ItemTypeFood, "An item that is considered edible by humans." +
				"\nExamples: Beer, Banana, Whiskey, Bacon Cheeseburger, Fud.");
			ToolTip.SetToolTip(ItemTypeConsumable, "An item that is not a food, but can be consumed." +
				"\nExamples: First Aid Kit, Syringe, Cocktail, Resurrection Shampoo, Rage Poison.");
			ToolTip.SetToolTip(ItemTypeWearable, "An item that can be worn." +
				"\nExamples: Bracelet of Strength, Sunglasses, Bulletproof Vest, Mayor Hat, Gas Mask.");
			ToolTip.SetToolTip(ItemTypeWeaponMelee, "An item that can be used in melee combat." +
				"\nExamples: Sledgehammer, Baseball Bat, Fist, Chloroform Hankie, Plasma Sword.");
			ToolTip.SetToolTip(ItemTypeWeaponProjectile, "An item that can be used in ranged combat." +
				"\nExamples: Freeze Ray, Water Cannon, Shotgun, Rocket Launcher, Oil Container.");
			ToolTip.SetToolTip(ItemTypeWeaponThrown, "An item that can be thrown." +
				"\nExamples: Bear Trap, Banana Peel, Warp Grenade, Shuriken, Paralyzer Trap.");
			ToolTip.SetToolTip(ItemTypeTool, "An item that can be used for something." +
				"\nExamples: Skeleton Key, Blindenizer, Monkey Barrel, Mini Fridge, Walkie-Talkie.");
			ToolTip.SetToolTip(ItemTypeCombine, "An item that can be combined with others." +
				"\nExamples: Melee Durability Spray, Drink Mixer, Ammo Processor, Silencer, Portable Sell-o-matic.");

			ToolTip.SetToolTip(ItemStackable, "Determines whether an item's amount will be displayed in the inventory.");
			ToolTip.SetToolTip(ItemHasCharges, "Determines whether an item should not be stackable." +
				"\nExamples: Ammo Processor, Food Processor, Cube of Lampey, Remote Control, Bomb Maker.");
			ToolTip.SetToolTip(ItemInitialCount, "Determines the initial amount of an item.");
			ToolTip.SetToolTip(ItemInitialCountLabel, "Determines the initial amount of an item.");
			ToolTip.SetToolTip(ItemRewardCount, "Determines the reward amount of an item, given for quests and in loadout.");
			ToolTip.SetToolTip(ItemRewardCountLabel, "Determines the reward amount of an item, given for quests and in loadout.");
			ToolTip.SetToolTip(ItemInitialCountAI, "Determines the initial amount of an item for NPCs.");
			ToolTip.SetToolTip(ItemInitialCountAILabel, "Determines the initial amount of an item for NPCs.");

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
			if (asLambda)
			{
				sb.AppendLine(asThis + " =>");
				sb.AppendLine("{");
			}
			List<string> lines = new List<string>();

			lines.Add(asThis + ".itemType = \"" + itemType + "\";");
			if (itemType == "WeaponMelee" || itemType == "WeaponProjectile" || itemType == "WeaponThrown")
			{
				lines.Add(asThis + ".isWeapon = true;");
				lines.Add(asThis + ".weaponCode = weaponType." + itemType + ";");
			}

			if (ItemStackable.Checked) lines.Add(asThis + ".stackable = true;");
			if (ItemHasCharges.Checked) lines.Add(asThis + ".hasCharges = true;");
			lines.Add(asThis + ".initCount = " + initCount + ";");
			if (initCount != rewardCount) lines.Add(asThis + ".rewardCount = " + rewardCount + ";");
			if (initCountAI != initCount) lines.Add(asThis + ".initCountAI = " + initCountAI + ";");
			lines.Add(asThis + ".itemValue = " + (int)ItemValueBox.Value + ";");

			#region Categories
			if (CategoryFood.Checked) lines.Add(asThis + ".Categories.Add(\"Food\");");
			if (CategoryHealth.Checked) lines.Add(asThis + ".Categories.Add(\"Health\");");
			if (CategoryDrugs.Checked) lines.Add(asThis + ".Categories.Add(\"Drugs\");");
			if (CategoryAlcohol.Checked) lines.Add(asThis + ".Categories.Add(\"Alcohol\");");
			if (CategorySex.Checked) lines.Add(asThis + ".Categories.Add(\"Sex\");");

			if (CategoryWeapons.Checked) lines.Add(asThis + ".Categories.Add(\"Weapons\");");
			if (CategoryNonStandardWeapons.Checked) lines.Add(asThis + ".Categories.Add(\"NonStandardWeapons\");");
			if (CategoryNonStandardWeapons2.Checked) lines.Add(asThis + ".Categories.Add(\"NonStandardWeapons2\");");
			if (CategoryNonViolent.Checked) lines.Add(asThis + ".Categories.Add(\"NonViolent\");");
			if (CategoryNotRealWeapons.Checked) lines.Add(asThis + ".Categories.Add(\"NotRealWeapons\");");

			if (CategoryMelee.Checked) lines.Add(asThis + ".Categories.Add(\"Melee\");");
			if (CategoryGuns.Checked) lines.Add(asThis + ".Categories.Add(\"Guns\");");
			if (CategorySocial.Checked) lines.Add(asThis + ".Categories.Add(\"Social\");");
			if (CategoryStealth.Checked) lines.Add(asThis + ".Categories.Add(\"Stealth\");");
			if (CategoryMovement.Checked) lines.Add(asThis + ".Categories.Add(\"Movement\");");
			if (CategoryDefense.Checked) lines.Add(asThis + ".Categories.Add(\"Defense\");");
			if (CategoryTrade.Checked) lines.Add(asThis + ".Categories.Add(\"Trade\");");
			if (CategoryWeird.Checked) lines.Add(asThis + ".Categories.Add(\"Weird\");");
			if (CategoryTechnology.Checked) lines.Add(asThis + ".Categories.Add(\"Technology\");");

			if (CategoryNonUsableTool.Checked) lines.Add(asThis + ".Categories.Add(\"NonUsableTool\");");
			if (CategoryUsable.Checked) lines.Add(asThis + ".Categories.Add(\"Usable\");");
			if (CategoryPassive.Checked) lines.Add(asThis + ".Categories.Add(\"Passive\");");

			if (CategoryMeleeAccessory.Checked) lines.Add(asThis + ".Categories.Add(\"MeleeAccessory\");");
			if (CategoryGunAccessory.Checked) lines.Add(asThis + ".Categories.Add(\"GunAccessory\");");

			if (CategorySupplies.Checked) lines.Add(asThis + ".Categories.Add(\"Supplies\");");
			if (CategoryMoney.Checked) lines.Add(asThis + ".Categories.Add(\"Money\");");
			if (CategoryNugget.Checked) lines.Add(asThis + ".Categories.Add(\"Nugget\");");
			if (CategoryNPCsCantPickUp.Checked) lines.Add(asThis + ".Categories.Add(\"NPCsCantPickUp\");");

			if (CustomCategory1.Text.Length > 0) lines.Add(asThis + ".Categories.Add(\"" + CustomCategory1.Text + "\");");
			if (CustomCategory2.Text.Length > 0) lines.Add(asThis + ".Categories.Add(\"" + CustomCategory2.Text + "\");");
			if (CustomCategory3.Text.Length > 0) lines.Add(asThis + ".Categories.Add(\"" + CustomCategory3.Text + "\");");
			if (CustomCategory4.Text.Length > 0) lines.Add(asThis + ".Categories.Add(\"" + CustomCategory4.Text + "\");");
			if (CustomCategory5.Text.Length > 0) lines.Add(asThis + ".Categories.Add(\"" + CustomCategory5.Text + "\");");
			if (CustomCategory6.Text.Length > 0) lines.Add(asThis + ".Categories.Add(\"" + CustomCategory6.Text + "\");");
			if (CustomCategory7.Text.Length > 0) lines.Add(asThis + ".Categories.Add(\"" + CustomCategory7.Text + "\");");
			if (CustomCategory8.Text.Length > 0) lines.Add(asThis + ".Categories.Add(\"" + CustomCategory8.Text + "\");");
			#endregion

			if (RechargeBox.Checked)
			{
				lines.Add(asThis + ".rechargeAmount" + (InverseRechargeBox.Checked ? "Inverse" : string.Empty)
					+ " = " + rechargeAmount + ";");
			}
			if (itemType == "WeaponProjectile")
				lines.Add(asThis + ".maxAmmo = " + maxAmmo + ";");





			for (int i = 0; i < lines.Count; i++)
			{
				if (asLambda) sb.Append("    ");
				sb.AppendLine(lines[i]);
			}
			if (asLambda) sb.AppendLine("}");
			OutputCode.Text = sb.ToString();
		}

		public string asThis = "item";
		private void AsThis_TextChanged(object sender, EventArgs e)
		{
			if (AsThis.Text.Length == 0)
				AsThis.BackColor = Color.IndianRed;
			else
			{
				AsThis.BackColor = SystemColors.Window;
				asThis = AsThis.Text;
				GenerateCode();
			}
		}
		public bool asLambda = true;
		private void AsLambda_CheckedChanged(object sender, EventArgs e)
		{
			asLambda = AsLambda.Checked;
			GenerateCode();
		}

		public string itemType = "Food";
		private void ItemTypeFood_CheckedChanged(object sender, EventArgs e)
		{
			if (ItemTypeFood.Checked)
				itemType = "Food";
			GenerateCode();
		}
		private void ItemTypeConsumable_CheckedChanged(object sender, EventArgs e)
		{
			if (ItemTypeConsumable.Checked)
				itemType = "Consumable";
			GenerateCode();
		}
		private void ItemTypeWearable_CheckedChanged(object sender, EventArgs e)
		{
			if (ItemTypeWearable.Checked)
				itemType = "Wearable";
			GenerateCode();
		}
		private void ItemTypeWeaponMelee_CheckedChanged(object sender, EventArgs e)
		{
			if (ItemTypeWeaponMelee.Checked)
				itemType = "WeaponMelee";
			GenerateCode();
		}
		private void ItemTypeWeaponProjectile_CheckedChanged(object sender, EventArgs e)
		{
			if (ItemTypeWeaponProjectile.Checked)
				itemType = "WeaponProjectile";
			GenerateCode();
		}
		private void ItemTypeWeaponThrown_CheckedChanged(object sender, EventArgs e)
		{
			if (ItemTypeWeaponThrown.Checked)
				itemType = "WeaponThrown";
			GenerateCode();
		}
		private void ItemTypeTool_CheckedChanged(object sender, EventArgs e)
		{
			if (ItemTypeTool.Checked)
				itemType = "Tool";
			GenerateCode();
		}
		private void ItemTypeCombine_CheckedChanged(object sender, EventArgs e)
		{
			if (ItemTypeCombine.Checked)
				itemType = "Combine";
			GenerateCode();
		}
		private void ItemTypeOther_CheckedChanged(object sender, EventArgs e)
		{
			ItemTypeOtherBox.Enabled = ItemTypeOther.Checked;
			ItemTypeOtherBox.BackColor = ItemTypeOther.Checked ? SystemColors.Window : SystemColors.ScrollBar;
			itemType = ItemTypeOtherBox.Text = ItemTypeOther.Checked ? "Other" : string.Empty;
			GenerateCode();
		}
		private void ItemTypeOtherBox_TextChanged(object sender, EventArgs e)
		{
			if (!ItemTypeOther.Checked) return;
			if (ItemTypeOtherBox.Text.Length == 0) ItemTypeOtherBox.BackColor = Color.IndianRed;
			else
			{
				itemType = ItemTypeOtherBox.Text;
				ItemTypeOtherBox.BackColor = SystemColors.Window;
			}
			GenerateCode();
		}

		public int initCount = 1;
		public int rewardCount = 1;
		public int initCountAI = 1;
		private void ItemStackable_CheckedChanged(object sender, EventArgs e)
		{
			ItemInitialCount.Enabled = ItemRewardCount.Enabled = ItemInitialCountAI.Enabled = ItemStackable.Checked;
			if (ItemStackable.Checked)
			{
				ItemInitialCount.Value = initCount;
				ItemRewardCount.Value = rewardCount;
				ItemInitialCountAI.Value = initCountAI;
			}
			else
			{
				ItemInitialCount.Value = ItemRewardCount.Value = ItemInitialCountAI.Value = 1;
				ItemRewardCount.BackColor = ItemInitialCountAI.BackColor = SystemColors.Info;
			}
			ItemHasCharges.Enabled = ItemStackable.Checked;
			GenerateCode();
		}
		private void ItemHasCharges_CheckedChanged(object sender, EventArgs e)
		{
			ItemStackable.Enabled = !ItemHasCharges.Checked;
			GenerateCode();
		}
		private void ItemInitialCount_ValueChanged(object sender, EventArgs e)
		{
			if (!ItemStackable.Checked) return;
			int oldCount = initCount;
			initCount = (int)ItemInitialCount.Value;
			if (oldCount == rewardCount) ItemRewardCount.Value = ItemInitialCount.Value;
			else ItemRewardCount.BackColor = initCount == rewardCount ? SystemColors.Info : SystemColors.Window;
			if (oldCount == initCountAI) ItemInitialCountAI.Value = ItemInitialCount.Value;
			else ItemInitialCountAI.BackColor = initCount == initCountAI ? SystemColors.Info : SystemColors.Window;
			if (oldCount == maxAmmo) MaxAmmoBox.Value = ItemInitialCount.Value;
			else MaxAmmoBox.BackColor = initCount == maxAmmo ? SystemColors.Info : SystemColors.Window;
			GenerateCode();
		}
		private void ItemRewardCount_ValueChanged(object sender, EventArgs e)
		{
			if (!ItemStackable.Checked) return;
			rewardCount = (int)ItemRewardCount.Value;
			ItemRewardCount.BackColor = initCount == rewardCount ? SystemColors.Info : SystemColors.Window;
			GenerateCode();
		}
		private void ItemInitialCountAI_ValueChanged(object sender, EventArgs e)
		{
			if (!ItemStackable.Checked) return;
			initCountAI = (int)ItemInitialCountAI.Value;
			ItemInitialCountAI.BackColor = initCount == initCountAI ? SystemColors.Info : SystemColors.Window;
			GenerateCode();
		}

		private void CustomCategory_TextChanged(object sender, EventArgs e)
		{
			TextBox box = (TextBox)sender;
			box.BackColor = box.Text.Length == 0 ? SystemColors.ScrollBar : SystemColors.Window;
			GenerateCode();
		}

		private void UpdateCategories(object sender, EventArgs e) => GenerateCode();

		private void CopyToClipboard_Click(object sender, EventArgs e)
		{
			OutputCode.Focus();
			OutputCode.SelectAll();
			Clipboard.SetText(OutputCode.Text);
		}

		public Form2 form2;
		private void ItemValueCalculator_Click(object sender, EventArgs e)
		{
			if (form2 == null)
			{
				ItemValueCalculator.Text = "Close Item Value\r\nCalculator";
				form2 = new Form2(this);
				form2.Show();
			}
			else
			{
				ItemValueCalculator.Text = "Open Item Value\r\nCalculator";
				form2.Close();
				form2.Dispose();
				form2 = null;
			}

		}
		private void ItemValueBox_ValueChanged(object sender, EventArgs e)
		{
			if (form2 != null)
			{
				form2.ItemValueBox.Value = ItemValueBox.Value;
				form2.UpdateCosts();
			}
		}

		public int maxAmmo = 1;
		public int rechargeAmount = 1;
		private void MaxAmmoBox_ValueChanged(object sender, EventArgs e)
		{
			if (itemType != "WeaponProjectile") return;
			maxAmmo = (int)MaxAmmoBox.Value;
			MaxAmmoBox.BackColor = initCount == maxAmmo ? SystemColors.Info : SystemColors.Window;
			GenerateCode();
		}
		private void RechargeBox_CheckedChanged(object sender, EventArgs e)
		{
			RechargeAmountBox.Enabled = InverseRechargeBox.Enabled = RechargeBox.Checked;
			if (!RechargeBox.Checked) InverseRechargeBox.Checked = false;
			RechargeAmountBox.Value = RechargeBox.Checked ? rechargeAmount : 0;
			GenerateCode();
		}
		private void RechargeAmountBox_ValueChanged(object sender, EventArgs e)
		{
			rechargeAmount = (int)RechargeAmountBox.Value;
			GenerateCode();
		}
		private void InverseRechargeBox_CheckedChanged(object sender, EventArgs e) => GenerateCode();

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
