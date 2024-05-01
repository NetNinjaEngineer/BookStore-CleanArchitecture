using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.UseCases.Book.Requests.Commands;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Commands;
public sealed class CreateBookCommandHandler(
    IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateBookCommand, Unit>
{
    public async Task<Unit> Handle(
        CreateBookCommand request,
        CancellationToken cancellationToken)
    {
        var validAuthor = unitOfWork
            .AuthorRepository
            .FindAll()
            .Any(x => x.Id == request.BookForCreationDto.AuthorId);

        var validGenre = unitOfWork
            .GenreRepository
            .FindAll()
            .Any(x => x.GenreId == request.BookForCreationDto.GenreId);

        if (validAuthor && validGenre)
        {
            var (created, uniqueImageName) = Utility.Utility
                .UploadImage(request.BookForCreationDto.Image, "Books");
            if (created)
            {
                var bookForCreation = mapper.Map<Domain.Book>(request.BookForCreationDto);
                bookForCreation.ImageName = uniqueImageName;
                bookForCreation.GenreId = request.BookForCreationDto.GenreId;

                var createdEntity = unitOfWork.BookRepository.Create(bookForCreation);
                await unitOfWork.SaveChangesAsync();

                unitOfWork.AuthorBooksRepository.Create(new Domain.AuthorBooks
                {
                    AuthorId = request.BookForCreationDto.AuthorId,
                    BookId = createdEntity.Id
                });

                await unitOfWork.SaveChangesAsync();

                return Unit.Value;
            }
        }

        throw new InvalidOperationException("Not valid author or valid genre !!!");
    }
}
