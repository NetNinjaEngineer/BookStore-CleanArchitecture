using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.RazorPages.Pages.Authentication
{
    public class LoginModel(IAuthenticationClient authenticationClient) : PageModel
    {
        private readonly IAuthenticationClient _authenticationClient = authenticationClient;

        public async Task<IActionResult> OnPostAsync(string email, string password)
        {
            bool isLoggedIn = await _authenticationClient.AuthenticateAsync(new AuthenticateModel
            {
                Email = email,
                Password = password
            });

            if (isLoggedIn)
                return RedirectToPage("/Index");
            return Page();
        }
    }
}
