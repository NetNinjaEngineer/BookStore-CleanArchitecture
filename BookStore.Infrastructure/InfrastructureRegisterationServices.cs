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
            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }

    }
}
