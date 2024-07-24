using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Specialities.Commands;
using SaudeSemFronteiras.Application.Specialities.Domain;
using SaudeSemFronteiras.Application.Specialities.Repository;

namespace SaudeSemFronteiras.Application.Specialities.Handlers;
public class SpecialityHandler : IRequestHandler<CreateSpecialityCommand, Result>,
                                 IRequestHandler<ChangeSpecialityCommand, Result>
{
    private readonly ISpecialityRepository _specialityRepository;

    public SpecialityHandler(ISpecialityRepository specialityRepository)
    {
        _specialityRepository = specialityRepository;
    }

    public async Task<Result> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var speciality = Speciality.Create(request.Description, true);

        await _specialityRepository.Insert(speciality, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeSpecialityCommand request, CancellationToken cancellationToken)
    {
        var speciality = await _specialityRepository.GetById(request.Id, cancellationToken);
        if (speciality == null)
            return Result.Failure("Especialidade não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        speciality.Update(request.Description, request.IsActive);
        
        await _specialityRepository.Update(speciality, cancellationToken);
        
        return Result.Success();
    }



}
