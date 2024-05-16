using BookStore.Application.Contracts.Infrastructure;
using BookStore.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure
{
    public static class InfrastructureRegisterationServices
    {
        public static IServiceCollection RegisterInfrastructurePart(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SendGridSettings>(configureOptions =>
            {
                configureOptions.ApiKey = configuration.GetSection("SendGridSettings:ApiKey").ToString();
                configureOptions.FromName = configuration.GetSection("SendGridSettings:FromName").ToString();
                configureOptions.FromEmail = configuration.GetSection("SendGridSettings:FromEmail").ToString();
            });

            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }

    }
}
