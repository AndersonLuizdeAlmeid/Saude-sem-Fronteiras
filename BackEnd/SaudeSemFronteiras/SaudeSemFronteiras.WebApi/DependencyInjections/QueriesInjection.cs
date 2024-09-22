using SaudeSemFronteiras.Application.Addresses.Queries;
using SaudeSemFronteiras.Application.Appointments.Queries;
using SaudeSemFronteiras.Application.Certificates.Queries;
using SaudeSemFronteiras.Application.Chats.Queries;
using SaudeSemFronteiras.Application.Cities.Queries;
using SaudeSemFronteiras.Application.Countries.Queries;
using SaudeSemFronteiras.Application.Doctors.Queries;
using SaudeSemFronteiras.Application.Documents.Queries;
using SaudeSemFronteiras.Application.Emergencys.Queries;
using SaudeSemFronteiras.Application.Exams.Queries;
using SaudeSemFronteiras.Application.Invoices.Queries;
using SaudeSemFronteiras.Application.Login.Queries;
using SaudeSemFronteiras.Application.Messages.Queries;
using SaudeSemFronteiras.Application.Patients.Queries;
using SaudeSemFronteiras.Application.Prescriptions.Queries;
using SaudeSemFronteiras.Application.Scheduled.Queries;
using SaudeSemFronteiras.Application.Screenings.Queries;
using SaudeSemFronteiras.Application.Specialities.Queries;
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
                .AddScoped<IUserQueries, UserQueries>()
                .AddScoped<ICredentialsQueries, CredentialsQueries>()
                .AddScoped<IUserQueries, UserQueries>()
                .AddScoped<IAddressQueries, AddressQueries>()
                .AddScoped<IAppointmentQueries, AppointmentQueries>()
                .AddScoped<ICertificateQueries, CertificateQueries>()
                .AddScoped<IEmergencyQueries, EmergencyQueries>()
                .AddScoped<IChatQueries, ChatQueries>()
                .AddScoped<IDoctorQueries, DoctorQueries>()
                .AddScoped<IDocumentQueries, DocumentQueries>()
                .AddScoped<IExamQueries, ExamQueries>()
                .AddScoped<IInvoiceQueries, InvoiceQueries>()
                .AddScoped<IMessageQueries, MessageQueries>()
                .AddScoped<IPatientQueries, PatientQueries>()
                .AddScoped<IPrescriptionQueries, PrescriptionQueries>()
                .AddScoped<IScheduleQueries, ScheduleQueries>()
                .AddScoped<IScreeningQueries, ScreeningQueries>()
                .AddScoped<ISpecialityQueries, SpecialityQueries>();

        return services;
    }
}
