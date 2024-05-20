using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.RazorPages.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;

        public IndexModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IEnumerable<BookListViewModel>? Books { get; set; }

        public async Task OnGet()
        {
            Books = await _bookService.GetAllBooks();
        }
    }
}
