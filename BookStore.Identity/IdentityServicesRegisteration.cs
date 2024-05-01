using BookStore.Application.Contracts.Identity;
using BookStore.Identity.Models;
using BookStore.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.Identity;

public static class IdentityServicesRegisteration
{
    public static IServiceCollection RegisterIdentityServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // register database
        services.AddDbContext<BookStoreIdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("BookStoreIdentityConnection"),
                options => options.MigrationsAssembly(typeof(BookStoreIdentityDbContext).Assembly.FullName)));
        // register identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<BookStoreIdentityDbContext>();

        // register authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtSettings:ValidIssuer"],
                ValidAudience = configuration["JwtSettings:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!))
            };
        });

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
