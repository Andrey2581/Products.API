using Microsoft.Extensions.DependencyInjection;
using Product.CrossCutting.Behaviors;
using Product.CrossCutting.GlobalException;

namespace Product.Application.Configurations.Mediator;

public static class MediatorConfig
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(MediatorConfig).Assembly);
            cfg.AddOpenBehavior(typeof(ValidatorPipelineBehavior<,>));
            cfg.AddOpenBehavior(typeof(GlobalExceptionPipelineBehavior<,>));
        });
        return services;
    }
}
