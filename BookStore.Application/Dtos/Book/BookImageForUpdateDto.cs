using Microsoft.AspNetCore.Http;

namespace BookStore.Application.Dtos.Book;
public sealed class BookImageForUpdateDto
{
    public required IFormFile ImageToUpload { get; set; }
}
