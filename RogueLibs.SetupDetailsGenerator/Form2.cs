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
	public partial class Form2 : Form
	{
		public Form2() => InitializeComponent();
		public Form2(Form1 form)
		{
			form1 = form;
			InitializeComponent();
			UpdateCosts();
			UpdateLocation();
		}

		public void UpdateCosts()
		{
			ClearOperations();

			ListViewItem item = OperationsList.Items.Add("Initial Amount: " + FinalValue);
			item.ForeColor = Color.DodgerBlue; // IndianRed, SpringGreen

			if (SellerDefaultSale.Checked) UpdateDefaultSaleCost();
			else if (SellerArtOfTheDealSale.Checked) UpdateArtOfTheDealSaleCost();
			else if (SellerATMMachine.Checked) UpdateATMMachineCost();
			else if (SellerCloneMachine.Checked) UpdateCloneMachineCost();
			else if (SellerLoadoutOMatic.Checked) UpdateLoadoutOMaticCost();
			else if (SellerAmmoDispenser.Checked) UpdateAmmoDispenserCost();
		}
		public float FinalValue = 1f;
		public void ClearOperations()
		{
			FinalValue = (int)ItemValueBox.Value;
			OperationsList.Clear();
		}
		public void DurabilityAmmoCost(Color color)
		{
			if (!SellerAmmoDispenser.Checked)
			{
				if (form1.itemType == "WeaponProjectile" && form1.rechargeAmount == 0)
				{
					if (FinalValue <= FinalValue * 0.1f)
						FinalValue = FinalValue * 0.1f;
					FinalValue += (float)(myItem.contents.Count * 30);
					ListViewItem item = OperationsList.Items.Add("");
					item.ForeColor = color;
				}
				else if (form1.itemType == "WeaponMelee")
				{
					int num = myItem.invItemCount;
					if (num > form1.initCount && (SellerDefaultSale.Checked || SellerArtOfTheDealSale.Checked || SellerLoadoutOMatic.Checked))
						num = form1.initCount;
					FinalValue *= (float)num / form1.initCount;
					if (FinalValue <= FinalValue * 0.1f)
						FinalValue = FinalValue * 0.1f;
					FinalValue += (float)(myItem.contents.Count * 30);
				}
				else if (myItem.isArmor)
				{
					FinalValue *= (float)myItem.invItemCount / (float)form1.initCount;
					if (FinalValue <= FinalValue * 0.1f)
						FinalValue = FinalValue * 0.1f;
					FinalValue += (float)Math.Min(Math.Max((myItem.contents.Count - 1) * 30, 0), 100);
				}
				else if (myItem.isArmorHead)
				{
					FinalValue *= (float)myItem.invItemCount / (float)form1.initCount;
					if (FinalValue <= FinalValue * 0.1f)
						FinalValue = FinalValue * 0.1f;
					FinalValue += (float)Math.Min(Math.Max((myItem.contents.Count - 1) * 30, 0), 100);
				}
				else if (form1.ItemHasCharges.Checked)
				{
					FinalValue = (float)(myItem.invItemCount * FinalValue);
					if (FinalValue <= FinalValue * 0.1f)
						FinalValue = FinalValue * 0.1f;
				}
			}
		}

		public void UpdateDefaultSaleCost()
		{
			ListViewItem item = OperationsList.Items.Add("");
		}
		public void UpdateArtOfTheDealSaleCost()
		{

		}
		public void UpdateATMMachineCost()
		{

		}
		public void UpdateCloneMachineCost()
		{
			
		}
		public void UpdateLoadoutOMaticCost()
		{

		}
		public void UpdateAmmoDispenserCost()
		{

		}

		public Form1 form1;
		private void ItemValueBox_ValueChanged(object sender, EventArgs e)
		{
			form1.ItemValueBox.Value = ItemValueBox.Value;
			UpdateCosts();
		}

		public void UpdateLocation()
		{
			int floorsPerLocation = QuickGameBox.Checked ? 2 : 3;
			int location = ((int)LevelBox.Value - 1) / floorsPerLocation + 1;
			int level = ((int)LevelBox.Value - 1) % floorsPerLocation + 1;
			LevelLabel.Text = (location == 1 ? "Slums "
				: location == 2 ? "Industrial "
				: location == 3 ? "Park "
				: location == 4 ? "Downtown "
				: location == 5 ? "Uptown " : "Mayor Village ")
				+ location.ToString() + "-" + level.ToString();
		}
		private void LevelBox_ValueChanged(object sender, EventArgs e)
		{
			UpdateLocation();
			UpdateCosts();
		}
		private void QuickGameBox_CheckedChanged(object sender, EventArgs e)
		{
			int floorsPerLocation = !QuickGameBox.Checked ? 2 : 3;
			int newFloorsPerLocation = QuickGameBox.Checked ? 2 : 3;
			int location = ((int)LevelBox.Value - 1) / floorsPerLocation + 1;
			int level = ((int)LevelBox.Value - 1) % floorsPerLocation + 1;
			LevelLabel.Text = (location == 1 ? "Slums "
				: location == 2 ? "Industrial "
				: location == 3 ? "Park "
				: location == 4 ? "Downtown "
				: location == 5 ? "Uptown " : "Mayor Village ")
				+ location.ToString() + "-" + level.ToString();
			if (level > 2) level = 2;
			LevelBox.Maximum = QuickGameBox.Checked ? 11 : 16;
			LevelBox.Value = (location - 1) * newFloorsPerLocation + level;

			UpdateLocation();
			UpdateCosts();
		}
		private void HighCostsBox_CheckedChanged(object sender, EventArgs e) => UpdateCosts();

		private void GoodTraderBox_CheckedChanged(object sender, EventArgs e)
		{
			GoodTrader2Box.Enabled = GoodTraderBox.Checked;
			if (GoodTraderBox.Checked) BadTraderBox.Checked = false;
			UpdateCosts();
		}
		private void GoodTrader2Box_CheckedChanged(object sender, EventArgs e)
		{
			GoodTraderBox.Enabled = !GoodTrader2Box.Checked;
			UpdateCosts();
		}
		private void BadTraderBox_CheckedChanged(object sender, EventArgs e)
		{
			if (BadTraderBox.Checked) GoodTraderBox.Checked = GoodTrader2Box.Checked = false;
			UpdateCosts();
		}
		private void HonorAmongThievesBox_CheckedChanged(object sender, EventArgs e)
		{
			HonorAmongThieves2Box.Enabled = HonorAmongThievesBox.Checked;
			UpdateCosts();
		}
		private void HonorAmongThieves2Box_CheckedChanged(object sender, EventArgs e)
		{
			HonorAmongThievesBox.Enabled = !HonorAmongThieves2Box.Checked;
			UpdateCosts();
		}

		private void SellerDefaultSale_CheckedChanged(object sender, EventArgs e)
		{
			BuyerSellOMatic.Checked = BuyerPortableSellOMatic.Checked = false;
			UpdateCosts();
		}
		private void SellerArtOfTheDealSale_CheckedChanged(object sender, EventArgs e)
		{
			BuyerSellOMatic.Checked = BuyerPortableSellOMatic.Checked = false;
			UpdateCosts();
		}
		private void SellerATMMachine_CheckedChanged(object sender, EventArgs e)
		{
			BuyerSellOMatic.Checked = BuyerPortableSellOMatic.Checked = false;
			UpdateCosts();
		}
		private void SellerCloneMachine_CheckedChanged(object sender, EventArgs e)
		{
			BuyerSellOMatic.Checked = BuyerPortableSellOMatic.Checked = false;
			UpdateCosts();
		}
		private void SellerLoadoutOMatic_CheckedChanged(object sender, EventArgs e)
		{
			BuyerSellOMatic.Checked = BuyerPortableSellOMatic.Checked = false;
			UpdateCosts();
		}
		private void SellerAmmoDispenser_CheckedChanged(object sender, EventArgs e)
		{
			BuyerSellOMatic.Checked = BuyerPortableSellOMatic.Checked = false;
			UpdateCosts();
		}
		private void BuyerSellOMatic_CheckedChanged(object sender, EventArgs e)
		{
			SellerDefaultSale.Checked = SellerArtOfTheDealSale.Checked = SellerATMMachine.Checked =
				SellerCloneMachine.Checked = SellerLoadoutOMatic.Checked = SellerAmmoDispenser.Checked = false;
			UpdateCosts();
		}
		private void BuyerPortableSellOMatic_CheckedChanged(object sender, EventArgs e)
		{
			SellerDefaultSale.Checked = SellerArtOfTheDealSale.Checked = SellerATMMachine.Checked =
				SellerCloneMachine.Checked = SellerLoadoutOMatic.Checked = SellerAmmoDispenser.Checked = false;
			UpdateCosts();
		}

		private void ShopkeepersBigQuestBox_CheckedChanged(object sender, EventArgs e) => UpdateCosts();
	}
}
