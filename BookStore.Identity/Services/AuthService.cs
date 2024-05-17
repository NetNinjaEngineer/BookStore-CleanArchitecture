using AutoMapper;
using BookStore.Application.Contracts.Identity;
using BookStore.Identity.Models;
using BookStore.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Identity.Services;

public sealed class AuthService(
    UserManager<ApplicationUser> userManager,
    IConfiguration configuration,
    IHttpContextAccessor contextAccessor,
    SignInManager<ApplicationUser> signInManager,
    IMapper mapper) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly IMapper _mapper = mapper;

    public async Task<(bool confirmed, string message)> ConfirmEmailAsync(ConfirmEmailModel confirmModel)
    {
        var user = await _userManager.FindByIdAsync(confirmModel.UserId!);

        if (user == null)
            return (false, $"There is no user with ID: ${confirmModel.UserId}");

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
            return (true, "Email confirmed successfully.");

        return (false, result.Errors.Select(e => e.Description).ToString()!);

    }

    public async Task<UserInfoModel> GetCurrentUserInformation(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return null!;

        var userInfo = new UserInfoModel()
        {
            UserName = user.UserName,
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            FirstName = user.FirstName,
            LastName = user.LastName,
            NormalizedEmail = user.NormalizedEmail,
            PhoneNumber = user.PhoneNumber
        };

        return userInfo;

    }

    public async Task<AuthModel> GetTokenRequestModelAsync(TokenRequestModel model)
    {
        var authModel = new AuthModel();

        var user = await _userManager.FindByEmailAsync(model.Email!);

        if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password!))
        {
            authModel.Message = "Invalid email or password";
            authModel.IsAuthenticated = false;
            return authModel;
        }

        var securityJwtToken = await CreateJwtToken(user);
        var userRoles = await _userManager.GetRolesAsync(user);

        authModel.IsAuthenticated = true;
        authModel.UserName = user.UserName;
        authModel.Roles = [.. userRoles];
        authModel.ExpiresOn = securityJwtToken.ValidTo;
        authModel.Email = model.Email;
        authModel.UserName = user.UserName;
        authModel.UserId = user.Id;
        authModel.Token = new JwtSecurityTokenHandler().WriteToken(securityJwtToken);
        authModel.IsEmailConfirmed = user.EmailConfirmed;
        authModel.UserId = user.Id;

        return authModel;
    }

    public async Task<AuthModel> RegisterAsync(RegisterModel requestModel)
    {
        if (await _userManager.FindByEmailAsync(requestModel.Email!) is not null)
            return new AuthModel { Message = "Email is already registered!" };

        if (await _userManager.FindByNameAsync(requestModel.Username!) is not null)
            return new AuthModel { Message = "Username is already registered !" };

        var user = new ApplicationUser
        {
            UserName = requestModel.Username,
            Email = requestModel.Email,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName
        };

        var result = await _userManager.CreateAsync(user, requestModel.Password!);

        if (!result.Succeeded)
        {
            var errors = string.Empty;

            foreach (var error in result.Errors)
            {
                errors += error.Description;
            }

            return new AuthModel { Message = errors };
        }

        await _userManager.AddToRoleAsync(user, "User");

        var jwtSecurityToken = await CreateJwtToken(user);

        return new AuthModel
        {
            Email = user.Email,
            IsAuthenticated = true,
            ExpiresOn = jwtSecurityToken.ValidTo,
            Roles = ["User"],
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            UserName = user.UserName,
            UserId = user.Id,
            IsEmailConfirmed = user.EmailConfirmed
        };
    }

    public async Task SignOutAsync()
    {
        _contextAccessor?.HttpContext?.Response.Cookies.Delete("token");
        await _signInManager.SignOutAsync();
    }

    public async Task<(bool, string)> UpdateUserInfoAsync(UpdateUserInfoModel model)
    {
        var userId = _contextAccessor.HttpContext?.User.FindFirstValue("uid");
        var user = await _userManager.FindByIdAsync(userId!);
        if (user == null)
            return (false, "Invalid user id.");

        user.Email = model.Email;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return (false, result.Errors.Select(e => e.Description).ToString()!);

        return (true, "User information Updated successfully");
    }

    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var role in roles)
            roleClaims.Add(new Claim(ClaimTypes.Role, role));

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("uid", user.Id)
        }
            .Union(userClaims)
            .Union(roleClaims);

        var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
        var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:ValidIssuer"],
            audience: _configuration["JwtSettings:ValidAudience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signingCredentials
        );

        return jwtSecurityToken;
    }
}
