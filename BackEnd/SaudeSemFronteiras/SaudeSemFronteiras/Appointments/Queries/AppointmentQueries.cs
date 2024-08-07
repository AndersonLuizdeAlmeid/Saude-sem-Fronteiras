﻿using Dapper;
using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Application.Appointments.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Appointments.Queries;

public class AppointmentQueries(IDatabaseFactory databaseFactory) : IAppointmentQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<AppointmentDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           time as Time,
                           duration as Duration
                      FROM appointments ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<AppointmentDto>(command);
    }

    public async Task<Appointment?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           time as Time,
                           duration as Duration
                      from appointments
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Appointment>(command);
    }
}
