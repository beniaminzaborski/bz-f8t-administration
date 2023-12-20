using Bz.F8t.Administration.Application.Common.Exceptions;
using Bz.F8t.Administration.Application.Common;
using Bz.F8t.Administration.Domain.ManagingCompetition;
using MediatR;

namespace Bz.F8t.Administration.Application.Competitions.Commands;

internal class ChangeMaxCompetitorsCommandHandler(
    IUnitOfWork unitOfWork,
    ICompetitionRepository competitionRepository) : IRequestHandler<ChangeMaxCompetitorsCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICompetitionRepository _competitionRepository = competitionRepository;

    public async Task Handle(ChangeMaxCompetitorsCommand request, CancellationToken cancellationToken)
    {
        var competition = await _competitionRepository.GetAsync(CompetitionId.From(request.Id)) ?? throw new NotFoundException();
        
        try
        {
            competition.ChangeMaxCompetitors(request.MaxCompetitors);
        }
        catch (CompetitionMaxCompetitorsChangeNotAllowedException)
        {
            throw new Common.Exceptions.ValidationException("Changing maximum numbers of competitors is not allowed");
        }

        await _competitionRepository.UpdateAsync(competition);
        await _unitOfWork.CommitAsync();
    }
}