namespace Bz.Fott.Administration.Messaging;

public sealed record CompetitionMaxCompetitorsIncreasedIntegrationEvent(
    Guid Id, 
    int MaxCompetitors) { }
