namespace BookStore.Application.Exceptions;
public sealed class AuthorNotFoundException
    (string? message) : Exception(message)
{
}
