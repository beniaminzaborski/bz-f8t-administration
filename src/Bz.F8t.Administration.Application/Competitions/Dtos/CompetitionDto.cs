using Bz.F8t.Administration.Domain.ManagingCompetition;

namespace Bz.F8t.Administration.Application.Competitions;

public sealed record CompetitionDto
{
    public Guid Id { get; init; }
    public DateTime StartAt { get; init; }
    public DistanceDto Distance { get; init; }
    public CompetitionPlaceDto Place { get; init; }
    public int MaxCompetitors { get; init; }
    public string Status { get; init; }
    public IEnumerable<CheckpointDto> Checkpoints { get; init; }

    public static CompetitionDto FromCompetition(Competition competition)
    {
        return new CompetitionDto
        {
            Id = competition.Id.Value,
            StartAt = competition.StartAt,
            Distance = DistanceDto.FromDistance(competition.Distance),
            Place = CompetitionPlaceDto.FromCompetitionPlace(competition.Place),
            MaxCompetitors = competition.MaxCompetitors,
            Status = competition.Status.ToString(),
            Checkpoints = competition.Checkpoints.Select(c => CheckpointDto.FromCheckpoint(c))
        };
    }
}
