using MediatR;

namespace Bz.F8t.Administration.Application.Competitions.Queries;

public sealed record GetCompetitionListQuery() 
    : IRequest<IEnumerable<CompetitionDto>>
{ }
