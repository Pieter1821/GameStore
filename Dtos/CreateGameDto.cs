namespace GameStore.API.Dtos;

public class CreateGameDto
{
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}