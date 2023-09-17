namespace Bz.F8t.Administration.Domain.ManagingCompetition;

public record Distance
{
    public Distance(decimal amount, DistanceUnit unit)
    {
        if (amount < 0) throw new DistanceAmountInvalidException();

        Amount = amount;
        Unit = unit;
    }

    public decimal Amount { get; init; }
    public DistanceUnit Unit { get; init; }
}
