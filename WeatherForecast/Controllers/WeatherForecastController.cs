using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Facades.Interfaces;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastFacade _weatherForecastFacade;

        public WeatherForecastController(IWeatherForecastFacade weatherForecastFacade)
        {
            _weatherForecastFacade = weatherForecastFacade;
        }

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
