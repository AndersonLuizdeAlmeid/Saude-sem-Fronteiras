namespace SaudeSemFronteiras.Application.Doctors.Domain;
public class Doctor
{
    public long Id { get; private set; }
    public string RegistryNumber { get; private set; } = string.Empty;
    public string AvaibalityHours { get; private set; } = string.Empty;
    public decimal ConsultationPrince { get; private set; }
    public long UserId { get; private set; }

    public Doctor(long id, string registryNumber, string avaibalityHours, decimal consultationPrince, long userId)
    {
        Id = id;
        RegistryNumber = registryNumber;
        AvaibalityHours = avaibalityHours;
        ConsultationPrince = consultationPrince;
        UserId = userId;
    }

    public static Doctor Create(string registryNumber, string avaibalityHours, decimal consultationPrince, long userId) =>
        new(0, registryNumber, avaibalityHours, consultationPrince, userId);

    public void Update(string registryNumber, string avaibalityHours, decimal consultationPrince, long userId)
    {
        RegistryNumber = registryNumber;
        AvaibalityHours = avaibalityHours;
        ConsultationPrince = consultationPrince;
        UserId = userId;
    }

}
