using BookStore.Application;
using BookStore.Identity;
using BookStore.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;

namespace BookStore.Api;

public static class ApiRegisterationServices
{
    public static IServiceCollection RegisterApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        //builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddControllers(options =>
        {
            options.Filters.Add(new AuthorizeFilter());
            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
            options.OutputFormatters.RemoveType<StringOutputFormatter>();
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.RegisterPersistenceServices(configuration);
        services.RegisterApplicationServices();
        services.RegisterIdentityServices(configuration);
        services.AddHttpContextAccessor();
        services.AddCors();

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("BookStoreApp", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Description = "Input a valid token to access this API"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "BookStoreApp"
                        }
                    },
                    new List<string>()
                }
            });
        });

        return services;

    }
}