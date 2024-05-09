using BookStore.Api.Middlewares;
using BookStore.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace BookStore.Api;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";
        var statusCode = (int)HttpStatusCode.InternalServerError;

        ErrorResponse response = new();

        switch (exception)
        {
            case ValidationException:
                var validationException = exception as ValidationException;
                var validationErrors = validationException!.Errors.Select(e => e.ErrorMessage).ToList();
                response.Errors = validationErrors;
                response.Message = "Validation Errors";
                statusCode = (int)HttpStatusCode.UnprocessableEntity;
                break;

            case AuthorNotFoundException:
            case BookNotFoundException:
            case GenreNotFoundException:
                response.Message = exception.Message;
                statusCode = (int)HttpStatusCode.NotFound;
                break;

            case ImageUploadFailedException:
                response.Message = exception.Message;
                statusCode = (int)HttpStatusCode.BadRequest;
                break;

            default:
                response.Message = "Internal Server Error";
                break;
        }

        var jsonResponse = JsonSerializer.Serialize(response);

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsync(jsonResponse, cancellationToken: cancellationToken);

        return true;
    }
}
