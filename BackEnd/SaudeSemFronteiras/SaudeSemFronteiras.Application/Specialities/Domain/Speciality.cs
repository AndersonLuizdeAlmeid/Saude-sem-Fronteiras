using SaudeSemFronteiras.Application.Doctors.Domain;

namespace SaudeSemFronteiras.Application.Specialities.Domain;
public class Speciality
{
    public long Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public long DoctorId { get; private set; }

    public Speciality(long id, string description, bool isActive, long doctorId)
    {
        Id = id;
        Description = description;
        IsActive = isActive;
        DoctorId = doctorId;
    }

    public static Speciality Create(string description, bool isActive, long doctorId) =>
        new(0, description, isActive, doctorId);

    public void Update(string description, bool isActive, long doctorId)
    {
        Description = description;
        IsActive = isActive;
        DoctorId = doctorId;
    }
}

