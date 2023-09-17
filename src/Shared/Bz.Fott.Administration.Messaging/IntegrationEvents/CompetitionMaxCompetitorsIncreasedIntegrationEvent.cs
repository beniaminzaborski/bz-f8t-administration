namespace Bz.Fott.Administration.Messaging.IntegrationEvents;

public sealed record CompetitionMaxCompetitorsIncreasedIntegrationEvent(
    Guid Id, 
    int MaxCompetitors) 
{ }
