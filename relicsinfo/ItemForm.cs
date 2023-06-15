using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace relicsInfo
{
	public partial class ItemForm : Form
	{
		public ItemForm()
		{
			InitializeComponent();
		}
		

		private void Form1_Load(object sender, EventArgs e)
		{
			ExistenceTimer.Interval = 15000;
			ExistenceTimer.Enabled = true;
		}

		private void ExistenceTimer_Tick(object sender, EventArgs e)
		{
			// Закрыть форму
			this.Dispose();
		}
	}
}
