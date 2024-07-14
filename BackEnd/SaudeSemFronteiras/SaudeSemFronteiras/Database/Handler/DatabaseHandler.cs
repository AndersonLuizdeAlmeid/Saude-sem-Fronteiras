using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Database.Commands;
using SaudeSemFronteiras.Application.Database.Repository;

namespace SaudeSemFronteiras.Application.Database.Handler;
public class DatabaseHandler : IRequestHandler<CreateTablesCommand, Result>
{
    private readonly IDatabaseRepository _databaseRepository;

    public DatabaseHandler(IDatabaseRepository databaseRepository)
    {
        _databaseRepository = databaseRepository;
    }

    public async Task<Result> Handle(CreateTablesCommand request, CancellationToken cancellationToken)
    {
        _databaseRepository.LocalDatabase.Begin();
        await _databaseRepository.CreateLoginsTable();
        await _databaseRepository.CreateUsersTable();
        _databaseRepository.LocalDatabase.Commit();

        return Result.Success();
    }
}
