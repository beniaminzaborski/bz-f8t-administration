namespace Bz.F8t.Administration.Domain.ManagingCompetition;

public class CheckpointAlreadyExistsException : Exception
{
    public CheckpointAlreadyExistsException() { }

    public CheckpointAlreadyExistsException(string message) : base(message) { }

    public CheckpointAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
}
