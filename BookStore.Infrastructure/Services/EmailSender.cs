using BookStore.Application.Contracts.Infrastructure;
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

        public async Task<bool> SendEmailAsync(string to, string subject, string message)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress(_emailSettings.CurrentValue.FromEmail, _emailSettings.CurrentValue.FromName);
            var toEmail = new EmailAddress(to, "Test User");
            var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, message, "");
            var response = await client.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
