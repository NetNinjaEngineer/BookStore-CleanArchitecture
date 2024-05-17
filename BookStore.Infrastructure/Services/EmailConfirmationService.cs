using BookStore.Application.Contracts.Infrastructure;
using BookStore.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BookStore.Infrastructure.Services
{
    public class EmailConfirmationService : IEmailConfirmationService
    {
        private readonly IEmailSender _emailSender;
        private readonly IUrlHelper _urlHelper;
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LinkGenerator _linkGenerator;

        public EmailConfirmationService(
            IEmailSender emailSender,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor context,
            LinkGenerator linkGenerator)
        {
            _emailSender = emailSender;
            _userManager = userManager;
            _context = context;
            _linkGenerator = linkGenerator;
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
            var confirmationLinkUrl = _linkGenerator.GetUriByAction(_context.HttpContext!, "ConfirmEmail", "Auth",
                new { userId, token }, _context.HttpContext?.Request.Scheme);

            var emailBody = $"Please confirm your account by clicking this link: <a href='{confirmationLinkUrl}'>link</a>";

            return await _emailSender.SendEmailAsync(email, subject, emailBody!);

        }
    }
}
