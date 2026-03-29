using Microsoft.Extensions.DependencyInjection;
using Product.CrossCutting.handlers;
using Product.Domain.Contracts.Mediator;

namespace Product.CrossCutting.Configurations.MediatR;

public static class MediatorConfig
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();
    }
}