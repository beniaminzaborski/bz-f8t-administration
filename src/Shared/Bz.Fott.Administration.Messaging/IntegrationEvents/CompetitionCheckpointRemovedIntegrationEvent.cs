namespace Bz.Fott.Administration.Messaging.IntegrationEvents;

public sealed record CompetitionCheckpointRemovedIntegrationEvent(
    Guid CompetitionId,
    Guid CheckpointId,
    decimal TrackPointDistance,
    string TrackPointUnit) { }