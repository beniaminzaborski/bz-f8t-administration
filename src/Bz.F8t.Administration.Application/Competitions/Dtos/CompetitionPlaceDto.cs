namespace Bz.F8t.Administration.Application.Competitions;

public sealed record CompetitionPlaceDto
{
    public string City { get; init; }
    public decimal Latitude { get; init; }
    public decimal Longitute { get; init; }
}
