namespace SaudeSemFronteiras.Application.Login.Dtos;
public class CredentialsDto
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public long UserId { get; set; }
}
