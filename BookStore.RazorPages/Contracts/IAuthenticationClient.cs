using BookStore.RazorPages.Models;

namespace BookStore.RazorPages.Contracts;

public interface IAuthenticationClient : IClient
{
    Task<bool> RegisterAsync(RegisterModel registerModel);
    Task<bool> AuthenticateAsync(AuthenticateModel authenticateModel);
    Task LogoutAsync();
}
