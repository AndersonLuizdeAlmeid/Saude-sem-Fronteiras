using CSharpFunctionalExtensions;
using MediatR;
using SaudeSemFronteiras.Application.Screenings.Commands;
using SaudeSemFronteiras.Application.Screenings.Domain;
using SaudeSemFronteiras.Application.Screenings.Queries;
using SaudeSemFronteiras.Application.Screenings.Repository;

namespace SaudeSemFronteiras.Application.Screenings.Handlers;
public class ScreeningHandler : IRequestHandler<CreateScreeningCommand, Result>,
                                IRequestHandler<ChangeScreeningCommand, Result>
{
    private readonly IScreeningRepository _screeningRepository;
    private readonly IScreeningQueries _screeningQueries;

    public ScreeningHandler(IScreeningRepository screeningRepository, IScreeningQueries screeningQueries)
    {
        _screeningRepository = screeningRepository;
        _screeningQueries = screeningQueries;
    }

    public async Task<Result> Handle(CreateScreeningCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        var screening = Screening.Create(request.DegreeSeverity, request.Symptons, request.DateSymptons, request.ContinuosMedicine, request.Allergies, request.EmergencyId);

        await _screeningRepository.Insert(screening, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> Handle(ChangeScreeningCommand request, CancellationToken cancellationToken)
    {
        var screening = await _screeningQueries.GetById(request.Id, cancellationToken);
        if (screening == null)
            return Result.Failure("Triagem não encontrada");

        var validationResult = request.Validation();

        if (validationResult.IsFailure)
            return validationResult;

        screening.Update(request.DegreeSeverity, request.Symptons, request.DateSymptons, request.ContinuosMedicine, request.Allergies, request.EmergencyId);

        await _screeningRepository.Update(screening, cancellationToken);

        return Result.Success();
    }
}
