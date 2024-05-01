using BookStore.Application.Dtos.Book;
using BookStore.Application.Dtos.Common;

namespace BookStore.Application.Dtos.Author
{
    public sealed class AuthorDto : BaseDto
    {
        public string? AuthorName { get; set; }
        public ICollection<BookDto> Books { get; set; } = [];
    }
}
