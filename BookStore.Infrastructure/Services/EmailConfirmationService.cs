using BookStore.Application.Contracts.Infrastructure;
using BookStore.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Infrastructure.Services
{
    public class EmailConfirmationService : IEmailConfirmationService
    {
        private readonly IEmailSender _emailSender;
        private readonly IUrlHelper _urlHelper;
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailConfirmationService(
            IEmailSender emailSender,
            IUrlHelper urlHelper,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor context)
        {
            _emailSender = emailSender;
            _urlHelper = urlHelper;
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> SendConfirmationEmailAsync(
            string userId,
            string email,
            string subject)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return false;

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLinkUrl = _urlHelper.Action("ConfirmEmail", "Auth",
                new { userId, token }, _context.HttpContext?.Request.Scheme);

            var emailBody = $"Please confirm your account by clicking this link: <a href='{confirmationLinkUrl}'>link</a>";

            return await _emailSender.SendEmailAsync(email, subject, emailBody!);

        }
    }
}
