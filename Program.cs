using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Endpoints;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
Env.Load();

var connString = Environment.GetEnvironmentVariable("GAME_STORE_DB");
if (string.IsNullOrEmpty(connString))
{
    throw new InvalidOperationException("Connection string not found.");
}

builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
