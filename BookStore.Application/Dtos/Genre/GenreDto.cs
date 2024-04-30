using BookStore.Application.Dtos.Book;
using BookStore.Application.Dtos.Common;

namespace BookStore.Application.Dtos.Genre;
public class GenreDto : BaseDto
{
    public string? GenreName { get; set; }

    public ICollection<BookDto> Books { get; set; } = [];
}
