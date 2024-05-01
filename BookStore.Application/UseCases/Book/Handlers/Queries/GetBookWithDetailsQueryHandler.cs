using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class GetBookWithDetailsQueryHandler(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor contextAccessor)
    : IRequestHandler<GetBookWithDetailsQuery, BookWithDetailsDto>
{
    public Task<BookWithDetailsDto> Handle(
        GetBookWithDetailsQuery request,
        CancellationToken cancellationToken
        )
    {
        var httpRequest = (contextAccessor.HttpContext?.Request)
            ?? throw new InvalidOperationException("HTTP context is not available.");

        var baseUrl = $"{httpRequest.Scheme}://{httpRequest.Host}";

        var bookWithDetails = (
            from authorBook in unitOfWork.AuthorBooksRepository.FindAll()
            join book in unitOfWork.BookRepository.FindAll() on authorBook.BookId equals book.Id
            join author in unitOfWork.AuthorRepository.FindAll() on authorBook.AuthorId equals author.Id
            join genre in unitOfWork.GenreRepository.FindAll() on book.GenreId equals genre.GenreId
            where book.Id == request.Id
            select new BookWithDetailsDto
            {
                BookId = book.Id,
                Authors = book.Authors.Select(x => x.AuthorName),
                Genre = genre.GenreName,
                Price = book.Price,
                PublicationYear = book.PublicationYear,
                Title = book.Title,
                ImageUrl = GetImageUrl(baseUrl, book.ImageName)
            }).SingleOrDefault() ?? throw new InvalidOperationException($"Book with ID {request.Id} not found.");

        return Task.FromResult(bookWithDetails);
    }

    private static string GetImageUrl(string baseUrl, string? imageName)
        => Path.Combine(baseUrl, "Files/Images/Books", imageName!);
}
