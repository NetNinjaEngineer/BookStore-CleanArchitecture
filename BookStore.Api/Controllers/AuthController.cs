using BookStore.Application.Contracts.Identity;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IEmailConfirmationService _emailConfirmationService;

    public AuthController(
        IAuthService authService,
        IEmailConfirmationService emailConfirmationService)
    {
        _authService = authService;
        _emailConfirmationService = emailConfirmationService;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(RegisterModel registerModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.RegisterAsync(registerModel);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        bool sent = await _emailConfirmationService
            .SendConfirmationEmailAsync(
                result.UserId!,
                result.Email!, "Confirm your email address");

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

        var result = await _authService.GetTokenRequestModelAsync(tokenRequest);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("Logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        await _authService.SignOutAsync();
        return Ok("Logged out successfully");
    }

    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailModel model)
    {
        var (confirmed, message) = await _authService.ConfirmEmailAsync(model);
        if (!confirmed)
            return BadRequest(message);

        return Ok(message);
    }

}
