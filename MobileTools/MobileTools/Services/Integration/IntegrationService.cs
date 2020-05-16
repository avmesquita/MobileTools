using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MobileTools.Services.Integration
{
	public class IntegrationService
	{
		public async System.Threading.Tasks.Task<dynamic> PostAsync(object obj, string endpoint)
		{
			using (var client = new HttpClient(new System.Net.Http.HttpClientHandler()))
			{				
				var json = JsonConvert.SerializeObject(obj);
				var content = new StringContent(json, Encoding.UTF8, "application/json");				
				var result = await client.PostAsync(endpoint, content);
				result.EnsureSuccessStatusCode();
				var resultString = await result.Content.ReadAsStringAsync();
				var deserialized = JsonConvert.DeserializeObject(resultString);
				return deserialized;
			}
		}
	}
}
