using BookStore.Domain.Common;

namespace BookStore.Domain
{
    public class Genre : BaseEntity
    {
        public string? GenreName { get; set; }
        public ICollection<Book> Books { get; set; } = [];
    }
}
