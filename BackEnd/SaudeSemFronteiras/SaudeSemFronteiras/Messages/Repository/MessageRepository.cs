﻿using Dapper;
using SaudeSemFronteiras.Application.Messages.Domain;
using SaudeSemFronteiras.Common.Factory.Interfaces;

namespace SaudeSemFronteiras.Application.Messages.Repository;
public class MessageRepository(IDatabaseFactory LocalDatabase) : IMessageRepository
{
    public async Task Insert(Message message, CancellationToken cancellationToken)
    {
        var sql = @"insert into messages(message_date, description, chat_id) 
                                 values (@MessageDate, @Description, @ChatId)";
        var command = new CommandDefinition(sql, message, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }

    public async Task Update(Message message, CancellationToken cancellationToken)
    {
        var sql = @"update messages
                       set message_date = @MessageDate,
                           description = @Description,
                           chat_id = @ChatId
                     where id = @Id";

        var command = new CommandDefinition(sql, message, transaction: LocalDatabase.Transaction, cancellationToken: cancellationToken);
        await LocalDatabase.Connection.ExecuteAsync(command);
    }
}
