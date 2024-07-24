namespace SaudeSemFronteiras.Application.Specialities.Domain;
public class Speciality
{
    public long Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    public Speciality(long id, string description, bool isActive)
    {
        Id = id;
        Description = description;
        IsActive = isActive;
    }

    public static Speciality Create(string description, bool isActive) =>
        new(0, description, isActive);

    public void Update(string description, bool isActive)
    {
        Description = description;
        IsActive = isActive;
    }
}

