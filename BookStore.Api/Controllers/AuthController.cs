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
<<<<<<< HEAD
        var user = await _userManager.FindByIdAsync(result.UserId!);
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user!);
        var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { userId = result.UserId, token }, Request.Scheme);
        var sent = await _emailSender.SendEmailAsync(result.Email!, "Confirm Email", confirmationLink!);

        if (sent)
            return Ok("Good, Please confirm your email, then login again.");

        return BadRequest("Email not verified");
=======

        bool sent = await _emailConfirmationService
            .SendConfirmationEmailAsync(
                result.UserId!,
                result.Email!, "Confirm your email address");

        if (sent)
            return Ok("Good, Please confirm email, then login again.");

        else
            return BadRequest("Confirmation message has not been sent.");
>>>>>>> UserInfomationFeature

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
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailModel model)
    {
        var (confirmed, message) = await _authService.ConfirmEmailAsync(model);
        if (!confirmed)
            return BadRequest(message);

        return Ok(message);
    }

    [HttpGet("Manage")]
    [ProducesResponseType(typeof(UserInfoModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserInformation(string userId)
        => await _authService.GetCurrentUserInformation(userId) is null ?
        NotFound($"User with ID: {userId} not founded.") : Ok(
            await _authService.GetCurrentUserInformation(userId));

    [HttpPost("Manage")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize]
    public async Task<IActionResult> UpdateUserInformation(UpdateUserInfoModel model)
    {
        var (updated, message) = await _authService.UpdateUserInfoAsync(model);
        if (!updated)
            return BadRequest(message);

        return Ok(message);
    }

}
