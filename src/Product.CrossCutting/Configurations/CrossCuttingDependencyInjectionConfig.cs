using Microsoft.Extensions.DependencyInjection;
using Product.CrossCutting.Configurations.MediatR;

namespace Product.CrossCutting.Configurations;

public static class CrossCuttingDependencyInjectionConfig
{

    public static IServiceCollection ConfigureCrossCutting(this IServiceCollection services)
    {
        services.AddMediator();

        return services;
    }
}