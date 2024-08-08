using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Specialities.Commands;
using SaudeSemFronteiras.Application.Specialities.Domain;
using SaudeSemFronteiras.Application.Specialities.Queries;
using SaudeSemFronteiras.Application.Specialities.Repository;

namespace SaudeSemFronteiras.Application.Specialities.Handlers;
public class SpecialityHandler : IRequestHandler<CreateSpecialityCommand, Result>,
                                 IRequestHandler<ChangeSpecialityCommand, Result>
{
    private readonly ISpecialityRepository _specialityRepository;
    private readonly ISpecialityQueries _specialityQueries;

    public SpecialityHandler(ISpecialityRepository specialityRepository, ISpecialityQueries specialityQueries)
    {
        _specialityRepository = specialityRepository;
        _specialityQueries = specialityQueries;
    }

    public async Task<Result> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var speciality = Speciality.Create(request.Description, true, request.IdDoctor);

        await _specialityRepository.Insert(speciality, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeSpecialityCommand request, CancellationToken cancellationToken)
    {
        var speciality = await _specialityQueries.GetById(request.Id, cancellationToken);
        if (speciality == null)
            return Result.Failure("Especialidade não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        speciality.Update(request.Description, request.IsActive, request.IdDoctor);
        
        await _specialityRepository.Update(speciality, cancellationToken);
        
        return Result.Success();
    }
}
