using BookStore.Application.Contracts.Identity;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[Route("api/auth")]
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
    [HttpPost("register")]
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
    [HttpPost("login")]
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
    [HttpPost("logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        await _authService.SignOutAsync();
        return Ok("Logged out successfully");
    }


    [HttpGet("confirm-email")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailModel model)
    {
        var (confirmed, message) = await _authService.ConfirmEmailAsync(model);
        if (!confirmed)
            return BadRequest(message);

        return Ok(message);
    }


    [HttpGet("manage-info")]
    [ProducesResponseType(typeof(UserInfoModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserInformation(string userId)
        => await _authService.GetCurrentUserInformation(userId) is null ?
        NotFound($"User with ID: {userId} not founded.") : Ok(
            await _authService.GetCurrentUserInformation(userId));


    [HttpPost("manage")]
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


    [HttpPost("forget-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgetPasswordModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var sent = await _authService.SendPasswordResetEmailAsync(model.Email!);

        if (sent)
            return Ok("Password reset email sent");

        return BadRequest("Failed to send password reset email.");
    }


    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.ResetPasswordAsync(model);
        if (result)
            return Ok("Password reset successfully");

        return BadRequest("Failed to reset password.");
    }

    [HttpPost("reset-password-token")]
    public async Task<IActionResult> GeneratePasswordResetToken([FromBody] string email)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var token = await _authService.GeneratePasswordResetToken(email);
        if (string.IsNullOrEmpty(token))
            return BadRequest("User email not exists.");
        return Ok(token);
    }
}
