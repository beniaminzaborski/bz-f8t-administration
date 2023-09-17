namespace Bz.F8t.Administration.Messaging;

public sealed record CompetitionCheckpointAddedIntegrationEvent(
    Guid CompetitionId,
    Guid CheckpointId,
    decimal TrackPointDistance,
    string TrackPointUnit) { }
