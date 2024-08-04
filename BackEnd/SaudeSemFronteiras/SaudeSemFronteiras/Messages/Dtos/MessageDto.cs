namespace SaudeSemFronteiras.Application.Messages.Dtos;

public class MessageDto
{
    public long Id { get; set; }
    public DateTime MessageDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public long ChatId { get; set; }
}
