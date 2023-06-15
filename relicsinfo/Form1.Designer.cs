namespace relicsInfo
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.LAST_UPDATE_LABEL = new System.Windows.Forms.Label();
			this.updateButton = new System.Windows.Forms.Button();
			this.updateTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LAST_UPDATE_LABEL
			// 
			this.LAST_UPDATE_LABEL.AutoSize = true;
			this.LAST_UPDATE_LABEL.Location = new System.Drawing.Point(12, 9);
			this.LAST_UPDATE_LABEL.Name = "LAST_UPDATE_LABEL";
			this.LAST_UPDATE_LABEL.Size = new System.Drawing.Size(98, 15);
			this.LAST_UPDATE_LABEL.TabIndex = 0;
			this.LAST_UPDATE_LABEL.Text = "Last update base:";
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(148, 58);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(68, 23);
			this.updateButton.TabIndex = 1;
			this.updateButton.Text = "Update";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// updateTime
			// 
			this.updateTime.AutoSize = true;
			this.updateTime.Location = new System.Drawing.Point(12, 24);
			this.updateTime.Name = "updateTime";
			this.updateTime.Size = new System.Drawing.Size(31, 15);
			this.updateTime.TabIndex = 2;
			this.updateTime.Text = "time";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(228, 93);
			this.Controls.Add(this.updateTime);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.LAST_UPDATE_LABEL);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.Name = "Form1";
			this.Text = "Main";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label LAST_UPDATE_LABEL;
		private Button updateButton;
		private Label updateTime;
	}
}