namespace SaudeSemFronteiras.Application.Messages.Domain;

public class Message
{
    public long Id { get; private set; }
    public DateTime MessageDate { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public long ChatId { get; private set; }

    public Message(long id, DateTime messageDate, string description, long chatId)
    {
        Id = id;
        MessageDate = messageDate;
        Description = description;
        ChatId = chatId;
    }

    public static Message Create(DateTime messageDate, string description, long chatId) =>
    new(0, messageDate, description, chatId);

    public void Update(DateTime messageDate, string description, long chatId)
    {
        MessageDate = messageDate;
        Description = description;
        ChatId = chatId;
    }
}
