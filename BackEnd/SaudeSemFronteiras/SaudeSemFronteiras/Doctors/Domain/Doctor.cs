namespace SaudeSemFronteiras.Application.Doctors.Domain;
public class Doctor
{
    public long Id { get; private set; }
    public string RegistryNumber { get; private set; } = string.Empty;
    public string AvaibalityHours { get; private set; } = string.Empty;
    public decimal ConsultationPrince { get; private set; }
    public long IdUser { get; private set; }

    public Doctor(long id, string registryNumber, string avaibalityHours, decimal consultationPrince, long idUser)
    {
        Id = id;
        RegistryNumber = registryNumber;
        AvaibalityHours = avaibalityHours;
        ConsultationPrince = consultationPrince;
        IdUser = idUser;
    }

    public static Doctor Create(string registryNumber, string avaibalityHours, decimal consultationPrince, long idUser) =>
        new(0, registryNumber, avaibalityHours, consultationPrince, idUser);

    public void Update(string registryNumber, string avaibalityHours, decimal consultationPrince, long idUser)
    {
        RegistryNumber = registryNumber;
        AvaibalityHours = avaibalityHours;
        ConsultationPrince = consultationPrince;
        IdUser = idUser;
    }

}
