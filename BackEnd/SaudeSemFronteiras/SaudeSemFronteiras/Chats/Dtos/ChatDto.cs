namespace SaudeSemFronteiras.Application.Chats.Dtos;

public class ChatDto
{
    public long Id { get; set; }
    public DateTime ChatDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public long AppointmentId { get; set; }
}
