using System.Text.Json.Serialization;

namespace WeatherForecast.Models
{
    public class WeatherForecastResponse
    {
        [JsonPropertyName("results")]
        public WeatherForecastResults Results { get; set; }
    }
}
