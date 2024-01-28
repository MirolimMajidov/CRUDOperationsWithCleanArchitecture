using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseFromPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));

        return services;
    }

    /// <summary>
    /// Calls migration to create or update the database
    /// </summary>
    public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<UserContext>();
            context.Database.Migrate();
        }

        return app;
    }
}
