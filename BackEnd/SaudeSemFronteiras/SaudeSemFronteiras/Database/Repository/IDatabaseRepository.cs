﻿using SaudeSemFronteiras.Common.Repository;

namespace SaudeSemFronteiras.Application.Database.Repository;
public interface IDatabaseRepository : ILocalDatabaseRepository
{
    Task CreateLoginsTable();
    Task CreateUsersTable();
    Task CreatePhonesTable();
    Task CreateAddressesTable();
    Task CreateCountriesTable();
    Task CreateStatesTable();
    Task CreateCitiesTable();
}
