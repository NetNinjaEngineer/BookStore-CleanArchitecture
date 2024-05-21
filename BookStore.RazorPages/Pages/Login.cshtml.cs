using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.RazorPages.Pages
{
    public class LoginModel(IAuthenticationClient authenticationClient) : PageModel
    {
        private readonly IAuthenticationClient _authenticationClient = authenticationClient;

        [BindProperty(SupportsGet = true)]
        public AuthenticateModel? AuthenticateModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            bool isLoggedIn = await _authenticationClient.AuthenticateAsync(AuthenticateModel!);
            if (isLoggedIn)
                return RedirectToPage("/Books/Index");
            return Page();
        }
    }
}
