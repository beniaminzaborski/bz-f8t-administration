namespace Bz.F8t.Administration.Messaging;

public sealed record CheckpointDto(
    Guid Id,
    decimal TrackPointAmount,
    string TrackPointUnit) { }
