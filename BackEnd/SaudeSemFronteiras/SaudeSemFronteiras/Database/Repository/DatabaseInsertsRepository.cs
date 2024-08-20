using Dapper;
using SaudeSemFronteiras.Common.Factory.Interfaces;
using SaudeSemFronteiras.Common.Repository;

namespace SaudeSemFronteiras.Application.Database.Repository;
public class DatabaseInsertsRepository : IDatabaseInsertsRepository
{
    public IDatabaseFactory LocalDatabase { get; }
    public DatabaseInsertsRepository(IDatabaseFactory databaseFactory)
    {
        LocalDatabase = databaseFactory;
    }
    public async Task InsertCountriesRecords()
    {
        var sql = @"INSERT INTO countries (Id, Description) 
                    VALUES (1, 'Brazil')";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task InsertStatesRecords()
    {
        var sql = @"INSERT INTO states (Id, Description, CountryId) 
                    VALUES (1, 'Acre', 1),
                           (2, 'Alagoas', 1),
                           (3, 'Amapá', 1),
                           (4, 'Amazonas', 1),
                           (5, 'Bahia', 1),
                           (6, 'Ceará', 1),
                           (7, 'Distrito Federal', 1),
                           (8, 'Espírito Santo', 1),
                           (9, 'Goiás', 1),
                           (10, 'Maranhão', 1),
                           (11, 'Mato Grosso', 1),
                           (12, 'Mato Grosso do Sul', 1),
                           (13, 'Minas Gerais', 1),
                           (14, 'Pará', 1),
                           (15, 'Paraíba', 1),
                           (16, 'Paraná', 1),
                           (17, 'Pernambuco', 1),
                           (18, 'Piauí', 1),
                           (19, 'Rio de Janeiro', 1),
                           (20, 'Rio Grande do Norte', 1),
                           (21, 'Rio Grande do Sul', 1),
                           (22, 'Rondônia', 1),
                           (23, 'Roraima', 1),
                           (24, 'Santa Catarina', 1),
                           (25, 'São Paulo', 1),
                           (26, 'Sergipe', 1),
                           (27, 'Tocantins', 1)";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task InsertCitiesRecords()
    {
        var sql = @" INSERT INTO City (Id, Description, StateId) 
                     VALUES (1, 'Rio Branco', 1),
                            (2, 'Maceió', 2),
                            (3, 'Macapá', 3),
                            (4, 'Manaus', 4),
                            (5, 'Salvador', 5),
                            (6, 'Fortaleza', 6),
                            (7, 'Brasília', 7),
                            (8, 'Vitória', 8),
                            (9, 'Goiânia', 9),
                            (10, 'São Luís', 10),
                            (11, 'Cuiabá', 11),
                            (12, 'Campo Grande', 12),
                            (13, 'Belo Horizonte', 13),
                            (14, 'Belém', 14),
                            (15, 'João Pessoa', 15),
                            (16, 'Curitiba', 16),
                            (17, 'Recife', 17),
                            (18, 'Teresina', 18),
                            (19, 'Rio de Janeiro', 19),
                            (20, 'Natal', 20),
                            (21, 'Porto Alegre', 21),
                            (22, 'Porto Velho', 22),
                            (23, 'Boa Vista', 23),
                            (24, 'Florianópolis', 24),
                            (25, 'São Paulo', 25),
                            (26, 'Aracaju', 26),
                            (27, 'Palmas', 27)";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }
}
