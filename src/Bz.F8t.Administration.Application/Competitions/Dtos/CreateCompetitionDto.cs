namespace Bz.F8t.Administration.Application.Competitions;

public record CreateCompetitionDto(
    DateTime StartAt,
    DistanceDto Distance,
    CompetitionPlaceDto Place,
    int MaxCompetitors)
{
}
