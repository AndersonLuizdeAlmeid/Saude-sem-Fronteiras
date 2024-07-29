namespace SaudeSemFronteiras.Application.Chat.Dtos;

public class ChatDto
{
    public long Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime ChatDate { get; set; }
    public long AppointmentId { get; set; }
}
