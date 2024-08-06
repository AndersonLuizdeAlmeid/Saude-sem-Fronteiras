using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Exams.Commands;
public class ChangeExamCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateExam { get; set; }
    public string LocalExam { get; set; } = string.Empty;
    public string Results { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public long DocumentId { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do exame não pode ser nulo.");
        if (Title.IsNullOrEmpty())
            return Result.Failure("Título do exame não pode ser nulo.");
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição do exame não pode ser nulo.");
        if (DateExam.ToString().IsNullOrEmpty())
            return Result.Failure("Data do exame não pode ser nula.");
        if (LocalExam.IsNullOrEmpty())
            return Result.Failure("Local do exame não pode ser nulo.");
        if (DocumentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do documento não pode ser nulo.");

        return Result.Success();
    }
}
