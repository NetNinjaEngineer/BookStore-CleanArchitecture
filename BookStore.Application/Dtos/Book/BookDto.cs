using BookStore.Application.Dtos.Common;
using BookStore.Domain;

namespace BookStore.Application.Dtos.Book
{
    public sealed class BookDto : BaseDto
    {
        public string? Title { get; set; }

        public int PublicationYear { get; set; }

        public decimal Price { get; set; }

        public ICollection<Author> Authors { get; set; } = [];

        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
    }
}
