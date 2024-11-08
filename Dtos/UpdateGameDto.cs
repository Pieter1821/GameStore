namespace GameStore.API.Dtos

    public record class UpdateGameDto
    (
        [Required]
        [StringLength(50)]
        string Title,

   [Required][StringLength(50)]
        string Genre,

   [Range(1, 100)] decimal Price,

   [Required] DateOnly ReleaseDate
    )

