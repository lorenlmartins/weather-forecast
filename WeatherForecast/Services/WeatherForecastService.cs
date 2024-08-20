using System.Text.Json;
using WeatherForecast.Models;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherForecastService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["WeatherApi:ApiKey"];
        }

        public async Task<WeatherForecastResponse> GetWeatherAsync(string cityName)
        {
            var encodedCity = System.Net.WebUtility.UrlEncode(cityName);
            var requestUri = $"weather?key={_apiKey}&city_name={encodedCity}";

            var response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var weatherResponse = JsonSerializer.Deserialize<WeatherForecastResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return weatherResponse;
            }

            return null;
        }
    }
}
