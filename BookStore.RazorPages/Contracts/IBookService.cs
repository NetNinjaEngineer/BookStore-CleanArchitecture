using BookStore.RazorPages.Models;

namespace BookStore.RazorPages.Contracts;

public interface IBookService
{
    Task<IEnumerable<BookListViewModel>> GetAllBooks();
}
