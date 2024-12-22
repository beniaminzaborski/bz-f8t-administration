using Bz.F8t.Administration.Domain.ManagingCompetition;

namespace Bz.F8t.Administration.Application.Competitions;

public sealed record CompetitionPlaceDto
{
    public string City { get; init; }
    public decimal Latitude { get; init; }
    public decimal Longitute { get; init; }

    public static CompetitionPlaceDto FromCompetitionPlace(CompetitionPlace competitionPlace)
    {
        return new CompetitionPlaceDto()
        {
            City = competitionPlace.City,
            Latitude = competitionPlace.Localization.Latitude,
            Longitute = competitionPlace.Localization.Longitude
        };
    }
}
