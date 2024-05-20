using BookStore.RazorPages.Contracts;
using BookStore.RazorPages.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddHttpClient("BooksClient", options =>
{
    options.BaseAddress = new Uri("https://localhost:7035");
    options.DefaultRequestHeaders.Clear();
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
