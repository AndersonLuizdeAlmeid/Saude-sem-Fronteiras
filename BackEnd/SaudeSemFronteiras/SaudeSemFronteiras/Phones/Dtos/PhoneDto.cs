namespace SaudeSemFronteiras.Application.Phones.Dtos;

public class PhoneDto
{
    public long Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public long UserId { get; set; }
}
