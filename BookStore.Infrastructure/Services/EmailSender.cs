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

        public async Task SendEmailAsync(EmailModel email)
        {
            // prepare client
            var client = new SendGridClient(_emailSettings.CurrentValue.ApiKey);

            //email message
            var message = new SendGridMessage
            {
                From = new EmailAddress(_emailSettings.CurrentValue.FromEmail,
                _emailSettings.CurrentValue.FromName),
                Subject = email.Subject,
                PlainTextContent = email.Message,
                HtmlContent = email.Message
            };

            message.AddTo(new EmailAddress(email.Email));
            await client.SendEmailAsync(message);
        }
    }
}
