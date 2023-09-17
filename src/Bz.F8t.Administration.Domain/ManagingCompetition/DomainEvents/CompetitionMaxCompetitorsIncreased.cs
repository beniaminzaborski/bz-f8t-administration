using Bz.F8t.Administration.Domain.Common;

namespace Bz.F8t.Administration.Domain.ManagingCompetition;

public sealed record CompetitionMaxCompetitorsIncreased(
    CompetitionId Id,
    int MaxCompetitors)
    : IDomainEvent
{ }
