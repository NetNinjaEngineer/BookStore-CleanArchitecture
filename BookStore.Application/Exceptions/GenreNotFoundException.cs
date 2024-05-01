namespace BookStore.Application.Exceptions;
public sealed class GenreNotFoundException
    (string? message) : Exception(message)
{
}
