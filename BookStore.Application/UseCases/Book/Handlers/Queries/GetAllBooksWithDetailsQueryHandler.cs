using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class GetAllBooksWithDetailsQueryHandler(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor? contextAccessor)
        : IRequestHandler<GetAllBooksWithDetailsQuery, IQueryable<BookWithDetailsDto>>
{
    public Task<IQueryable<BookWithDetailsDto>> Handle(
        GetAllBooksWithDetailsQuery request,
        CancellationToken cancellationToken
        )
    {
        var httpRequest = (contextAccessor?.HttpContext?.Request)
            ?? throw new InvalidOperationException("HTTP context is not available.");

        var baseUrl = $"{httpRequest.Scheme}://{httpRequest.Host}";

        var booksWithDetails = unitOfWork.BookRepository
            .FindAll(book => book.Genre, book => book.Authors)
            .Select(book => new BookWithDetailsDto
            {
                BookId = book.Id,
                Title = book.Title,
                Price = book.Price,
                PublicationYear = book.PublicationYear,
                Genre = book.Genre.GenreName,
                Authors = book.Authors.Select(x => x.AuthorName),
                ImageUrl = GetImageUrl(book, baseUrl)
            });

        return Task.FromResult(booksWithDetails);

    }

    private static string GetImageUrl(Domain.Book book, string baseUrl)
        => Path.Combine(baseUrl, $"Files/Images/Books/{book.ImageName}");
}