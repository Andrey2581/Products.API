using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Persistence.Configurations.SqlServer;

namespace Product.Persistence.Configurations;

public static class PersistenceDependencyInjectionConfig
{
    public static IServiceCollection ConfigurePersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddData(configuration);
        
        #region Repositories

        #endregion

        return services;
    }
}