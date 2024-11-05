using GameStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games =
[
    new GameDto(1, "Super Mario Bros.", "Platformer", 29.99m, new DateOnly(1985, 9, 13)),
    new GameDto(2, "The Legend of Zelda", "Action-adventure", 49.99m, new DateOnly(1986, 2, 21)),
    new GameDto(3, "Minecraft", "Sandbox", 19.99m, new DateOnly(2011, 11, 18)),
    new GameDto(4, "Among Us", "Party", 4.99m, new DateOnly(2018, 11, 16)),
    new GameDto(5, "Halo: Combat Evolved", "First-person shooter", 29.99m, new DateOnly(2001, 11, 15))
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id))
.WithName(GetGameEndpointName);


// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    var game = new GameDto(
        games.Count + 1,
        newGame.Title,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});

app.Run();