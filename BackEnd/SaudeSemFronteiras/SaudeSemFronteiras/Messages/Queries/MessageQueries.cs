using Dapper;
using SaudeSemFronteiras.Application.Messages.Domain;
using SaudeSemFronteiras.Application.Messages.Dtos;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Messages.Queries;

public class MessageQueries(IDatabaseFactory databaseFactory) : IMessageQueries
{
    private readonly IDatabaseFactory LocalDatabase = databaseFactory;

    public async Task<IEnumerable<MessageDto>> GetAll(CancellationToken cancellationToken)
    {
        var sql = @"SELECT id as Id, 
                           message_date as MessageDate,
                           description as Description,
                           chat_id as ChatId
                      FROM messages ";

        var command = new CommandDefinition(sql, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryAsync<MessageDto>(command);
    }

    public async Task<Message?> GetById(long iD, CancellationToken cancellationToken)
    {
        var sql = @"select id as Id, 
                           message_date as MessageDate,
                           description as Description,
                           chat_id as ChatId
                      from messages
                     where id = @iD";

        var command = new CommandDefinition(sql, new { iD }, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        return await LocalDatabase.Connection.QueryFirstOrDefaultAsync<Message>(command);
    }

}
