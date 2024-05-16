using BookStore.Application.Contracts.Infrastructure.Models;

namespace BookStore.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(EmailModel email);
    }
}
