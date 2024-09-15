namespace SaudeSemFronteiras.Application.Users.Dtos;
public class UserDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string MotherName { get; set; } = string.Empty;
    public DateTime DateBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public long CredentialsId {  get; set; }
}
