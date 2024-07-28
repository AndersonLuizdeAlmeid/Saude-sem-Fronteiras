using SaudeSemFronteiras.Application.Exams.Domain;

namespace SaudeSemFronteiras.Application.Exams.Repository;
public interface IExamRepository
{
    Task<Exam?> GetById(long iD, CancellationToken cancellationToken);
    Task Insert(Exam exam, CancellationToken cancellationToken);
    Task Update(Exam exam, CancellationToken cancellationToken);
}
