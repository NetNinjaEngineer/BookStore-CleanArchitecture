namespace BookStore.Application.Contracts.Infrastructure
{
    public interface IEmailConfirmationService
    {
        Task<bool> SendConfirmationEmailAsync(string userId, string email, string subject);
    }
}
