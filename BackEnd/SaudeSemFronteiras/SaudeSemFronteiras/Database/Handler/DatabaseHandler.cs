using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Countries.Queries;
using SaudeSemFronteiras.Application.Database.Commands;
using SaudeSemFronteiras.Application.Database.Repository;

namespace SaudeSemFronteiras.Application.Database.Handler;
public class DatabaseHandler : IRequestHandler<CreateTablesCommand, Result>
{
    private readonly IDatabaseRepository _databaseRepository;
    private readonly ICountryQueries _countryQueries;
    private readonly IDatabaseInsertsRepository _databaseInsertsRepository;

    public DatabaseHandler(IDatabaseRepository databaseRepository, ICountryQueries countryQueries, IDatabaseInsertsRepository databaseInsertsRepository)
    {
        _databaseRepository = databaseRepository;
        _countryQueries = countryQueries;
        _databaseInsertsRepository = databaseInsertsRepository;
    }

    public async Task<Result> Handle(CreateTablesCommand request, CancellationToken cancellationToken)
    {
        _databaseRepository.LocalDatabase.Begin();
       
        await _databaseRepository.CreateCountriesTable();
        await _databaseRepository.CreateStatesTable();
        await _databaseRepository.CreateCitiesTable();
        await _databaseRepository.CreateAddressesTable();
        await _databaseRepository.CreateUsersTable();
        await _databaseRepository.CreateLoginsTable();
        await _databaseRepository.CreatePhonesTable();
        await _databaseRepository.CreatePatientsTable();
        await _databaseRepository.CreateDoctorsTable();
        await _databaseRepository.CreateSpecialitiesTable();
        await _databaseRepository.CreateAppointmentsTable();
        await _databaseRepository.CreateInvoicesTable();
        await _databaseRepository.CreateChatsTable();
        await _databaseRepository.CreateMessagesTable();
        await _databaseRepository.CreateDocumentsTable();
        await _databaseRepository.CreateExamsTable();
        await _databaseRepository.CreatePrescriptionsTable();
        await _databaseRepository.CreateCertificatesTable();
        await _databaseRepository.CreateScheduledTable();
        await _databaseRepository.CreateEmergenciesTable();
        await _databaseRepository.CreateScreeningsTable();

        if (await _countryQueries.GetCountryCountable() > 0)
        {
            await _databaseInsertsRepository.InsertCountriesRecords();
            await _databaseInsertsRepository.InsertStatesRecords();
            await _databaseInsertsRepository.InsertCitiesRecords();
        }

        _databaseRepository.LocalDatabase.Commit();

        return Result.Success();
    }
}
