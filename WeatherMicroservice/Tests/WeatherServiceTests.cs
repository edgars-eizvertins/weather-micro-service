using System.Threading.Tasks;
using WeatherMicroservice.Clients;
using WeatherMicroservice.Models;
using WeatherMicroservice.Services;
using Xunit;
using Moq;
using System.Text.Json;

namespace WeatherMicroservice.Tests
{
    public class WeatherServiceTests
    {
        [Fact]
        public async Task GetWeatherAsync_ReturnsNull_WhenApiFails()
        {
            var clientMock = new Mock<OpenWeatherClient>(null!, null!);
            clientMock.Setup(c => c.GetCurrentWeatherAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((JsonDocument?)null);
            clientMock.Setup(c => c.GetForecastAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((JsonDocument?)null);
            var service = new WeatherService(clientMock.Object);
            var result = await service.GetWeatherAsync("Riga", "LV");
            Assert.Null(result);
        }
        // More tests can be added for parsing and valid responses
    }
}
