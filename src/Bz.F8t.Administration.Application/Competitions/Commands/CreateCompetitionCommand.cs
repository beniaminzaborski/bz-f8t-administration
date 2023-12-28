using Bz.F8t.Administration.Application.Common;
using MediatR;

namespace Bz.F8t.Administration.Application.Competitions.Commands;

public sealed record CreateCompetitionCommand(
    DateTime StartAt,
    DistanceDto Distance,
    CompetitionPlaceDto Place,
    int MaxCompetitors) : IRequest<Guid>, ICommand { }
