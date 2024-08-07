﻿using Dapper;
using SaudeSemFronteiras.Application.Certificates.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Certificates.Repository;
public class CertificateRepository(IDatabaseFactory LocalDatabase) : ICertificateRepository
{
    public async Task Insert(Certificate certificate, CancellationToken cancellationToken)
    {
        var sql = @"insert into certificates(issuance_date, title, description, start_date, final_date, observations, document_id) 
                    values (@IssuanceDate, @Title, @Description, @StartDate, @FinalDate, @Observations, @DocumentId)";

        var command = new CommandDefinition(sql, certificate, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Certificate certificate, CancellationToken cancellationToken)
    {
        var sql = @"update certificates
                       set issuance_date = @IssuanceDate, 
                           title = @Title, 
                           description = @Description,
                           start_date = @StartDate
                           final_date = @FinalDate,
                           observations = @Observations,
                           document_id = @DocumentId
                     where id = @Id";

        var command = new CommandDefinition(sql, certificate, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
