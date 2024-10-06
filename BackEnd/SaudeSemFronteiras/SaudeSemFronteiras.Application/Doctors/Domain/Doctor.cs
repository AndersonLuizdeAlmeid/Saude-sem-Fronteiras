namespace SaudeSemFronteiras.Application.Doctors.Domain;
public class Doctor
{
    public long Id { get; private set; }
    public string RegistryNumber { get; private set; } = string.Empty;
    public string InitialHour { get; private set; } = string.Empty;
    public string FinalHour { get; private set; } = string.Empty;
    public decimal ConsultationPrice { get; private set; }
    public string Days { get; private set; } = string.Empty;
    public long UserId { get; private set; }

    public Doctor(long id, string registryNumber, string initialHour, string finalHour, decimal consultationPrice, string days, long userId)
    {
        Id = id;
        RegistryNumber = registryNumber;
        InitialHour = initialHour;
        FinalHour = finalHour;
        ConsultationPrice = consultationPrice;
        Days = days;
        UserId = userId;
    }

    public static Doctor Create(string registryNumber, string initialHour, string finalHour, decimal consultationPrice, string days, long userId) =>
        new(0, registryNumber, initialHour, finalHour, consultationPrice, days, userId);

    public void Update(string registryNumber, string initialHour, string finalHour, decimal consultationPrice, string days, long userId)
    {
        RegistryNumber = registryNumber;
        InitialHour = initialHour;
        FinalHour = finalHour;
        ConsultationPrice = consultationPrice;
        Days = days;
        UserId = userId;
    }

}
