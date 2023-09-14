namespace Bz.Fott.Administration.Application.Competitions.Dtos;

public record CheckpointDto
{
    public Guid Id { get; init; }
    public decimal TrackPointAmount { get; init; }
    public string TrackPointUnit { get; init; }
}
