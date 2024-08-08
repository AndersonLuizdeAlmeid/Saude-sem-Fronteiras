using Dapper;
using SaudeSemFronteiras.Application.Chats.Domain;
using SaudeSemFronteiras.Application.Chats.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Chats.Queries;

public class ChatQueries(IDatabaseFactory databaseFactory) : IChatQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<ChatDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           chat_date as ChatDate,
                           status as Status,
                           appointment_id as AppointmentId
                      FROM chats ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<ChatDto>(command);
    }

    public async Task<Chat?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           chat_date as ChatDate,
                           status as Status,
                           appointment_id as AppointmentId
                      from chats
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Chat>(command);
    }
}
