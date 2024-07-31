using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Certificates.Commands;
public class CreateCertificateCommand : IRequest<Result>
{
    public DateTime IssuanceDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime FinalDate { get; set; }
    public string Observations { get; set; } = string.Empty;
    public long DocumentId { get; set; }

    public Result Validation()
    {
        if (IssuanceDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data de emissão do atestado não pode ser nulo.");
        if (Title.IsNullOrEmpty())
            return Result.Failure("Título do atestado não pode ser nulo.");
        if (Description.IsNullOrEmpty())
            return Result.Failure("Descrição do atestado não pode ser nulo.");
        if (StartDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data de início do atestado não pode ser nulo.");
        if (FinalDate.ToString().IsNullOrEmpty())
            return Result.Failure("Data de final do atestado não pode ser nulo.");
        if (DocumentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do documento não pode ser nulo.");

        return Result.Success();
    }
}
