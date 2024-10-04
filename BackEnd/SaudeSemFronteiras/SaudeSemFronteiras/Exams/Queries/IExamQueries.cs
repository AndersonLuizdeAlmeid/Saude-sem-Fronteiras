using SaudeSemFronteiras.Application.Certificates.Dtos;
using SaudeSemFronteiras.Application.Exams.Domain;
using SaudeSemFronteiras.Application.Exams.Dtos;

namespace SaudeSemFronteiras.Application.Exams.Queries;
public interface IExamQueries
{
    Task<IEnumerable<ExamDto>> GetAll(CancellationToken cancellationToken);
    Task<Exam?> GetById(long iD, CancellationToken cancellationToken);
    Task<ExamDtoShow?> GetExamByDocumentIdQuery(long iD, CancellationToken cancellationToken);
}
