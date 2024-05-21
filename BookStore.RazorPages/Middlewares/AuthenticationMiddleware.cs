
namespace BookStore.RazorPages.Middlewares;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity is not null)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.Redirect("/Login.cshtml");
                return;
            }
        }

        await _next(context);
    }
}
