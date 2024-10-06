namespace SaudeSemFronteiras.Application.Login.Domain;
public class Credentials
{
    public long Id { get; private set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;

    public Credentials(long id, string email, string password)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public static Credentials Create(string email, string password) =>
        new(0, email, password);

    public void Update(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
