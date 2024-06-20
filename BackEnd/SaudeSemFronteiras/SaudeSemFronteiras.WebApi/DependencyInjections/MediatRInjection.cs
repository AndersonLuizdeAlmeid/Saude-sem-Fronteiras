namespace SaudeSemFronteiras.WebApi.DependencyInjections;
public static class MediatRInjection
{
    public static IServiceCollection AddMediatRInjection(this IServiceCollection service)
    {
        var assembly = AppDomain.CurrentDomain.Load("SaudeSemFronteiras.Application");
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        return service;
    }
}
