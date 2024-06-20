using SaudeSemFronteiras.Application.JwtToken.Models;
using SaudeSemFronteiras.WebApi.DependencyInjections;

namespace SaudeSemFronteiras.WebApi;
public static class DependenciesInjections
{
    public static IServiceCollection AddInjection(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddMediatRInjection();
        service.AddDatabaseInjection(configuration);
        service.AddQueriesInjection();
        service.AddRepositoriesInjection();
        service.AddServicesInjection();

        Key.SetSecret(configuration.GetSection("Secret").Value);

        return service;
    }
}
