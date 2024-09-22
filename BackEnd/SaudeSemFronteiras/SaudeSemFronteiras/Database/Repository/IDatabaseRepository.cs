using SaudeSemFronteiras.Common.Repository;

namespace SaudeSemFronteiras.Application.Database.Repository;
public interface IDatabaseRepository : ILocalDatabaseRepository
{
    Task CreateCountriesTable();
    Task CreateStatesTable();
    Task CreateCitiesTable();
    Task CreateAddressesTable();
    Task CreateUsersTable();
    Task CreateCredentialsTable();
    Task CreatePatientsTable();
    Task CreateDoctorsTable();
    Task CreateSpecialitiesTable();
    Task CreateAppointmentsTable();
    Task CreateInvoicesTable();
    Task CreateChatsTable();
    Task CreateMessagesTable();
    Task CreateDocumentsTable();
    Task CreateExamsTable();
    Task CreatePrescriptionsTable();
    Task CreateCertificatesTable();
    Task CreateScheduledTable();
    Task CreateEmergenciesTable();
    Task CreateScreeningsTable();
}
