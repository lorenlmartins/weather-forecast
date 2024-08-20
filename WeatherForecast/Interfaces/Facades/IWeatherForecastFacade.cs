using WeatherForecast.Models;

namespace WeatherForecast.Interfaces.Facades
{
    public interface IWeatherForecastFacade
    {
        Task<WeatherForecastResponse> GetWeatherAsync(string cityName);
    }
}
