using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving weather data.
    /// </summary>
    public interface IWeatherForecastService
    {
        /// <summary>
        /// Gets the weather forecast for a city.
        /// </summary>
        /// <param name="cityName">The city's name.</param>
        /// <returns>The weather forecast.</returns>
        Task<WeatherForecastResponse> GetWeatherAsync(string cityName);
    }
}
