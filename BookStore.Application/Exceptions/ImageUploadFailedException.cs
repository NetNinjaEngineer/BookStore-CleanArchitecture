namespace BookStore.Application.Exceptions;
public sealed class ImageUploadFailedException
    (string? message) : Exception(message)
{
}
