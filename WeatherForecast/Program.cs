using WeatherForecast.Facades;
using WeatherForecast.Facades.Interfaces;
using WeatherForecast.Services;
using WeatherForecast.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registering the WeatherForecastFacade and WeatherForecastService
builder.Services.AddScoped<IWeatherForecastFacade, WeatherForecastFacade>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

// Configuring HttpClient for external API calls
builder.Services.AddHttpClient<IWeatherForecastService, WeatherForecastService>(client =>
{
    var baseUrl = builder.Configuration["WeatherApi:BaseUrl"];
    client.BaseAddress = new Uri(baseUrl); //Use base URL from appsettings
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
