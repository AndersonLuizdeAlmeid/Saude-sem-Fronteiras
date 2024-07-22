namespace SaudeSemFronteiras.Application.Doctors.Domain;
public class Doctor
{
    public long Id { get; private set; }
    public string RegistryNumber { get; private set; } = string.Empty;
    public string AvaibalityHours { get; private set; } = string.Empty;
    public decimal ConsultationPrince { get; private set; }
    public long IdUser { get; private set; }
    public long IdAppointment { get; private set; }

    public Doctor(long id, string registryNumber, string avaibalityHours, decimal consultationPrince, long idUser, long idAppointment)
    {
        Id = id;
        RegistryNumber = registryNumber;
        AvaibalityHours = avaibalityHours;
        ConsultationPrince = consultationPrince;
        IdUser = idUser;
        IdAppointment = idAppointment;
    }

    public static Doctor Create(string registryNumber, string avaibalityHours, decimal consultationPrince, long idUser, long idAppointment) =>
        new(0, registryNumber, avaibalityHours, consultationPrince, idUser, idAppointment);

    public void Update(string registryNumber, string avaibalityHours, decimal consultationPrince, long idUser, long idAppointment)
    {
        RegistryNumber = registryNumber;
        AvaibalityHours = avaibalityHours;
        ConsultationPrince = consultationPrince;
        IdUser = idUser;
        IdAppointment = idAppointment;
    }

}
