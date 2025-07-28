using Microsoft.EntityFrameworkCore;
using Repository;

namespace RoadRunner.MigrationManager;
public static class MigrationManager
{
    public static IServiceProvider MigrateDatabase(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>())
            {
                try
                {
                    // Apply any pending migrations
                    appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // Log the error or handle it as needed
                    throw new Exception("An error occurred while migrating the database.", ex);
                }
            }            
        }

        return services;
    }
}
