using BookStore.Application.Dtos.Common;

namespace BookStore.Application.Dtos.Book;
public sealed class BookForListDto : BaseDto
{
    public string? Title { get; set; }

    public int PublicationYear { get; set; }

    public decimal Price { get; set; }

    public string? ImageName { get; set; }

    public IEnumerable<string?> Authors { get; set; } = [];

    public string? Genre { get; set; }

    public string? ImageUrl { get; set; }
}
