using BookStore.Application.Dtos.Author;
using BookStore.Application.Dtos.AuthorBooks;
using BookStore.Application.Dtos.Common;
using BookStore.Application.Dtos.Genre;

namespace BookStore.Application.Dtos.Book
{
    public sealed class BookDto : BaseDto
    {
        public string? Title { get; set; }

        public int PublicationYear { get; set; }

        public decimal Price { get; set; }

        public string? ImageName { get; set; }

        public ICollection<AuthorDto> Authors { get; set; } = [];

        public ICollection<AuthorBooksDto> AuthorBooks { get; set; } = [];

        public int GenreId { get; set; }

        public GenreDto Genre { get; set; } = null!;
    }
}
