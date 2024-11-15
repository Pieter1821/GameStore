using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;


namespace GameStore.API.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndpointName = "GetGame";

        private static readonly List<GameSummaryDto> games = new()
                    {
                        new (1, "Super Mario Bros.", "Platformer", 29.99m, new DateOnly(1985, 9, 13)),
                        new (2, "The Legend of Zelda", "Action-adventure", 49.99m, new DateOnly(1986, 2, 21)),
                        new (3, "Minecraft", "Sandbox", 19.99m, new DateOnly(2011, 11, 18)),
                        new (4, "Among Us", "Party", 4.99m, new DateOnly(2018, 11, 16)),
                        new (5, "Halo: Combat Evolved", "First-person shooter", 29.99m, new DateOnly(2001, 11, 15))
                    };

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {

            var group = app.MapGroup("games")
                            .WithParameterValidation();

            // GET /games
            group.MapGet("/", () => games);

            // GET /games/1
            group.MapGet("/{id}", (int id , GameStoreContext dbContext) =>
            {
                Game? game = dbContext.Games.Find(id);
                
                return game is null ? 
                              Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
            })
            .WithName(GetGameEndpointName);

            // POST /games
            group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>

            {
                Game game = newGame.ToEntity();
              

                dbContext.Games.Add(game);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameDetailsDto());
            });

            // PUT /games/1
            group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
           {
               var index = games.FindIndex(game => game.Id == id);
               if (index == -1)
               {
                   return Results.NotFound();
               }
               games[index] = new GameSummaryDto(
                   id,
                   updatedGame.Name,
                   updatedGame.Genre,
                   updatedGame.Price,
                   updatedGame.ReleaseDate
               );
               return Results.NoContent();
           });

            // DELETE /games/1
            group.MapDelete("/{id}", (int id) =>
            {
                var index = games.FindIndex(game => game.Id == id);
                if (index == -1)
                {
                    return Results.NotFound();
                }
                games.RemoveAt(index);
                return Results.NoContent();
            });

            return group;
        }
    }
}
