using BookStore.RazorPages.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace BookStore.RazorPages.Services;

public abstract class BaseHttpService
{
    protected readonly HttpClient _httpClient;
    protected readonly ILocalStorageService _localStorageService;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

    protected BaseHttpService(HttpClient httpClient,
        ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    }

    protected void AddBearerToken(string token)
    {
        if (!_localStorageService.Exists(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
