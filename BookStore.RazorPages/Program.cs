using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddHttpClient("BooksClient", options =>
{
    options.BaseAddress = new Uri("https://localhost:7035");
    options.DefaultRequestHeaders.Clear();
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IBookClient, BookClient>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/AccessDenied");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
