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
    public async Task<IEnumerable<BookForListDto>> Handle(
        GetAllBooksWithDetailsQuery request,
        CancellationToken cancellationToken
        )
    {

        var query = await unitOfWork
            .BookRepository
            .GetAllWithSpecifications(new GetAllBooksWithGenreAndAuthorsSpecification());

        return query.Select(x => new BookForListDto
        {
            Id = x.Id,
            Title = x.Title,
            Price = x.Price,
            PublicationYear = x.PublicationYear,
            Genre = x.Genre.GenreName,
            Authors = x.Authors.Select(x => x.AuthorName),
            ImageUrl = Utility.Utility.GetImageUrl(x.ImageName!),
            ImageName = x.ImageName
        });
    }
}