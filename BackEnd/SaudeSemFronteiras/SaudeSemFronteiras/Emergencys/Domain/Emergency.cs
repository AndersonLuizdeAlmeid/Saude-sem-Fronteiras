namespace SaudeSemFronteiras.Application.Emergencys.Domain;
public class Emergency
{
    public long Id { get; private set; }
    public string Value { get; private set; } = string.Empty;
    public DateTime WaitTime { get; private set; }
    public bool IsActive { get; private set; }
    public long AppointmentId { get; private set; }

    public Emergency(long id, string value, DateTime waitTime, bool isActive, long appointmentId)
    {
        Id = id;
        Value = value;
        WaitTime = waitTime;
        IsActive = isActive;
        AppointmentId = appointmentId;
    }

    public static Emergency Create(string value, DateTime waitTime, long appointmentId) =>
        new(0, value, waitTime, true, appointmentId);

    public void Update(string value, DateTime waitTime, bool isActive, long appointmentId)
    {
        Value = value;
        WaitTime = waitTime;
        IsActive = isActive;
        AppointmentId = appointmentId;
    }
}
