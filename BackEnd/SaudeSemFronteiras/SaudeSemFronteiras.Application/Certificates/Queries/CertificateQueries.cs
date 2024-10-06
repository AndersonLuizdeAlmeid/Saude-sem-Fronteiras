using Dapper;
using SaudeSemFronteiras.Application.Certificates.Domain;
using SaudeSemFronteiras.Application.Certificates.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;
using System.Xml.Linq;

namespace SaudeSemFronteiras.Application.Certificates.Queries;

public class CertificateQueries(IDatabaseFactory databaseFactory) : ICertificateQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<CertificateDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           name as Name,
                           cpf as Cpf,
                           days as Days,
                           cid as Cid,
                           document_id as DocumentId
                      FROM certificates ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<CertificateDto>(command);
    }

    public async Task<Certificate?> GetByID(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id,
                           name as Name,
                           cpf as Cpf,
                           days as Days,
                           cid as Cid,
                           document_id as DocumentId
                      from certificates
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Certificate>(command);
    }

    public async Task<CertificateShowDto?> GetByIdDtoQuery(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select certificates.name as Name,
                           certificates.cpf as Cpf,
                           certificates.days as Days,
                           certificates.cid as Cid,
                           users.name as NameDoctor,
                           doctors.registry_number as Crm,
                           cities.description as CityDescription
                      from certificates inner join documents
                      							on documents.id = certificates.document_id 
                      					inner join appointments 
                      							on documents.appointment_id = appointments.id 
                      					inner join doctors 
                      							on appointments.doctor_id = doctors.id
                      					inner join users 
                      							on users.id = doctors.user_id
                                        inner join addresses 
                                                on doctors.user_id = addresses.user_id 
       									inner join cities
       											on cities.id = addresses.city_id
                     where document_id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<CertificateShowDto>(command);
    }

    public async Task<CertificateDto?> GetCertificateByDocumentIdQuery(long documentId, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           name as Name,
                           cpf as Cpf,
                           days as Days,
                           cid as Cid,
                           document_id as DocumentId
                      from certificates
                     where document_id = @documentId";

        var command = new CommandDefinition(sql, new { documentId }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<CertificateDto>(command);
    }
}
