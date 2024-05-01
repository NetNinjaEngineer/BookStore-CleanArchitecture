using Microsoft.AspNetCore.Http;

namespace BookStore.Application.Dtos.Book
{
    public sealed record BookForUpdateDto : BookForManipulationDto
    {
        public IFormFile? ImageForUpdate { get; set; } = null;
    }
}
