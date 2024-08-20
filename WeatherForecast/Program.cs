using WeatherForecast.Facades;
using WeatherForecast.Facades.Interfaces;
using WeatherForecast.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registering the WeatherForecastFacade and WeatherForecastService
builder.Services.AddScoped<IWeatherForecastFacade, WeatherForecastFacade>();
builder.Services.AddScoped<WeatherForecastService>();

// Configuring HttpClient for external API calls
builder.Services.AddHttpClient<WeatherForecastService>(client =>
{
    var baseUrl = builder.Configuration["WeatherApi:BaseUrl"];
    client.BaseAddress = new Uri(baseUrl); // Usar a URL base do appsettings
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
