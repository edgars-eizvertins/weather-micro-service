using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WeatherMicroservice.Models;
using WeatherMicroservice.Services;

namespace WeatherMicroservice.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WeatherController : ControllerBase
	{
		private readonly WeatherService _weatherService;
		private readonly ILogger<WeatherController> _logger;

		public WeatherController(WeatherService weatherService, ILogger<WeatherController> logger)
		{
			_weatherService = weatherService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] string city, [FromQuery] string country)
		{
			if (string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(country))
			{
				_logger.LogWarning("Missing city or country parameter.");
				return BadRequest(new { error = "Missing city or country parameter." });
			}

			var result = await _weatherService.GetWeatherAsync(city, country);
			if (result == null)
			{
				_logger.LogError($"Failed to fetch weather for {city}, {country}.");
				return StatusCode(502, new { error = "Failed to fetch weather data." });
			}
			return Ok(result);
		}
	}
}
