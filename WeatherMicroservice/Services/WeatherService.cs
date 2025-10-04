using System.Text.Json;
using WeatherMicroservice.Clients;
using WeatherMicroservice.Models;

namespace WeatherMicroservice.Services
{
	public class WeatherService
	{
		private readonly IOpenWeatherClient _client;

		public WeatherService(IOpenWeatherClient client)
		{
			_client = client;
		}

		public async Task<WeatherResponse?> GetWeatherAsync(string city, string country)
		{
			var currentDocTask = _client.GetCurrentWeatherAsync(city, country);
			var forecastDocTask = _client.GetForecastAsync(city, country);
			await Task.WhenAll(currentDocTask, forecastDocTask);

			var currentDoc = currentDocTask.Result;
			var forecastDoc = forecastDocTask.Result;

			if (currentDoc == null || forecastDoc == null) return null;

			var response = new WeatherResponse
			{
				City = city,
				Country = country
			};

			// Parse current weather
			var root = currentDoc.RootElement;
			response.Temperature = root.GetProperty("main").GetProperty("temp").GetDouble();
			response.Cloud = root.GetProperty("clouds").GetProperty("all").GetInt32();
			response.WindSpeed = root.GetProperty("wind").GetProperty("speed").GetDouble();
			response.Condition = root.GetProperty("weather")[0].GetProperty("main").GetString() ?? "";
			response.Rain = root.TryGetProperty("rain", out var rainProp) ? rainProp.GetProperty("1h").GetDouble() : (double?)null;
			response.Snow = root.TryGetProperty("snow", out var snowProp) ? snowProp.GetProperty("1h").GetDouble() : (double?)null;

			// Parse forecast (next hours and 3 days)
			var forecastRoot = forecastDoc.RootElement;
			var list = forecastRoot.GetProperty("list").EnumerateArray().ToList();
			response.HourlyForecast = list.Take(8).Select(item => ParseForecastItem(item)).ToList(); // Next 8 x 3h = 24h
			response.DailyForecast = list.GroupBy(item => item.GetProperty("dt_txt").GetString()?.Substring(0, 10))
				.Take(3)
				.Select(g => ParseForecastItem(g.First()))
				.ToList();

			return response;
		}

		private ForecastItem ParseForecastItem(JsonElement item)
		{
			return new ForecastItem
			{
				DateTime = DateTime.Parse(item.GetProperty("dt_txt").GetString() ?? ""),
				Temperature = item.GetProperty("main").GetProperty("temp").GetDouble(),
				Cloud = item.GetProperty("clouds").GetProperty("all").GetInt32(),
				WindSpeed = item.GetProperty("wind").GetProperty("speed").GetDouble(),
				Condition = item.GetProperty("weather")[0].GetProperty("main").GetString() ?? "",
				Rain = item.TryGetProperty("rain", out var rainProp) ? rainProp.GetProperty("3h").GetDouble() : (double?)null,
				Snow = item.TryGetProperty("snow", out var snowProp) ? snowProp.GetProperty("3h").GetDouble() : (double?)null
			};
		}
	}
}
