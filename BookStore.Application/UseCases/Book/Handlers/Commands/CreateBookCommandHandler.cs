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
        var (created, uniqueImageName) = Utility.Utility.UploadImage(request.Image, "Books");

        if (created)
        {
            var bookForCreation = mapper.Map<Domain.Book>(request.BookForCreationDto);
            bookForCreation.ImageName = uniqueImageName;
            bookForCreation.GenreId = request.BookForCreationDto.GenreId;
            unitOfWork.BookRepository.Create(bookForCreation);
            await unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }

        throw new InvalidOperationException("Image Required!!!");
    }
}
