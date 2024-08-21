using WeatherForecast.Models;
using WeatherForecast.Services.Interfaces;
using WeatherForecast.Facades.Interfaces;

namespace WeatherForecast.Facades
{
    public class WeatherForecastFacade : IWeatherForecastFacade
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastFacade(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public async Task<WeatherForecastResponse> GetWeatherAsync(string cityName)
        {
            return await _weatherForecastService.GetWeatherAsync(cityName);
        }
    }
}
