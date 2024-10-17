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
        var sql = @"INSERT INTO countries (id, description) 
                    VALUES (1, 'Brasil')";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task InsertStatesRecords()
    {
        var sql = @"INSERT INTO states (id, description, uf, country_id) 
                        VALUES (1, 'Acre', 'AC', 1),
                               (2, 'Alagoas', 'AL', 1),
                               (3, 'Amapá', 'AP', 1),
                               (4, 'Amazonas', 'AM', 1),
                               (5, 'Bahia', 'BA', 1),
                               (6, 'Ceará', 'CE', 1),
                               (7, 'Distrito Federal', 'DF', 1),
                               (8, 'Espírito Santo', 'ES', 1),
                               (9, 'Goiás', 'GO', 1),
                               (10, 'Maranhão', 'MA', 1),
                               (11, 'Mato Grosso', 'MT', 1),
                               (12, 'Mato Grosso do Sul', 'MS', 1),
                               (13, 'Minas Gerais', 'MG', 1),
                               (14, 'Pará', 'PA', 1),
                               (15, 'Paraíba', 'PB', 1),
                               (16, 'Paraná', 'PR', 1),
                               (17, 'Pernambuco', 'PE', 1),
                               (18, 'Piauí', 'PI', 1),
                               (19, 'Rio de Janeiro', 'RJ', 1),
                               (20, 'Rio Grande do Norte', 'RN', 1),
                               (21, 'Rio Grande do Sul', 'RS', 1),
                               (22, 'Rondônia', 'RO', 1),
                               (23, 'Roraima', 'RR', 1),
                               (24, 'Santa Catarina', 'SC', 1),
                               (25, 'São Paulo', 'SP', 1),
                               (26, 'Sergipe', 'SE', 1),
                               (27, 'Tocantins', 'TO', 1)";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }

    public async Task InsertCitiesRecords()
    {
        var sql = @" INSERT INTO cities (id, description, cep, state_id) 
                     VALUES (1, 'Rio Branco', '69900-000', 1),
                            (2, 'Maceió', '57000-000', 2),
                            (3, 'Macapá', '68900-000', 3),
                            (4, 'Manaus', '69000-000', 4),
                            (5, 'Salvador', '40000-000', 5),
                            (6, 'Fortaleza', '60000-000', 6),
                            (7, 'Brasília', '70000-000', 7),
                            (8, 'Vitória', '29000-000', 8),
                            (9, 'Goiânia', '74000-000', 9),
                            (10, 'São Luís', '65000-000', 10),
                            (11, 'Cuiabá', '78000-000', 11),
                            (12, 'Campo Grande', '79000-000', 12),
                            (13, 'Belo Horizonte', '30000-000', 13),
                            (14, 'Belém', '66000-000', 14),
                            (15, 'João Pessoa', '58000-000', 15),
                            (16, 'Curitiba', '80000-000', 16),
                            (17, 'Recife', '50000-000', 17),
                            (18, 'Teresina', '64000-000', 18),
                            (19, 'Rio de Janeiro', '20000-000', 19),
                            (20, 'Natal', '59000-000', 20),
                            (21, 'Porto Alegre', '90000-000', 21),
                            (22, 'Porto Velho', '76800-000', 22),
                            (23, 'Boa Vista', '69300-000', 23),
                            (24, 'Florianópolis', '88000-000', 24),
                            (25, 'São Paulo', '01000-000', 25),
                            (26, 'Aracaju', '49000-000', 26),
                            (27, 'Palmas', '77000-000', 27)";

        await LocalDatabase.Connection.ExecuteAsync(sql, transaction: LocalDatabase.Transaction);
    }
}
