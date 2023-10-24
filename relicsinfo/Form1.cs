using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using Tesseract;


// 3 binds

namespace relicsInfo
{
	public partial class Form1 : Form
	{
		[DllImport("user32.dll")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
		private const int MY_HOTKEY_ID_2 = 2;
		private const int MY_HOTKEY_ID_3 = 3;
		private const int MY_HOTKEY_ID_4 = 4;

		public Form1()
		{
			InitializeComponent();
			NamesUpdate();
			bool success0 = RegisterHotKey(this.Handle, MY_HOTKEY_ID_2, 0x0006, (uint)Keys.D2);
			bool success1 = RegisterHotKey(this.Handle, MY_HOTKEY_ID_3, 0x0006, (uint)Keys.D3);
			bool success2 = RegisterHotKey(this.Handle, MY_HOTKEY_ID_4, 0x0006, (uint)Keys.D4);
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			if (m.Msg == 0x0312)
			{
				int hotkeyId = m.WParam.ToInt32();

				if (hotkeyId == MY_HOTKEY_ID_2)
				{
					GetItemsInfo(MY_HOTKEY_ID_2);
				}
				else if (hotkeyId == MY_HOTKEY_ID_3)
				{
					GetItemsInfo(MY_HOTKEY_ID_3);
				}
				else if (hotkeyId == MY_HOTKEY_ID_4)
				{
					GetItemsInfo(MY_HOTKEY_ID_4);
				}
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			UnregisterHotKey(this.Handle, MY_HOTKEY_ID_2);
			UnregisterHotKey(this.Handle, MY_HOTKEY_ID_3);
			UnregisterHotKey(this.Handle, MY_HOTKEY_ID_4);
			base.OnFormClosing(e);
		}

		async void GetItemsInfo(int rewardsCount)
		{
			List<TessRectangle> rectangles = TessRectangle.getRectangles(rewardsCount);
			TesseractUtils.takeScreenshot();

			for (int i = 0; i < rewardsCount; i++)
			{
				Item item = new(rectangles[i]);
				item.createItem();
			}

			rectangles.Clear();
		}

		public async Task NamesUpdate()
		{
			updateTime.Text = System.DateTime.Now.ToString();
			string response = await WebSurfer.MakeRequest("https://api.warframe.market/v1/items");
			JObject json = JObject.Parse(response);
			var itemsHash = json["payload"]["items"];
			Dictionary<string, string> itemsDictionary = new Dictionary<string, string>(itemsHash.Count());

			foreach (var item in itemsHash)
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
		}
	}
}
