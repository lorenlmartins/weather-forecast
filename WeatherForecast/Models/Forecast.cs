using System.Text.Json.Serialization;

namespace WeatherForecast.Models
{
    public class Forecast
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }

        [JsonPropertyName("min")]
        public int Min { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}