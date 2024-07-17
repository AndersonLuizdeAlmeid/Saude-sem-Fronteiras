namespace SaudeSemFronteiras.Application.Users.Domain;
public class User
{
    public long Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string CPF { get; private set; } = string.Empty;
    public string MotherName { get; private set; } = string.Empty;
    public DateTime DateBirth { get; private set; }
    public DateTime DateOfCreation { get; private set; }
    public string Language { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    public User(long id, string name, string cPF, string motherName, DateTime dateBirth, DateTime dateOfCreation, string language, bool isActive)
    {
        Id = id;
        Name = name;
        CPF = cPF;
        MotherName = motherName;
        DateBirth = dateBirth;
        DateOfCreation = dateOfCreation;
        Language = language;
        IsActive = isActive;
    }

    public static User Create(string name, string cpf, string motherName, DateTime dateBirth, DateTime dateOfCreation, string language, bool isActive) =>
        new(0, name, cpf, motherName, dateBirth, DateTime.Now, language, isActive);

    public void Update(string name, string cpf, string motherName, DateTime dateBirth, string language, bool isActive)
    {
        Name = name;
        CPF = cpf;
        MotherName = motherName;
        DateBirth = dateBirth;
        Language = language;
        IsActive = isActive;
    }
}
