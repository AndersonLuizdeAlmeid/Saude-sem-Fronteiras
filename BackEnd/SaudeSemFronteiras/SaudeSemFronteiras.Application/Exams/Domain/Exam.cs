namespace SaudeSemFronteiras.Application.Exams.Domain;
public class Exam
{
    public long Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string Justification { get; private set; } = string.Empty;
    public DateTime DateExam { get; private set; }
    public string LocalExam { get; private set; } = string.Empty;
    public string Results { get; private set; } = string.Empty;
    public string Comments { get; private set; } = string.Empty;
    public long DocumentId { get; private set; }

    public Exam(long id, string description, string justification, string localExam, string results, string comments, long documentId)
    {
        Id = id;
        Description = description;
        Justification = justification;
        LocalExam = localExam;
        Results = results;
        Comments = comments;
        DocumentId = documentId;
    }

    public static Exam Create(string description, string justification, string localExam, string results, string comments, long documentId) =>
        new(0, description, justification, localExam, results, comments, documentId);

    public void Update(string description, string justification, DateTime dateExam, string localExam, string results, string comments, long documentId)
    {
        Description = description;
        Justification = justification;
        DateExam = dateExam;
        LocalExam = localExam;
        Results = results;
        Comments = comments;
        DocumentId = documentId;
    }
}
