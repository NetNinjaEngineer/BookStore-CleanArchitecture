using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.RazorPages.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IBookClient _bookService;

        public IndexModel(IBookClient bookService)
        {
            _bookService = bookService;
        }

        public IEnumerable<BookListViewModel>? Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public async Task OnGet()
        {
            if (string.IsNullOrEmpty(SearchTerm))
                Books = await _bookService.GetAllBooks();
            else
                Books = await _bookService.GetAllBooks(SearchTerm);
        }
    }
}
