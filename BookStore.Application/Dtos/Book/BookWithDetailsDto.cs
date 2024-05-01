namespace BookStore.Application.Dtos.Book;
public sealed record BookWithDetailsDto : BookForManipulationDto
{
    public int BookId { get; set; }

    public IEnumerable<string?> Authors { get; set; } = [];

    public string? Genre { get; set; }

    public string? ImageUrl { get; set; }

}
