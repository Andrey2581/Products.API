using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Domain.Contracts.Repositories;
using Product.Persistence.Repositories.Generic;

namespace Product.Persistence.Configurations.SqlServer;

public static class DataBaseConfig
{
    public static void AddData(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("App")));

        //services.AddDbContext<DataContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("App"), x =>
            //{
                //x.MigrationsAssembly("Product.Persistence");
                //x.EnableRetryOnFailure(
                    //maxRetryCount: 5,
                    //maxRetryDelay: TimeSpan.FromSeconds(10),
                    //errorNumbersToAdd: null);
            //}));

        services.AddScoped<IGenericRepositoryQuery, GenericRepositoryQuery>();

    }
}