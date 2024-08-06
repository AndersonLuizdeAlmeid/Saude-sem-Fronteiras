namespace SaudeSemFronteiras.Application.Exams.Dtos;
public class ExamDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateExam { get; set; }
    public string LocalExam { get; set; } = string.Empty;
    public string Results { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public long DocumentId { get; set; }
}
