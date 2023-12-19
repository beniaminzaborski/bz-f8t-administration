namespace Bz.F8t.Administration.Application.Competitions;

public sealed record DistanceDto
{
    public decimal Amount { get; init; }
    public string Unit { get; init; }
}
