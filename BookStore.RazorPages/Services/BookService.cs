using AutoMapper;
using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BookStore.RazorPages.Services;

public class BookService : IBookService
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
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJtZTUyNjAyODdAZ21haWwuY29tIiwianRpIjoiMjUyZmFiZmEtNWUyOC00OTRiLWFhNzktMmEyY2RlNTc2NWRiIiwiZW1haWwiOiJtZTUyNjAyODdAZ21haWwuY29tIiwidWlkIjoiYWJhNTJkNDAtOGMxMS00YmQ3LTljZDMtZjZhM2ZmZDVkZjgwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE3MTYxOTE2ODIsImlzcyI6IkFwaVVzZXIiLCJhdWQiOiJBcGlBdWRpZW5jZSJ9.d_MSk9I5Xt5At-5Dkm6YXx5yNW5v4EXVgLFDLS7Vjgw");
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
                else
                {
                    throw new Exception(response.Content.ToString());
                }
            }
        }

        return books;
    }
}
