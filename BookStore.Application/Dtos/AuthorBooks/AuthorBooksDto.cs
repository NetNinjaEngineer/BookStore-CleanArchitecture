using BookStore.Application.Dtos.Author;
using BookStore.Application.Dtos.Book;

namespace BookStore.Application.Dtos.AuthorBooks;
public sealed class AuthorBooksDto
{
    public int AuthorId { get; set; }

    public int BookId { get; set; }

    public AuthorDto Author { get; set; } = null!;

    public BookDto Book { get; set; } = null!;
}
