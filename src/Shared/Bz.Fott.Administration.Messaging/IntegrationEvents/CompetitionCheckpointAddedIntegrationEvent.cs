namespace Bz.Fott.Administration.Messaging;

public sealed record CompetitionCheckpointAddedIntegrationEvent(
    Guid CompetitionId,
    Guid CheckpointId,
    decimal TrackPointDistance,
    string TrackPointUnit) { }
