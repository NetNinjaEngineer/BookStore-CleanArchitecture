using BookStore.Domain.Common;

namespace BookStore.Domain
{
    public sealed class Author : BaseEntity
    {
        public string? AuthorName { get; set; }

        public int? BookId { get; set; }

        public Book? Book { get; set; } = null;
    }
}
