using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Exams.Commands;
public class DeleteExamCommand : IRequest<Result>
{
    public long Id { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do exame não pode ser nulo.");

        return Result.Success();
    }
}