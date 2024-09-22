namespace SaudeSemFronteiras.Application.Emergencys.Domain;
public class Emergency
{
    public long Id { get; private set; }
    public decimal Price { get; private set; }
    public string WaitTime { get; private set; } = string.Empty;
    public short Status { get; private set; }
    public long AppointmentId { get; private set; }

    public Emergency(long id, decimal price, string waitTime, short status, long appointmentId)
    {
        Id = id;
        Price = price;
        WaitTime = waitTime;
        Status = status;
        AppointmentId = appointmentId;
    }

    public static Emergency Create(decimal price, string waitTime, long appointmentId) =>
        new(0, price, waitTime, 1, appointmentId);

    public void Update(decimal price, string waitTime, short status, long appointmentId)
    {
        Price = price;
        WaitTime = waitTime;
        Status = status;
        AppointmentId = appointmentId;
    }
}
