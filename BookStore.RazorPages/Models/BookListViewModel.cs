namespace BookStore.RazorPages.Models;

public class BookListViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public string? ImageName { get; set; }
    public string? Genre { get; set; }
    public string? ImageUrl { get; set; }
    public List<string> Authors { get; set; } = [];
    public int PublicationYear { get; set; }

}
