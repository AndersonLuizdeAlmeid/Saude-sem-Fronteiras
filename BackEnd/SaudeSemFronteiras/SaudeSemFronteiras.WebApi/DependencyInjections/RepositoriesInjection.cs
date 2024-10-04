using SaudeSemFronteiras.Application.Addresses.Repositories;
using SaudeSemFronteiras.Application.Appointments.Repository;
using SaudeSemFronteiras.Application.Certificates.Repository;
using SaudeSemFronteiras.Application.Database.Repository;
using SaudeSemFronteiras.Application.Doctors.Repository;
using SaudeSemFronteiras.Application.Documents.Repository;
using SaudeSemFronteiras.Application.Emergencys.Repository;
using SaudeSemFronteiras.Application.Exams.Repository;
using SaudeSemFronteiras.Application.Invoices.Repository;
using SaudeSemFronteiras.Application.Login.Repository;
using SaudeSemFronteiras.Application.Medicines.Repositories;
using SaudeSemFronteiras.Application.Patients.Repository;
using SaudeSemFronteiras.Application.Prescriptions.Repository;
using SaudeSemFronteiras.Application.Scheduled.Repository;
using SaudeSemFronteiras.Application.Screenings.Repository;
using SaudeSemFronteiras.Application.Specialities.Repository;
using SaudeSemFronteiras.Application.Users.Repository;

namespace SaudeSemFronteiras.WebApi.DependencyInjections;
public static class RepositoriesInjection
{
    public static IServiceCollection AddRepositoriesInjection(this IServiceCollection services)
    {
        services.AddScoped<IAddressRepository, AddressRepository>()
                .AddScoped<IAppointmentRepository, AppointmentRepository>()
                .AddScoped<ICertificateRepository, CertificateRepository>()
                .AddScoped<ICredentialsRepository, CredentialsRepository>()
                .AddScoped<IDoctorRepository, DoctorRepository>()
                .AddScoped<IDocumentRepository, DocumentRepository>()
                .AddScoped<IEmergencyRepository, EmergencyRepository>()
                .AddScoped<IExamRepository, ExamRepository>()
                .AddScoped<IInvoiceRepository, InvoiceRepository>()
                .AddScoped<IPatientRepository, PatientRepository>()
                .AddScoped<IPrescriptionRepository, PrescriptionRepository>()
                .AddScoped<IScheduleRepository, ScheduleRepository>()
                .AddScoped<IScreeningRepository, ScreeningRepository>()
                .AddScoped<ISpecialityRepository, SpecialityRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IMedicineRepository, MedicineRepository>()
                .AddScoped<IDatabaseRepository, DatabaseRepository>()
                .AddScoped<IDatabaseInsertsRepository, DatabaseInsertsRepository>();

        return services;
    }
}
