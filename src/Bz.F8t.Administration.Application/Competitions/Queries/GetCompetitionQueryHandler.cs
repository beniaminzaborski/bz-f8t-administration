using Bz.F8t.Administration.Application.Common.Exceptions;
using Bz.F8t.Administration.Domain.ManagingCompetition;
using MediatR;

namespace Bz.F8t.Administration.Application.Competitions.Queries;

internal class GetCompetitionQueryHandler(
    ICompetitionRepository competitionRepository) : IRequestHandler<GetCompetitionQuery, CompetitionDto>
{
    private readonly ICompetitionRepository _competitionRepository = competitionRepository;

    public async Task<CompetitionDto> Handle(GetCompetitionQuery request, CancellationToken cancellationToken)
    {
        var competition = await _competitionRepository.GetAsync(CompetitionId.From(request.Id), i => i.Checkpoints);
        return competition is null ? throw new NotFoundException() : CompetitionDto.FromCompetition(competition);
    }
}
