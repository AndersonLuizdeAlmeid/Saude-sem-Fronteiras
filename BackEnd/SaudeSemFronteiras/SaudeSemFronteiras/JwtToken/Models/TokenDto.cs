namespace SaudeSemFronteiras.Application.JwtToken.Models;
public class TokenDto
{
    public long UserID { get; set; }
    public bool IsDoctor { get; set; }
    public DateTime ExpirationDate { get; set; }
}
