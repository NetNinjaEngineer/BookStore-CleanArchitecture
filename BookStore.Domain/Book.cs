namespace BookStore.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
        public ICollection<Author> Authors { get; set; } = [];
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
