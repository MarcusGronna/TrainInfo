using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.IO;
using Microsoft.Extensions.Hosting;

namespace Infrastructure;

// Public method that WebApi can call - but type TrainDbContext is still internal in Infrastructure
public static class StartupExtentions
{
    public static IApplicationBuilder UseInfrastructureMigrations(this IApplicationBuilder app)
    {
        var dataDir = Path.Combine(app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope().ServiceProvider
            .GetRequiredService<IHostEnvironment>()
            .ContentRootPath, "Data");
        Directory.CreateDirectory(dataDir);

        // Execute pending migrations
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<TrainDbContext>();
        db.Database.Migrate();

        return app;
    }
}

