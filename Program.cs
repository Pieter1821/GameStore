using GameStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new(1, "Super Mario Bros.", "Platformer", 29.99m, new DateOnly(1985, 9, 13)),
    new(2, "The Legend of Zelda", "Action-adventure", 49.99m, new DateOnly(1986, 2, 21)),
    new(3, "Minecraft", "Sandbox", 19.99m, new DateOnly(2011, 11, 18)),
    new(4, "Among Us", "Party", 4.99m, new DateOnly(2018, 11, 16)),
    new(5, "Halo: Combat Evolved", "First-person shooter", 29.99m, new DateOnly(2001, 11, 15))
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id) =>
{
    var game = games.Find(game => game.Id == id);
    return game is null ? Results.NotFound() : Results.Ok(game);
});

app.Run();