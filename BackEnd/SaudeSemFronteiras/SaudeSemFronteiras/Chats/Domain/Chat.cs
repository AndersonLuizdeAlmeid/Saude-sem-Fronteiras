namespace SaudeSemFronteiras.Application.Chats.Domain;

public class Chat
{
    public long Id { get; private set; }
    public DateTime ChatDate { get; private set; }
    public string Status { get; private set; } = string.Empty;
    public long AppointmentId { get; private set; }

    public Chat(long id, DateTime chatDate, string status, long appointmentId)
    {
        Id = id;
        ChatDate = chatDate;
        Status = status;
        AppointmentId = appointmentId;
    }

    public static Chat Create(DateTime chatDate, string status, long appointmentId) =>
        new(0, chatDate, status, appointmentId);

    public void Update(DateTime chatDate, string status, long appointmentId)
    {
        ChatDate = chatDate;
        Status = status;
        AppointmentId = appointmentId;
    }
}
