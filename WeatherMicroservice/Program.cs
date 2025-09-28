using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register OpenWeatherClient and WeatherService
builder.Services.AddHttpClient<WeatherMicroservice.Clients.IOpenWeatherClient, WeatherMicroservice.Clients.OpenWeatherClient>();
builder.Services.AddScoped<WeatherMicroservice.Services.WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use custom token authentication middleware
app.UseMiddleware<WeatherMicroservice.Middleware.TokenAuthenticationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
