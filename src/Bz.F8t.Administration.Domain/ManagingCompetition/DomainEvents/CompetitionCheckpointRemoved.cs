using Bz.F8t.Administration.Domain.Common;

namespace Bz.F8t.Administration.Domain.ManagingCompetition;

public sealed record CompetitionCheckpointRemoved(
    CompetitionId CompetitionId,
    CheckpointId CheckpointId,
    Distance TrackPoint) : IDomainEvent
{ }
