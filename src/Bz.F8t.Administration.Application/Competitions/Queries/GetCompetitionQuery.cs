using MediatR;

namespace Bz.F8t.Administration.Application.Competitions.Queries;

public sealed record GetCompetitionQuery(
    Guid Id) : IRequest<CompetitionDto> { }
