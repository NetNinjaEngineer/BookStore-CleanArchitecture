using BookStore.Application.Contracts.Identity.Models;

namespace BookStore.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);

        Task<AuthModel> GetTokenRequestModelAsync(TokenRequestModel model);

        Task SignOutAsync();
    }
}
