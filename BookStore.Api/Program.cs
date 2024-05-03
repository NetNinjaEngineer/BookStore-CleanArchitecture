using BookStore.Api;
using BookStore.Application;
using BookStore.Identity;
using BookStore.Identity.Services;
using BookStore.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
    options.OutputFormatters.RemoveType<StringOutputFormatter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterPersistenceServices(builder.Configuration);
builder.Services.RegisterApplicationServices();
builder.Services.RegisterIdentityServices(builder.Configuration);
builder.Services.RegisterApiServices();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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