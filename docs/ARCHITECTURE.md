# Architecture Overview

This document describes the architecture of the Weather Microservice.

## Technology Stack
- .NET 8 (C#)
- REST API
- Docker (x64 and ARM64)
- OpenWeather API (external)

## SOLID Principles
- Single Responsibility: Each class has one responsibility.
- Open/Closed: Components are open for extension, closed for modification.
- Liskov Substitution: Interfaces and base classes are substitutable.
- Interface Segregation: Fine-grained interfaces for specific needs.
- Dependency Inversion: High-level modules depend on abstractions.

## Main Components
- WeatherController: Handles API requests.
- WeatherService: Fetches and processes weather data.
- OpenWeatherClient: Communicates with OpenWeather API.
- OpenWeatherClient (implements IOpenWeatherClient): Communicates with OpenWeather API. The client is registered via DI as `IOpenWeatherClient` to allow easy testing and mocking.
- AuthenticationMiddleware: Validates token from query parameter.
- Logging: Basic logging using .NET built-in logging.

## Data Flow
1. Client sends request with city, country, and token.
2. Authentication middleware validates token.
3. WeatherController processes request and calls WeatherService.
4. WeatherService fetches data from OpenWeatherClient.
5. Response is formatted and returned in JSON (metric units).

## Extensibility
- Easy to add caching, health checks, or support for other weather APIs.
- Unit tests cover main business logic.

---
This document will be updated as the project evolves.
