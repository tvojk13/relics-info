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
			this.Dispose();
		}
	}
}
