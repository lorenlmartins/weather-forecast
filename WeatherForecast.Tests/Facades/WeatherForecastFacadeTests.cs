using Moq;
using WeatherForecast.Facades;
using WeatherForecast.Models;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Tests.Facades
{
    public class WeatherForecastFacadeTests
    {
        [Fact]
        public async Task GetWeatherAsync_ReturnsWeatherForecastResponse()
        {
            // Arrange
            var mockWeatherService = new Mock<IWeatherForecastService>();
            var cityName = "Uberlândia";
            var expectedResponse = new WeatherForecastResponse();

            mockWeatherService
                .Setup(service => service.GetWeatherAsync(cityName))
                .ReturnsAsync(expectedResponse);

            var facade = new WeatherForecastFacade(mockWeatherService.Object);

            // Act
            var result = await facade.GetWeatherAsync(cityName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse, result);
        }
    }
}