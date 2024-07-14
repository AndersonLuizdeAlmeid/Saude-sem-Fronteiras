using SaudeSemFronteiras.Application.Database.Repository;
using SaudeSemFronteiras.Application.Login.Repository;
using SaudeSemFronteiras.Application.Users.Repository;

namespace SaudeSemFronteiras.WebApi.DependencyInjections;
public static class RepositoriesInjection
{
    public static IServiceCollection AddRepositoriesInjection(this IServiceCollection services)
    {
        services.AddScoped<ICredentialsRepository, CredentialsRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IDatabaseRepository, DatabaseRepository>();

        return services;
    }
}
