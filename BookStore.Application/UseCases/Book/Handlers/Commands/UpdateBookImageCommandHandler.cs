﻿using BookStore.Application.Contracts.Infrastructure;
using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Book.Requests.Commands;
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
        var booksExists = unitOfWork.BookRepository.Exists(request.BookId);
        if (!booksExists)
            throw new BookNotFoundException($"Book with ID {request.BookId} was not founded.");


        var (created, uniqueImageName) = Utility.Utility.UploadImage(request.ImageToUpload, "Books");

        if (created)
        {
            var book = unitOfWork
                .BookRepository
                .FindByCondition(x => x.Id == request.BookId)
                .SingleOrDefault();

            book!.ImageName = uniqueImageName;

            await unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }

        throw new ImageUploadFailedException("Image Upload Faild.");
    }
}