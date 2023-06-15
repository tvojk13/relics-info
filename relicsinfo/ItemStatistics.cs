using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace relicsInfo
{
	public class Rootobject
	{
		public Payload payload { get; set; }
	}

	public class Payload
	{
		public Statistics_Closed statistics_closed { get; set; }
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
