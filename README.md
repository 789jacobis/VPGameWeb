# VPGameWeb

[![CI](https://github.com/789jacobis/VPGameWeb/actions/workflows/ci.yml/badge.svg)](https://github.com/789jacobis/VPGameWeb/actions/workflows/ci.yml)

VPGameWeb is an ASP.NET Core MVC + Web API portfolio project for a game-data website. It presents character, skill, monster, item, and lore data through Razor pages, while also exposing a documented backend API for integration and architecture review.

The project began as an MVC website and was refactored into a cleaner backend structure with service interfaces, DTO-based API responses, pagination, filtering, sorting, Swagger documentation, automated tests, CI, and Docker deployment.

## Live Demo

- Website: https://vpgameweb.onrender.com
- Swagger API Docs: https://vpgameweb.onrender.com/swagger
- Repository: https://github.com/789jacobis/VPGameWeb

The Render free instance may take extra time to wake up after inactivity.

## Project Goals

- Keep the existing Razor UI behavior stable.
- Improve backend maintainability without changing the database schema.
- Move data access and query logic out of controllers.
- Return consistent API responses using DTOs instead of EF entities.
- Add API documentation, tests, CI, and a deployable demo environment.

## Features

- ASP.NET Core MVC pages for game content browsing
- REST-style API endpoints for characters, skills, monsters, and items
- Entity Framework Core with SQLite
- Service interface abstraction for backend business/query logic
- DTO-based API boundaries
- Consistent `ApiResponse<T>` response wrapper
- `PagedResult<T>` metadata for list endpoints
- Filtering, sorting, and pagination on API list endpoints
- Async EF Core queries
- Swagger / OpenAPI documentation
- Basic logging and API exception handling middleware
- Development-only seed data initialization
- NUnit tests for response helpers, pagination, service queries, and middleware behavior
- GitHub Actions CI for restore, build, and test
- Dockerfile for Render deployment

## Tech Stack

- .NET 10
- ASP.NET Core MVC
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / Swashbuckle
- NUnit
- Docker
- GitHub Actions
- Render

## Architecture

The backend follows a layered structure:

```text
MVC / API Controller
    -> Service Interface
        -> Service
            -> AppDbContext
                -> SQLite
```

Controllers are responsible for HTTP concerns. Services own query composition, DTO mapping, filtering, sorting, pagination, and persistence behavior.

API controllers return DTOs wrapped in a consistent response envelope:

```json
{
  "success": true,
  "message": null,
  "data": {}
}
```

Paged endpoints return metadata that clients can use to build stable pagination UI:

```json
{
  "success": true,
  "message": null,
  "data": {
    "items": [],
    "page": 1,
    "pageSize": 20,
    "totalCount": 100,
    "totalPages": 5,
    "hasPreviousPage": false,
    "hasNextPage": true
  }
}
```

## API Overview

| Endpoint | Description |
| --- | --- |
| `GET /api/characters` | Returns a paged list of characters. |
| `GET /api/characters/{id}` | Returns one character by id. |
| `GET /api/skills` | Returns a paged list of skills. |
| `GET /api/skills/{id}` | Returns one skill by id. |
| `GET /api/monsters` | Returns a paged list of monsters. |
| `GET /api/monsters/{id}` | Returns one monster by id. |
| `GET /api/items` | Returns a paged list of items. |
| `GET /api/items/{id}` | Returns one item by id. |

Example list queries:

```text
GET /api/characters?page=1&pageSize=10&race=human&sort=hp_desc
GET /api/monsters?page=1&pageSize=10&type=undead&sort=attack_desc
GET /api/skills?page=1&pageSize=10&category=active&sort=name_asc
GET /api/items?page=1&pageSize=10&category=pickup&sort=category_desc
```

Example success response:

```json
{
  "success": true,
  "message": null,
  "data": {
    "items": [
      {
        "id": 1,
        "name": "Talan",
        "race": "human",
        "hp": 120,
        "attack": 20,
        "moveSpeed": 1.2,
        "description": "A young mage entering the forbidden forest.",
        "age": "29",
        "traits": "",
        "battleScene": "",
        "monsterGroup": "",
        "portraitUrl": "",
        "iconUrl": "",
        "abilities": []
      }
    ],
    "page": 1,
    "pageSize": 10,
    "totalCount": 1,
    "totalPages": 1,
    "hasPreviousPage": false,
    "hasNextPage": false
  }
}
```

Example error response:

```json
{
  "success": false,
  "message": "Character not found.",
  "data": null
}
```

## Run Locally

Requirements:

- .NET SDK 10 or later

Commands:

```bash
dotnet restore
dotnet build
dotnet run --project VpGameWeb.csproj
```

Then open the local URL printed by the terminal.

Swagger is available in Development:

```text
/swagger
```

## Tests

Run all tests:

```bash
dotnet test
```

Current test coverage includes:

- `ApiResponse<T>` success and failure response shape
- `PaginationQuery` default values and bounds
- Character service filtering, sorting, pagination, and detail lookup
- API exception middleware JSON error behavior

## Deployment

This project includes a `Dockerfile` for Render Web Service deployment.

Recommended Render settings:

```text
Service Type: Web Service
Runtime: Docker
Branch: main
Dockerfile Path: ./Dockerfile
```

The container starts ASP.NET Core with Render's `PORT` environment variable:

```bash
dotnet VpGameWeb.dll --urls http://0.0.0.0:${PORT:-8080}
```

For the public portfolio demo, the container currently runs with `ASPNETCORE_ENVIRONMENT=Development` so Swagger and seed data are available online. The app creates the SQLite schema when needed and seeds demo data on startup.

## Interview Notes

This project demonstrates:

- Refactoring an MVC project without breaking existing UI behavior
- Separating controllers, services, DTOs, and data access concerns
- Designing predictable API response contracts
- Adding query patterns expected by client applications
- Using async EF Core access
- Documenting APIs with Swagger
- Adding automated tests and CI
- Deploying a working demo with Docker and Render

## Notes

SQLite runtime files such as `*.db-shm` and `*.db-wal` are ignored because they are generated during local execution.
