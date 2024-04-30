using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book;
using BookStore.Application.UseCases.Book.Requests.Queries;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Queries;
public sealed class GetBookWithDetailsQueryHandler(
    IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetBookWithDetailsQuery, BookWithDetailsDto>
{
    public Task<BookWithDetailsDto> Handle(
        GetBookWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var bookWithDetails = (from authorBook in unitOfWork.AuthorBooksRepository.FindAll()
                               join book in unitOfWork.BookRepository.FindAll()
                               on authorBook.BookId equals book.Id
                               join author in unitOfWork.AuthorRepository.FindAll()
                               on authorBook.AuthorId equals author.Id
                               join genre in unitOfWork.GenreRepository.FindAll()
                               on book.GenreId equals genre.GenreId
                               where book.Id == request.Id
                               select new BookWithDetailsDto
                               {
                                   BookId = book.Id,
                                   Author = author.AuthorName,
                                   Genre = genre.GenreName,
                                   Price = book.Price,
                                   PublicationYear = book.PublicationYear,
                                   Title = book.Title,
                               }).SingleOrDefault();

        return Task.FromResult(bookWithDetails!);
    }
}
