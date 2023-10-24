using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace relicsInfo
{
	public class RootObject
	{
		public Payload payload { get; set; }
	}

	public class Payload
	{
		public Items[] items { get; set; }
		public Statistics_Closed statistics_closed { get; set; }
	}

	public class Items
	{
		public string url_name { get; set; }
		public string icon { get; set; }
		public string item_name { get; set; }
		public string riven_type { get; set; }
		public string id { get; set; }
		public string group { get; set; }
		public int mastery_level { get; set; }
	}

	public class Statistics_Closed
	{
		[JsonProperty("48hours")]
		public _48Hours[] _48hours { get; set; }
	}

	public class _48Hours
	{
		public float avg_price { get; set; }
	}
}
