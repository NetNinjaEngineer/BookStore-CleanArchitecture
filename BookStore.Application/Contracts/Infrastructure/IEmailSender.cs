namespace BookStore.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string to, string subject, string message);
    }
}
