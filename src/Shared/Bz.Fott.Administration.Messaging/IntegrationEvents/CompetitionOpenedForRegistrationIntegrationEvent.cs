using Bz.Fott.Administration.Messaging.Dtos;

namespace Bz.Fott.Administration.Messaging.IntegrationEvents;

public sealed record CompetitionOpenedForRegistrationIntegrationEvent(
    Guid Id,
    CompetitionPlaceDto Place,
    DistanceDto Distance,
    DateTime StartAt,
    int MaxCompetitors,
    IEnumerable<CheckpointDto> Checkpoints) 
{ }
