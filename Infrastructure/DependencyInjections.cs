using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Application.Abstractions;

namespace Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Read connection string
        var conn = configuration.GetConnectionString("DefaultConnection");
        //var dbPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "traininfo.db");

        // Register DbContext (TrainDbContext can be internal)
        services.AddDbContext<TrainDbContext>(opt => opt.UseSqlite(conn));

        // Register implementations
        services.AddScoped<ITrainRepository, TrainRepository>();

        // Register IUnitOfWork through fabric inside Infrastructure
        services.AddScoped<IUnitOfWork>(sp =>
        {
            var db = sp.GetRequiredService<TrainDbContext>();
            return new UnitOfWork(db);
        });

        return services;
    }
}

