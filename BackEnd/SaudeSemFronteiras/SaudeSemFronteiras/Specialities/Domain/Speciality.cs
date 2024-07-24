namespace SaudeSemFronteiras.Application.Specialities.Domain;
public class Speciality
{
    public long Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public long IdDoctor { get; private set; }

    public Speciality(long id, string description, bool isActive, long idDoctor)
    {
        Id = id;
        Description = description;
        IsActive = isActive;
        IdDoctor = idDoctor;
    }

    public static Speciality Create(string description, bool isActive, long idDoctor) =>
        new(0, description, isActive, idDoctor);

    public void Update(string description, bool isActive, long idDoctor)
    {
        Description = description;
        IsActive = isActive;
        IdDoctor = idDoctor;
    }
}

