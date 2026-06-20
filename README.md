# TrainInfo

A learning project built to exercise and explore **Clean Architecture** principles in .NET.

## Purpose

This project exists as a hands-on exercise for implementing Clean Architecture in a .NET solution. The goal is to practice separating concerns into distinct layers with clear dependency rules, ensuring the domain and application logic remain independent of infrastructure and presentation details.

## Project Structure

The solution is organized into the following layers:

| Layer | Project | Description |
|-------|---------|-------------|
| **Domain** | `Domain/` | Core entities and enums — the innermost layer with no external dependencies. |
| **Application** | `Application/` | Use cases, abstractions, and DTOs — orchestrates domain logic. |
| **Infrastructure** | `Infrastructure/` | Data access, repositories, migrations, and external service integrations. |
| **Presentation** | `WebApi/` | ASP.NET Core Web API — the entry point for HTTP requests. |

### Tests

| Project | Description |
|---------|-------------|
| `Domain.UnitTests/` | Unit tests for domain entities and logic. |
| `Application.UnitTest/` | Unit tests for application use cases. |
| `Tests/` | Integration tests for the application layer. |

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (compatible with .NET 8+)

### Build

```bash
dotnet build
```

### Run Tests

```bash
dotnet test
```

### Run the API

```bash
dotnet run --project WebApi
```
