namespace RogueLibsCore.SetupDetailsGenerator
{
	partial class Form2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ItemValueBox = new System.Windows.Forms.NumericUpDown();
			this.ItemValueLabel = new System.Windows.Forms.Label();
			this.LevelGroup = new System.Windows.Forms.GroupBox();
			this.HighCostsBox = new System.Windows.Forms.CheckBox();
			this.LevelLabel = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.QuickGameBox = new System.Windows.Forms.CheckBox();
			this.TraitsGroup = new System.Windows.Forms.GroupBox();
			this.HonorAmongThieves2Box = new System.Windows.Forms.CheckBox();
			this.HonorAmongThievesBox = new System.Windows.Forms.CheckBox();
			this.GoodTrader2Box = new System.Windows.Forms.CheckBox();
			this.BadTraderBox = new System.Windows.Forms.CheckBox();
			this.GoodTraderBox = new System.Windows.Forms.CheckBox();
			this.BuyersGroup = new System.Windows.Forms.GroupBox();
			this.BuyerPortableSellOMatic = new System.Windows.Forms.RadioButton();
			this.BuyerSellOMatic = new System.Windows.Forms.RadioButton();
			this.SellersGroup = new System.Windows.Forms.GroupBox();
			this.SellerAmmoDispenser = new System.Windows.Forms.RadioButton();
			this.SellerLoadoutOMatic = new System.Windows.Forms.RadioButton();
			this.SellerCloneMachine = new System.Windows.Forms.RadioButton();
			this.SellerATMMachine = new System.Windows.Forms.RadioButton();
			this.SellerArtOfTheDealSale = new System.Windows.Forms.RadioButton();
			this.SellerDefaultSale = new System.Windows.Forms.RadioButton();
			this.RelationshipBar = new System.Windows.Forms.TrackBar();
			this.RelationshipGroup = new System.Windows.Forms.GroupBox();
			this.RelationshipLabel = new System.Windows.Forms.Label();
			this.OperationsList = new System.Windows.Forms.ListView();
			this.ShopkeepersBigQuestBox = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.ItemValueBox)).BeginInit();
			this.LevelGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			this.TraitsGroup.SuspendLayout();
			this.BuyersGroup.SuspendLayout();
			this.SellersGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RelationshipBar)).BeginInit();
			this.RelationshipGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// ItemValueBox
			// 
			this.ItemValueBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ItemValueBox.Location = new System.Drawing.Point(263, 50);
			this.ItemValueBox.Margin = new System.Windows.Forms.Padding(4);
			this.ItemValueBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.ItemValueBox.Name = "ItemValueBox";
			this.ItemValueBox.Size = new System.Drawing.Size(160, 62);
			this.ItemValueBox.TabIndex = 0;
			this.ItemValueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ItemValueBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.ItemValueBox.ValueChanged += new System.EventHandler(this.ItemValueBox_ValueChanged);
			// 
			// ItemValueLabel
			// 
			this.ItemValueLabel.AutoSize = true;
			this.ItemValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ItemValueLabel.Location = new System.Drawing.Point(253, 9);
			this.ItemValueLabel.Name = "ItemValueLabel";
			this.ItemValueLabel.Size = new System.Drawing.Size(179, 37);
			this.ItemValueLabel.TabIndex = 1;
			this.ItemValueLabel.Text = "Item Value";
			// 
			// LevelGroup
			// 
			this.LevelGroup.Controls.Add(this.HighCostsBox);
			this.LevelGroup.Controls.Add(this.LevelLabel);
			this.LevelGroup.Controls.Add(this.LevelBox);
			this.LevelGroup.Controls.Add(this.QuickGameBox);
			this.LevelGroup.Location = new System.Drawing.Point(12, 12);
			this.LevelGroup.Name = "LevelGroup";
			this.LevelGroup.Size = new System.Drawing.Size(235, 82);
			this.LevelGroup.TabIndex = 3;
			this.LevelGroup.TabStop = false;
			this.LevelGroup.Text = "Level";
			// 
			// HighCostsBox
			// 
			this.HighCostsBox.AutoSize = true;
			this.HighCostsBox.Location = new System.Drawing.Point(123, 54);
			this.HighCostsBox.Name = "HighCostsBox";
			this.HighCostsBox.Size = new System.Drawing.Size(101, 22);
			this.HighCostsBox.TabIndex = 0;
			this.HighCostsBox.Text = "High Costs";
			this.HighCostsBox.UseVisualStyleBackColor = true;
			this.HighCostsBox.CheckedChanged += new System.EventHandler(this.HighCostsBox_CheckedChanged);
			// 
			// LevelLabel
			// 
			this.LevelLabel.AutoSize = true;
			this.LevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LevelLabel.Location = new System.Drawing.Point(50, 22);
			this.LevelLabel.Name = "LevelLabel";
			this.LevelLabel.Size = new System.Drawing.Size(155, 24);
			this.LevelLabel.TabIndex = 9;
			this.LevelLabel.Text = "Mayor Village 6-1";
			// 
			// LevelBox
			// 
			this.LevelBox.Location = new System.Drawing.Point(6, 24);
			this.LevelBox.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.LevelBox.Name = "LevelBox";
			this.LevelBox.Size = new System.Drawing.Size(38, 24);
			this.LevelBox.TabIndex = 4;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.ValueChanged += new System.EventHandler(this.LevelBox_ValueChanged);
			// 
			// QuickGameBox
			// 
			this.QuickGameBox.AutoSize = true;
			this.QuickGameBox.Location = new System.Drawing.Point(6, 54);
			this.QuickGameBox.Name = "QuickGameBox";
			this.QuickGameBox.Size = new System.Drawing.Size(111, 22);
			this.QuickGameBox.TabIndex = 8;
			this.QuickGameBox.Text = "Quick Game";
			this.QuickGameBox.UseVisualStyleBackColor = true;
			this.QuickGameBox.CheckedChanged += new System.EventHandler(this.QuickGameBox_CheckedChanged);
			// 
			// TraitsGroup
			// 
			this.TraitsGroup.Controls.Add(this.HonorAmongThieves2Box);
			this.TraitsGroup.Controls.Add(this.HonorAmongThievesBox);
			this.TraitsGroup.Controls.Add(this.GoodTrader2Box);
			this.TraitsGroup.Controls.Add(this.BadTraderBox);
			this.TraitsGroup.Controls.Add(this.GoodTraderBox);
			this.TraitsGroup.Location = new System.Drawing.Point(12, 100);
			this.TraitsGroup.Name = "TraitsGroup";
			this.TraitsGroup.Size = new System.Drawing.Size(235, 105);
			this.TraitsGroup.TabIndex = 8;
			this.TraitsGroup.TabStop = false;
			this.TraitsGroup.Text = "Traits";
			// 
			// HonorAmongThieves2Box
			// 
			this.HonorAmongThieves2Box.AutoSize = true;
			this.HonorAmongThieves2Box.Enabled = false;
			this.HonorAmongThieves2Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.HonorAmongThieves2Box.Location = new System.Drawing.Point(177, 79);
			this.HonorAmongThieves2Box.Name = "HonorAmongThieves2Box";
			this.HonorAmongThieves2Box.Size = new System.Drawing.Size(37, 22);
			this.HonorAmongThieves2Box.TabIndex = 4;
			this.HonorAmongThieves2Box.Text = "+";
			this.HonorAmongThieves2Box.UseVisualStyleBackColor = true;
			this.HonorAmongThieves2Box.CheckedChanged += new System.EventHandler(this.HonorAmongThieves2Box_CheckedChanged);
			// 
			// HonorAmongThievesBox
			// 
			this.HonorAmongThievesBox.AutoSize = true;
			this.HonorAmongThievesBox.Location = new System.Drawing.Point(6, 79);
			this.HonorAmongThievesBox.Name = "HonorAmongThievesBox";
			this.HonorAmongThievesBox.Size = new System.Drawing.Size(175, 22);
			this.HonorAmongThievesBox.TabIndex = 3;
			this.HonorAmongThievesBox.Text = "Honor Among Thieves";
			this.HonorAmongThievesBox.UseVisualStyleBackColor = true;
			this.HonorAmongThievesBox.CheckedChanged += new System.EventHandler(this.HonorAmongThievesBox_CheckedChanged);
			// 
			// GoodTrader2Box
			// 
			this.GoodTrader2Box.AutoSize = true;
			this.GoodTrader2Box.Enabled = false;
			this.GoodTrader2Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.GoodTrader2Box.Location = new System.Drawing.Point(153, 23);
			this.GoodTrader2Box.Name = "GoodTrader2Box";
			this.GoodTrader2Box.Size = new System.Drawing.Size(37, 22);
			this.GoodTrader2Box.TabIndex = 2;
			this.GoodTrader2Box.Text = "+";
			this.GoodTrader2Box.UseVisualStyleBackColor = true;
			this.GoodTrader2Box.CheckedChanged += new System.EventHandler(this.GoodTrader2Box_CheckedChanged);
			// 
			// BadTraderBox
			// 
			this.BadTraderBox.AutoSize = true;
			this.BadTraderBox.Location = new System.Drawing.Point(6, 51);
			this.BadTraderBox.Name = "BadTraderBox";
			this.BadTraderBox.Size = new System.Drawing.Size(74, 22);
			this.BadTraderBox.TabIndex = 1;
			this.BadTraderBox.Text = "Sucker";
			this.BadTraderBox.UseVisualStyleBackColor = true;
			this.BadTraderBox.CheckedChanged += new System.EventHandler(this.BadTraderBox_CheckedChanged);
			// 
			// GoodTraderBox
			// 
			this.GoodTraderBox.AutoSize = true;
			this.GoodTraderBox.Location = new System.Drawing.Point(6, 23);
			this.GoodTraderBox.Name = "GoodTraderBox";
			this.GoodTraderBox.Size = new System.Drawing.Size(150, 22);
			this.GoodTraderBox.TabIndex = 0;
			this.GoodTraderBox.Text = "Shrewd Negotiator";
			this.GoodTraderBox.UseVisualStyleBackColor = true;
			this.GoodTraderBox.CheckedChanged += new System.EventHandler(this.GoodTraderBox_CheckedChanged);
			// 
			// BuyersGroup
			// 
			this.BuyersGroup.Controls.Add(this.BuyerPortableSellOMatic);
			this.BuyersGroup.Controls.Add(this.BuyerSellOMatic);
			this.BuyersGroup.Location = new System.Drawing.Point(438, 12);
			this.BuyersGroup.Name = "BuyersGroup";
			this.BuyersGroup.Size = new System.Drawing.Size(184, 82);
			this.BuyersGroup.TabIndex = 10;
			this.BuyersGroup.TabStop = false;
			this.BuyersGroup.Text = "Buyers";
			// 
			// BuyerPortableSellOMatic
			// 
			this.BuyerPortableSellOMatic.AutoSize = true;
			this.BuyerPortableSellOMatic.Location = new System.Drawing.Point(10, 51);
			this.BuyerPortableSellOMatic.Name = "BuyerPortableSellOMatic";
			this.BuyerPortableSellOMatic.Size = new System.Drawing.Size(167, 22);
			this.BuyerPortableSellOMatic.TabIndex = 1;
			this.BuyerPortableSellOMatic.TabStop = true;
			this.BuyerPortableSellOMatic.Text = "Portable Sell-O-Matic";
			this.BuyerPortableSellOMatic.UseVisualStyleBackColor = true;
			this.BuyerPortableSellOMatic.CheckedChanged += new System.EventHandler(this.BuyerPortableSellOMatic_CheckedChanged);
			// 
			// BuyerSellOMatic
			// 
			this.BuyerSellOMatic.AutoSize = true;
			this.BuyerSellOMatic.Location = new System.Drawing.Point(10, 23);
			this.BuyerSellOMatic.Name = "BuyerSellOMatic";
			this.BuyerSellOMatic.Size = new System.Drawing.Size(108, 22);
			this.BuyerSellOMatic.TabIndex = 0;
			this.BuyerSellOMatic.TabStop = true;
			this.BuyerSellOMatic.Text = "Sell-O-Matic";
			this.BuyerSellOMatic.UseVisualStyleBackColor = true;
			this.BuyerSellOMatic.CheckedChanged += new System.EventHandler(this.BuyerSellOMatic_CheckedChanged);
			// 
			// SellersGroup
			// 
			this.SellersGroup.Controls.Add(this.SellerAmmoDispenser);
			this.SellersGroup.Controls.Add(this.SellerLoadoutOMatic);
			this.SellersGroup.Controls.Add(this.SellerCloneMachine);
			this.SellersGroup.Controls.Add(this.SellerATMMachine);
			this.SellersGroup.Controls.Add(this.SellerArtOfTheDealSale);
			this.SellersGroup.Controls.Add(this.SellerDefaultSale);
			this.SellersGroup.Location = new System.Drawing.Point(253, 119);
			this.SellersGroup.Name = "SellersGroup";
			this.SellersGroup.Size = new System.Drawing.Size(179, 192);
			this.SellersGroup.TabIndex = 11;
			this.SellersGroup.TabStop = false;
			this.SellersGroup.Text = "Sellers";
			// 
			// SellerAmmoDispenser
			// 
			this.SellerAmmoDispenser.AutoSize = true;
			this.SellerAmmoDispenser.Location = new System.Drawing.Point(6, 163);
			this.SellerAmmoDispenser.Name = "SellerAmmoDispenser";
			this.SellerAmmoDispenser.Size = new System.Drawing.Size(141, 22);
			this.SellerAmmoDispenser.TabIndex = 5;
			this.SellerAmmoDispenser.Text = "Ammo Dispenser";
			this.SellerAmmoDispenser.UseVisualStyleBackColor = true;
			this.SellerAmmoDispenser.CheckedChanged += new System.EventHandler(this.SellerAmmoDispenser_CheckedChanged);
			// 
			// SellerLoadoutOMatic
			// 
			this.SellerLoadoutOMatic.AutoSize = true;
			this.SellerLoadoutOMatic.Location = new System.Drawing.Point(6, 135);
			this.SellerLoadoutOMatic.Name = "SellerLoadoutOMatic";
			this.SellerLoadoutOMatic.Size = new System.Drawing.Size(138, 22);
			this.SellerLoadoutOMatic.TabIndex = 4;
			this.SellerLoadoutOMatic.Text = "Loadout-O-Matic";
			this.SellerLoadoutOMatic.UseVisualStyleBackColor = true;
			this.SellerLoadoutOMatic.CheckedChanged += new System.EventHandler(this.SellerLoadoutOMatic_CheckedChanged);
			// 
			// SellerCloneMachine
			// 
			this.SellerCloneMachine.AutoSize = true;
			this.SellerCloneMachine.Location = new System.Drawing.Point(6, 107);
			this.SellerCloneMachine.Name = "SellerCloneMachine";
			this.SellerCloneMachine.Size = new System.Drawing.Size(125, 22);
			this.SellerCloneMachine.TabIndex = 3;
			this.SellerCloneMachine.Text = "Clone Machine";
			this.SellerCloneMachine.UseVisualStyleBackColor = true;
			this.SellerCloneMachine.CheckedChanged += new System.EventHandler(this.SellerCloneMachine_CheckedChanged);
			// 
			// SellerATMMachine
			// 
			this.SellerATMMachine.AutoSize = true;
			this.SellerATMMachine.Location = new System.Drawing.Point(6, 79);
			this.SellerATMMachine.Name = "SellerATMMachine";
			this.SellerATMMachine.Size = new System.Drawing.Size(117, 22);
			this.SellerATMMachine.TabIndex = 2;
			this.SellerATMMachine.Text = "ATM Machine";
			this.SellerATMMachine.UseVisualStyleBackColor = true;
			this.SellerATMMachine.CheckedChanged += new System.EventHandler(this.SellerATMMachine_CheckedChanged);
			// 
			// SellerArtOfTheDealSale
			// 
			this.SellerArtOfTheDealSale.AutoSize = true;
			this.SellerArtOfTheDealSale.Location = new System.Drawing.Point(6, 51);
			this.SellerArtOfTheDealSale.Name = "SellerArtOfTheDealSale";
			this.SellerArtOfTheDealSale.Size = new System.Drawing.Size(152, 22);
			this.SellerArtOfTheDealSale.TabIndex = 1;
			this.SellerArtOfTheDealSale.Text = "Art of the Deal Sale";
			this.SellerArtOfTheDealSale.UseVisualStyleBackColor = true;
			this.SellerArtOfTheDealSale.CheckedChanged += new System.EventHandler(this.SellerArtOfTheDealSale_CheckedChanged);
			// 
			// SellerDefaultSale
			// 
			this.SellerDefaultSale.AutoSize = true;
			this.SellerDefaultSale.Checked = true;
			this.SellerDefaultSale.Location = new System.Drawing.Point(6, 23);
			this.SellerDefaultSale.Name = "SellerDefaultSale";
			this.SellerDefaultSale.Size = new System.Drawing.Size(105, 22);
			this.SellerDefaultSale.TabIndex = 0;
			this.SellerDefaultSale.TabStop = true;
			this.SellerDefaultSale.Text = "Default Sale";
			this.SellerDefaultSale.UseVisualStyleBackColor = true;
			this.SellerDefaultSale.CheckedChanged += new System.EventHandler(this.SellerDefaultSale_CheckedChanged);
			// 
			// RelationshipBar
			// 
			this.RelationshipBar.LargeChange = 1;
			this.RelationshipBar.Location = new System.Drawing.Point(6, 22);
			this.RelationshipBar.Maximum = 5;
			this.RelationshipBar.Minimum = 1;
			this.RelationshipBar.Name = "RelationshipBar";
			this.RelationshipBar.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.RelationshipBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.RelationshipBar.Size = new System.Drawing.Size(45, 100);
			this.RelationshipBar.TabIndex = 12;
			this.RelationshipBar.Value = 1;
			// 
			// RelationshipGroup
			// 
			this.RelationshipGroup.Controls.Add(this.RelationshipLabel);
			this.RelationshipGroup.Controls.Add(this.RelationshipBar);
			this.RelationshipGroup.Location = new System.Drawing.Point(12, 239);
			this.RelationshipGroup.Name = "RelationshipGroup";
			this.RelationshipGroup.Size = new System.Drawing.Size(127, 125);
			this.RelationshipGroup.TabIndex = 13;
			this.RelationshipGroup.TabStop = false;
			this.RelationshipGroup.Text = "Relationship";
			// 
			// RelationshipLabel
			// 
			this.RelationshipLabel.AutoSize = true;
			this.RelationshipLabel.Location = new System.Drawing.Point(35, 26);
			this.RelationshipLabel.Name = "RelationshipLabel";
			this.RelationshipLabel.Size = new System.Drawing.Size(84, 90);
			this.RelationshipLabel.TabIndex = 13;
			this.RelationshipLabel.Text = "Submissive\r\nAligned\r\nLoyal\r\nFriendly\r\nNeutral";
			// 
			// OperationsList
			// 
			this.OperationsList.HideSelection = false;
			this.OperationsList.Location = new System.Drawing.Point(438, 100);
			this.OperationsList.Name = "OperationsList";
			this.OperationsList.Size = new System.Drawing.Size(184, 346);
			this.OperationsList.TabIndex = 14;
			this.OperationsList.UseCompatibleStateImageBehavior = false;
			this.OperationsList.View = System.Windows.Forms.View.List;
			// 
			// ShopkeepersBigQuestBox
			// 
			this.ShopkeepersBigQuestBox.AutoSize = true;
			this.ShopkeepersBigQuestBox.Location = new System.Drawing.Point(18, 211);
			this.ShopkeepersBigQuestBox.Name = "ShopkeepersBigQuestBox";
			this.ShopkeepersBigQuestBox.Size = new System.Drawing.Size(218, 22);
			this.ShopkeepersBigQuestBox.TabIndex = 15;
			this.ShopkeepersBigQuestBox.Text = "Has Shopkeeper\'s Big Quest";
			this.ShopkeepersBigQuestBox.UseVisualStyleBackColor = true;
			this.ShopkeepersBigQuestBox.CheckedChanged += new System.EventHandler(this.ShopkeepersBigQuestBox_CheckedChanged);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 519);
			this.Controls.Add(this.ShopkeepersBigQuestBox);
			this.Controls.Add(this.OperationsList);
			this.Controls.Add(this.RelationshipGroup);
			this.Controls.Add(this.SellersGroup);
			this.Controls.Add(this.BuyersGroup);
			this.Controls.Add(this.TraitsGroup);
			this.Controls.Add(this.LevelGroup);
			this.Controls.Add(this.ItemValueLabel);
			this.Controls.Add(this.ItemValueBox);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form2";
			this.Text = "Form2";
			((System.ComponentModel.ISupportInitialize)(this.ItemValueBox)).EndInit();
			this.LevelGroup.ResumeLayout(false);
			this.LevelGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.TraitsGroup.ResumeLayout(false);
			this.TraitsGroup.PerformLayout();
			this.BuyersGroup.ResumeLayout(false);
			this.BuyersGroup.PerformLayout();
			this.SellersGroup.ResumeLayout(false);
			this.SellersGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RelationshipBar)).EndInit();
			this.RelationshipGroup.ResumeLayout(false);
			this.RelationshipGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label ItemValueLabel;
		private System.Windows.Forms.GroupBox LevelGroup;
		public System.Windows.Forms.NumericUpDown ItemValueBox;
		private System.Windows.Forms.CheckBox QuickGameBox;
		private System.Windows.Forms.Label LevelLabel;
		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.GroupBox TraitsGroup;
		private System.Windows.Forms.CheckBox HighCostsBox;
		private System.Windows.Forms.CheckBox GoodTrader2Box;
		private System.Windows.Forms.CheckBox BadTraderBox;
		private System.Windows.Forms.CheckBox GoodTraderBox;
		private System.Windows.Forms.CheckBox HonorAmongThieves2Box;
		private System.Windows.Forms.CheckBox HonorAmongThievesBox;
		private System.Windows.Forms.GroupBox BuyersGroup;
		private System.Windows.Forms.RadioButton BuyerSellOMatic;
		private System.Windows.Forms.RadioButton BuyerPortableSellOMatic;
		private System.Windows.Forms.GroupBox SellersGroup;
		private System.Windows.Forms.RadioButton SellerArtOfTheDealSale;
		private System.Windows.Forms.RadioButton SellerDefaultSale;
		private System.Windows.Forms.TrackBar RelationshipBar;
		private System.Windows.Forms.GroupBox RelationshipGroup;
		private System.Windows.Forms.Label RelationshipLabel;
		private System.Windows.Forms.RadioButton SellerATMMachine;
		private System.Windows.Forms.RadioButton SellerCloneMachine;
		private System.Windows.Forms.RadioButton SellerLoadoutOMatic;
		private System.Windows.Forms.RadioButton SellerAmmoDispenser;
		private System.Windows.Forms.ListView OperationsList;
		private System.Windows.Forms.CheckBox ShopkeepersBigQuestBox;
	}
}