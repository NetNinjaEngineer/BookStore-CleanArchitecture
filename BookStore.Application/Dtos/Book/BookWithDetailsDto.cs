namespace BookStore.Application.Dtos.Book;
public sealed record BookWithDetailsDto : BookForManipulationDto
{
    public int BookId { get; set; }

    public string? Author { get; set; }

    public string? Genre { get; set; }
}
