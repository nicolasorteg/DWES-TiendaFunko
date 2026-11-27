using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.EntityFrameworkCore.Extensions;
using TiendaFunko.Shared.Entity;

namespace TiendaFunko.Shared.Infrastructures;

public static class DatabaseConfig {

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) {
        var postgresConnection = configuration.GetConnectionString("Postgres")
            ?? throw new InvalidOperationException("Falta la connection string 'Postgres'");
        var mongoConnection = configuration.GetConnectionString("Mongo")
            ?? throw new InvalidOperationException("Falta la connection string 'Mongo'");
        var mongoDatabase = configuration["MongoDatabase"] ?? "tiendafunko";

        // PostgreSQL (EF Core)
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(postgresConnection));

        // MongoDB (EF Core provider)
        services.AddDbContext<AppMongoDbContext>(options =>
            options.UseMongoDB(mongoConnection, mongoDatabase));

        return services;
    }
}