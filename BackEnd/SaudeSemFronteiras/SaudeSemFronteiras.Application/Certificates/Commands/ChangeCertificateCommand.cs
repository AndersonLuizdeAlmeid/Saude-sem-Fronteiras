using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Certificates.Commands;
public class ChangeCertificateCommand : IRequest<Result>
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public short Days { get; set; }
    public long Cid { get; set; }
    public long DocumentId { get; set; }

    public Result Validation()
    {
        if (Id.ToString().IsNullOrEmpty())
            return Result.Failure("Código do atestado não pode ser nulo.");
        if (Name.IsNullOrEmpty())
            return Result.Failure("Nome do paciente do atestado não pode ser nulo.");
        if (Cpf.IsNullOrEmpty())
            return Result.Failure("CPF do atestado não pode ser nulo.");
        if (Days.ToString().IsNullOrEmpty())
            return Result.Failure("Dias de atestado não pode ser nulo.");
        if (DocumentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do documento não pode ser nulo.");

        return Result.Success();
    }

}
