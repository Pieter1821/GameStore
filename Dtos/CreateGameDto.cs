namespace GameStore.API.Dtos;

public class CreateGameDto
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}