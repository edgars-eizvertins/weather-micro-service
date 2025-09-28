namespace WeatherMicroservice.Models
{
    public class WeatherResponse
    {
		public string Now { get; set; } = DateTime.Now.ToString();
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public int Cloud { get; set; }
        public double? Rain { get; set; }
        public double? Snow { get; set; }
        public double WindSpeed { get; set; }
        public string Condition { get; set; } = string.Empty;
        public List<ForecastItem> HourlyForecast { get; set; } = new();
        public List<ForecastItem> DailyForecast { get; set; } = new();
    }

    public class ForecastItem
    {
        public DateTime DateTime { get; set; }
        public double Temperature { get; set; }
        public int Cloud { get; set; }
        public double? Rain { get; set; }
        public double? Snow { get; set; }
        public double WindSpeed { get; set; }
        public string Condition { get; set; } = string.Empty;
    }
}
