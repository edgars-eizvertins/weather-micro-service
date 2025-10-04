# Deployment Instructions

## Building Docker Images

### x64 Architecture
```bash
docker build -t weather-microservice:x64 --platform linux/amd64 .
```

### ARM64 Architecture
```bash
docker build -t weather-microservice:arm64 --platform linux/arm64 .
```

## Running with Docker Compose
1. Edit `docker-compose.yml` to select the desired image/architecture.
2. Run:
```
docker compose up -d
```

## Pushing to Docker Hub
```
docker tag weather-microservice:x64 <your-dockerhub-username>/weather-microservice:x64
docker tag weather-microservice:arm64 <your-dockerhub-username>/weather-microservice:arm64

docker push <your-dockerhub-username>/weather-microservice:x64
docker push <your-dockerhub-username>/weather-microservice:arm64
```

## Environment Variables
- `WEATHER_API_TOKEN`: Static token for authentication
- `OPENWEATHER_API_KEY`: API key for OpenWeather

## Local run & debug (HTTP/HTTPS)

To run locally (both HTTP and HTTPS):

```bash
dotnet run --project WeatherMicroservice/WeatherMicroservice.csproj --urls "http://localhost:5000;https://localhost:5001"
```

In VS Code debugging, `launch.json` and `launchSettings.json` have been prepared to expose both endpoints. If HTTP still doesn't work in the debugger, run the command above in the terminal to confirm.

## Updating Tokens
- Change the value in your environment or Docker Compose file and restart the service.

---
This document will be updated as the project evolves.
