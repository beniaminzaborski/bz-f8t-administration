using Bz.F8t.Administration.Domain.ManagingCompetition;

namespace Bz.F8t.Administration.Application.Competitions;

public sealed record CheckpointDto
{
    public Guid Id { get; init; }
    public decimal TrackPointAmount { get; init; }
    public string TrackPointUnit { get; init; }

    public static CheckpointDto FromCheckpoint(Checkpoint checkpoint)
    {
        return new CheckpointDto()
        {
            Id = checkpoint.Id.Value,
            TrackPointAmount = checkpoint.TrackPoint.Amount,
            TrackPointUnit = checkpoint.TrackPoint.Unit.ToString()
        };
    }
}
