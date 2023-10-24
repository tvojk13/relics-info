using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace relicsInfo
{
	class Item
	{
		private TessRectangle rectangle;

		public Item(TessRectangle rectangle)
		{
			this.rectangle = rectangle;
		}

		public async void createItem()
		{
			string itemOnPic = TesseractUtils.getItemOnPic(rectangle.x, rectangle.y, rectangle.width, rectangle.height);
			string avgPrice = await ItemInfo.getItemStatistic(itemOnPic);
			ItemFormCreator.showForm(itemOnPic, avgPrice, rectangle.x);
		}
	}
}
