using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace BookStore.RazorPages.Services;

public sealed class AuthenticationClient : BaseHttpService, IAuthenticationClient
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<AuthenticationClient> _logger;

    public AuthenticationClient(
        HttpClient httpClient,
        ILocalStorageService localStorageService,
        IHttpContextAccessor contextAccessor,
        ILogger<AuthenticationClient> logger)
        : base(httpClient, localStorageService)
    {
        _contextAccessor = contextAccessor;
        _logger = logger;
    }

    public async Task<bool> AuthenticateAsync(AuthenticateModel authenticateModel)
    {
        try
        {
            AuthenticateModel model = new()
            {
                Email = authenticateModel.Email,
                Password = authenticateModel.Password
            };
            using var requestMessage = PrepareRequest(HttpMethod.Post, "api/auth/login");
            requestMessage.Content!.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var serializedAuthenticationModel = JsonSerializer.Serialize(model);
            requestMessage.Content = new StringContent(serializedAuthenticationModel);
            using var response = await ProcessResponse(requestMessage, HttpCompletionOption.ResponseHeadersRead);

            var apiResponse = await response.Content.ReadAsStringAsync();

            var authenticatedResult = JsonSerializer.Deserialize<AuthModel>(apiResponse);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    if (authenticatedResult is not null && !string.IsNullOrEmpty(authenticatedResult.Token))
                    {
                        var jwtToken = _jwtSecurityTokenHandler.ReadJwtToken(authenticatedResult.Token);
                        if (jwtToken is not null)
                        {
                            var decodedJwt = DecodeJwtToken(jwtToken);
                            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(decodedJwt.Claims));
                            await _contextAccessor.HttpContext!.SignInAsync(claimsPrincipal, new AuthenticationProperties
                            {
                                IsPersistent = true,
                            });

                            _localStorageService.SetStorageValue("token", authenticatedResult.Token);

                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;

                case HttpStatusCode.BadRequest:
                    _logger.LogError($"Bad request while authenticating => {authenticatedResult!.Message}");
                    return false;
                default:
                    return false;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while authenticating: {ex.Message}");
            return false;
        }
    }

    private static DecodedToken DecodeJwtToken(JwtSecurityToken jwtToken)
    {
        return new()
        {
            Issuer = jwtToken.Issuer,
            Claims = jwtToken.Claims.ToList(),
            KeyId = jwtToken.Header.Kid,
            ValidTo = jwtToken.ValidTo,
            ValidFrom = jwtToken.ValidFrom
        };
    }

    public async Task LogoutAsync()
    {
        _localStorageService.ClearStorage(["token"]);
        await _contextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public Task<bool> RegisterAsync(RegisterModel registerModel)
    {
        throw new NotImplementedException();
    }
}
