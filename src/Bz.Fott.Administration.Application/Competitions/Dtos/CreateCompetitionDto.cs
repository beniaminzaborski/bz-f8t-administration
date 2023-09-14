namespace Bz.Fott.Administration.Application.Competitions.Dtos;

public record CreateCompetitionDto(
    DateTime StartAt,
    DistanceDto Distance,
    CompetitionPlaceDto Place,
    int MaxCompetitors)
{
}
