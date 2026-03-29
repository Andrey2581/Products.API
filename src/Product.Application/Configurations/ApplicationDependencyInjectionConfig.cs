using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Configurations.Mediator;

namespace Product.Application.Configurations;

public static class ApplicationDependencyInjectionConfig
{
    public static IServiceCollection ConfigureApplication(
    this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediator();
            
        return services;
    }
}