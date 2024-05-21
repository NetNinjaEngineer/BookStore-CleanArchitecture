using BookStore.RazorPages.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.RazorPages.Pages.Authentication
{
    public class LogoutModel : PageModel
    {
        private readonly IAuthenticationClient _authenticationClient;

        public LogoutModel(IAuthenticationClient authenticationClient)
        {
            _authenticationClient = authenticationClient;
        }

        public async Task<IActionResult> OnGet()
        {
            await _authenticationClient.LogoutAsync();
            return RedirectToPage("/Authentication/Login");
        }
    }
}
