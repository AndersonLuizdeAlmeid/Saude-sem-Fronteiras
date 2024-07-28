namespace SaudeSemFronteiras.Application.Exams.Domain;
public class Exam
{
    public long Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime DateExam { get; private set; }
    public string LocalExam { get; private set; } = string.Empty;
    public string Results { get; private set; } = string.Empty;
    public string Comments { get; private set; } = string.Empty;

    public Exam(long id, string title, string description, DateTime dateExam, string localExam, string results, string comments)
    {
        Id = id;
        Title = title;
        Description = description;
        DateExam = dateExam;
        LocalExam = localExam;
        Results = results;
        Comments = comments;
    }

    public static Exam Create(string title, string description, DateTime dateExam, string localExam, string results, string comments) =>
        new(0, title, description, dateExam, localExam, results, comments);

    public void Update(string title, string description, DateTime dateExam, string localExam, string results, string comments)
    {
        Title = title;
        Description = description;
        DateExam = dateExam;
        LocalExam = localExam;
        Results = results;
        Comments = comments;
    }
}
