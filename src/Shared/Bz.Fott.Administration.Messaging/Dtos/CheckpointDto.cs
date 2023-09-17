namespace Bz.Fott.Administration.Messaging;

public record CheckpointDto(
    Guid Id,
    decimal TrackPointAmount,
    string TrackPointUnit) { }
