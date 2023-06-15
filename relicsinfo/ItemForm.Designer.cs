namespace relicsInfo
{
	partial class ItemForm
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
			this.components = new System.ComponentModel.Container();
			this.AVG_PRICE_LABEL = new System.Windows.Forms.Label();
			this.avgPrice = new System.Windows.Forms.Label();
			this.itemName = new System.Windows.Forms.Label();
			this.ExistenceTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// AVG_PRICE_LABEL
			// 
			this.AVG_PRICE_LABEL.AutoSize = true;
			this.AVG_PRICE_LABEL.Location = new System.Drawing.Point(12, 24);
			this.AVG_PRICE_LABEL.Name = "AVG_PRICE_LABEL";
			this.AVG_PRICE_LABEL.Size = new System.Drawing.Size(146, 15);
			this.AVG_PRICE_LABEL.TabIndex = 0;
			this.AVG_PRICE_LABEL.Text = "average price for 48 hours:";
			// 
			// avgPrice
			// 
			this.avgPrice.AutoSize = true;
			this.avgPrice.Location = new System.Drawing.Point(164, 24);
			this.avgPrice.Name = "avgPrice";
			this.avgPrice.Size = new System.Drawing.Size(13, 15);
			this.avgPrice.TabIndex = 1;
			this.avgPrice.Text = "0";
			// 
			// itemName
			// 
			this.itemName.AutoSize = true;
			this.itemName.Location = new System.Drawing.Point(12, 9);
			this.itemName.Name = "itemName";
			this.itemName.Size = new System.Drawing.Size(37, 15);
			this.itemName.TabIndex = 2;
			this.itemName.Text = "name";
			// 
			// ExistenceTimer
			// 
			this.ExistenceTimer.Enabled = true;
			this.ExistenceTimer.Interval = 14000;
			this.ExistenceTimer.Tick += new System.EventHandler(this.ExistenceTimer_Tick);
			// 
			// ItemForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(224, 101);
			this.Controls.Add(this.itemName);
			this.Controls.Add(this.avgPrice);
			this.Controls.Add(this.AVG_PRICE_LABEL);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ItemForm";
			this.Text = "ItemForm";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label AVG_PRICE_LABEL;
		private Label avgPrice;
		private Label itemName;
		private System.Windows.Forms.Timer ExistenceTimer;
	}
}