namespace BookStore.Domain
{
    public class Author
    {
        public int Id { get; set; }

        public string? AuthorName { get; set; }

        public int? BookId { get; set; }

        public Book? Book { get; set; } = null;
    }
}
