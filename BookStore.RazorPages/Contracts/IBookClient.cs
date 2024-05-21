using BookStore.RazorPages.Models;

namespace BookStore.RazorPages.Contracts;

public interface IBookClient : IClient
{
    Task<IEnumerable<BookListViewModel>> GetAllBooks();
    Task<IEnumerable<BookListViewModel>?> GetAllBooks(string searchTerm);
    Task<BookListViewModel> GetBookById(int id);
}
