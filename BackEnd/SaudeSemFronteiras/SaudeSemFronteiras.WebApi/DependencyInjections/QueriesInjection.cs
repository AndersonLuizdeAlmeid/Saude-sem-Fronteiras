using SaudeSemFronteiras.Application.Cities.Queries;
using SaudeSemFronteiras.Application.Countries.Queries;
using SaudeSemFronteiras.Application.Login.Queries;
using SaudeSemFronteiras.Application.States.Queries;
using SaudeSemFronteiras.Application.Users.Queries;

namespace SaudeSemFronteiras.WebApi.DependencyInjections;
public static class QueriesInjection
{
    public static IServiceCollection AddQueriesInjection(this IServiceCollection services)
    {
        services.AddScoped<ICityQueries, CityQueries>()
                .AddScoped<ICountryQueries, CountryQueries>()
                .AddScoped<ICredentialsQueries, CredentialsQueries>()
                .AddScoped<IStateQueries, StateQueries>()
                .AddScoped<IUserQueries, UserQueries>();

        return services;
    }
}
