# Project Info & Requirements

## Summary
- .NET 8 C# REST API microservice
- Returns current weather, hourly forecast, and 3-day forecast
- Uses OpenWeather API (free tier)
- Metric units only
- Requires city name and country code in request
- Token-based authentication via query parameter
- Basic logging and error handling
- Docker support for x64 and ARM64
- Unit tests for main business logic
- Follows SOLID principles

## To-Do
- Scaffold .NET project ✅
- Implement authentication middleware ✅
- Integrate OpenWeather API client ✅
- Implement WeatherService and controller ✅
- Add logging and error handling ✅
- Write unit tests (basic test added, expand as needed)
- Prepare Docker and Compose files ✅
- Update documentation as needed

## Instructions
- Set your `WEATHER_API_TOKEN` and `OPENWEATHER_API_KEY` in `appsettings.json`, environment, or docker-compose.
- Build and run with Docker or Docker Compose for x64/arm64 (see DEPLOYMENT.md).
- API endpoint: `/api/weather?city={city}&country={country}&token={token}`
- Returns JSON with current weather, hourly and 3-day forecast (metric units).
- Token must match configured value.
- Logging and error handling are included.

## Running & Testing

- To run the app locally (both HTTP and HTTPS):

```bash
dotnet run --project WeatherMicroservice/WeatherMicroservice.csproj --urls "http://localhost:5000;https://localhost:5001"
```

- To run tests from the terminal:

```bash
dotnet test WeatherMicroservice.Tests/WeatherMicroservice.Tests.csproj
```

- Test Explorer in VS Code: ensure the Microsoft C# extension is installed (C# Dev Kit or OmniSharp). Reload the window after installing. The Test Explorer should discover tests from the `WeatherMicroservice.Tests` project. If tests run in the terminal but not in the Test Explorer, open the test project folder in the workspace root and check the "Output" pane for the test adapter logs.

---
This file will be updated with any changes to requirements or project scope.
