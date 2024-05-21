using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.RazorPages.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly IBookClient bookService;

        public DetailsModel(IBookClient bookService)
        {
            this.bookService = bookService;
        }

        public BookListViewModel? Book { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Book = await bookService.GetBookById(id);
            return Page();
        }
    }
}
