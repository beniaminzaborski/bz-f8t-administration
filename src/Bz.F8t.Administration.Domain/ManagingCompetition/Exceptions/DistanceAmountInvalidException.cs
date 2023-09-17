namespace Bz.F8t.Administration.Domain.ManagingCompetition;

public class DistanceAmountInvalidException : Exception
{
    public DistanceAmountInvalidException() { }

    public DistanceAmountInvalidException(string message) : base(message) { }

    public DistanceAmountInvalidException(string message, Exception inner) : base(message, inner) { }
}
