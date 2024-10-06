using SaudeSemFronteiras.Application.Prescriptions.Domain;
using System.Xml.Linq;

namespace SaudeSemFronteiras.Application.Certificates.Domain;

public class Certificate
{
    public long Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Cpf { get; private set; } = string.Empty;
    public short Days { get; private set; }
    public long Cid { get; private set; }
    public long DocumentId { get; private set; }

    public Certificate(long id, string name, string cpf, short days, long cid, long documentId)
    {
        Id = id;
        Name = name;
        Cpf = cpf;
        Days = days;
        Cid = cid;
        DocumentId = documentId;
    }

    public static Certificate Create(string name, string cpf, short days, long cid, long documentId) =>
        new(0, name, cpf, days, cid, documentId);

    public void Update(string name, string cpf, short days, long cid, long documentId)
    {
        Name = name;
        Cpf = cpf;
        Days = days;
        Cid = cid;
        DocumentId = documentId;
    }
}
