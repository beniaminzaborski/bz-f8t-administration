namespace Bz.F8t.Administration.Messaging;

public record CheckpointDto(
    Guid Id,
    decimal TrackPointAmount,
    string TrackPointUnit) { }
