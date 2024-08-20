using WeatherForecast.Models;

namespace WeatherForecast.Facades.Interfaces
{
    /// <summary>
    /// Provides weather data for a specified city.
    /// </summary>
    public interface IWeatherForecastFacade
    {
        /// <summary>
        /// Gets the weather forecast for a city.
        /// </summary>
        /// <param name="cityName">The city's name.</param>
        /// <returns>The weather forecast.</returns>
        Task<WeatherForecastResponse> GetWeatherAsync(string cityName);
    }
}
