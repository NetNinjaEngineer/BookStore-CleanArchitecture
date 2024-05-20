using AutoMapper;
using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BookStore.RazorPages.Services;

public class BookService : BaseHttpService, IBookService
{
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _httpClientFactory;

    public BookService(IMapper mapper, IHttpClientFactory httpClientFactory)
    {
        _mapper = mapper;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<BookListViewModel>> GetAllBooks()
    {
        var client = _httpClientFactory.CreateClient("BooksClient");
        var books = new List<BookListViewModel>();

        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/Books"))
        {
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
            using (var response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
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
        var client = _httpClientFactory.CreateClient("BooksClient");
        var books = new List<BookListViewModel>();

        using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"api/Books/Search?SearchTerm={searchTerm}"))
        {
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
            using (var response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
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
        var client = _httpClientFactory.CreateClient("BooksClient");
        BookListViewModel book = new();

        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/Books/{id}"))
        {
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
            using (var response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
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
