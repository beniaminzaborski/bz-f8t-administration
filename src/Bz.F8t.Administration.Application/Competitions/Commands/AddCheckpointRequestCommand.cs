using Bz.F8t.Administration.Application.Common;
using MediatR;

namespace Bz.F8t.Administration.Application.Competitions.Commands;

public sealed record AddCheckpointRequestCommand(
    Guid CompetitionId,
    decimal TrackPointAmount,
    string TrackPointUnit) : IRequest, ICommand  { }
