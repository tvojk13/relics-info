using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace relicsInfo
{
	class TesseractUtils 
	{
		public static string json = System.IO.File.ReadAllText(@"listNames.json");
		public static Dictionary<string, string> collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
		public static ICollection<string> keys = collection.Keys;

		public static string getItemOnPic(int xPos, int yPos, int rectWidth, int rectHeight)
		{
			var region = new Rect(xPos, yPos, rectWidth, rectHeight);
			using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
			{
				engine.SetVariable("tessedit_char_whitelist", " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
				using (var img = Pix.LoadFromFile("screenshot.png"))
				{
					List<string> wordsList = new List<string>();
					var page = engine.Process(img, region, PageSegMode.AutoOsd); // AUTOOSD OR SPARSETEXT
					var iterator = page.GetIterator();

					do
					{
						wordsList.Add(iterator.GetText(PageIteratorLevel.Word));
					}
					while (iterator.Next(PageIteratorLevel.Word));

					string itemOnPic = string.Join(" ", wordsList);
					itemOnPic = itemOnPic.TrimStart(' ');

					return getExactItemName(itemOnPic);
				}
			}
		}

		private static string getExactItemName(string itemOnPic)
		{
			foreach (string key in keys)
			{
				if (itemOnPic.Contains(key) | key.Contains(itemOnPic) & itemOnPic != "" & itemOnPic != null)
				{
					return key;
				}
			}

			return "failed to recognize";
		}

		public static void takeScreenshot()
		{
			Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
			Bitmap screenshot = new Bitmap(screenBounds.Width, screenBounds.Height);

			using (Graphics graphics = Graphics.FromImage(screenshot))
			{
				// copy to bitmap
				graphics.CopyFromScreen(Point.Empty, Point.Empty, screenBounds.Size);
			}

			screenshot.Save("screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
		}
	}

	
}
