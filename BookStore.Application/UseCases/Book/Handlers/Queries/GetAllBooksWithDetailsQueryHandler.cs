using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class GetAllBooksWithDetailsQueryHandler(
    IUnitOfWork unitOfWork)
        : IRequestHandler<GetAllBooksWithDetailsQuery,
            IQueryable<BookWithDetailsDto>>
{
    public Task<IQueryable<BookWithDetailsDto>> Handle(
        GetAllBooksWithDetailsQuery request,
        CancellationToken cancellationToken
        )
    {
        var query = unitOfWork
            .AuthorBooksRepository
            .FindAll().Join(
                unitOfWork.AuthorRepository.FindAll(),
                authorBookEntity => authorBookEntity.AuthorId,
                authorEntity => authorEntity.Id,
                (authorBookEntity, authorEntity) => new { authorBookEntity, authorEntity }
            ).Join(
                unitOfWork.BookRepository.FindAll(),
                combined => combined.authorBookEntity.BookId,
                bookEntity => bookEntity.Id,
                (combined, bookEntity) => new { combined, bookEntity }
            ).Join(
                unitOfWork.GenreRepository.FindAll(),
                combined => combined.bookEntity.GenreId,
                genreEntity => genreEntity.GenreId,
                (combined, genreEntity) => new { combined, genreEntity }
            ).Select(result => new BookWithDetailsDto
            {
                BookId = result.combined.bookEntity.Id,
                Title = result.combined.bookEntity.Title,
                Price = result.combined.bookEntity.Price,
                PublicationYear = result.combined.bookEntity.PublicationYear,
                Genre = result.genreEntity.GenreName,
                Author = result.combined.combined.authorEntity.AuthorName,

            });

        return Task.FromResult(query);
    }
}