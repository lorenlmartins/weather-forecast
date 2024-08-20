using WeatherForecast.Models;
using WeatherForecast.Interfaces.Facades;
using WeatherForecast.Services;

namespace WeatherForecast.Facades
{
    public class WeatherForecastFacade : IWeatherForecastFacade
    {
        private readonly WeatherForecastService _weatherForecastService;

        public WeatherForecastFacade(WeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public async Task<WeatherForecastResponse> GetWeatherAsync(string cityName)
        {
            return await _weatherForecastService.GetWeatherAsync(cityName);
        }
    }
}
