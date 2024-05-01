using Microsoft.OpenApi.Models;

namespace BookStore.Api;

public static class ApiRegisterationServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
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