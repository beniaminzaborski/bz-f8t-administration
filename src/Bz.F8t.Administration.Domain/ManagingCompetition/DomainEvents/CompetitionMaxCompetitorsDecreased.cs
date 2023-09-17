using Bz.F8t.Administration.Domain.Common;

namespace Bz.F8t.Administration.Domain.ManagingCompetition;

public sealed record CompetitionMaxCompetitorsDecreased(
    CompetitionId Id,
    int MaxCompetitors)
    : IDomainEvent
{ }
