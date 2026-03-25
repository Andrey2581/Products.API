using Product.Api.Configurations.OpenApi;

namespace Product.Api.Configurations;

public static class ApiDependencyInjectionConfig
{
    public static IServiceCollection ConfigureApi(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Registrar Repositories
        services.AddControllers();
        
        services.AddVersionedOpenApi();
        
        return services;
    }

    public static WebApplication UseApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}