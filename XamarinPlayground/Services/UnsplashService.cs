using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinPlayground.Models;

namespace XamarinPlayground.Services
{
	public class UnsplashService: IUnsplashService
	{
		private readonly HttpClient client;

		public UnsplashService(string apiKey)
		{
			client = new HttpClient() { BaseAddress = new Uri("https://api.unsplash.com/") };
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Client-ID", apiKey);
		}

		public async Task<IEnumerable<Photo>> GetRandomPhotosAsync(int count = 1)
		{
			var response = await client.GetAsync($"photos/random?count={count}");
			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				try
				{
					var photos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(json);
					return photos;
				}
				catch (Exception ex)
				{
				}
			}

			return null;
		}
	}
}
