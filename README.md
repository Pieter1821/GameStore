# GameStore API

## Overview
The GameStore API is a simple project for managing a collection of video games. It provides endpoints to create, retrieve, and list games.

## Technologies
- **Language**: C#
- **Framework**: .NET
- **Libraries**: ASP.NET Core

## Endpoints
### GET /games
Retrieves the list of all games.

### GET /games/{id}
Retrieves a specific game by ID.

### POST /games
Creates a new game.
- **Request Body**:
  ```json
  {
    "title": "string",
    "genre": "string",
    "price": decimal,
    "releaseDate": "yyyy-MM-dd"
  }
  ```