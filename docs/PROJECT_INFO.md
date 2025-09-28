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

---
This file will be updated with any changes to requirements or project scope.
