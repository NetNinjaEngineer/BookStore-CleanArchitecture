using BookStore.Domain.Common;

namespace BookStore.Domain
{
    public sealed class Book : BaseEntity
    {
        public string? Title { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
        public ICollection<Author> Authors { get; set; } = [];
        public ICollection<AuthorBooks> AuthorBooks { get; set; } = [];
    }
}
