using BookStore.Application.Contracts.Identity;
using BookStore.Application.Contracts.Identity.Models;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController(IAuthService authService,
    UserManager<ApplicationUser> userManager,
    IEmailSender emailSender) : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailSender _emailSender = emailSender;

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(RegisterModel registerModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await authService.RegisterAsync(registerModel);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        var token = await _userManager.GenerateEmailConfirmationTokenAsync((ApplicationUser)result.User!);
        var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { userId = result.UserId, token }, Request.Scheme);
        var sent = await _emailSender.SendEmailAsync(result.Email!, "Confirm Email", confirmationLink!);

        if (sent)
            return Ok("Good, Please confirm email, then login again.");

        else
            return BadRequest("Confirmation message has not been sent.");

    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("Login")]
    public async Task<ActionResult<AuthModel>> GetTokenAsync(TokenRequestModel tokenRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await authService.GetTokenRequestModelAsync(tokenRequest);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("Logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        await authService.SignOutAsync();
        return Ok("Logged out successfully");
    }

    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailModel model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId!);
        if (user == null) return BadRequest("Invalid User ID");

        var result = await _userManager.ConfirmEmailAsync(user, model.Token!);
        if (result.Succeeded) return Ok("Email confirmed successfully");

        return BadRequest(result.Errors);
    }

}
