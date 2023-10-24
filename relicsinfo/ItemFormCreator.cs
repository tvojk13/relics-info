using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relicsInfo
{
	class ItemFormCreator
	{
		public static ItemForm itemForm;
		private static Label avgPriceForm;
		private static Label itemNameForm;

		public static void showForm(string itemOnPic, string avgPrice, int xPos)
		{
			itemForm = new ItemForm();
			avgPriceForm = (Label)itemForm.Controls["avgPrice"];
			itemNameForm = (Label)itemForm.Controls["itemName"];

			avgPriceForm.Text = avgPrice;
			itemNameForm.Text = itemOnPic;

			itemForm.StartPosition = FormStartPosition.Manual;
			itemForm.Location = new Point(xPos, 650);
			itemForm.Show();
		}
	}
}
