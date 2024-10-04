namespace SaudeSemFronteiras.Application.Documents.Domain;
public class Document
{
    public long Id { get; private set; }
    public short TypeDocument { get; private set; }
    public DateTime DateDocument { get; private set; }
    public long AppointmentId { get; private set; }

    public Document(long id, short typeDocument, DateTime dateDocument, long appointmentId)
    {
        Id = id;
        TypeDocument = typeDocument;
        DateDocument = dateDocument;
        AppointmentId = appointmentId;
    }

    public static Document Create(short typeDocument, DateTime dateDocument, long appointmentId) =>
        new(0, typeDocument, dateDocument, appointmentId);

    public void Update(short typeDocument, DateTime dateDocument, long appointmentId)
    {
        TypeDocument = typeDocument;
        DateDocument = dateDocument;
        AppointmentId = appointmentId;
    }
}
