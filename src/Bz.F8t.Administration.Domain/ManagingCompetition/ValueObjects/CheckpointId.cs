using Bz.F8t.Administration.Domain.Common;

namespace Bz.F8t.Administration.Domain.ManagingCompetition;

public record CheckpointId : EntityId<Guid>
{
    public CheckpointId(Guid value) : base(value) { }

    public static CheckpointId From(Guid value)
    {
        return new CheckpointId(value);
    }
}
