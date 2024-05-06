using Microsoft.AspNetCore.Http;

namespace BookStore.Application.Dtos.Book;
public abstract record BookForManipulationDto
{
    public string? Title { get; set; }

    public int PublicationYear { get; set; }

    public decimal Price { get; set; }

    public IFormFile Image { get; set; } = null!;
}
