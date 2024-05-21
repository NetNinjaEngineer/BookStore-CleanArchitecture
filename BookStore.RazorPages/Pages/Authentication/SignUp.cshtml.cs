using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.RazorPages.Pages.Authentication
{
    public class SignUpModel : PageModel
    {
        private readonly IAuthenticationClient _authenticationClient;

        public SignUpModel(IAuthenticationClient authenticationClient)
        {
            _authenticationClient = authenticationClient;
        }

        public RegisterInputModel? RegisterInputModel { get; set; }

        public void OnGet()
        {
            RegisterInputModel = new RegisterInputModel();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            bool isSignUp = await _authenticationClient.RegisterAsync(new RegisterModel
            {
                Email = RegisterInputModel!.Email,
                FirstName = RegisterInputModel!.FirstName,
                LastName = RegisterInputModel!.LastName,
                Password = RegisterInputModel!.Password,
                UserName = RegisterInputModel.Username
            });

            if (isSignUp)
                return RedirectToPage("/Authentication/Login");

            return Page();

        }
    }
}
