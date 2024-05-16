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
            services.Configure<SendGridSettings>(options =>
            {
                options.ApiKey = configuration["SendGrid:ApiKey"];
                options.FromEmail = configuration["SendGrid:FromEmail"];
                options.FromName = configuration["SendGrid:FromName"];

            });

            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }

    }
}
