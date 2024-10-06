using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace SaudeSemFronteiras.Application.Certificates.Commands;
public class CreateCertificateCommand : IRequest<Result>
{
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public short Days { get; set; }
    public long Cid { get; set; }
    public long DocumentId { get; set; }

    public Result Validation()
    {
        if (Name.IsNullOrEmpty())
            return Result.Failure("Nome do atestado não pode ser nulo.");
        if (Cpf.IsNullOrEmpty())
            return Result.Failure("CPF do atestado não pode ser nulo.");
        if (Days.ToString().IsNullOrEmpty())
            return Result.Failure("Data de início do atestado não pode ser nulo.");
        if (DocumentId.ToString().IsNullOrEmpty())
            return Result.Failure("Código do documento não pode ser nulo.");

        return Result.Success();
    }
}
