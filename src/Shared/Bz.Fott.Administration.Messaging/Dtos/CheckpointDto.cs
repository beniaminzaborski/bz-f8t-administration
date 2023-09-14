namespace Bz.Fott.Administration.Messaging.Dtos;

public record CheckpointDto(
    Guid Id,
    decimal TrackPointAmount,
    string TrackPointUnit) { }
