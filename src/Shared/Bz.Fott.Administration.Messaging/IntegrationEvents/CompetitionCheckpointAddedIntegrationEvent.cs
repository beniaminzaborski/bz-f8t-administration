namespace Bz.Fott.Administration.Messaging.IntegrationEvents;

public sealed record CompetitionCheckpointAddedIntegrationEvent(
    Guid CompetitionId,
    Guid CheckpointId,
    decimal TrackPointDistance,
    string TrackPointUnit)
{ }
