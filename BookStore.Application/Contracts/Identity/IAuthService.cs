using BookStore.Shared.Models;

namespace BookStore.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);

        Task<AuthModel> GetTokenRequestModelAsync(TokenRequestModel model);

        Task SignOutAsync();

        Task<bool> ConfirmEmailAsync(ConfirmEmailModel confirmModel);
    }
}
