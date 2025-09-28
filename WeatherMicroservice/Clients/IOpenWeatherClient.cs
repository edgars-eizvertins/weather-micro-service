using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherMicroservice.Clients
{
    public interface IOpenWeatherClient
    {
        Task<JsonDocument?> GetCurrentWeatherAsync(string city, string country);
        Task<JsonDocument?> GetForecastAsync(string city, string country);
    }
}
