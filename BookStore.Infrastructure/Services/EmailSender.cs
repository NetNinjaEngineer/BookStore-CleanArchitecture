using BookStore.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BookStore.Infrastructure.Services
{
    public sealed class EmailSender : IEmailSender
    {
        private readonly IOptions<SendGridSettings> _emailSettings;

        public EmailSender(IOptions<SendGridSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string message)
        {
            var client = new SendGridClient(_emailSettings.Value.ApiKey);
            var from = new EmailAddress(_emailSettings.Value.FromEmail, _emailSettings.Value.FromName);
            var toEmail = new EmailAddress(to, "Test User");
            var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, message, "");
            var response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode ? true : false;
        }
    }
}
