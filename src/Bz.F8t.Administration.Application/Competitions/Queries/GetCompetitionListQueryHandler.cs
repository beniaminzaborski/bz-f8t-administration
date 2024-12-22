using Bz.F8t.Administration.Domain.ManagingCompetition;
using MediatR;

namespace Bz.F8t.Administration.Application.Competitions.Queries;

internal class GetCompetitionListQueryHandler(
    ICompetitionRepository competitionRepository) : IRequestHandler<GetCompetitionListQuery, IEnumerable<CompetitionDto>>
{
    private readonly ICompetitionRepository _competitionRepository = competitionRepository;

    public async Task<IEnumerable<CompetitionDto>> Handle(GetCompetitionListQuery request, CancellationToken cancellationToken)
    {
        var competitions = await _competitionRepository.GetAllAsync(i => i.Checkpoints);
        return competitions.Select(c => CompetitionDto.FromCompetition(c)).ToList();
    }
}