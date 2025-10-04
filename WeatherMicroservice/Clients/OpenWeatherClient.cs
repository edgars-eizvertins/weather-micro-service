using System.Text.Json;

namespace WeatherMicroservice.Clients
{
	public class OpenWeatherClient : IOpenWeatherClient
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;

		public OpenWeatherClient(HttpClient httpClient, IConfiguration config)
		{
			_httpClient = httpClient;
			_apiKey = config["OpenWeatherApiKey"] ?? "";
		}

		public async Task<JsonDocument?> GetCurrentWeatherAsync(string city, string country)
		{
			var url = $"https://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid={_apiKey}&units=metric";
			return await MakeRequest(url);
		}

		public async Task<JsonDocument?> GetForecastAsync(string city, string country)
		{
			var url = $"https://api.openweathermap.org/data/2.5/forecast?q={city},{country}&appid={_apiKey}&units=metric";
			return await MakeRequest(url);
		}
		
		private async Task<JsonDocument?> MakeRequest(string url)
		{
			var response = await _httpClient.GetAsync(url);
			if (!response.IsSuccessStatusCode) return null;
			var stream = await response.Content.ReadAsStreamAsync();
			return await JsonDocument.ParseAsync(stream);
		}
    }
}
