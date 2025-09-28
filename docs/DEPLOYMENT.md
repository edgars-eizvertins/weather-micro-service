# Deployment Instructions

## Building Docker Images

### x64 Architecture
```
docker build -t weather-microservice:x64 --platform linux/amd64 .
```

### ARM64 Architecture
```
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

## Updating Tokens
- Change the value in your environment or Docker Compose file and restart the service.

---
This document will be updated as the project evolves.
