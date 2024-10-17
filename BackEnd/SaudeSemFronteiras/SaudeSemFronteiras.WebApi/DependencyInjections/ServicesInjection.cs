using SaudeSemFronteiras.Application.Appointments.Services;
using SaudeSemFronteiras.Application.Invoices.Services;
using SaudeSemFronteiras.Application.Login.Services;

namespace SaudeSemFronteiras.WebApi.DependencyInjections;
public static class ServicesInjection
{
    public static IServiceCollection AddServicesInjection(this IServiceCollection services)
    {
        services.AddScoped<CredentialsService>()
                .AddScoped<AppointmentsService>()
                .AddScoped<InvoiceService>();
        return services;
    }
}
