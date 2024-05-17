using BookStore.Api;
using BookStore.Api.Middlewares;
using BookStore.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApiServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<RequestCultureMiddleware>();

app.UseCors(x =>
    x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

using (var scope = app.Services.CreateScope())
{
    var seedRoleService = scope.ServiceProvider.GetRequiredService<SeedRoleService>();
    await seedRoleService.SeedRoles();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();