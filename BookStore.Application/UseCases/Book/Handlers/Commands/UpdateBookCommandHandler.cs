using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book.Validators;
using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Book.Requests.Commands;
using FluentValidation;
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

        await new BookForUpdateDtoValidator()
                .ValidateAndThrowAsync(request.BookForUpdateDto, cancellationToken);

        // check if there is a book with the requested id
        var entity = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);

        if (entity is not null)
        {
            // if update image requested
            if (request.BookForUpdateDto.Image is not null &&
                request.BookForUpdateDto.Image.Length > 0)
            {
                var bookForUpdate = _mapper.Map(request.BookForUpdateDto, entity);

                Utility.Utility.DeleteOldBookImage(entity.ImageName!);

                var (created, uniqueImageName) = Utility.Utility
                    .UploadImage(request.BookForUpdateDto.Image, "Books");

                if (!created)
                    throw new ImageUploadFailedException("Failed to upload book image.");

                bookForUpdate.ImageName = uniqueImageName;
                _unitOfWork.BookRepository.Update(bookForUpdate);
                await _unitOfWork.SaveChangesAsync();
                return Unit.Value;

            }
        }

        throw new BookNotFoundException($"Book with ID {request.BookId} not found.");
    }
}
