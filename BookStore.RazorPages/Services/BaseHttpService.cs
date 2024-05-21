using BookStore.RazorPages.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace BookStore.RazorPages.Services;

public abstract class BaseHttpService
{
    protected readonly HttpClient _httpClient;
    protected readonly ILocalStorageService _localStorageService;
    protected readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

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

    protected HttpRequestMessage PrepareRequest(
        HttpMethod method, string url)
    {
        HttpRequestMessage requestMessage = new(method, url);
        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return requestMessage;
    }

    protected async Task<HttpResponseMessage> ProcessResponse(
        HttpRequestMessage requestMessage,
        HttpCompletionOption completionOption)
    {
        HttpResponseMessage response = await _httpClient.SendAsync(
            requestMessage, completionOption);
        return response;
    }
}
