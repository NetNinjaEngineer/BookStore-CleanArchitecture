using BookStore.Application.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace BookStore.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        var statusCode = HttpStatusCode.InternalServerError;

        switch (ex)
        {
            case ValidationException:
                statusCode = HttpStatusCode.UnprocessableEntity;
                break;
            case AuthorNotFoundException:
            case BookNotFoundException:
            case GenreNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;
            case ImageUploadFailedException:
                statusCode = HttpStatusCode.BadRequest;
                break;
        }

        var jsonResponse = JsonSerializer.Serialize(ex.Message);

        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(jsonResponse);
    }
}
