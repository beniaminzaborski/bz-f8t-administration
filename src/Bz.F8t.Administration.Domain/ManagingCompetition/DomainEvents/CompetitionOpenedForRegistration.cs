using Bz.F8t.Administration.Domain.Common;

namespace Bz.F8t.Administration.Domain.ManagingCompetition;

public sealed record CompetitionOpenedForRegistration(
    CompetitionId Id,
    CompetitionPlace Place,
     Distance Distance,
     DateTime StartAt,
     int MaxCompetitors,
     IEnumerable<Checkpoint> Checkpoints)
    : IDomainEvent
{ }
