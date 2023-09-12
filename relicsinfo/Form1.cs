using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using Tesseract;


namespace relicsInfo
{
	public partial class Form1 : Form
	{
		[DllImport("user32.dll")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
		private const int MY_HOTKEY_ID = 1;

		public Form1()
		{
			InitializeComponent();
			NamesUpdate();
			updateTime.Text = System.DateTime.Now.ToString();
			bool success = RegisterHotKey(this.Handle, MY_HOTKEY_ID, 0x0006, (uint)Keys.M);
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			if (m.Msg == 0x0312 && m.WParam.ToInt32() == MY_HOTKEY_ID)
			{
				GetItemsInfo();
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			UnregisterHotKey(this.Handle, MY_HOTKEY_ID);
			base.OnFormClosing(e);
		}

		async void GetItemsInfo()
		{
			int x = 460;
			int y = 220;
			int width = 250;
			int height = 242;

			string json = System.IO.File.ReadAllText(@"listNames.json");
			Dictionary<string, string> collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
			ICollection<string> keys = collection.Keys;

			TakeScreenshot();
			for (int i = 0; i < 4; i++)
			{
				Rect region = new Rect(x, y, width, height);
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

						foreach (string key in keys)
						{
							if (itemOnPic.Contains(key) | key.Contains(itemOnPic) & itemOnPic != "" & itemOnPic != null)
							{
								string response = await MakeRequest("https://api.warframe.market/v1/items/" + collection[key] + "/statistics");
								var data = JsonConvert.DeserializeObject<Rootobject>(response);
								float price = 0;
								ItemForm itemForm = new ItemForm();

								foreach (var item in data.payload.statistics_closed._48hours)
								{
									price += item.avg_price;
								}

								price = price / data.payload.statistics_closed._48hours.Length;
								Label avgPrice = (Label)itemForm.Controls["avgPrice"];
								avgPrice.Text = price.ToString("F2");
								Label itemName = (Label)itemForm.Controls["itemName"];
								itemName.Text = key;

								itemForm.StartPosition = FormStartPosition.Manual;
								itemForm.Location = new Point(x, 650);
								itemForm.Show();
							}
						}
						x += width + 5;
					}
				}
			}
		}

		public async Task<string> MakeRequest(string url)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					string jsonString = await response.Content.ReadAsStringAsync();
					JObject json = JObject.Parse(jsonString);
					string seriailizedJson = JsonConvert.SerializeObject(json);
					return seriailizedJson;
				}

			}
			catch (HttpRequestException ex)
			{
				return ex.Message;
			}
		}

		public void TakeScreenshot()
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

		public async Task NamesUpdate()
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync("https://api.warframe.market/v1/items");
			client.Dispose();

			string jsonString = await response.Content.ReadAsStringAsync();
			JObject json = JObject.Parse(jsonString);
			var itemsList = json["payload"]["items"];
			Dictionary<string, string> itemsDictionary = new Dictionary<string, string>(itemsList.Count());

			foreach (var item in itemsList)
			{
				var itemName = item["item_name"].ToString();
				var urlName = item["url_name"].ToString();
				itemsDictionary[itemName] = urlName;
			}

			string seriailizeDict = JsonConvert.SerializeObject(itemsDictionary);

			try
			{
				System.IO.File.WriteAllText(@"listNames.json", seriailizeDict);
			}
			catch (FileNotFoundException ex)
			{
				System.IO.File.Create(@"listNames.json");
				System.IO.File.WriteAllText(@"listNames.json", seriailizeDict);
			}

		}

		public void updateButton_Click(object sender, EventArgs e)
		{
			NamesUpdate();
			updateTime.Text = System.DateTime.Now.ToString();
		}
	}
}
