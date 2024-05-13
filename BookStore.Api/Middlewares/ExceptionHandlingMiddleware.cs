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

        var response = new ErrorResponse();

        switch (ex)
        {
            case ValidationException:
                statusCode = HttpStatusCode.UnprocessableEntity;
                if (ex is ValidationException)
                {
                    var validationException = ex as ValidationException;
                    var validationErrors = validationException!.Errors
                        .Select(e => e.ErrorMessage).ToList();
                    response.Errors = validationErrors;
                    response.Message = "Validation Errors";

                }
                break;
            case AuthorNotFoundException:
            case BookNotFoundException:
            case GenreNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                response.Message = ex.Message;
                break;
            case ImageUploadFailedException:
                statusCode = HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                break;
            default:
                response.Message = ex.Message;
                break;
        }

        var jsonResponse = JsonSerializer.Serialize(response);

        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(jsonResponse);
    }
}
class ErrorResponse
{
    public string? Message { get; set; }
    public IEnumerable<string> Errors { get; set; } = [];
}