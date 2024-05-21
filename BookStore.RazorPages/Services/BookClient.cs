using AutoMapper;
using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
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

        using (var requestMessage = PrepareRequest(HttpMethod.Get, "api/Books"))
        {
            AddBearerToken(_localStorageService.GetStorageValue<string>("token"));
            using var response = await ProcessResponse(requestMessage, HttpCompletionOption.ResponseHeadersRead);
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

        return books;
    }

    public async Task<IEnumerable<BookListViewModel>?> GetAllBooks(string searchTerm)
    {
        var books = new List<BookListViewModel>();

        using (var requestMessage = PrepareRequest(HttpMethod.Post, $"api/Books/Search?SearchTerm={searchTerm}"))
        {
            AddBearerToken(_localStorageService.GetStorageValue<string>("token"));
            using var response = await ProcessResponse(requestMessage, HttpCompletionOption.ResponseHeadersRead);
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

        return books;
    }

    public async Task<BookListViewModel> GetBookById(int id)
    {
        BookListViewModel book = new();

        using (var requestMessage = PrepareRequest(HttpMethod.Get, $"api/books/{id}"))
        {
            AddBearerToken(_localStorageService.GetStorageValue<string>("token"));
            using var response = await ProcessResponse(requestMessage, HttpCompletionOption.ResponseHeadersRead);
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

        return book;
    }
}
