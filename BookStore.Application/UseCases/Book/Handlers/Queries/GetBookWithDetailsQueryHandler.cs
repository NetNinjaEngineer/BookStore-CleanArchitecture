using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book;
using BookStore.Application.Exceptions;
using BookStore.Application.Specifications.Features.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class GetBookWithDetailsQueryHandler(
    IUnitOfWork unitOfWork)
    : IRequestHandler<GetBookWithDetailsQuery, BookForListDto>
{
    public async Task<BookForListDto> Handle(
        GetBookWithDetailsQuery request,
        CancellationToken cancellationToken
        )
    {
        var query = await unitOfWork.BookRepository
            .GetBookByIdWithSpecification(
                new GetBookByIdWithDetailsSpecification(request.Id));

        var bookWithDetails = (
            from authorBook in await unitOfWork.AuthorBooksRepository.FindAll()
            join book in await unitOfWork.BookRepository.FindAll() on authorBook.BookId equals book.Id
            join author in await unitOfWork.AuthorRepository.FindAll() on authorBook.AuthorId equals author.Id
            join genre in await unitOfWork.GenreRepository.FindAll() on book.GenreId equals genre.Id
            where book.Id == request.Id
            select new BookForListDto
            {
                Id = book.Id,
                Authors = book.Authors.Select(x => x.AuthorName),
                Genre = genre.GenreName,
                Price = book.Price,
                PublicationYear = book.PublicationYear,
                Title = book.Title,
                ImageName = book.ImageName,
                ImageUrl = Utility.Utility.GetImageUrl(book.ImageName!),
            }).FirstOrDefault() ?? throw new BookNotFoundException($"Book with ID {request.Id} not found.");

        return bookWithDetails;
    }
}
