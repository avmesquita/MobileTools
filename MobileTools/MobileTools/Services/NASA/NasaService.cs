using MobileTools.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MobileTools.Services.NASA
{
	public class NasaService
	{
		private async System.Threading.Tasks.Task<NasaAPOD> getAPODAsync()
		{
			var obj = new
			{
				url = "https://api.nasa.gov/planetary/apod",
				date = DateTime.Now.ToString("yyyy-MM-dd"),
                hd = true,
                api_key = "DEMO_KEY"
			};			

			string endpoint = $"{obj.url}?api_key={obj.api_key}&date={obj.date}&hd={obj.hd.ToString().ToLower()}";

			using (var client = new HttpClient(new System.Net.Http.HttpClientHandler()))
			{
				var result = await client.GetAsync(endpoint);
				result.EnsureSuccessStatusCode();
				var resultString = await result.Content.ReadAsStringAsync();
				var deserialized = JsonConvert.DeserializeObject<NasaAPOD>(resultString);
				return deserialized;
			}
		}

		private NasaAPOD getAPOD()
		{
			var obj = new
			{
				url = "https://api.nasa.gov/planetary/apod",
				date = DateTime.Now.ToString("yyyy-MM-dd"),
				hd = true,
				api_key = "DEMO_KEY"
			};

			string endpoint = $"{obj.url}?api_key={obj.api_key}"; // &date={obj.date}&hd={obj.hd.ToString().ToLower()}";

			using (var client = new HttpClient(new System.Net.Http.HttpClientHandler()))
			{
				var result =  client.GetAsync(endpoint);

				var retobj = result.Result.Content.ReadAsStringAsync();

				var deserialized = JsonConvert.DeserializeObject<NasaAPOD>(retobj.Result.ToString());

				return deserialized;
			}
		}

		public byte[] getAstronomicPicOfDay()
		{
			var apod = this.getAPOD();

			return this.getImageFromURL(apod.hdurl);		
		}

		private byte[] getImageFromURL(string url)
		{
			using (var client = new HttpClient(new System.Net.Http.HttpClientHandler()))
			{
				var result = client.GetByteArrayAsync(url);
								
				return result.Result;
			}
		}

	}
}
