﻿using Dapper;
using SaudeSemFronteiras.Application.Prescriptions.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Prescriptions.Repository;
public class PrescriptionRepository(IDatabaseFactory LocalDatabase) : IPrescriptionRepository
{
    public async Task Insert(Prescription prescription, CancellationToken cancellationToken)
    {
        var sql = @"insert into prescriptions(issuance_date, title, description, final_date, observations, prescritpion_validate, document_id) 
                    values (@IssuanceDate, @Title, @Description, @FinalDate, @Observations, @PrescriptionValidate, @DocumentId)";

        var command = new CommandDefinition(sql, prescription, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Prescription prescription, CancellationToken cancellationToken)
    {
        var sql = @"update prescriptions
                       set issuance_date = @IssuanceDate, 
                           title = @Title, 
                           description = @Description,
                           final_date = @FinalDate,
                           observations = @Observations,
                           prescritpion_validate = @PrescriptionValidate,
                           document_id = @DocumentId
                     where id = @Id";

        var command = new CommandDefinition(sql, prescription, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
