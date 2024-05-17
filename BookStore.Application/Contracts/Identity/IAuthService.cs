using BookStore.Shared.Models;

namespace BookStore.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);

        Task<AuthModel> GetTokenRequestModelAsync(TokenRequestModel model);

        Task SignOutAsync();

        Task<(bool confirmed, string message)> ConfirmEmailAsync(ConfirmEmailModel confirmModel);

        Task<(bool, string)> UpdateUserInfoAsync(UpdateUserInfoModel model);

        Task<UserInfoModel> GetCurrentUserInformation(string userId);
        Task<bool> SendPasswordResetEmailAsync(string email, string newPassword);
        Task<bool> ResetPasswordAsync(ResetPasswordModel model);

    }
}
