using BookStore.Application.Dtos.Book;
using BookStore.Application.Dtos.Common;

namespace BookStore.Application.Dtos.Author
{
    public sealed class AuthorDto : BaseDto
    {
        public string? AuthorName { get; set; }

        public int? BookId { get; set; }

        public BookDto? Book { get; set; } = null;
    }
}
