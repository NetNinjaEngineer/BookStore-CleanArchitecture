using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Book.Requests.Commands;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Commands;
public sealed class UpdateBookCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork
        ?? throw new ArgumentNullException(nameof(unitOfWork));

    private readonly IMapper _mapper = mapper
        ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Unit> Handle(
        UpdateBookCommand request,
        CancellationToken cancellationToken
        )
    {
        // check if there is a book with the requested id
        var entity = _unitOfWork.BookRepository
            .FindByCondition(x => x.Id == request.BookId)
            .SingleOrDefault();

        if (entity is not null)
        {
            // if update image requested
            if (request.BookForUpdateDto.ImageForUpdate is not null &&
                request.BookForUpdateDto.ImageForUpdate.Length > 0)
            {
                var bookForUpdate = _mapper.Map(request.BookForUpdateDto, entity);

                DeleteOldBookImage(entity);

                var (created, uniqueImageName) = Utility.Utility
                    .UploadImage(request.BookForUpdateDto.ImageForUpdate, "Books");

                if (!created)
                    throw new ImageUploadFailedException("Failed to upload book image.");

                bookForUpdate.ImageName = uniqueImageName;
                _unitOfWork.BookRepository.Update(bookForUpdate);
                await _unitOfWork.SaveChangesAsync();
                return Unit.Value;

            }
        }

        throw new InvalidOperationException($"Book with ID {request.BookId} not found.");
    }

    private static void DeleteOldBookImage(Domain.Book? entity)
    {
        if (!string.IsNullOrEmpty(entity?.ImageName))
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot\\Files\\Images\\Books", entity.ImageName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
