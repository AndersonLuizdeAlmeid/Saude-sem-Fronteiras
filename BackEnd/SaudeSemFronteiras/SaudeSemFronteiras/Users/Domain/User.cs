using SaudeSemFronteiras.Application.Login.Domain;

namespace SaudeSemFronteiras.Application.Users.Domain;
public class User
{
    public long Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string CPF { get; private set; } = string.Empty;
    public string MotherName { get; private set; } = string.Empty;
    public DateTime DateBirth { get; private set; }
    public DateTime DateOfCreation { get; private set; }
    public string Gender { get; private set; } = string.Empty;
    public string Language { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public string Phone { get; private set; } = string.Empty;
    public long CredentialsId { get; private set; }

    public User(long id, string name, string cPF, string motherName, DateTime dateBirth, DateTime dateOfCreation, string gender, string language, bool isActive, string phone, long credentialsId)
    {
        Id = id;
        Name = name;
        CPF = cPF;
        MotherName = motherName;
        DateBirth = dateBirth;
        DateOfCreation = dateOfCreation;
        Gender = gender;
        Language = language;
        IsActive = isActive;
        Phone = phone;
        CredentialsId = credentialsId;
    }

    public User(long id, string name, string cPF, string motherName, DateTime dateBirth, string gender, string language, bool isActive, string phone)
    {
        Id = id;
        Name = name;
        CPF = cPF;
        MotherName = motherName;
        DateBirth = dateBirth;
        Gender = gender;
        Language = language;
        IsActive = isActive;
        Phone = phone;
    }

    public static User Create(string name, string cpf, string motherName, DateTime dateBirth, DateTime dateOfCreation, string gender, string language, bool isActive, string phone, long credentialsId) =>
        new(0, name, cpf, motherName, dateBirth, DateTime.Now, gender, language, isActive, phone, credentialsId);

    public void Update(string name, string cpf, string motherName, DateTime dateBirth, string gender, string language, bool isActive, string phone)
    {
        Name = name;
        CPF = cpf;
        MotherName = motherName;
        DateBirth = dateBirth;
        Gender = gender;
        Language = language;
        IsActive = isActive;
        Phone = phone;
    }
}
