using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relicsInfo
{
	class JsonUtils
	{
		public static string SerializeResponse(string jsonString)
		{
			JObject json = JObject.Parse(jsonString);
			string seriailizedJson = JsonConvert.SerializeObject(json);
			return seriailizedJson;
		}

		public static RootObject DeserializeResponse(string response)
		{
			try
			{
				RootObject data = JsonConvert.DeserializeObject<RootObject>(response);
				return data;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
