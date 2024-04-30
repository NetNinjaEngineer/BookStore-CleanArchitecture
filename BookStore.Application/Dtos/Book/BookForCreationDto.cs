namespace BookStore.Application.Dtos.Book
{
    public abstract class BookForCreationDto
    {
        public string? Title { get; set; }

        public int PublicationYear { get; set; }

        public decimal Price { get; set; }
    }
}
