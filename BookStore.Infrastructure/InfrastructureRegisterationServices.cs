using BookStore.Application.Contracts.Infrastructure;
using BookStore.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure
{
    public static class InfrastructureRegisterationServices
    {
        public static IServiceCollection RegisterInfrastructurePart(
            this IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var sendGridSection = configuration.GetSection("SendGrid");

            services.Configure<SendGridSettings>(options =>
            {
                options.ApiKey = sendGridSection.GetValue<string>("ApiKey");
                options.FromEmail = sendGridSection.GetValue<string>("FromEmail");
                options.FromName = sendGridSection.GetValue<string>("FromName");
            });

            services.AddScoped<IEmailSender, EmailSender>();

            services.AddScoped<IEmailConfirmationService, EmailConfirmationService>();

            return services;
        }

    }
}
