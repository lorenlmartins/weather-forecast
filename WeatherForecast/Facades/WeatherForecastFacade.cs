using WeatherForecast.Models;
using WeatherForecast.Services;
using WeatherForecast.Facades.Interfaces;

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
