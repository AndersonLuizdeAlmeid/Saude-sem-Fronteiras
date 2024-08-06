using Dapper;
using SaudeSemFronteiras.Application.Chats.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Chats.Repository;
public class ChatRepository(IDatabaseFactory LocalDatabase) : IChatRepository
{
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

    public async Task Insert(Chat chat, CancellationToken cancellationToken)
    {
        var sql = @"insert into chats(chat_date, status, appointment_id) 
                                 values (@ChatDate, @Status, @AppointmentId)";
        var command = new CommandDefinition(sql, chat, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Chat chat, CancellationToken cancellationToken)
    {
        var sql = @"update chats
                       set chat_date = @ChatDate,
                           status = @Status,
                           appointment_id = @AppointmentId
                     where id = @Id";

        var command = new CommandDefinition(sql, chat, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
