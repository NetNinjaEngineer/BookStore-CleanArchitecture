using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Contracts.Infrastructure.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BookStore.Infrastructure.Services
{
    public sealed class EmailSender : IEmailSender
    {
        private readonly IOptionsMonitor<SendGridSettings> _emailSettings;

        public EmailSender(IOptionsMonitor<SendGridSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task<bool> SendEmailAsync(EmailModel email)
        {
            var apiKey = _emailSettings.CurrentValue.ApiKey;

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(_emailSettings.CurrentValue.FromEmail,
                _emailSettings.CurrentValue.FromName);

            var subject = email.Subject;

            var toEmail = new EmailAddress(email.To);

            var plainTextContent = $"{email.Message}";

            var htmlContent = $"<strong>{email.Message}</strong>";

            var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }
    }
}
