using BookStore.RazorPages.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BookStore.RazorPages.Services;

public abstract class BaseHttpService
{
    protected async Task<string> GetToken()
    {
        using (var client = new HttpClient())
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post,
                "https://localhost:7035/api/auth/login"))
            {
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var tokenRequestModel = new GetTokenRequestModel
                {
                    Email = "me5260287@gmail.com",
                    Password = "Password@123"
                };

                var serializedModel = JsonSerializer.Serialize(tokenRequestModel);
                requestMessage.Content = new StringContent(serializedModel);
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var authModel = JsonSerializer.Deserialize<AuthModel>(content, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    if (authModel != null)
                        return authModel.Token!;
                    else
                        return default!;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
