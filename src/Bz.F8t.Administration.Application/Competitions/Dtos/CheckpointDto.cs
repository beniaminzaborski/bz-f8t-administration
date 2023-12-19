namespace Bz.F8t.Administration.Application.Competitions;

public sealed record CheckpointDto
{
    public Guid Id { get; init; }
    public decimal TrackPointAmount { get; init; }
    public string TrackPointUnit { get; init; }
}
