using SaudeSemFronteiras.Common.Factory;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.WebApi.DependencyInjections;
public static class DatabaseInjection
{
    public static IServiceCollection AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDatabaseFactory, DatabaseFactory>(sr => new DatabaseFactory(configuration.GetConnectionString("SQLite")!));

        return services;
    }
}
