using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookStore.Application;
public static class ApplicationRegisterationServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies());

        return services;
    }
}
