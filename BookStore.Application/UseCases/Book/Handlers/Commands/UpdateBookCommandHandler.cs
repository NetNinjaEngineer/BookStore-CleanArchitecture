using AutoMapper;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Dtos.Book.Validators;
using BookStore.Application.Exceptions;
using BookStore.Application.Helpers;
using BookStore.Application.UseCases.Book.Requests.Commands;
using FluentValidation;
using MediatR;
using System.Text.Json;

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

        try
        {
            await new BookForUpdateDtoValidator()
                .ValidateAndThrowAsync(request.BookForUpdateDto, cancellationToken);
        }
        catch (ValidationException ex)
        {
            var validationErrors = ex.Errors.Select(e => new ValidationError
            {
                PropertyName = e.PropertyName,
                Value = e.ErrorMessage
            });

            var jsonErrors = JsonSerializer.Serialize(validationErrors);

            throw new ValidationException(jsonErrors);
        }

        // check if there is a book with the requested id
        var entity = _unitOfWork.BookRepository
            .FindByCondition(x => x.Id == request.BookId)
            .SingleOrDefault();

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
