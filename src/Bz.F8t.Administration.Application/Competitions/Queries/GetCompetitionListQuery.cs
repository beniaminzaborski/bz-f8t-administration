using MediatR;

namespace Bz.F8t.Administration.Application.Competitions.Queries;

public sealed record GetCompetitionListQuery(string? Search) 
    : IRequest<IEnumerable<CompetitionDto>>
{ }
