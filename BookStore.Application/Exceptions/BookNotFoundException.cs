namespace BookStore.Application.Exceptions;
public sealed class BookNotFoundException
    (string? message) : Exception(message)
{
}
