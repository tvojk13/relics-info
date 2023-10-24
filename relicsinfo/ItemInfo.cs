using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace relicsInfo
{
	class ItemInfo
	{
		private const string API_URL = "https://api.warframe.market/v1/items/";
		private static float avgPrice;
		public static string json = System.IO.File.ReadAllText(@"listNames.json");
		public static Dictionary<string, string> collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
		public static ICollection<string> keys = collection.Keys;

		public static async Task<string> getItemStatistic(string itemOnPic)
		{
			foreach (string key in keys)
			{
				if (itemOnPic.Contains(key) | key.Contains(itemOnPic) & itemOnPic != "" & itemOnPic != null)
				{
					float price = 0;
					string response = await WebSurfer.MakeRequest(API_URL + collection[key] + "/statistics");
					var data = JsonConvert.DeserializeObject<RootObject>(response);
					
					foreach (var item in data.payload.statistics_closed._48hours)
					{
						price += item.avg_price;
					}

					avgPrice = price / data.payload.statistics_closed._48hours.Length;
				}
			}

			return avgPrice.ToString("F2");
		}
	}
}
