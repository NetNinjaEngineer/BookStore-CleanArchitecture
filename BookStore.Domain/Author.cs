using BookStore.Domain.Common;

namespace BookStore.Domain
{
    public sealed class Author : BaseEntity
    {
        public string? AuthorName { get; set; }
        public int? BookId { get; set; }
        public ICollection<Book> Books { get; set; } = [];
        public ICollection<AuthorBooks> AuthorBooks { get; set; } = [];
    }
}
