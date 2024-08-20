using System.Text.Json.Serialization;

namespace WeatherForecast.Models
{
    public class WeatherForecastResults
    {
        [JsonPropertyName("temp")]
        public int Temp { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("forecast")]
        public List<Forecast> Forecast { get; set; }
    }
}
