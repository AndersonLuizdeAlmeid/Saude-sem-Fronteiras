namespace SaudeSemFronteiras.Application.Login.Domain;
public class Credentials
{
    public long Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public long UserId { get; private set; }

    public Credentials(long id, string email, string password, long userId)
    {
        Id = id;
        Email = email;
        Password = password;
        UserId = userId;
    }

    public static Credentials Create(string email, string password, long userId) =>
        new(0, email, password, userId);

    public void Update(string email, string password, long userId)
    {
        Email = email;
        Password = password;
        UserId = userId;
    }
}
