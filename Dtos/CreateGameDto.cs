using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record class CreateGameDto
(
  [Required][StringLength(50)] string Name,
  int GenreId, 
  string Genre,
  [Range(1, 100)] decimal Price,
  [Required] DateOnly ReleaseDate
);

