using AutoMapper;
using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BookStore.RazorPages.Services;

public sealed class BookClient : BaseHttpService, IBookClient
{
    private readonly IMapper _mapper;

    public BookClient(
        HttpClient httpClient,
        ILocalStorageService localStorageService,
        IMapper mapper)
        : base(httpClient, localStorageService)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookListViewModel>> GetAllBooks()
    {
        var books = new List<BookListViewModel>();

        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/Books"))
        {
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AddBearerToken());
            using (var response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    books = JsonSerializer.Deserialize<List<BookListViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
        }

        return books;
    }

    public async Task<IEnumerable<BookListViewModel>?> GetAllBooks(string searchTerm)
    {
        var books = new List<BookListViewModel>();

        using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"api/Books/Search?SearchTerm={searchTerm}"))
        {
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AddBearerToken());
            using (var response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    books = JsonSerializer.Deserialize<List<BookListViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
        }

        return books;
    }

    public async Task<BookListViewModel> GetBookById(int id)
    {
        BookListViewModel book = new();

        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/Books/{id}"))
        {
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AddBearerToken());
            using (var response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JsonSerializerOptions options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    book = JsonSerializer.Deserialize<BookListViewModel>(content, options)!;
                }
                else
                {
                    throw new Exception(response.Content.ToString());
                }
            }
        }

        return book;
    }
}
