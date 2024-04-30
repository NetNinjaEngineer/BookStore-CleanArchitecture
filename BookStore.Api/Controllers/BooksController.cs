using BookStore.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IUnitOfWork unitOfWork, ILogger<BooksController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _unitOfWork.BookRepository.FindAll(x => x.Authors);
            if (!books.Any())
                return NotFound("There is no books founded");

            return Ok(books);
        }
    }
}
