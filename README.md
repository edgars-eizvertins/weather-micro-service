# Weather Microservice

A small .NET 8 C# microservice that fetches weather data from OpenWeather and exposes a simple REST API.

## Summary
- Returns current weather, hourly forecast, and 3-day forecast
- Metric units only
- Token-based query parameter authentication
- Docker-ready (x64/arm64)
- Unit tests in `WeatherMicroservice.Tests`

## Quick start (local)
1. Copy template to local dev appsettings (ignored by git):

```bash
cp WeatherMicroservice/appsettings.json.template WeatherMicroservice/appsettings.Development.json
# edit WeatherMicroservice/appsettings.Development.json and set
# WeatherApiToken and OpenWeatherApiKey
```

2. Run the app (both HTTP and HTTPS):

```bash
dotnet run --project WeatherMicroservice/WeatherMicroservice.csproj --urls "http://localhost:5000;https://localhost:5001"
```

3. Call the API:

```
http://localhost:5000/api/weather?city=Riga&country=LV&token=YOUR_TOKEN
```

## Tests
Run tests in terminal:

```bash
dotnet test WeatherMicroservice.Tests/WeatherMicroservice.Tests.csproj
```

To use VS Code Test Explorer, install the C# extension (C# Dev Kit or OmniSharp) and reload the window.

## Debugging in VS Code
- Open the workspace root in VS Code.
- Set a breakpoint in `WeatherMicroservice/Controllers/WeatherController.cs`.
- Run the `.NET Core Launch (web)` configuration from the Run and Debug panel.

## Docs
- `docs/ARCHITECTURE.md` – architecture and SOLID notes
- `docs/DEPLOYMENT.md` – docker, run & debug instructions
- `docs/PROJECT_INFO.md` – project summary, requirements, and notes

---
If you want, I can also add a GitHub Actions workflow to run tests on push.