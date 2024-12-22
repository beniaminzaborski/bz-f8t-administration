using Bz.F8t.Administration.Domain.ManagingCompetition;

namespace Bz.F8t.Administration.Application.Competitions;

public sealed record DistanceDto
{
    public decimal Amount { get; init; }
    public string Unit { get; init; }

    public static DistanceDto FromDistance(Distance competitionDistance)
    {
        return new DistanceDto
        {
            Amount =  competitionDistance.Amount,
            Unit = competitionDistance.Unit.ToString()
        };
    }
}
