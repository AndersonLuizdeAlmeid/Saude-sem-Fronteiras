using Dapper;
using SaudeSemFronteiras.Application.Certificates.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Certificates.Repository;
public class CertificateRepository(IDatabaseFactory LocalDatabase) : ICertificateRepository
{
    public async Task Insert(Certificate certificate, CancellationToken cancellationToken)
    {
        var sql = @"insert into certificates(name, cpf, days, cid, document_id) 
                    values (@Name, @Cpf, @Days, @Cid, @DocumentId)";

        var command = new CommandDefinition(sql, certificate, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
    public async Task Update(Certificate certificate, CancellationToken cancellationToken)
    {
        var sql = @"update certificates
                       set name = @Name, 
                           cpf = @Cpf,
                           days = @Days
                           cid = @Cid,
                           document_id = @DocumentId
                     where id = @Id";

        var command = new CommandDefinition(sql, certificate, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Delete(long iD, CancellationToken cancellationToken)
    {
        var sql = @"delete from certificates
                     where document_id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
