using Microsoft.AspNetCore.Http;

namespace BookStore.Application.Dtos.Book
{
    public sealed record BookForCreationDto : BookForManipulationDto
    {
        public required IFormFile Image { get; set; }
        public required int GenreId { get; set; }
    }
}
