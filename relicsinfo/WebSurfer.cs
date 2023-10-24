using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relicsInfo
{
	class WebSurfer
	{
		public static async Task<string> MakeRequest(string url)
		{
			using (var httpClient = new HttpClient())
			{
				try
				{
					HttpResponseMessage response = await httpClient.GetAsync(url);
					response.EnsureSuccessStatusCode();
					string jsonString = await response.Content.ReadAsStringAsync();
					return jsonString;
				}
				catch (HttpRequestException ex)
				{
					return ex.Message;
				}
			}
		}
	}
}
