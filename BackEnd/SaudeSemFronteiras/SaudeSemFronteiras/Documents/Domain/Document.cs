namespace SaudeSemFronteiras.Application.Documents.Domain;
public class Document
{
    public long Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public short TypeDocument { get; private set; }
    public DateTime DateDocument { get; private set; }
    //:TODO VERIFICAR COMO CRIAR ASSINATURA DIGITAL
    public short DigitallySigned { get; private set; }
    public long AppointmentId { get; private set; }

    public Document(long id, string description, short typeDocument, DateTime dateDocument, short digitallySigned, long appointmentId)
    {
        Id = id;
        Description = description;
        TypeDocument = typeDocument;
        DateDocument = dateDocument;
        DigitallySigned = digitallySigned;
        AppointmentId = appointmentId;
    }

    public static Document Create(string description, short typeDocument, DateTime dateDocument, short digitallySigned, long appointmentId) =>
        new(0, description, typeDocument, dateDocument, digitallySigned, appointmentId);

    public void Update(string description, short typeDocument, DateTime dateDocument, short digitallySigned, long appointmentId)
    {
        Description = description;
        TypeDocument = typeDocument;
        DateDocument = dateDocument;
        DigitallySigned = digitallySigned;
        AppointmentId = appointmentId;
    }
}
