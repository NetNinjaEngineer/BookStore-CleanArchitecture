using BookStore.Application.Contracts.Persistence;
using BookStore.Application.Dtos.Book.Validators;
using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Book.Requests.Commands;
using FluentValidation;
using MediatR;

namespace BookStore.Application.UseCases.Book.Handlers.Commands;
public sealed class UpdateBookImageCommandHandler(
        IUnitOfWork unitOfWork
    )
    : IRequestHandler<UpdateBookImageCommand, Unit>
{
    public async Task<Unit> Handle(
        UpdateBookImageCommand request,
        CancellationToken cancellationToken)
    {
        await new BookImageForUpdateDtoValidator()
                .ValidateAndThrowAsync(request.BookImageForUpdateDto, cancellationToken: cancellationToken);

        var booksExists = unitOfWork.BookRepository.Exists(request.BookId);
        if (!booksExists)
            throw new BookNotFoundException($"Book with ID {request.BookId} was not founded.");

        var (created, uniqueImageName) = Utility.Utility.UploadImage(
            request.BookImageForUpdateDto.ImageToUpload, "Books");

        if (created)
        {
            var book = await unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);

            if (!string.IsNullOrEmpty(book!.ImageName))
                Utility.Utility.DeleteOldBookImage(book.ImageName);

            book!.ImageName = uniqueImageName;

            await unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }

        throw new ImageUploadFailedException("Image Upload Faild.");
    }
}
