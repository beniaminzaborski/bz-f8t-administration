namespace Bz.F8t.Administration.Messaging;

public sealed record CompetitionMaxCompetitorsIncreasedIntegrationEvent(
    Guid Id, 
    int MaxCompetitors) { }
