using Bz.F8t.Administration.Application.Common;
using MediatR;

namespace Bz.F8t.Administration.Application.Competitions.Commands;

public sealed record RemoveCheckpointCommand(
    Guid CompetitionId,
    Guid CheckpointId) : IRequest, ICommand { }
