using SaudeSemFronteiras.Application.Exams.Domain;

namespace SaudeSemFronteiras.Application.Exams.Repository;
public interface IExamRepository
{
    Task Insert(Exam exam, CancellationToken cancellationToken);
    Task Update(Exam exam, CancellationToken cancellationToken);
    Task Delete(long iD, CancellationToken cancellationToken);
}
