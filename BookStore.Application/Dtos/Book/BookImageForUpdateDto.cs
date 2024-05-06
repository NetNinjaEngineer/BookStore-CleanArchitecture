using BookStore.Application.Dtos.Common;
using Microsoft.AspNetCore.Http;

namespace BookStore.Application.Dtos.Book;
public sealed class BookImageForUpdateDto : BaseDto
{
    public required IFormFile ImageToUpload { get; set; }
}
