using Dapper;
using SaudeSemFronteiras.Application.Chats.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Chats.Repository;
public class ChatRepository(IDatabaseFactory LocalDatabase) : IChatRepository
{
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
