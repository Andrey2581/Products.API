using Microsoft.EntityFrameworkCore;
using Product.Persistence.Configurations.SqlServer;

namespace Product.Api.Configurations.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        dataContext.Database.Migrate();
    }
}