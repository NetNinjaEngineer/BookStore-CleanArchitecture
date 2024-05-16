using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure
{
    public static class InfrastructureRegisterationServices
    {
        public static IServiceCollection RegisterInfrastructurePart(
            this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }

    }
}
