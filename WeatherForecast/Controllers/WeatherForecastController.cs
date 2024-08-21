using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Facades.Interfaces;

namespace WeatherForecast.Controllers
{
    /// <summary>
    /// Controller to handle weather forecast requests.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastFacade _weatherForecastFacade;

        /// <summary>
        /// Creates a new instance of <see cref="WeatherForecastController"/>.
        /// </summary>
        /// <param name="weatherForecastFacade">Facade for weather forecast data.</param>
        public WeatherForecastController(IWeatherForecastFacade weatherForecastFacade)
        {
            _weatherForecastFacade = weatherForecastFacade;
        }

        /// <summary>
        /// Retrieves the weather forecast for a given city.
        /// </summary>
        /// <param name="city">City name to get the forecast for.</param>
        /// <returns>Weather forecast data or an error message.</returns>
        [HttpGet("forecast")]
        public async Task<ActionResult<WeatherForecastResponse>> GetWeather([FromQuery] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City name must be provided.");
            }

            var weatherResponse = await _weatherForecastFacade.GetWeatherAsync(city);

            if (weatherResponse is null)
            {
                return NotFound("Weather data not found for the specified city.");
            }

            return Ok(weatherResponse);
        }
    }
}
