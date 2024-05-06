namespace BookStore.Application.Dtos.Book;

public sealed record BookForCreationDto : BookForManipulationDto
{
    public required int GenreId { get; set; }
    public required int AuthorId { get; set; }
}
