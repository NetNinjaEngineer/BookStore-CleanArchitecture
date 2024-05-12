using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book;
using BookStore.Application.Specifications.Features.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class GetAllBooksWithDetailsQueryHandler(
    IUnitOfWork unitOfWork)
        : IRequestHandler<GetAllBooksWithDetailsQuery, IEnumerable<BookForListDto>>
{
    public Task<IEnumerable<BookForListDto>> Handle(
        GetAllBooksWithDetailsQuery request,
        CancellationToken cancellationToken
        )
    {
        var booksWithDetailsQuery = unitOfWork.BookRepository
            .GetAllWithSpecifications(new GetAllBooksWithGenreAndAuthorsSpecification())
            .Result.Select(book => new BookForListDto
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                PublicationYear = book.PublicationYear,
                Genre = book.Genre.GenreName,
                Authors = book.Authors.Select(x => x.AuthorName),
                ImageUrl = Utility.Utility.GetImageUrl(book.ImageName!),
                ImageName = book.ImageName
            });

        return Task.FromResult(booksWithDetailsQuery);
    }
}